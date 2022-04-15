using ClinicManager.Controls;
using ClinicManager.DataAccessLayer;
using ClinicManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.Windows.Forms;
using Test;
using static Test.Form1;
using System.Data;
using ClinicManager.Properties;

namespace ClinicManager.ViewModels
{
    public class CostViewModel : ICostDetailsViewModel
    {
        public void AddCost()
        {
            var form = new CostDetails(DetailsMode.Add);
            form.ShowDialog();
        }

        public void AddCost(ProducentRow producent)
        {
            var form = new CostDetails(DetailsMode.Add);
            form.ShowDialog();
        }

        public void CheckCurrencyFormat(DataGridView grid, bool isCheapest = false, bool isFastest = false)
        {
            if (!isCheapest && !isFastest)
            {
                grid.Columns[2].DefaultCellStyle.Format = "c";
                grid.Columns[3].DefaultCellStyle.Format = "0 dni";
            }
            else if(isCheapest)
            {
                grid.Columns[1].DefaultCellStyle.Format = "c";
            }
            else if(isFastest)
            {
                grid.Columns[1].DefaultCellStyle.Format = "0 dni";
            }
        }


        public void EditCost(CostRow row)
        {
            var form = new CostDetails(DetailsMode.Edit);
            form.ShowDialog();
        }

        public List<CostRow> Filter()
        {
            var parameters = new string[] { "[Nazwa leku]", "[Cena]", "[Czas dostawy dni]", "[Producent]" };
            var form = new FilterForm(parameters);
            if (form.ShowDialog() == DialogResult.OK)
            {
            }
            return null;
        }

        public BindingSource RefreshCosts()
        {
            var bsMain = new BindingSource();
            using (var context = new ClinicDataEntities())
            {
                var costList = context.CostRow.ToList();
                bsMain.DataSource = typeof(CostRow);
                bsMain.DataSource = costList;
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
