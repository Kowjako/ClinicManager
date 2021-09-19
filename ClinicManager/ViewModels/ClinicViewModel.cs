using ClinicManager.DataAccessLayer;
using ClinicManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.ViewModels
{
    public class ClinicViewModel : IClinicDetailsViewModel
    {
        public event Action RefreshHandler;
        public void DeleteClinics(ClinicRow clinic)
        {
            using (var context = new ClinicDataEntities())
            {
                var deleteClinic = context.Clinics.Find(clinic.Id);
                context.Clinics.Remove(deleteClinic);
                context.SaveChanges();
            }
        }

        public void RefreshClinics()
        {
            if(RefreshHandler != null)
            {
                RefreshHandler.Invoke();
            }
        }
    }
}
