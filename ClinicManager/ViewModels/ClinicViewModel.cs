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
        public event Action RefreshHandler;

        public void AddClinic()
        {
            var form = new ClinicDetails(DetailsMode.Add);
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
            var parameters = new string[] { "Name", "OpenDate", "IsPrivate", "UserMark", "EmployeeId", "LocalizationId" };
            var form = new FilterForm(parameters);
            if(form.ShowDialog() == DialogResult.OK)
            {
                var sqlFilter = form.ReturnFilterString();
                var sqlQuery = $"SELECT * FROM Clinics {sqlFilter}";
                using(var context = new ClinicDataEntities())
                {
                    try
                    {
                        var entites = context.Database.SqlQuery<Clinics>(sqlQuery).ToList();
                        var entityRows = new List<ClinicRow>();
                        foreach (var obj in entites)
                        {
                            entityRows.Add(context.ClinicRow.First(p => p.Id == obj.Id));
                        }
                        return entityRows;
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

        public void RefreshClinics()
        {
            if(RefreshHandler != null)
            {
                RefreshHandler.Invoke();
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
                        MessageBox.Show(null, "Wybrana lokalizacja jest już zajęta", "Błąd!");
                    }
                }
            }
        }
    }
}
