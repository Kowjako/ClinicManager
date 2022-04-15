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
    public class FixedAssetViewModel : IFixedAssetViewModel
    {
        public void AddFixedAsset()
        {
            var form = new FixedAsset(DetailsMode.Add);
            form.ShowDialog();
        }

        public void CheckAmountFormat(DataGridView grid)
        {
            grid.Columns[2].DefaultCellStyle.Format = "0 szt" + @"\.";
        }

        public void EditFixedAsset(ToolRow row)
        {
            var form = new FixedAsset(DetailsMode.Edit);
            form.ShowDialog();
        }

        public List<ToolRow> Filter()
        {
            var parameters = new string[] { "[Nazwa]", "[Ilosc dostepna]", "[Data produkcji]", "[Data waznosci]", "[Opis]" };
            var form = new FilterForm(parameters);
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
            return null;
        }


        public BindingSource RefreshFixedAssets()
        {
            var bsMain = new BindingSource();
            using (var context = new ClinicDataEntities())
            {
                var clinicList = context.ToolRow.ToList();
                bsMain.DataSource = typeof(ToolRow);
                bsMain.DataSource = clinicList;
                return bsMain;
            }
        }

        public void Sort(DataGridView grid, BindingSource list)
        {
            var form = new SortDetails();
            form.ShowDialog();
        }
    }
}
