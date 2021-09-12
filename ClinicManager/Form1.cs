﻿using ClinicManager;
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
    }
}
