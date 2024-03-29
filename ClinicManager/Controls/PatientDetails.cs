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
    public partial class PatientDetails : Form
    {
        private StaticDictionaries Dictionaries;
        private DetailsMode Mode;
        private IPatientDetailsViewModel PatientsViewModel;

        public PatientDetails(DetailsMode mode)
        {
            InitializeComponent();
            Mode = mode;   /* 1 - Add, 2 - Edit */
            Dictionaries = new StaticDictionaries();

            if (mode == DetailsMode.Add)
            {
                _bsPatients.DataSource = new List<Patients> { new Patients() };
                _bsPatientsData.DataSource = new List<Data> { new Data() };
            }

            PatientsViewModel = new PatientViewModel();

            var opList = new List<OperationRow>();
            foreach (var operation in Dictionaries.OperationList.Value)
            {
                opList.Add(operation.Value);
            }
            _bsOperations.DataSource = opList;
        }

        public List<Patients> BindingSource
        {
            set
            {
                _bsPatients.DataSource = value;
                /* Ustawienie danych w przypadku edycji istniejacego */
                using (var context = new ClinicDataEntities())
                {
                    _bsPatientsData.DataSource = context.Data.Find(value.First().DataId);
                }
            }
        }

        public void SetSpecificProperties()
        {
            operationBox.SelectedItem= Dictionaries.OperationList.Value
                                                     .Where(p => p.Value.Id == (_bsPatients.DataSource as List<Patients>)
                                                     .First().OperationId).First().Value;
            /* Ustawienie plci */
            if ((_bsPatientsData.DataSource as Data).Gender == "M")
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
                var newPatientData = (_bsPatients.DataSource as List<Patients>).First();
                var newData = new Data();
                if (Mode == DetailsMode.Add)
                {
                    newData = (_bsPatientsData.DataSource as List<Data>).First();
                }
                else
                {
                    newData = _bsPatientsData.DataSource as Data;
                }
                newData.Gender = _maleBtn.Checked ? "M" : "K";
                newPatientData.OperationId = (operationBox.SelectedItem as OperationRow).Id;
                PatientsViewModel.SavePatient(newPatientData, newData, Mode);
                this.Close();
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

        private void numericUpDown1_Validating(object sender, CancelEventArgs e)
        {
            if(numericUpDown1.Value <= 0 || numericUpDown1.Value > 10)
            {
                e.Cancel = true;
                erp.SetError(numericUpDown1, "Priorytet od 1 do 10");
            }
            else
            {
                e.Cancel = false;
                erp.SetError(numericUpDown1, null);
            }
        }

        private void textBox1_Validating_1(object sender, CancelEventArgs e)
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
    }
}
