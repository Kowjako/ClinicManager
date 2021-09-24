using ClinicManager.Controls;
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

        public void DeleteEmployee(EmployeeRow employee)
        {
            using (var context = new ClinicDataEntities())
            {
                var deleteEmployee = context.Employees.Find(employee.Id);
                var deleteData = context.Data.Find(deleteEmployee.DataId); /* Usuwanie kaskadowe - usuniecie danych osobowych => usuniecie pracownika */
                context.Data.Remove(deleteData);
                context.SaveChanges();
            }
        }

        public void EditEmployee(EmployeeRow row)
        {
            var form = new DoctorDetails(DetailsMode.Edit);
            using (var context = new ClinicDataEntities())
            {
                var employee = context.Employees.Find(row.Id);
                form.BindingSource = new List<Employees> { employee };
            }
            form.SetSpecificProperties();
            form.ShowDialog();
        }

        public void Enroll()
        {
            var form = new EnrollDetails();
            form.ShowDialog();
        }

        public List<EmployeeRow> Filter()
        {
            var parameters = new string[] { "OperationCount", "OperationId", "ClinicId", "Rank", "Cost" };
            var form = new FilterForm(parameters);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var sqlFilter = form.ReturnFilterString();
                var sqlQuery = $"SELECT * FROM Employees {sqlFilter}";
                using (var context = new ClinicDataEntities())
                {
                    try
                    {
                        var entites = context.Database.SqlQuery<Employees>(sqlQuery).ToList();
                        var entityRows = new List<EmployeeRow>();
                        foreach (var obj in entites)
                        {
                            entityRows.Add(context.EmployeeRow.First(p => p.Id == obj.Id));
                        }
                        return entityRows;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(null, "Niepoprawne zapytanie filtrowania", "Błąd");
                    }
                }
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

        public void SaveEmployee(Employees employee, Data employeeData, DetailsMode Mode)
        {
            using (var context = new ClinicDataEntities())
            {
                if (Mode == DetailsMode.Add)
                {
                    employeeData.BirthDate = DateTime.Parse(employeeData.BirthDate.ToShortDateString());
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
