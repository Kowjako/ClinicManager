using ClinicManager.DataAccessLayer;
using ClinicManager.Interfaces;
using ClinicManager.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Test.Form1;

namespace ClinicManager
{
    public partial class VisitDetails : Form
    {
        private StaticDictionaries Dictionaries;
        private DetailsMode Mode;
        private IVisitDetailsViewModel VisitViewModel;
        public PatientRow Patient;

        public VisitDetails(DetailsMode mode)
        {
            InitializeComponent();

            Mode = mode;   /* 1 - Add, 2 - Edit */
            Dictionaries = new StaticDictionaries();

            if (mode == DetailsMode.Add)
            {
                _bsRegistration.DataSource = new List<Registrations> { new Registrations() };
            }

            VisitViewModel = new VisitViewModel();

            var empList = new List<EmployeeRow>();
            foreach (var employee in Dictionaries.EmployeeList.Value)
            {
                empList.Add(employee.Value);
            }
            _bsEmployees.DataSource = empList;

            var patientList = new List<PatientRow>();
            foreach (var patient in Dictionaries.PatientList.Value)
            {
                patientList.Add(patient.Value);
            }
            _bsPatients.DataSource = patientList;
        }

        public List<Registrations> BindingSource
        {
            set
            {
                _bsRegistration.DataSource = value;
            }
        }

        public void SetSpecificProperties()
        {
            employeeBox.SelectedItem = Dictionaries.EmployeeList.Value
                                                   .Where(p => p.Value.Id == (_bsRegistration.DataSource as List<Registrations>)
                                                   .First().EmployeeId).First().Value;
            patientBox.SelectedItem = Dictionaries.PatientList.Value
                                                  .Where(p => p.Value.Id == (_bsRegistration.DataSource as List<Registrations>)
                                                  .First().PatientId).First().Value;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if(ValidateChildren(ValidationConstraints.Enabled))
            {
                var newRegistrationData = (_bsRegistration.DataSource as List<Registrations>).First();
                newRegistrationData.PatientId = (patientBox.SelectedItem as PatientRow).Id;
                newRegistrationData.EmployeeId = (employeeBox.SelectedItem as EmployeeRow).Id;
                if (newRegistrationData.Date != dateTimePicker1.Value)
                {
                    newRegistrationData.Date = dateTimePicker1.Value;
                }
                VisitViewModel.SaveVisit(newRegistrationData, Mode, Patient);
                this.Close();
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                erp.SetError(textBox1, "Podaj godzine");
            }
            else
            {
                e.Cancel = false;
                erp.SetError(textBox1, null);
            }
        }
    }
}
