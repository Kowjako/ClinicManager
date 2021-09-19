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

        public void SaveClinics(Clinics newClinicData, Form1.DetailsMode Mode)
        {
            using (var context = new ClinicDataEntities())
            {
                if (Mode == DetailsMode.Add)
                {
                    newClinicData.OpenDate = DateTime.Parse(newClinicData.OpenDate.ToShortDateString());
                    context.Clinics.Add(newClinicData);
                }
                else
                {
                    context.Entry(newClinicData).State = System.Data.Entity.EntityState.Modified;
                }
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException.InnerException.Message.Contains("UQ__Clinics_LocalizationId"))
                    {
                        MessageBox.Show(null, "Wybrana lokalizacja jest już zajęta", "Błąd!");
                    }
                }
            }
        }
    }
}
