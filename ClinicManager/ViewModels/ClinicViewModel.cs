using ClinicManager.Controls;
using ClinicManager.DataAccessLayer;
using ClinicManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test;
using static Test.Form1;

namespace ClinicManager.ViewModels
{
    public class ClinicViewModel : IClinicDetailsViewModel
    {
        public void AddClinic()
        {
            var form = new ClinicDetails(DetailsMode.Add);
            form.ShowDialog();
        }

        public void AddOpinion()
        {
            var form = new OpinionDetails();
            form.ShowDialog();
        }

        public void DeleteClinics(ClinicRow clinic)
        {
            using (var context = new ClinicDataEntities())
            {
                var deleteClinic = context.Clinics.Find(clinic.Id);
                context.Clinics.Remove(deleteClinic);
                context.SaveChanges();
            }
        }

        public void EditClinic(ClinicRow row)
        {
            var form = new ClinicDetails(DetailsMode.Edit);
            using (var context = new ClinicDataEntities())
            {
                var clinic = context.Clinics.Find(row.Id);
                form.BindingSource = new List<Clinics> { clinic };
            }
            form.SetSpecificProperties();
            form.ShowDialog();
        }

        public List<ClinicRow> Filter()
        {
            var parameters = new string[] { "[Nazwa]", "[Data otwarcia]", "[Prywatna]", "[Ocena]", "[Lokalizacja]", "[Kierownik]" };
            var form = new FilterForm(parameters);
            if(form.ShowDialog() == DialogResult.OK)
            {
                var sqlFilter = form.ReturnFilterString();
                var sqlQuery = $"SELECT Id, Nazwa, [Data otwarcia] AS Data_otwarcia, Prywatna, Ocena, Lokalizacja, Kierownik FROM ClinicRow {sqlFilter}";
                using(var context = new ClinicDataEntities())
                {
                    try
                    {
                        var entites = context.Database.SqlQuery<ClinicRow>(sqlQuery).ToList();
                        return entites;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(null, "Niepoprawne zapytanie filtrowania", "Błąd");
                    }
                }
            }
            return null;
        }

        public BindingSource GetOpinions(ClinicRow row)
        {
            var bsMain = new BindingSource();
            using (var context = new ClinicDataEntities())
            {
                var clinic = context.Clinics.Find(row.Id);
                var opinions = context.Opinions.Where(p => p.ClinicId == clinic.Id).ToList();
                var opinionList = new List<OpinionRow>();
                foreach (var opinion in opinions)
                {
                    opinionList.Add(context.OpinionRow.First(p => p.Id == opinion.Id));
                }
                bsMain.DataSource = typeof(OpinionRow);
                bsMain.DataSource = opinionList;
                return bsMain;
            }
        }

        public void MakeOrder()
        {
            var form = new OrderDetails(DetailsMode.Add);
            form.ShowDialog();
        }

        public void MakeOrderTool()
        {
            var form = new OrderToolDetails(DetailsMode.Add);
            form.ShowDialog();
        }

        public BindingSource RefreshClinics()
        {
            var bsMain = new BindingSource();
            using (var context = new ClinicDataEntities())
            {
                var clinicList = context.ClinicRow.ToList();
                bsMain.DataSource = typeof(ClinicRow);
                bsMain.DataSource = clinicList;
                return bsMain;
            }
        }

        public void SaveClinics(Clinics newClinicData, Form1.DetailsMode Mode)
        {
            using (var context = new ClinicDataEntities())
            {
                if (Mode == DetailsMode.Add)
                {
                    newClinicData.OpenDate = DateTime.Parse(newClinicData.OpenDate.ToShortDateString());
                    context.Clinics.Add(newClinicData);
                }
                else
                {
                    context.Entry(newClinicData).State = System.Data.Entity.EntityState.Modified;
                }
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException.InnerException.Message.Contains("UQ__Clinics_LocalizationId"))
                    {
                        MessageBox.Show(null, "Wybrana lokalizacja jest już zajęta. Prosze stworzyc nowa", "Błąd!");
                    }
                }
            }
        }

        public void SaveOrder(Orders order)
        {
            using(var context = new ClinicDataEntities())
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }

        public void SaveOrderTools(OrdersTools order)
        {
            using(var context = new ClinicDataEntities())
            {
                context.OrdersTools.Add(order);
                context.SaveChanges();
            }
        }

        public void ShowHierarchy(ClinicRow row)
        {
            var form = new HierarchyControl();
            form.SetHierarchy(row);
            form.ShowDialog();
        }

        public void Sort(DataGridView grid, BindingSource list)
        {
            var form = new SortDetails();
            form.SetParameters(grid, list);
            form.ShowDialog();

            var newBs = new BindingSource();
            
            using (var context = new ClinicDataEntities())
            {
                var clinicList = context.ClinicRow.SqlQuery($"SELECT Id, Nazwa, [Data otwarcia] AS Data_otwarcia, Prywatna, Ocena, Lokalizacja, Kierownik FROM ClinicRow ORDER BY {list.Sort}").ToList();
                newBs.DataSource = typeof(ClinicRow);
                newBs.DataSource = clinicList;
                grid.DataSource = newBs;
            }
        }

    }
}
