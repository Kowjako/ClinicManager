using ClinicManager.DataAccessLayer;
using ClinicManager.Interfaces;
using ClinicManager.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Test.Form1;

namespace ClinicManager
{
    public partial class DoctorDetails : Form
    {
        private StaticDictionaries Dictionaries;
        private DetailsMode Mode;
        private IDoctorDetailsViewModel EmployeeViewModel;
        public DoctorDetails(DetailsMode mode)
        {
            InitializeComponent();
            Mode = mode;   /* 1 - Add, 2 - Edit */
            Dictionaries = new StaticDictionaries();

            if (mode == DetailsMode.Add)
            {
                _bsEmployees.DataSource = new List<Employees> { new Employees() };
                _bsEmployeeData.DataSource = new List<Data> { new Data() };
            }

            EmployeeViewModel = new EmployeeViewModel();

            foreach (var operation in Dictionaries.OperationList)
            {
                operationBox.Items.Add(operation.Value.Nazwa + " - " + operation.Value.Typ);
            }
        }

        public List<Employees> BindingSource
        {
            set
            {
                _bsEmployees.DataSource = value;
                /* Ustawienie danych w przypadku edycji istniejacego */
                using(var context = new ClinicDataEntities())
                {
                    _bsEmployeeData.DataSource = context.Data.Find(value.First().Id);
                }
            }
        }

        public void SetSpecificProperties()
        {
            var opId = (_bsEmployees.DataSource as List<Employees>).First().OperationId;
            operationBox.SelectedIndex = Dictionaries.OperationList.Values.Where(p => p.Id == opId).First().Id - 1;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var newEmployeeData = (_bsEmployees.DataSource as List<Employees>).First();
            var newData = (_bsEmployeeData.DataSource as List<Data>).First();
            newData.Gender = _maleBtn.Checked ? "M" : "K";
            newEmployeeData.OperationId = operationBox.SelectedIndex + 1;
            EmployeeViewModel.SaveEmployee(newEmployeeData, newData, Mode);
            this.Close();
        }
    }
}
