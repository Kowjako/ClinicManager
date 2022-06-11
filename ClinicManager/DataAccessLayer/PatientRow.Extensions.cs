using ClinicManager.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace ClinicManager.DataAccessLayer
{
    public partial class PatientRow
    {
        /// <summary>
        /// Zwraca przychodnie w jakim byl dany pacjent
        /// </summary>
        /// <returns></returns>
        public List<ClinicRow> GetVisitedClinics()
        {
            using(var dbContext = new ClinicDataEntities())
            {
                var clinics = from registration in dbContext.Registrations
                              join employee in dbContext.Employees
                              on registration.EmployeeId equals employee.Id
                              join clinic in dbContext.ClinicRow
                              on employee.ClinicId equals clinic.Id
                              where registration.PatientId == Id
                              select clinic;
                return clinics.ToList();
            }
        }

        public bool ExistsOpinionForClinic(int clinicId)
        {
            using(var dbContext = new ClinicDataEntities())
            {
                if ((Form1.Rights.dataId as int?).HasValue)
                {
                    var dataId = (Form1.Rights.dataId as int?).Value;
                    return dbContext.Opinions.Any(p => p.ClinicId == clinicId && p.DataId == dataId);
                }
                else return false;
            }
        }

        public int GetIdByDataId(int dataId)
        {
            using (var dbContext = new ClinicDataEntities())
            {
                return dbContext.Patients.First(p => p.DataId == dataId).Id;
            }
        }
    }
}
