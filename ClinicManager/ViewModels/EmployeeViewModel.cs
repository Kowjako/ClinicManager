using ClinicManager.DataAccessLayer;
using ClinicManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test;

namespace ClinicManager.ViewModels
{
    public class EmployeeViewModel : IDoctorDetailsViewModel
    {
        public void AddEmployee()
        {
            var form = new DoctorDetails();
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

        public void SaveEmployee(Employees clinic, Form1.DetailsMode mode)
        {
            throw new NotImplementedException();
        }
    }
}
