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
    public partial class CostDetails : Form
    {
        private StaticDictionaries Dictionaries;
        private DetailsMode Mode;
        private ICostDetailsViewModel CostViewModel;
        public CostDetails(DetailsMode mode)
        {
            InitializeComponent();

            Mode = mode;   /* 1 - Add, 2 - Edit */
            Dictionaries = new StaticDictionaries();

            if (mode == DetailsMode.Add)
            {
                bsCosts.DataSource = new List<Costs> { new Costs() };
            }

            CostViewModel = new CostViewModel();

            var producentList = new List<ProducentRow>();
            foreach (var operation in Dictionaries.ProducentList.Value)
            {
                producentList.Add(operation.Value);
            }
            bsProducent.DataSource = producentList;

            var drugList = new List<DrugRow>();
            foreach(var drug in Dictionaries.DrugList.Value)
            {
                drugList.Add(drug.Value);
            }
            bsDrugs.DataSource = drugList;
        }

        public List<Costs> BindingSource
        {
            set
            {
                bsCosts.DataSource = value;
            }
        }

        public void SetSpecificProperties()
        {
            drugsBox.SelectedItem = Dictionaries.DrugList.Value
                                                    .Where(p => p.Value.Id == (bsCosts.DataSource as List<Costs>)
                                                    .First().DrugId).First().Value;
            producentBox.SelectedItem = Dictionaries.ProducentList.Value
                                                    .Where(p => p.Value.Id == (bsCosts.DataSource as List<Costs>)
                                                    .First().ProducentId).First().Value;

        }

        public void SetSpecificProducent(ProducentRow prod)
        {
            producentBox.SelectedItem = Dictionaries.ProducentList.Value
                                                     .Where(p => p.Value.Id == prod.Id).First().Value;
            producentBox.Enabled = false;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if(ValidateChildren(ValidationConstraints.Enabled))
            {
                var newCostData = (bsCosts.DataSource as List<Costs>).First();
                newCostData.ProducentId = (producentBox.SelectedItem as ProducentRow).Id;
                newCostData.DrugId = (drugsBox.SelectedItem as DrugRow).Id;
                CostViewModel.SaveCost(newCostData, Mode);
                this.Close();
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                erp.SetError(textBox1, "Cena musi byc wieksza od 0");
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
                erp.SetError(numericUpDown1, "Czas dostawy nie moze byc 0");
            }
            else
            {
                e.Cancel = false;
                erp.SetError(numericUpDown1, null);
            }
        }
    }
}
