using ClinicManager;
using ClinicManager.Controls;
using ClinicManager.DataAccessLayer;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHospitalAdd_Click(object sender, EventArgs e)
        {
            var form = new ClinicDetails();
            form.ShowDialog();
        }

        private void btnHospitalEdit_Click(object sender, EventArgs e)
        {
            var form = new ClinicDetails();
            using (var context = new ClinicDataEntities())
            {
                var clinic = context.Clinics.Find((_gvMain.SelectedRows[0].DataBoundItem as ClinicRow).Id);
                form.BindingSource = new List<Clinics> { clinic };
            }
            form.ShowDialog();
        }

        private void btnDoctorsAdd_Click(object sender, EventArgs e)
        {
            var form = new DoctorDetails();
            form.ShowDialog();
        }

        private void btnClientsAdd_Click(object sender, EventArgs e)
        {
            var form = new PatientDetails();
            form.ShowDialog();
        }

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

        private void btnHospitalShowList_Click(object sender, EventArgs e)
        {
            using(var context = new ClinicDataEntities())
            {
                var clinicList = context.ClinicRow.ToList();
                bsMain.DataSource = typeof(ClinicRow);
                bsMain.DataSource = clinicList;
                _gvMain.DataSource = bsMain;
            }
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
    }
}
