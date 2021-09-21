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
    public class EmployeeViewModel : IDoctorDetailsViewModel
    {
        public void AddEmployee()
        {
            var form = new DoctorDetails(DetailsMode.Add);
            form.ShowDialog();
        }

        public void DeleteEmployee(EmployeeRow clinic)
        {
            throw new NotImplementedException();
        }

        public void EditEmployee(EmployeeRow row)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeRow> Filter()
        {
            throw new NotImplementedException();
        }

        public BindingSource RefreshEmployees()
        {
            throw new NotImplementedException();
        }

        public void SaveEmployee(Employees employee, Data employeeData, DetailsMode Mode)
        {
            using (var context = new ClinicDataEntities())
            {
                if (Mode == DetailsMode.Add)
                {
                    context.Data.Add(employeeData);
                    context.SaveChanges();  /* zapisywanie danych osobowych */

                    employee.DataId = employeeData.Id;  /* przypisanie danych osobowych do pracownika */
                    context.Employees.Add(employee);
                }
                else
                {
                    context.Entry(employeeData).State = System.Data.Entity.EntityState.Modified;
                    context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                }
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show(null, ex.Message, "Blad");
                }
            }
        }
    }
}
