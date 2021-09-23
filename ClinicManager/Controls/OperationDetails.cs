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
    public partial class OperationDetails : Form
    {
        private StaticDictionaries Dictionaries;
        private DetailsMode Mode;
        private IOperationDetailsViewModel OperationViewModel;

        public OperationDetails(DetailsMode mode)
        {
            InitializeComponent();

            Mode = mode;
            Dictionaries = new StaticDictionaries();

            if(mode == DetailsMode.Add)
            {
                _bsOperation.DataSource = new List<Operations> { new Operations() };
            }

            OperationViewModel = new OperationViewModel();

            var toolList = new List<ToolRow>();
            foreach (var operation in Dictionaries.ToolList)
            {
                toolList.Add(operation.Value);
            }
            _bsTools.DataSource = toolList;

            var drugList = new List<DrugRow>();
            foreach (var operation in Dictionaries.DrugList)
            {
                drugList.Add(operation.Value);
            }
            _bsDrugs.DataSource = drugList;

            foreach(var item in Dictionaries.TypeOperationList)
            {
                typeBox.Items.Add(item.Value);
            }
        }

        public List<Operations> BindingSource
        {
            set
            {
                _bsOperation.DataSource = value;
            }
        }

        public void SetSpecificProperties()
        {
            drugBox.SelectedItem = Dictionaries.DrugList
                                                     .Where(p => p.Value.Id == (_bsOperation.DataSource as List<Operations>)
                                                     .First().DrugId).First().Value;
            toolBox.SelectedItem = Dictionaries.ToolList
                                                     .Where(p => p.Value.Id == (_bsOperation.DataSource as List<Operations>)
                                                     .First().ToolId).First().Value;
            typeBox.SelectedItem = (_bsOperation.DataSource as List<Operations>).First().Type;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var newOperationData = (_bsOperation.DataSource as List<Operations>).First();
            newOperationData.ToolId = (toolBox.SelectedItem as ToolRow).Id;
            newOperationData.DrugId = (drugBox.SelectedItem as DrugRow).Id;
            newOperationData.Type = typeBox.SelectedItem as string;
            OperationViewModel.SaveOperation(newOperationData, Mode);
            this.Close();
        }
    }
}
