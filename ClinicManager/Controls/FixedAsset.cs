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
    public partial class FixedAsset : Form
    {
        private DetailsMode Mode;
        private IFixedAssetViewModel FixedAssetViewModel;

        public FixedAsset(DetailsMode mode)
        {
            InitializeComponent();
            Mode = mode;   /* 1 - Add, 2 - Edit */

            if (mode == DetailsMode.Add)
            {
                _bsFixedAsset.DataSource = new List<Tools> { new Tools() };
            }

            FixedAssetViewModel = new FixedAssetViewModel();
        }

        public List<Tools> BindingSource
        {
            set
            {
                _bsFixedAsset.DataSource = value;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if(ValidateChildren(ValidationConstraints.Enabled))
            {
                var newFixedAsset = (_bsFixedAsset.DataSource as List<Tools>).First();
                FixedAssetViewModel.SaveFixedAsset(newFixedAsset, Mode);
                this.Close();
            }            
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                erp.SetError(textBox1, "Wypelnij nazwe");
            }
            else
            {
                e.Cancel = false;
                erp.SetError(textBox1, null);
            }
        }

        private void numericUpDown1_Validating(object sender, CancelEventArgs e)
        {
            if (numericUpDown1.Value <= 0)
            {
                e.Cancel = true;
                erp.SetError(numericUpDown1, "Podaj ilosc");
            }
            else
            {
                e.Cancel = false;
                erp.SetError(numericUpDown1, null);
            }
        }
    }
}
