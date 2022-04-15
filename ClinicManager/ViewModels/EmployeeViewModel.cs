using ClinicManager.Controls;
using ClinicManager.DataAccessLayer;
using ClinicManager.Interfaces;
using ClinicManager.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
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

        public void CheckCurrencyFormat(DataGridView grid)
        {
            grid.Columns[4].DefaultCellStyle.Format = "c";
        }

        public void EditEmployee(EmployeeRow row)
        {
            var form = new DoctorDetails(DetailsMode.Edit);
            form.ShowDialog();
        }

        public void Enroll()
        {
            var form = new EnrollDetails();
            form.ShowDialog();
        }

        public List<EmployeeRow> Filter()
        {
            var parameters = new string[] { "[Lekarz]", "[Miejsce pracy]", "[Specjalizacja]", "[Koszt operacji]", "[Stanowisko]" };
            var form = new FilterForm(parameters);
            if (form.ShowDialog() == DialogResult.OK)
            {
               
            }
            return null;
        }

        public BindingSource RefreshEmployees()
        {
            var bsMain = new BindingSource();
            using (var context = new ClinicDataEntities())
            {
                var employeeList = context.EmployeeRow.ToList();
                bsMain.DataSource = typeof(EmployeeRow);
                bsMain.DataSource = employeeList;
                return bsMain;
            }
        }

        public void ShowContact(EmployeeRow row)
        {
            var form = new ContactDetails();
            form.ShowDialog();
        }


        public void Sort(DataGridView grid, BindingSource list)
        {
            var form = new SortDetails();
            form.ShowDialog();    
        }
    }
}
