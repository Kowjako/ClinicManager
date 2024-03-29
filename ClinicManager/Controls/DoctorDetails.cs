﻿using ClinicManager.DataAccessLayer;
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

            var operationList = new List<OperationRow>();
            foreach (var operation in Dictionaries.OperationList.Value)
            {
                operationList.Add(operation.Value);
            }
            _bsOperations.DataSource = operationList;
        }

        public List<Employees> BindingSource
        {
            set
            {
                _bsEmployees.DataSource = value;
                /* Ustawienie danych w przypadku edycji istniejacego */
                using(var context = new ClinicDataEntities())
                {
                    _bsEmployeeData.DataSource = context.Data.Find(value.First().DataId);
                }
            }
        }

        public void SetSpecificProperties()
        {
            operationBox.SelectedItem = Dictionaries.OperationList.Value
                                                    .Where(p => p.Value.Id == (_bsEmployees.DataSource as List<Employees>)
                                                    .First().OperationId).First().Value;
            /* Ustawienie plci */
            if((_bsEmployeeData.DataSource as Data).Gender == "M")
            {
                _maleBtn.Checked = true;
            }
            else
            {
                _femaleBtn.Checked = true;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if(ValidateChildren(ValidationConstraints.Enabled))
            {
                var newEmployeeData = (_bsEmployees.DataSource as List<Employees>).First();
                var newData = new Data();
                if (Mode == DetailsMode.Add)
                {
                    newData = (_bsEmployeeData.DataSource as List<Data>).First();
                }
                else
                {
                    newData = _bsEmployeeData.DataSource as Data;
                }
                newData.Gender = _maleBtn.Checked ? "M" : "K";
                newEmployeeData.OperationId = (operationBox.SelectedItem as OperationRow).Id;
                EmployeeViewModel.SaveEmployee(newEmployeeData, newData, Mode);
                this.Close();
            }          
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                erp.SetError(textBox1, "Wypelnij imie");
            }
            else
            {
                e.Cancel = false;
                erp.SetError(textBox1, null);
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                e.Cancel = true;
                erp.SetError(textBox2, "Wypelnij nazwisko");
            }
            else
            {
                e.Cancel = false;
                erp.SetError(textBox2, null);
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                e.Cancel = true;
                erp.SetError(textBox6, "Wypelnij stanowisko");
            }
            else
            {
                e.Cancel = false;
                erp.SetError(textBox6, null);
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (Int32.Parse(textBox5.Text) <= 0) 
            {
                e.Cancel = true;
                erp.SetError(textBox5, "Cena musi byc wieksza od 0");
            }
            else
            {
                e.Cancel = false;
                erp.SetError(textBox5, null);
            }
        }
    }
}
