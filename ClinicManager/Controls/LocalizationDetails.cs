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

namespace ClinicManager.Controls
{
    public partial class LocalizationDetails : Form
    {
        public LocalizationDetails()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if(ValidateChildren(ValidationConstraints.Enabled))
            {
                var localization = new Localizations
                {
                    Country = countryBox.Text,
                    City = cityBox.Text,
                    Street = streetBox.Text,
                    House = Byte.Parse(houseBox.Text),
                    Flat = Byte.Parse(flatBox.Text),
                    PostalCode = codeBox.Text,
                };
                using (var context = new ClinicDataEntities())
                {
                    context.Localizations.Add(localization);
                    context.SaveChanges();
                }
                this.Close();
            } 
        }

        private void countryBox_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(countryBox.Text))
            {
                e.Cancel = true;
                erp.SetError(countryBox, "Wypelnij kraj");
            }
            else
            {
                e.Cancel = false;
                erp.SetError(countryBox, null);
            }
        }

        private void cityBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cityBox.Text))
            {
                e.Cancel = true;
                erp.SetError(cityBox, "Wypelnij miasto");
            }
            else
            {
                e.Cancel = false;
                erp.SetError(cityBox, null);
            }
        }

        private void streetBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(streetBox.Text))
            {
                e.Cancel = true;
                erp.SetError(streetBox, "Wypelnij ulice");
            }
            else
            {
                e.Cancel = false;
                erp.SetError(streetBox, null);
            }
        }

        private void houseBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(houseBox.Text))
            {
                e.Cancel = true;
                erp.SetError(houseBox, "Wypelnij dom");
            }
            else
            {
                e.Cancel = false;
                erp.SetError(houseBox, null);
            }
        }

        private void flatBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(flatBox.Text))
            {
                e.Cancel = true;
                erp.SetError(flatBox, "Wypelnij mieszkanie");
            }
            else
            {
                e.Cancel = false;
                erp.SetError(flatBox, null);
            }
        }

        private void codeBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(codeBox.Text))
            {
                e.Cancel = true;
                erp.SetError(codeBox, "Wypelnij kod");
            }
            else
            {
                e.Cancel = false;
                erp.SetError(codeBox, null);
            }
        }
    }
}
