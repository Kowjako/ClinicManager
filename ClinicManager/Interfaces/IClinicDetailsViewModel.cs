using ClinicManager.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Interfaces
{
    interface IClinicDetailsViewModel
    {
        event Action RefreshHandler;
        void SaveClinics(Clinics clinic, int empId, int locId);
        void DeleteClinics(ClinicRow clinic);
        void RefreshClinics();
    }
}
