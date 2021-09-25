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
    public class VisitViewModel : IVisitDetailsViewModel
    {
        public void AddRegistration()
        {
            var form = new VisitDetails(DetailsMode.Add);
            form.ShowDialog();
        }

        public void DeleteVisit(RegistrationRow visit)
        {
            using (var context = new ClinicDataEntities())
            {
                var deleteVisit = context.Registrations.Find(visit.Id);
                context.Registrations.Remove(deleteVisit);
                context.SaveChanges();
            }
        }

        public void EditRegistration(RegistrationRow row)
        {
            var form = new VisitDetails(DetailsMode.Edit);
            using (var context = new ClinicDataEntities())
            {
                var visit = context.Registrations.Find(row.Id);
                form.BindingSource = new List<Registrations> { visit };
            }
            form.SetSpecificProperties();
            form.ShowDialog();
        }

        public List<RegistrationRow> Filter()
        {
            var parameters = new string[] { "Date", "Time", "EmployeeId", "PatientId" };
            var form = new FilterForm(parameters);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var sqlFilter = form.ReturnFilterString();
                var sqlQuery = $"SELECT * FROM Registrations {sqlFilter}";
                using (var context = new ClinicDataEntities())
                {
                    try
                    {
                        var entites = context.Database.SqlQuery<Registrations>(sqlQuery).ToList();
                        var entityRows = new List<RegistrationRow>();
                        foreach (var obj in entites)
                        {
                            entityRows.Add(context.RegistrationRow.First(p => p.Id == obj.Id));
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

        public void GetSchedule()
        {
            var form = new Schedule();
            form.ShowDialog();
        }

        public BindingSource RefreshVisits()
        {
            var bsMain = new BindingSource();
            using (var context = new ClinicDataEntities())
            {
                var visitList = context.RegistrationRow.ToList();
                bsMain.DataSource = typeof(RegistrationRow);
                bsMain.DataSource = visitList;
                return bsMain;
            }
        }

        public void SaveVisit(Registrations visit, Form1.DetailsMode Mode)
        {
            using (var context = new ClinicDataEntities())
            {
                if (Mode == DetailsMode.Add)
                {
                    visit.Date = DateTime.Parse(visit.Date.ToShortDateString());
                    context.Registrations.Add(visit);
                }
                else
                {
                    context.Entry(visit).State = System.Data.Entity.EntityState.Modified;
                }
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show(null, "Nie udalo sie zapisac wizyty", "Błąd!");
                }
            }
        }
    }
}
