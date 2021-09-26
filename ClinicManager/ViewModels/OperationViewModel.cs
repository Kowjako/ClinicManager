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

        public void DeleteOperation(OperationRow op)
        {
            using (var context = new ClinicDataEntities())
            {
                var deleteReg = context.Operations.Find(op.Id);
                context.Operations.Remove(deleteReg);
                context.SaveChanges();
            }
        }

        public void EditOperation(OperationRow row)
        {
            var form = new OperationDetails(DetailsMode.Edit);
            using (var context = new ClinicDataEntities())
            {
                var op = context.Operations.Find(row.Id);
                form.BindingSource = new List<Operations> { op };
            }
            form.SetSpecificProperties();
            form.ShowDialog();
        }

        public List<OperationRow> Filter()
        {
            var parameters = new string[] { "Name", "Type", "IsAnesthesia", "Description", "ToolId", "DrugId" };
            var form = new FilterForm(parameters);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var sqlFilter = form.ReturnFilterString();
                var sqlQuery = $"SELECT * FROM Operations {sqlFilter}";
                using (var context = new ClinicDataEntities())
                {
                    try
                    {
                        var entites = context.Database.SqlQuery<Operations>(sqlQuery).ToList();
                        var entityRows = new List<OperationRow>();
                        foreach (var obj in entites)
                        {
                            entityRows.Add(context.OperationRow.First(p => p.Id == obj.Id));
                        }
                        return entityRows;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(null, "Niepoprawne zapytanie filtrowania", "Błąd");
                    }
                }
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

        public void SaveOperation(Operations op, Form1.DetailsMode Mode)
        {
            using (var context = new ClinicDataEntities())
            {
                if (Mode == DetailsMode.Add)
                {
                    context.Operations.Add(op);
                }
                else
                {
                    context.Entry(op).State = System.Data.Entity.EntityState.Modified;
                }
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show(null, "Nie udalo sie zapisac operacji", "Błąd!");
                }
            }
        }

        public void Sort(DataGridView grid, BindingSource list)
        {
            var form = new SortDetails();
            form.SetParameters(grid, list);
            form.ShowDialog();

            var newBs = new BindingSource();

            using (var context = new ClinicDataEntities())
            {
                var clinicList = context.OperationRow.SqlQuery($"SELECT Id, Nazwa, Typ, Znieczulenie, [Narzędzie] AS Narzędzie, Lek FROM OperationRow ORDER BY {list.Sort}").ToList();
                newBs.DataSource = typeof(ClinicRow);
                newBs.DataSource = clinicList;
                grid.DataSource = newBs;
            }
        }
    }
}
