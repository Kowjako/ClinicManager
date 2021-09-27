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

        public void DeleteFixedAsset(ToolRow tool)
        {
            using (var context = new ClinicDataEntities())
            {
                var deleteTool = context.Tools.Find(tool.Id);
                context.Tools.Remove(deleteTool);
                context.SaveChanges();
            }
        }

        public void EditFixedAsset(ToolRow row)
        {
            var form = new FixedAsset(DetailsMode.Edit);
            using (var context = new ClinicDataEntities())
            {
                var tool = context.Tools.Find(row.Id);
                form.BindingSource = new List<Tools> { tool };
            }
            form.ShowDialog();
        }

        public List<ToolRow> Filter()
        {
            var parameters = new string[] { "Name", "AvailableCount", "ProductionDate", "ExpireDate", "Description" };
            var form = new FilterForm(parameters);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var sqlFilter = form.ReturnFilterString();
                var sqlQuery = $"SELECT * FROM Tools {sqlFilter}";
                using (var context = new ClinicDataEntities())
                {
                    try
                    {
                        var entites = context.Database.SqlQuery<Tools>(sqlQuery).ToList();
                        var entityRows = new List<ToolRow>();
                        foreach (var obj in entites)
                        {
                            entityRows.Add(context.ToolRow.First(p => p.Id == obj.Id));
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

        public void SaveFixedAsset(Tools tool, Form1.DetailsMode Mode)
        {
            using (var context = new ClinicDataEntities())
            {
                if (Mode == DetailsMode.Add)
                {
                    tool.ProductionDate = DateTime.Parse(tool.ProductionDate.ToShortDateString());
                    tool.ExpireDate = DateTime.Parse(tool.ExpireDate.ToShortDateString());
                    context.Tools.Add(tool);
                }
                else
                {
                    context.Entry(tool).State = System.Data.Entity.EntityState.Modified;
                }
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show(null, "Nie udalo sie zapisac srodka trwalego", "Błąd!");
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
                var clinicList = context.ToolRow.SqlQuery($"SELECT Id, Nazwa,[Ilosc dostepna] as Ilosc_dostepna, [Data produkcji] AS Data_produkcji, [Data waznosci] AS Data_waznosci, Opis FROM ToolRow ORDER BY {list.Sort}").ToList();
                newBs.DataSource = typeof(ClinicRow);
                newBs.DataSource = clinicList;
                grid.DataSource = newBs;
            }
        }
    }
}
