using ClinicManager.Controls;
using ClinicManager.DataAccessLayer;
using ClinicManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Drawing;
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
        public void AcceptVisit(RegistrationRow row)
        {
            using (var context = new ClinicDataEntities())
            {
                var editedVisit = context.Registrations.Find(row.Id);
                editedVisit.Status = "Zaakceptowana";
                context.Entry(editedVisit).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void AddRegistration()
        {
            var form = new VisitDetails(DetailsMode.Add);
            form.ShowDialog();
        }

        public void AddRegistrationForClient(PatientRow client)
        {
            var form = new VisitDetails(DetailsMode.Add);
            form.Patient = client;
            form.dateTimePicker1.Value = client.Planowana_data;
            form.patientBox.SelectedItem = form.patientBox.Items.OfType<PatientRow>().First(p => p.Id == client.Id);
            form.ShowDialog();
        }

        public void CheckRegistrationStatus(DataGridView gridView)
        {
            foreach (DataGridViewRow row in gridView.Rows)
            {
                if (row.Cells[6].Value != null)
                {
                    if (row.Cells[5].Value.ToString() == "Zaakceptowana")
                    {
                        row.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else if (row.Cells[5].Value.ToString() == "Zrealizowana")
                    {
                        row.DefaultCellStyle.ForeColor = Color.Green;
                    }
                    else
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }
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
            var parameters = new string[] { "[Pacjent]", "[Lekarz]", "[Data operacji]", "[Czas rozpoczecia]", "[Status]" };
            var form = new FilterForm(parameters);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var sqlFilter = form.ReturnFilterString();
                var sqlQuery = $"SELECT Id, Pacjent, Lekarz, [Data operacji] AS Data_operacji, [Czas rozpoczecia] AS Czas_rozpoczecia, Status FROM RegistrationRow {sqlFilter}";
                using (var context = new ClinicDataEntities())
                {
                    try
                    {
                        var entites = context.Database.SqlQuery<RegistrationRow>(sqlQuery).ToList();
                        return entites;
                    }
                    catch (Exception)
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

        public void RealizeVisit(RegistrationRow row)
        {
            using (var context = new ClinicDataEntities())
            {
                var editedVisit = context.Registrations.Find(row.Id);
                if(editedVisit.Status != "Zaakceptowana")
                {
                    MessageBox.Show(null, "Nie mozna zrealizowac niezaakceptowanej wizyty", "Blad");
                    return;
                }
                editedVisit.Status = "Zrealizowana";
                context.Entry(editedVisit).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
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

        public void SaveVisit(Registrations visit, Form1.DetailsMode Mode, PatientRow patientRow)
        {
            using (var context = new ClinicDataEntities())
            {
                if (Mode == DetailsMode.Add)
                {
                    visit.Date = DateTime.Parse(visit.Date.Value.ToShortDateString());
                    visit.Status = "Zaakceptowana"; 
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

        public void Sort(DataGridView grid, BindingSource list)
        {
            var form = new SortDetails();
            form.SetParameters(grid, list);
            form.ShowDialog();

            var newBs = new BindingSource();

            if (!string.IsNullOrEmpty(list.Sort))
            {
                using (var context = new ClinicDataEntities())
                {
                    var clinicList = context.RegistrationRow.SqlQuery($"SELECT Id, Pacjent, Lekarz, [Data operacji] AS Data_operacji, [Czas rozpoczecia] AS Czas_rozpoczecia, Status FROM registrationRow ORDER BY {list.Sort}").ToList();
                    newBs.DataSource = typeof(ClinicRow);
                    newBs.DataSource = clinicList;
                    grid.DataSource = newBs;
                }
            }
            else
            {
                MessageBox.Show(null, "Nalezy zaznaczyc po czym filtrowac", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UndoVisit(RegistrationRow row)
        {
            using (var context = new ClinicDataEntities())
            {
                var editedVisit = context.Registrations.Find(row.Id);
                editedVisit.Status = "Anulowana";
                context.Entry(editedVisit).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
