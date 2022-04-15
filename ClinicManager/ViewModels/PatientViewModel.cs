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
    public class PatientViewModel : IPatientDetailsViewModel
    {
        public void AddPatient()
        {
            var form = new PatientDetails(DetailsMode.Add);
            form.ShowDialog();
        }

        public void EditPatient(PatientRow row)
        {
            var form = new PatientDetails(DetailsMode.Edit);
            form.ShowDialog();
        }

        public List<PatientRow> Filter()
        {
            var parameters = new string[] { "[Pacjent]", "[Operacja]", "[Planowana data]", "[Priorytet]" };
            var form = new FilterForm(parameters);
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
            return null;
        }

        public BindingSource RefreshPatients()
        {
            var bsMain = new BindingSource();
            using (var context = new ClinicDataEntities())
            {
                var patientList = context.PatientRow.ToList();
                bsMain.DataSource = typeof(PatientRow);
                bsMain.DataSource = patientList;
                return bsMain;
            }
        }

        public void ShowContact(PatientRow row)
        {
            var form = new ContactDetails();
            form.ShowDialog();
        }

        public void Sort(DataGridView grid, BindingSource list)
        {
            var form = new SortDetails();
            form.ShowDialog();
        }
    }
}
