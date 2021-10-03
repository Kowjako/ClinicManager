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

        public void CheckCurrencyFormat(DataGridView grid)
        {
            grid.Columns[4].DefaultCellStyle.Format = "c";
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
            var parameters = new string[] { "[Lekarz]", "[Miejsce pracy]", "[Specjalizacja]", "[Koszt operacji]", "[Stanowisko]" };
            var form = new FilterForm(parameters);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var sqlFilter = form.ReturnFilterString();
                var sqlQuery = $"SELECT Id, Lekarz, [Miejsce pracy] AS Miejsce_pracy, Specjalizacja, [Koszt operacji] AS Koszt_operacji, Stanowisko FROM EmployeeRow {sqlFilter}";
                using (var context = new ClinicDataEntities())
                {
                    try
                    {
                        var entites = context.Database.SqlQuery<EmployeeRow>(sqlQuery).ToList();
                        return entites;
                    }
                    catch (Exception)
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

        public void ShowContact(EmployeeRow row)
        {
            Employees employee = null;
            using(var context = new ClinicDataEntities())
            {
                employee = context.Employees.Find(row.Id);
            }
            var form = new ContactDetails();
            form.InitializeData<Employees>(employee);
            form.ShowDialog();
        }

        public BindingSource ShowHistory(EmployeeRow row)
        {
            var bs = new BindingSource();
            using (var context = new ClinicDataEntities())
            {
                bs.DataSource = typeof(RegistrationRow);
                var registrationList = context.Registrations.Where(p => p.EmployeeId == row.Id).ToList();

                var regRows = context.RegistrationRow.AsEnumerable()
                                                     .Where(p => registrationList.Any(x => x.Id == p.Id))
                                                     .OrderBy(x => x.Data_operacji).ToList();
                bs.DataSource = regRows;
            }
            return bs;
        }

        public void Sort(DataGridView grid, BindingSource list)
        {
            var form = new SortDetails();
            form.SetParameters(grid, list);
            form.ShowDialog();

            var newBs = new BindingSource();

            using (var context = new ClinicDataEntities())
            {
                var clinicList = context.EmployeeRow.SqlQuery($"SELECT Id, Lekarz, [Miejsce pracy] AS Miejsce_pracy, Specjalizacja, [Koszt operacji] AS Koszt_operacji, Stanowisko FROM EmployeeRow ORDER BY {list.Sort}").ToList();
                newBs.DataSource = typeof(ClinicRow);
                newBs.DataSource = clinicList;
                grid.DataSource = newBs;
            }
        }
    }
}
