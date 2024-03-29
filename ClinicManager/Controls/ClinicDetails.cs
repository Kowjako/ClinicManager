﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicManager.DataAccessLayer;
using ClinicManager.Interfaces;
using ClinicManager.ViewModels;
using static Test.Form1;

namespace ClinicManager
{
    public partial class ClinicDetails : Form
    {
        private StaticDictionaries Dictionaries;
        private DetailsMode Mode;
        private IClinicDetailsViewModel ClinicViewModel;
        public ClinicDetails(DetailsMode mode)
        {
            InitializeComponent();
            Mode = mode;   /* 1 - Add, 2 - Edit */
            Dictionaries = new StaticDictionaries();

            if(mode == DetailsMode.Add)
            {
                _bsDetails.DataSource = new List<Clinics> { new Clinics() };
            }

            ClinicViewModel = new ClinicViewModel();

            var empList = new List<EmployeeRow>();
            foreach (var employee in Dictionaries.EmployeeList.Value)
            {
                empList.Add(employee.Value);
            }
            _bsEmployees.DataSource = empList;

            var locList = new List<LocalizationRow>();
            foreach (var localization in Dictionaries.LocalizationList.Value)
            {
                locList.Add(localization.Value);
            }
            _bsLocalizations.DataSource = locList;
        }

        public List<Clinics> BindingSource
        {
            set { _bsDetails.DataSource = value; }
        }
        
        public void SetSpecificProperties()
        {
            employeeBox.SelectedItem = Dictionaries.EmployeeList.Value
                                                   .Where(p => p.Value.Id == (_bsDetails.DataSource as List<Clinics>)
                                                   .First().EmployeeId).First().Value;
            localizationBox.SelectedItem = Dictionaries.LocalizationList.Value
                                                       .Where(p => p.Value.Id == (_bsDetails.DataSource as List<Clinics>)
                                                       .First().LocalizationId).First().Value;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                var newClinicData = (_bsDetails.DataSource as List<Clinics>).First();
                newClinicData.LocalizationId = (localizationBox.SelectedItem as LocalizationRow).Id;
                newClinicData.EmployeeId = (employeeBox.SelectedItem as EmployeeRow).Id;
                ClinicViewModel.SaveClinics(newClinicData, Mode);
                this.Close();
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                epClinic.SetError(textBox1, "Nazwa nie moze byc pusta");
            }
            else
            {
                e.Cancel = false;
                epClinic.SetError(textBox1, null);
            } 
        }
    }
}
