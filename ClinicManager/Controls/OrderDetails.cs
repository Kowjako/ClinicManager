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
    public partial class OrderDetails : Form
    {
        private StaticDictionaries Dictionaries;
        private DetailsMode Mode;
        private IClinicDetailsViewModel ClinicViewModel;

        public OrderDetails(DetailsMode mode)
        {
            InitializeComponent();

            Mode = mode;   /* 1 - Add, 2 - Edit */
            Dictionaries = new StaticDictionaries();

            if (mode == DetailsMode.Add)
            {
                bsOrder.DataSource = new List<Orders> { new Orders() };
            }

            ClinicViewModel = new ClinicViewModel();

            var empList = new List<DrugRow>();
            foreach (var employee in Dictionaries.DrugList.Value)
            {
                empList.Add(employee.Value);
            }
            bsDrugs.DataSource = empList;

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
            bsProducent.DataSource = prodList;

            foreach (var operation in Dictionaries.UnitList)
            {
                unitBox.Items.Add(operation.Value);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if(ValidateChildren(ValidationConstraints.Enabled))
            {
                var newOrderData = (bsOrder.DataSource as List<Orders>).First();
                newOrderData.Unit = Dictionaries.UnitList.Where(p => p.Key == unitBox.SelectedIndex + 1).First().Value;
                newOrderData.ProducentId = (producentBox.SelectedItem as ProducentRow).Id;
                newOrderData.DrugId = (drugBox.SelectedItem as DrugRow).Id;
                newOrderData.ClinicId = (clinicBox.SelectedItem as ClinicRow).Id;
                if (amount.Value == 0)
                {
                    MessageBox.Show(null, "Ilosc musi byc wieksza od zera", "Blad");
                    return;
                }
                ClinicViewModel.SaveOrder(newOrderData);
                this.Close();
            }
        }

        private void amount_Validating(object sender, CancelEventArgs e)
        {
            if(amount.Value <= 0)
            {
                e.Cancel = true;
                erp.SetError(amount, "Podaj ilosc");
            }
            else
            {
                e.Cancel = false;
                erp.SetError(amount, null);
            }
        }

        private void unitBox_Validating(object sender, CancelEventArgs e)
        {
            if (unitBox.SelectedIndex == -1)
            {
                e.Cancel = true;
                erp.SetError(unitBox, "Podaj jednostke");
            }
            else
            {
                e.Cancel = false;
                erp.SetError(unitBox, null);
            }
        }
    }
}
