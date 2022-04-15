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
        public void AddRegistration()
        {
            var form = new VisitDetails(DetailsMode.Add);
            form.ShowDialog();
        }

        public void AddRegistrationForClient(PatientRow client)
        {
            var form = new VisitDetails(DetailsMode.Add);
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

        public void EditRegistration(RegistrationRow row)
        {
            var form = new VisitDetails(DetailsMode.Edit);
            form.ShowDialog();
        }

        public List<RegistrationRow> Filter()
        {
            var parameters = new string[] { "[Pacjent]", "[Lekarz]", "[Data operacji]", "[Czas rozpoczecia]", "[Status]" };
            var form = new FilterForm(parameters);
            if (form.ShowDialog() == DialogResult.OK)
            {

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

        public void Sort(DataGridView grid, BindingSource list)
        {
            var form = new SortDetails();
            form.ShowDialog();
        }
    }
}
