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

namespace ClinicManager.Controls
{
    public partial class OrderToolDetails : Form
    {
        private StaticDictionaries Dictionaries;
        private DetailsMode Mode;
        private IClinicDetailsViewModel ClinicViewModel;

        public OrderToolDetails(DetailsMode mode)
        {
            InitializeComponent();

            Mode = mode;   /* 1 - Add, 2 - Edit */
            Dictionaries = new StaticDictionaries();

            if (mode == DetailsMode.Add)
            {
                bsOrderTools.DataSource = new List<OrdersTools> { new OrdersTools() };
            }

            ClinicViewModel = new ClinicViewModel();

            var empList = new List<ToolRow>();
            foreach (var employee in Dictionaries.ToolList.Value)
            {
                empList.Add(employee.Value);
            }
            bsTools.DataSource = empList;

            var clinicList = new List<ClinicRow>();
            foreach (var localization in Dictionaries.ClinicList.Value)
            {
                clinicList.Add(localization.Value);
            }
            bsClinic.DataSource = clinicList;

            var prodList = new List<ProducentRow>();
            foreach (var localization in Dictionaries.ProducentList.Value)
            {
                prodList.Add(localization.Value);
            }
            bsProducents.DataSource = prodList;

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var newOrderToolsData = (bsOrderTools.DataSource as List<OrdersTools>).First();
            newOrderToolsData.ToolId = (toolBox.SelectedItem as ToolRow).Id;
            newOrderToolsData.ProducentId = (producentBox.SelectedItem as ProducentRow).Id;
            newOrderToolsData.ClinicId = (clinicBox.SelectedItem as ClinicRow).Id;
            ClinicViewModel.SaveOrderTools(newOrderToolsData);
            this.Close();
        }
    }
}
