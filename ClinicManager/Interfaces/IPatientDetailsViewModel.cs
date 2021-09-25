using ClinicManager.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Test.Form1;

namespace ClinicManager.Interfaces
{
    interface IPatientDetailsViewModel
    {
        void SavePatient(Patients patient, Data patientData, DetailsMode mode);
        void DeletePatient(PatientRow patient);
        BindingSource RefreshPatients();
        List<PatientRow> Filter();
        void EditPatient(PatientRow row);
        void AddPatient();
        void ShowContact(PatientRow row);
    }
}
