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
    public partial class ProducentDetails : Form
    {
        private StaticDictionaries Dictionaries;
        private DetailsMode Mode;
        private IProducentDetailsViewModel ProducentViewModel;

        public ProducentDetails(DetailsMode mode)
        {
            InitializeComponent();

            Mode = mode;   /* 1 - Add, 2 - Edit */
            Dictionaries = new StaticDictionaries();

            if (mode == DetailsMode.Add)
            {
                bsProducents.DataSource = new List<Producents> { new Producents() };
                bsData.DataSource = new List<Data> { new Data() };
            }

            ProducentViewModel = new ProducentViewModel();

            var locList = new List<LocalizationRow>();
            foreach (var operation in Dictionaries.LocalizationList.Value)
            {
                locList.Add(operation.Value);
            }
            bsLocalizations.DataSource = locList;
        }

        public List<Producents> BindingSource
        {
            set
            {
                bsProducents.DataSource = value;
                /* Ustawienie danych w przypadku edycji istniejacego */
                using (var context = new ClinicDataEntities())
                {
                    bsData.DataSource = context.Data.Find(value.First().DataId);
                }
            }
        }

        public void SetSpecificProperties()
        {
            localizationBox.SelectedItem = Dictionaries.LocalizationList.Value
                                                     .Where(p => p.Value.Id == (bsProducents.DataSource as List<Producents>)
                                                     .First().LocalizationId).First().Value;
            /* Ustawienie plci */
            if ((bsData.DataSource as Data).Gender == "M")
            {
                _maleBtn.Checked = true;
            }
            else
            {
                _femaleBtn.Checked = true;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if(ValidateChildren(ValidationConstraints.Enabled))
            {
                var newProducentData = (bsProducents.DataSource as List<Producents>).First();
                var newData = new Data();
                if (Mode == DetailsMode.Add)
                {
                    newData = (bsData.DataSource as List<Data>).First();
                }
                else
                {
                    newData = bsData.DataSource as Data;
                }
                newData.Gender = _maleBtn.Checked ? "M" : "K";
                newProducentData.LocalizationId = (localizationBox.SelectedItem as LocalizationRow).Id;
                ProducentViewModel.SaveProducent(newProducentData, newData, Mode);
                this.Close();
            } 
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                erp.SetError(textBox1, "Wypelnij imie");
            }
            else
            {
                e.Cancel = false;
                erp.SetError(textBox1, null);
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                e.Cancel = true;
                erp.SetError(textBox2, "Wypelnij nazwisko");
            }
            else
            {
                e.Cancel = false;
                erp.SetError(textBox2, null);
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                e.Cancel = true;
                erp.SetError(textBox6, "Wypelnij nazwe");
            }
            else
            {
                e.Cancel = false;
                erp.SetError(textBox6, null);
            }
        }
    }
}
