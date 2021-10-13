using ClinicManager;
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

        public enum AddValues
        {
            Unit = 1,
            Operation = 2
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
        IProducentDetailsViewModel ProducentViewModel;

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
            ProducentViewModel = new ProducentViewModel();
        }

        #endregion

        #region Clinics & Localizations & Opinions

        private void btnHospitalAdd_Click(object sender, EventArgs e)
        {
            ClinicViewModel.AddClinic();
        }

        private void btnClinicsStructure_Click(object sender, EventArgs e)
        {
            try
            {
                ClinicViewModel.ShowHierarchy(_gvMain.SelectedRows[0].DataBoundItem as ClinicRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHospitalEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ClinicViewModel.EditClinic(_gvMain.SelectedRows[0].DataBoundItem as ClinicRow);
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHospitalShowList_Click(object sender, EventArgs e)
        {
            bsMain.Sort = string.Empty;
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
            try
            {
                _gvMain.DataSource = ClinicViewModel.GetOpinions(_gvMain.SelectedRows[0].DataBoundItem as ClinicRow);
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac przychodnie", "Blad");
            }
        }

        private void btnOpinionAdd_Click(object sender, EventArgs e)
        {
            ClinicViewModel.AddOpinion();
        }

        private void btnLocalizationAdd_Click(object sender, EventArgs e)
        {
            var form = new LocalizationDetails();
            form.ShowDialog();
        }

        private void btnHospitalRemove_Click(object sender, EventArgs e)
        {
            try
            {
                ClinicViewModel.DeleteClinics(_gvMain.SelectedRows[0].DataBoundItem as ClinicRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
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

        private void btnClinicsSort_Click(object sender, EventArgs e)
        {
            ClinicViewModel.Sort(_gvMain, bsMain);
        }

        private void btnClinicsOrder_Click(object sender, EventArgs e)
        {
            ClinicViewModel.MakeOrder();
        }

        private void btnClinicOrderTool_Click(object sender, EventArgs e)
        {
            ClinicViewModel.MakeOrderTool();
        }

        #endregion

        #region Employees

        private void btnDoctorsAdd_Click(object sender, EventArgs e)
        {
            EmployeeViewModel.AddEmployee();
        }

        private void btnDoctorsShow_Click(object sender, EventArgs e)
        {
            bsMain.Sort = string.Empty;
            using (var context = new ClinicDataEntities())
            {
                var clinicList = context.EmployeeRow.ToList();
                bsMain.DataSource = typeof(EmployeeRow);
                bsMain.DataSource = clinicList;
                _gvMain.DataSource = bsMain;
            }

            EmployeeViewModel.CheckCurrencyFormat(_gvMain);
        }

        private void btnDoctorsEdit_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeViewModel.EditEmployee(_gvMain.SelectedRows[0].DataBoundItem as EmployeeRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDoctorsDelete_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeViewModel.DeleteEmployee(_gvMain.SelectedRows[0].DataBoundItem as EmployeeRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDoctorsRefresh_Click(object sender, EventArgs e)
        {
            _gvMain.DataSource = EmployeeViewModel.RefreshEmployees();
            EmployeeViewModel.CheckCurrencyFormat(_gvMain);
        }

        private void btnDoctorsFilter_Click(object sender, EventArgs e)
        {
            bsMain.DataSource = EmployeeViewModel.Filter();
            _gvMain.DataSource = bsMain;
        }

        private void btnDoctorsEnroll_Click(object sender, EventArgs e)
        {
            EmployeeViewModel.Enroll();
        }

        private void btnDoctorsShowContact_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeViewModel.ShowContact(_gvMain.SelectedRows[0].DataBoundItem as EmployeeRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDoctorsSort_Click(object sender, EventArgs e)
        {
            EmployeeViewModel.Sort(_gvMain, bsMain);
        }

        private void btnDoctorsHistory_Click(object sender, EventArgs e)
        {
            try
            {
                _gvMain.DataSource = EmployeeViewModel.ShowHistory(_gvMain.SelectedRows[0].DataBoundItem as EmployeeRow);
                VisitViewModel.CheckRegistrationStatus(_gvMain);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        #endregion

        #region Patients

        private void btnClientsAdd_Click(object sender, EventArgs e)
        {
            PatientViewModel.AddPatient();
        }

        private void btnClientsShow_Click(object sender, EventArgs e)
        {
            bsMain.Sort = string.Empty;
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
            try
            {
                PatientViewModel.EditPatient(_gvMain.SelectedRows[0].DataBoundItem as PatientRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClientsDelete_Click(object sender, EventArgs e)
        {
            try
            {
                PatientViewModel.DeletePatient(_gvMain.SelectedRows[0].DataBoundItem as PatientRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnPatientShowContact_Click(object sender, EventArgs e)
        {
            try
            {
                PatientViewModel.ShowContact(_gvMain.SelectedRows[0].DataBoundItem as PatientRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnPatientSort_Click(object sender, EventArgs e)
        {
            PatientViewModel.Sort(_gvMain, bsMain);
        }

        private void btnPatientVisits_Click(object sender, EventArgs e)
        {
            try
            {
                _gvMain.DataSource = PatientViewModel.ShowVisits(_gvMain.SelectedRows[0].DataBoundItem as PatientRow);
                VisitViewModel.CheckRegistrationStatus(_gvMain);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region FixedAssets

        private void btnAssetsAdd_Click(object sender, EventArgs e)
        {
            FixedAssetViewModel.AddFixedAsset();
        }

        private void btnAssetsShow_Click(object sender, EventArgs e)
        {
            bsMain.Sort = string.Empty;
            using (var context = new ClinicDataEntities())
            {
                var clinicList = context.ToolRow.ToList();
                bsMain.DataSource = typeof(ToolRow);
                bsMain.DataSource = clinicList;
                _gvMain.DataSource = bsMain;
            }

            FixedAssetViewModel.CheckAmountFormat(_gvMain);
        }

        private void btnAssetsEdit_Click(object sender, EventArgs e)
        {
            try
            {
                FixedAssetViewModel.EditFixedAsset(_gvMain.SelectedRows[0].DataBoundItem as ToolRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAssetsDelete_Click(object sender, EventArgs e)
        {
            try
            {
                FixedAssetViewModel.DeleteFixedAsset(_gvMain.SelectedRows[0].DataBoundItem as ToolRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnAssetsRefresh_Click(object sender, EventArgs e)
        {
            _gvMain.DataSource = FixedAssetViewModel.RefreshFixedAssets();
            FixedAssetViewModel.CheckAmountFormat(_gvMain);
        }

        private void btnAssetsFilter_Click(object sender, EventArgs e)
        {
            bsMain.DataSource = FixedAssetViewModel.Filter();
            _gvMain.DataSource = bsMain;
            FixedAssetViewModel.CheckAmountFormat(_gvMain);
        }

        private void btnToolsSort_Click(object sender, EventArgs e)
        {
            FixedAssetViewModel.Sort(_gvMain, bsMain);
        }

        private void btnToolsInventarize_Click(object sender, EventArgs e)
        {
            FixedAssetViewModel.Inventarize();
        }

        #endregion

        #region Drugs

        private void btnArticleAdd_Click(object sender, EventArgs e)
        {
            ArticleViewModel.AddArticle();
        }

        private void btnArticleShow_Click(object sender, EventArgs e)
        {
            bsMain.Sort = string.Empty;
            using (var context = new ClinicDataEntities())
            {
                var articleList = context.DrugRow.ToList();
                bsMain.DataSource = typeof(DrugRow);
                bsMain.DataSource = articleList;
                _gvMain.DataSource = bsMain;
            }

            ArticleViewModel.CheckPercentageFormat(_gvMain);
        }

        private void btnArticleEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ArticleViewModel.EditArticle(_gvMain.SelectedRows[0].DataBoundItem as DrugRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnArticleDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ArticleViewModel.DeleteArticle(_gvMain.SelectedRows[0].DataBoundItem as DrugRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }

        private void btnArticleRefresh_Click(object sender, EventArgs e)
        {
            _gvMain.DataSource = ArticleViewModel.RefreshArticles();
            ArticleViewModel.CheckPercentageFormat(_gvMain);
        }

        private void btnArticleFilter_Click(object sender, EventArgs e)
        {
            bsMain.DataSource = ArticleViewModel.Filter();
            _gvMain.DataSource = bsMain;
            ArticleViewModel.CheckPercentageFormat(_gvMain);
        }

        private void btnArticleAddUnit_Click(object sender, EventArgs e)
        {
            ArticleViewModel.AddUnit();
        }

        private void btnArticleSort_Click(object sender, EventArgs e)
        {
            ArticleViewModel.Sort(_gvMain, bsMain);
        }

        private void btnArticleRemoveExpired_Click(object sender, EventArgs e)
        {
            ArticleViewModel.Inventarize();
        }

        #endregion

        #region Visits

        private void btnVisitsShow_Click(object sender, EventArgs e)
        {
            bsMain.Sort = string.Empty;
            using (var context = new ClinicDataEntities())
            {
                var clinicList = context.RegistrationRow.ToList();
                bsMain.DataSource = typeof(RegistrationRow);
                bsMain.DataSource = clinicList;
                _gvMain.DataSource = bsMain;
            }

            VisitViewModel.CheckRegistrationStatus(_gvMain);
        }

        private void btnVisitsAdd_Click(object sender, EventArgs e)
        {
            VisitViewModel.AddRegistration();
        }

        private void btnVisitsEdit_Click(object sender, EventArgs e)
        {
            try
            {
                VisitViewModel.EditRegistration(_gvMain.SelectedRows[0].DataBoundItem as RegistrationRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVisitsDelete_Click(object sender, EventArgs e)
        {
            try
            {
                VisitViewModel.DeleteVisit(_gvMain.SelectedRows[0].DataBoundItem as RegistrationRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnVisitsRefresh_Click(object sender, EventArgs e)
        {
            _gvMain.DataSource = VisitViewModel.RefreshVisits();
            VisitViewModel.CheckRegistrationStatus(_gvMain);
        }

        private void btnVisitsFilter_Click(object sender, EventArgs e)
        {
            bsMain.DataSource = VisitViewModel.Filter();
            _gvMain.DataSource = bsMain;
            VisitViewModel.CheckRegistrationStatus(_gvMain);
        }

        private void btnVisitsSchedule_Click(object sender, EventArgs e)
        {
            VisitViewModel.GetSchedule();
        }

        private void btnVisitSort_Click(object sender, EventArgs e)
        {
            VisitViewModel.Sort(_gvMain, bsMain);
            VisitViewModel.CheckRegistrationStatus(_gvMain);
        }

        private void btnVisitAccept_Click(object sender, EventArgs e)
        {
            try
            {
                VisitViewModel.AcceptVisit(_gvMain.SelectedRows[0].DataBoundItem as RegistrationRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVisitRealize_Click(object sender, EventArgs e)
        {
            try
            {
                VisitViewModel.RealizeVisit(_gvMain.SelectedRows[0].DataBoundItem as RegistrationRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVisitUndo_Click(object sender, EventArgs e)
        {
            try
            {
                VisitViewModel.UndoVisit(_gvMain.SelectedRows[0].DataBoundItem as RegistrationRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Operations

        private void btnOperationsAdd_Click(object sender, EventArgs e)
        {
            OperationViewModel.AddOperation();
        }

        private void btnOperationsShow_Click(object sender, EventArgs e)
        {
            bsMain.Sort = string.Empty;
            using (var context = new ClinicDataEntities())
            {
                var clinicList = context.OperationRow.ToList();
                bsMain.DataSource = typeof(OperationRow);
                bsMain.DataSource = clinicList;
                _gvMain.DataSource = bsMain;
            }
        }

        private void btnOperationsEdit_Click(object sender, EventArgs e)
        {
            try
            {
                OperationViewModel.EditOperation(_gvMain.SelectedRows[0].DataBoundItem as OperationRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOperationsDelete_Click(object sender, EventArgs e)
        {
            try
            {
                OperationViewModel.DeleteOperation(_gvMain.SelectedRows[0].DataBoundItem as OperationRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOperationsRefresh_Click(object sender, EventArgs e)
        {
            _gvMain.DataSource = OperationViewModel.RefreshOperations();
        }

        private void btnOperationsFilter_Click(object sender, EventArgs e)
        {
            bsMain.DataSource = OperationViewModel.Filter();
            _gvMain.DataSource = bsMain;
        }

        private void btnOperationAddType_Click(object sender, EventArgs e)
        {
            OperationViewModel.AddOperationType();
        }

        private void btnOperationSort_Click(object sender, EventArgs e)
        {
            OperationViewModel.Sort(_gvMain, bsMain);
        }

        #endregion

        #region Prices
        private void btnPriceAdd_Click(object sender, EventArgs e)
        {
            CostViewModel.AddCost();
        }


        private void btnPriceShow_Click(object sender, EventArgs e)
        {
            bsMain.Sort = string.Empty;
            using (var context = new ClinicDataEntities())
            {
                var clinicList = context.CostRow.ToList();
                bsMain.DataSource = typeof(CostRow);
                bsMain.DataSource = clinicList;
                _gvMain.DataSource = bsMain;
            }
            CostViewModel.CheckCurrencyFormat(_gvMain);
        }

        private void btnPriceEdit_Click(object sender, EventArgs e)
        {
            try
            {
                CostViewModel.EditCost(_gvMain.SelectedRows[0].DataBoundItem as CostRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }       
        }

        private void btnPriceDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CostViewModel.DeleteCost(_gvMain.SelectedRows[0].DataBoundItem as CostRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
        }

        private void btnPriceRefresh_Click(object sender, EventArgs e)
        {
            _gvMain.DataSource = CostViewModel.RefreshCosts();
            CostViewModel.CheckCurrencyFormat(_gvMain);
        }

        private void btnPriceFilter_Click(object sender, EventArgs e)
        {
            bsMain.DataSource = CostViewModel.Filter();
            _gvMain.DataSource = bsMain;
            CostViewModel.CheckCurrencyFormat(_gvMain);
        }

        private void btnCostSort_Click(object sender, EventArgs e)
        {
            CostViewModel.Sort(_gvMain, bsMain);
        }

        private void btnCostsCheapest_Click(object sender, EventArgs e)
        {
            _gvMain.DataSource = CostViewModel.GetCheapest();
            CostViewModel.CheckCurrencyFormat(_gvMain, true);
        }

        private void btnCostsFastest_Click(object sender, EventArgs e)
        {
            _gvMain.DataSource = CostViewModel.GetFastest();
            CostViewModel.CheckCurrencyFormat(_gvMain, false, true);
        }

        #endregion

        #region Producents
        private void btnSupplierShow_Click(object sender, EventArgs e)
        {
            bsMain.Sort = string.Empty;
            using (var context = new ClinicDataEntities())
            {
                var prodList = context.ProducentRow.ToList();
                bsMain.DataSource = typeof(ProducentRow);
                bsMain.DataSource = prodList;
                _gvMain.DataSource = bsMain;
            }
        }

        private void btnSupplierAdd_Click(object sender, EventArgs e)
        {
            ProducentViewModel.AddProducent();
        }

        private void btnSupplierEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ProducentViewModel.EditProducent(_gvMain.SelectedRows[0].DataBoundItem as ProducentRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnSupplierDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ProducentViewModel.DeleteProducent(_gvMain.SelectedRows[0].DataBoundItem as ProducentRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupplierRefresh_Click(object sender, EventArgs e)
        {
            _gvMain.DataSource = ProducentViewModel.RefreshProducents();
        }

        private void btnSupplierFilter_Click(object sender, EventArgs e)
        {
            bsMain.DataSource = ProducentViewModel.Filter();
            _gvMain.DataSource = bsMain;
        }

        private void btnProducentShowContact_Click(object sender, EventArgs e)
        {
            try
            {
                ProducentViewModel.ShowContact(_gvMain.SelectedRows[0].DataBoundItem as ProducentRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        private void btnProducentsSort_Click(object sender, EventArgs e)
        {
            ProducentViewModel.Sort(_gvMain, bsMain);
        }

        private void btnProducentsOrders_Click(object sender, EventArgs e)
        {
            try
            {
                _gvMain.DataSource = ProducentViewModel.GetRelatedOrders(_gvMain.SelectedRows[0].DataBoundItem as ProducentRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProducentsOrdersTools_Click(object sender, EventArgs e)
        {
            try
            {
                _gvMain.DataSource = ProducentViewModel.GetRelatedOrdersTools(_gvMain.SelectedRows[0].DataBoundItem as ProducentRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnProducentsAddPrice_Click(object sender, EventArgs e)
        {
            try
            {
                CostViewModel.AddCost(_gvMain.SelectedRows[0].DataBoundItem as ProducentRow);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(null, "Nalezy wybrac rekord", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        #endregion

        #region Configuration

        private void btnConfigurationShowDBScript_Click(object sender, EventArgs e)
        {
            if (((RibbonButton)sender).Name == "btnConfigurationShowDBScript")
            {
                var form = new ScriptForm();
                form.HeaderText = "Poniższy skrypt należy uruchomić na bazie danych do tworzenia struktury:";
                form.ScriptText = ClinicManager.Properties.Resources.dbConfig;
                form.HeaderColor = Color.Red;
                form.ShowDialog();
            }
            else
            if(((RibbonButton)sender).Name == "btnConfigurationInsertDBData")
            {
                var form = new ScriptForm();
                form.HeaderColor = Color.Blue;
                form.ScriptText = ClinicManager.Properties.Resources.dbData;
                form.HeaderText = "Poniższy skrypt należy uruchomić na bazie danych do wypelniania danych:";
                form.ShowDialog();
            }
            else
            {
                var form = new ScriptForm();
                form.HeaderText = "Poniższy skrypt należy uruchomić na bazie do tworzenia triggerów";
                form.ScriptText = ClinicManager.Properties.Resources.dbTriggers;
                form.HeaderColor = Color.Green;
                form.ShowDialog();
            }
        }

        private void addUser_Click(object sender, EventArgs e)
        {
            var form = new AddUserControl();
            form.ShowDialog();
        }

        #endregion
    }
}
