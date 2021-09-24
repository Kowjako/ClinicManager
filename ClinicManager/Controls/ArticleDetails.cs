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
    public partial class ArticleDetails : Form
    {
        private StaticDictionaries Dictionaries;
        private DetailsMode Mode;
        private IArticleDetailsViewModel ArticleDetailsViewModel;

        public ArticleDetails(DetailsMode mode)
        {
            InitializeComponent();

            Mode = mode;   /* 1 - Add, 2 - Edit */
            Dictionaries = new StaticDictionaries();

            if (mode == DetailsMode.Add)
            {
                _bsArticle.DataSource = new List<Drugs> { new Drugs() };
            }

            ArticleDetailsViewModel = new ArticleViewModel();

            foreach (var operation in Dictionaries.UnitList)
            {
                unitCombo.Items.Add(operation.Value);
            }
        }

        public List<Drugs> BindingSource
        {
            set
            {
                _bsArticle.DataSource = value;
            }
        }

        public void SetSpecificProperties()
        {
            var unitId = (_bsArticle.DataSource as List<Drugs>).First().Unit;
            unitCombo.SelectedIndex = Dictionaries.UnitList.Where(p => p.Value == unitId).First().Key - 1;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var newDrugData = (_bsArticle.DataSource as List<Drugs>).First();
            newDrugData.Unit = Dictionaries.UnitList.Where(p => p.Key == unitCombo.SelectedIndex + 1).First().Value;
            ArticleDetailsViewModel.SaveArticle(newDrugData, Mode);
            this.Close();
        }

    }
}
