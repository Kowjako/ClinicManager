﻿using ClinicManager;
using ClinicManager.Controls;
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

namespace Test
{
    public partial class Form1 : Form
    {
        #region Enums & values

        public enum DetailsMode
        {
            Add = 1,
            Edit = 2
        }

        #endregion

        #region ViewModels

        IClinicDetailsViewModel ClinicViewModel;
        IArticleDetailsViewModel ArticleViewModel;
        IFixedAssetViewModel FixedAssetViewModel;
        IVisitDetailsViewModel VisitViewModel;
        IPatientDetailsViewModel PatientViewModel;
        IOperationDetailsViewModel OperationViewModel;
        ICostDetailsViewModel CostViewModel;
        IDoctorDetailsViewModel EmployeeViewModel;

        #endregion

        #region Initializing

        public Form1()
        {
            InitializeComponent();
            ClinicViewModel = new ClinicViewModel();
            ArticleViewModel = new ArticleViewModel();
            FixedAssetViewModel = new FixedAssetViewModel();
            VisitViewModel = new VisitViewModel();
            PatientViewModel = new PatientViewModel();
            OperationViewModel = new OperationViewModel();
            CostViewModel = new CostViewModel();
            EmployeeViewModel = new EmployeeViewModel();
        }

        #endregion

        #region Clinics & Localizations & Opinions

        private void btnHospitalAdd_Click(object sender, EventArgs e)
        {
            ClinicViewModel.AddClinic();
        }

        private void btnHospitalEdit_Click(object sender, EventArgs e)
        {
            ClinicViewModel.EditClinic(_gvMain.SelectedRows[0].DataBoundItem as ClinicRow);
        }

        private void btnHospitalShowList_Click(object sender, EventArgs e)
        {
            using (var context = new ClinicDataEntities())
            {
                var clinicList = context.ClinicRow.ToList();
                bsMain.DataSource = typeof(ClinicRow);
                bsMain.DataSource = clinicList;
                _gvMain.DataSource = bsMain;
            }
        }

        private void btnOpinionShow_Click(object sender, EventArgs e)
        {
            _gvMain.DataSource = ClinicViewModel.GetOpinions(_gvMain.SelectedRows[0].DataBoundItem as ClinicRow);
        }

        private void btnLocalizationAdd_Click(object sender, EventArgs e)
        {
            var form = new LocalizationDetails();
            form.ShowDialog();
        }

        private void btnHospitalRemove_Click(object sender, EventArgs e)
        {
            ClinicViewModel.DeleteClinics(_gvMain.SelectedRows[0].DataBoundItem as ClinicRow);
        }

        private void btnHospitalFilter_Click(object sender, EventArgs e)
        {
            bsMain.DataSource = ClinicViewModel.Filter();
            _gvMain.DataSource = bsMain;
        }

        private void btnHospitalRefresh_Click(object sender, EventArgs e)
        {
            _gvMain.DataSource = ClinicViewModel.RefreshClinics();
        }

        #endregion

        #region Employees

        private void btnDoctorsAdd_Click(object sender, EventArgs e)
        {
            EmployeeViewModel.AddEmployee();
        }

        private void btnDoctorsShow_Click(object sender, EventArgs e)
        {
            using (var context = new ClinicDataEntities())
            {
                var clinicList = context.EmployeeRow.ToList();
                bsMain.DataSource = typeof(EmployeeRow);
                bsMain.DataSource = clinicList;
                _gvMain.DataSource = bsMain;
            }
        }

        private void btnDoctorsEdit_Click(object sender, EventArgs e)
        {
            EmployeeViewModel.EditEmployee(_gvMain.SelectedRows[0].DataBoundItem as EmployeeRow);
        }

        private void btnDoctorsDelete_Click(object sender, EventArgs e)
        {
            EmployeeViewModel.DeleteEmployee(_gvMain.SelectedRows[0].DataBoundItem as EmployeeRow);
        }

        private void btnDoctorsRefresh_Click(object sender, EventArgs e)
        {
            _gvMain.DataSource = EmployeeViewModel.RefreshEmployees();
        }

        private void btnDoctorsFilter_Click(object sender, EventArgs e)
        {
            bsMain.DataSource = EmployeeViewModel.Filter();
            _gvMain.DataSource = bsMain;
        }

        #endregion

        #region Patients

        private void btnClientsAdd_Click(object sender, EventArgs e)
        {
            PatientViewModel.AddPatient();
        }

        private void btnClientsShow_Click(object sender, EventArgs e)
        {
            using (var context = new ClinicDataEntities())
            {
                var clinicList = context.PatientRow.ToList();
                bsMain.DataSource = typeof(PatientRow);
                bsMain.DataSource = clinicList;
                _gvMain.DataSource = bsMain;
            }
        }

        private void btnClientsEdit_Click(object sender, EventArgs e)
        {
            PatientViewModel.EditPatient(_gvMain.SelectedRows[0].DataBoundItem as PatientRow);
        }

        private void btnClientsDelete_Click(object sender, EventArgs e)
        {
            PatientViewModel.DeletePatient(_gvMain.SelectedRows[0].DataBoundItem as PatientRow);
        }

        private void btnClientsRefresh_Click(object sender, EventArgs e)
        {
            _gvMain.DataSource = PatientViewModel.RefreshPatients();
        }

        private void btnClientsFilter_Click(object sender, EventArgs e)
        {
            bsMain.DataSource = PatientViewModel.Filter();
            _gvMain.DataSource = bsMain;
        }

        #endregion



        private void btnAssetsAdd_Click(object sender, EventArgs e)
        {
            var form = new FixedAsset();
            form.ShowDialog();
        }

        private void btnArticleAdd_Click(object sender, EventArgs e)
        {
            var form = new ArticleDetails();
            form.ShowDialog();
        }

        private void btnVisitsAdd_Click(object sender, EventArgs e)
        {
            var form = new VisitDetails();
            form.ShowDialog();
        }

        private void btnOperationsAdd_Click(object sender, EventArgs e)
        {
            var form = new OperationDetails();
            form.ShowDialog();
        }

        private void btnPriceAdd_Click(object sender, EventArgs e)
        {
            var form = new CostDetails();
            form.ShowDialog();
        }

        

        

        

        private void btnAssetsShow_Click(object sender, EventArgs e)
        {
            using (var context = new ClinicDataEntities())
            {
                var clinicList = context.ToolRow.ToList();
                bsMain.DataSource = typeof(ToolRow);
                bsMain.DataSource = clinicList;
                _gvMain.DataSource = bsMain;
            }
        }

        private void btnArticleShow_Click(object sender, EventArgs e)
        {
            using (var context = new ClinicDataEntities())
            {
                var clinicList = context.DrugRow.ToList();
                bsMain.DataSource = typeof(DrugRow);
                bsMain.DataSource = clinicList;
                _gvMain.DataSource = bsMain;
            }
        }

        private void btnVisitsShow_Click(object sender, EventArgs e)
        {
            using (var context = new ClinicDataEntities())
            {
                var clinicList = context.RegistrationRow.ToList();
                bsMain.DataSource = typeof(RegistrationRow);
                bsMain.DataSource = clinicList;
                _gvMain.DataSource = bsMain;
            }
        }

        private void btnOperationsShow_Click(object sender, EventArgs e)
        {
            using (var context = new ClinicDataEntities())
            {
                var clinicList = context.OperationRow.ToList();
                bsMain.DataSource = typeof(OperationRow);
                bsMain.DataSource = clinicList;
                _gvMain.DataSource = bsMain;
            }
        }

        private void btnPriceShow_Click(object sender, EventArgs e)
        {
            using (var context = new ClinicDataEntities())
            {
                var clinicList = context.CostRow.ToList();
                bsMain.DataSource = typeof(CostRow);
                bsMain.DataSource = clinicList;
                _gvMain.DataSource = bsMain;
            }
        }

        private void btnConfigurationShowDBScript_Click(object sender, EventArgs e)
        {
            if(((RibbonButton)sender).Name == "btnConfigurationShowDBScript")
            {
                var form = new ScriptForm();
                form.HeaderText = "Poniższy skrypt należy uruchomić na bazie danych do tworzenia struktury:";
                form.ScriptText = ClinicManager.Properties.Resources.dbConfig;
                form.HeaderColor = Color.Red;
                form.ShowDialog();
            }
            else
            {
                var form = new ScriptForm();
                form.HeaderColor = Color.Blue;
                form.ScriptText = ClinicManager.Properties.Resources.dbData;
                form.HeaderText = "Poniższy skrypt należy uruchomić na bazie danych do wypelniania danych:";
                form.ShowDialog();
            }
        }
    }
}
