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
            foreach (var operation in Dictionaries.ProducentList)
            {
                producentList.Add(operation.Value);
            }
            bsProducent.DataSource = producentList;

            var drugList = new List<DrugRow>();
            foreach(var drug in Dictionaries.DrugList)
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
            drugsBox.SelectedItem = Dictionaries.DrugList
                                                    .Where(p => p.Value.Id == (bsCosts.DataSource as List<Costs>)
                                                    .First().DrugId).First().Value;
            producentBox.SelectedItem = Dictionaries.ProducentList
                                                    .Where(p => p.Value.Id == (bsCosts.DataSource as List<Costs>)
                                                    .First().ProducentId).First().Value;

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var newCostData = (bsCosts.DataSource as List<Costs>).First();
            newCostData.ProducentId = (producentBox.SelectedItem as ProducentRow).Id;
            newCostData.DrugId = (drugsBox.SelectedItem as DrugRow).Id;
            CostViewModel.SaveCost(newCostData, Mode);
            this.Close();
        }
    }
}
