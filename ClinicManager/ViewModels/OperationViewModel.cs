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
    public class OperationViewModel : IOperationDetailsViewModel
    {
        public void AddOperation()
        {
            var form = new OperationDetails(DetailsMode.Add);
            form.ShowDialog();
        }

        public void AddOperationType()
        {
            var form = new UnitDetails(AddValues.Operation);
            form.ShowDialog();
        }


        public void EditOperation(OperationRow row)
        {
            var form = new OperationDetails(DetailsMode.Edit);
            form.ShowDialog();
        }

        public List<OperationRow> Filter()
        {
            var parameters = new string[] { "[Nazwa]", "[Typ]", "[Znieczulenie]", "[Narzedzie]", "[Lek]"};
            var form = new FilterForm(parameters);
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
            return null;
        }

        public BindingSource RefreshOperations()
        {
            var bsMain = new BindingSource();
            using (var context = new ClinicDataEntities())
            {
                var opList = context.OperationRow.ToList();
                bsMain.DataSource = typeof(OperationRow);
                bsMain.DataSource = opList;
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
