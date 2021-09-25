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
    public class ProducentViewModel : IProducentDetailsViewModel
    {
        public void AddProducent()
        {
            var form = new ProducentDetails(DetailsMode.Add);
            form.ShowDialog();
        }

        public void DeleteProducent(ProducentRow prod)
        {
            using (var context = new ClinicDataEntities())
            {
                var deleteProd = context.Producents.Find(prod.Id);
                var deleteData = context.Data.Find(deleteProd.DataId); /* Usuwanie kaskadowe - usuniecie danych osobowych => usuniecie producenta */
                context.Data.Remove(deleteData);
                context.SaveChanges();
            }
        }

        public void EditProducent(ProducentRow row)
        {
            var form = new ProducentDetails(DetailsMode.Edit);
            using (var context = new ClinicDataEntities())
            {
                var prod = context.Producents.Find(row.Id);
                form.BindingSource = new List<Producents> { prod };
            }
            form.SetSpecificProperties();
            form.ShowDialog();
        }

        public List<ProducentRow> Filter()
        {
            var parameters = new string[] { "OpenDate", "Name", "Email", "LocalizationId" };
            var form = new FilterForm(parameters);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var sqlFilter = form.ReturnFilterString();
                var sqlQuery = $"SELECT * FROM Producents {sqlFilter}";
                using (var context = new ClinicDataEntities())
                {
                    try
                    {
                        var entites = context.Database.SqlQuery<Producents>(sqlQuery).ToList();
                        var entityRows = new List<ProducentRow>();
                        foreach (var obj in entites)
                        {
                            entityRows.Add(context.ProducentRow.First(p => p.Id == obj.Id));
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

        public BindingSource RefreshProducents()
        {
            var bsMain = new BindingSource();
            using (var context = new ClinicDataEntities())
            {
                var prodList = context.ProducentRow.ToList();
                bsMain.DataSource = typeof(ProducentRow);
                bsMain.DataSource = prodList;
                return bsMain;
            }
        }

        public void SaveProducent(Producents prod, Data producentData, Form1.DetailsMode Mode)
        {
            using (var context = new ClinicDataEntities())
            {
                if (Mode == DetailsMode.Add)
                {
                    producentData.BirthDate = DateTime.Parse(producentData.BirthDate.ToShortDateString());
                    prod.OpenDate = DateTime.Parse(prod.OpenDate.ToShortDateString());
                    context.Data.Add(producentData);
                    context.SaveChanges();  /* zapisywanie danych osobowych */

                    prod.DataId = producentData.Id;  /* przypisanie danych osobowych do pracownika - ustawianie klucza obcego */
                    context.Producents.Add(prod);
                }
                else
                {
                    context.Entry(producentData).State = System.Data.Entity.EntityState.Modified;
                    context.Entry(prod).State = System.Data.Entity.EntityState.Modified;
                }
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show(null, "Błąd podczas zapisywania producenta", "Blad");
                }
            }
        }

        public void ShowContact(ProducentRow row)
        {
            Producents producent = null;
            using (var context = new ClinicDataEntities())
            {
                producent = context.Producents.Find(row.Id);
            }
            var form = new ContactDetails();
            form.InitializeData<Producents>(producent);
            form.ShowDialog();
        }
    }
}
