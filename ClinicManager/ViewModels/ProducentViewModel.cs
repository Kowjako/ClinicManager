using ClinicManager.Controls;
using ClinicManager.DataAccessLayer;
using ClinicManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test;
using static Test.Form1;

namespace ClinicManager.ViewModels
{
    public class ProducentViewModel : IProducentDetailsViewModel
    {
        public void AddProducent()
        {
            var form = new ProducentDetails(DetailsMode.Add);
            form.ShowDialog();
        }

        public void EditProducent(ProducentRow row)
        {
            var form = new ProducentDetails(DetailsMode.Edit);
            form.ShowDialog();
        }

        public List<ProducentRow> Filter()
        {
            var parameters = new string[] { "[Nazwa producenta]", "[Email]", "[Siedziba firmy]", "[Kierownik]" };
            var form = new FilterForm(parameters);
            if (form.ShowDialog() == DialogResult.OK)
            {
            }
            return null;
        }


        public BindingSource RefreshProducents()
        {
            var bsMain = new BindingSource();
            using (var context = new ClinicDataEntities())
            {
                var prodList = context.ProducentRow.ToList();
                bsMain.DataSource = typeof(ProducentRow);
                bsMain.DataSource = prodList;
                return bsMain;
            }
        }
        public void ShowContact(ProducentRow row)
        {
            var form = new ContactDetails();
            form.ShowDialog();
        }

        public void Sort(DataGridView grid, BindingSource list)
        {
            var form = new SortDetails();
            form.ShowDialog();
        }
    }
}
