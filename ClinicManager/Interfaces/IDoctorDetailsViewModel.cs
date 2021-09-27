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
    interface IDoctorDetailsViewModel
    {
        void SaveEmployee(Employees employee, Data employeeData, DetailsMode mode);
        void DeleteEmployee(EmployeeRow employee);
        BindingSource RefreshEmployees();
        List<EmployeeRow> Filter();
        void EditEmployee(EmployeeRow row);
        void AddEmployee();
        void Enroll();
        void ShowContact(EmployeeRow row);
        void Sort(DataGridView grid, BindingSource list);
        BindingSource ShowHistory(EmployeeRow row);
    }
}
