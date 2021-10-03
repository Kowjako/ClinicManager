using ClinicManager.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManager.Controls
{
    public partial class EnrollDetails : Form
    {
        private StaticDictionaries Dictionaries;
        public EnrollDetails()
        {
            InitializeComponent();

            Dictionaries = new StaticDictionaries();

            var empList = new List<EmployeeRow>();
            foreach (var obj in Dictionaries.EmployeeList.Value)
            {
                empList.Add(obj.Value);
            }
            bsEmployees.DataSource = empList;

            var clinicList = new List<ClinicRow>();
            foreach (var obj in Dictionaries.ClinicList.Value)
            {
                clinicList.Add(obj.Value);
            }
            bsClinics.DataSource = clinicList;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var changedEmployee = empBox.SelectedItem as EmployeeRow;
            try
            {
                using (var context = new ClinicDataEntities())
                {
                    var changedEmp = context.Employees.Find(changedEmployee.Id);
                    changedEmp.ClinicId = (clinicBox.SelectedItem as ClinicRow).Id;
                    if (_isManager.Checked)
                    {
                        var clinic = context.Clinics.Find((clinicBox.SelectedItem as ClinicRow).Id);
                        clinic.EmployeeId = changedEmp.Id;
                        context.Entry(clinic).State = System.Data.Entity.EntityState.Modified;
                    }
                    context.Entry(changedEmp).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(null, "Nie udalo sie zatrudnic pracownika", "Blad");
            }
            this.Close();
        }
    }
}
