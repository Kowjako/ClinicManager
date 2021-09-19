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

            foreach (var employee in Dictionaries.EmployeeList)
            {
                employeeBox.Items.Add(employee.Value.Lekarz);
            }
            foreach (var localization in Dictionaries.LocalizationList)
            {
                localizationBox.Items.Add(localization.Value.Kraj + ", " + localization.Value.Miasto + ", " + localization.Value.Budynek);
            }
        }

        public List<Clinics> BindingSource
        {
            set { _bsDetails.DataSource = value; }
        }
        
        public void SetSpecificProperties()
        {
            var locId = (_bsDetails.DataSource as List<Clinics>).First().LocalizationId;
            var empId = (_bsDetails.DataSource as List<Clinics>).First().EmployeeId;
            employeeBox.SelectedIndex = Dictionaries.EmployeeList.Values.Where(p => p.Id == empId).First().Id - 1;
            localizationBox.SelectedIndex = Dictionaries.LocalizationList.Values.Where(p => p.Id == locId).First().Id - 1;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var newClinicData = (_bsDetails.DataSource as List<Clinics>).First();
            newClinicData.LocalizationId = localizationBox.SelectedIndex + 1;
            newClinicData.EmployeeId = employeeBox.SelectedIndex + 1;
            ClinicViewModel.SaveClinics(newClinicData, Mode);
            this.Close();
        }
    }
}
