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
    interface IClinicDetailsViewModel
    {
        event Action RefreshHandler;
        void SaveClinics(Clinics clinic, DetailsMode mode);
        void DeleteClinics(ClinicRow clinic);
        void RefreshClinics();
        List<ClinicRow> Filter();
        void EditClinic(ClinicRow row);
        void AddClinic();
        BindingSource GetOpinions(ClinicRow row);
    }
}
