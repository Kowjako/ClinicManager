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
            form.SetSpecificProducent(producent);
            form.ShowDialog();
        }

        public void CheckCurrencyFormat(DataGridView grid)
        {
            grid.Columns[2].DefaultCellStyle.Format = "c";
            grid.Columns[3].DefaultCellStyle.Format = "0 dni";
        }

        public void DeleteCost(CostRow cost)
        {
            using (var context = new ClinicDataEntities())
            {
                var deleteCost = context.Costs.Find(cost.Id);
                context.Costs.Remove(deleteCost);
                context.SaveChanges();
            }
        }

        public void EditCost(CostRow row)
        {
            var form = new CostDetails(DetailsMode.Edit);
            using (var context = new ClinicDataEntities())
            {
                var costs = context.Costs.Find(row.Id);
                form.BindingSource = new List<Costs> { costs };
            }
            form.SetSpecificProperties();
            form.ShowDialog();
        }

        public List<CostRow> Filter()
        {
            var parameters = new string[] { "[Nazwa leku]", "[Cena]", "[Czas dostawy dni]", "[Producent]" };
            var form = new FilterForm(parameters);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var sqlFilter = form.ReturnFilterString();
                var sqlQuery = $"SELECT Id, [Nazwa leku] AS Nazwa_leku, Cena" +
                               $",[Czas dostawy dni] AS Czas_dostawy_dni, Producent FROM CostRow {sqlFilter}";
                using (var context = new ClinicDataEntities())
                {
                    try
                    {
                        var entites = context.Database.SqlQuery<CostRow>(sqlQuery).ToList();
                        return entites;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(null, "Niepoprawne zapytanie filtrowania", "Błąd");
                    }
                }
            }
            return null;
        }

        public BindingSource GetCheapest()
        {
            var bsMain = new BindingSource();
            var sqlQuery = $"SELECT [Nazwa leku], MIN([Cena]) AS [Minimalna cena] " +
                           $"FROM CostRow " +
                           $"GROUP BY [Nazwa leku] " +
                           $"ORDER BY [Nazwa leku]";

            using (SqlConnection connection = new SqlConnection(Resources.ConnectionString))
            {
                connection.Open();
                var adapter = new SqlDataAdapter(sqlQuery, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                bsMain.DataSource = ds.Tables[0];
                connection.Close();
            }

            return bsMain;              
        }



        public BindingSource GetFastest()
        {
            var bsMain = new BindingSource();
            var sqlQuery = $"SELECT [Nazwa leku], MIN([Czas dostawy dni]) AS [Czas dostawy] " +
                           $"FROM CostRow " +
                           $"GROUP BY [Nazwa leku] " +
                           $"ORDER BY [Nazwa leku]";

            using (SqlConnection connection = new SqlConnection(Resources.ConnectionString))
            {
                connection.Open();
                var adapter = new SqlDataAdapter(sqlQuery, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                bsMain.DataSource = ds.Tables[0];
                connection.Close();
            }

            return bsMain;
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

        public void SaveCost(Costs cost, Form1.DetailsMode Mode)
        {
            using (var context = new ClinicDataEntities())
            {
                if (Mode == DetailsMode.Add)
                {
                    context.Costs.Add(cost);
                }
                else
                {
                    context.Entry(cost).State = System.Data.Entity.EntityState.Modified;
                }
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    MessageBox.Show(null, "Błąd podczas zapisywania ", "Błąd!");
                }
            }
        }

        public void Sort(DataGridView grid, BindingSource list)
        {
            var form = new SortDetails();
            form.SetParameters(grid, list);
            form.ShowDialog();

            var newBs = new BindingSource();

            if (!string.IsNullOrEmpty(list.Sort))
            {
                using (var context = new ClinicDataEntities())
                {
                    var clinicList = context.CostRow.SqlQuery($"SELECT Id, [Nazwa leku] AS Nazwa_leku, Cena" +
                                                              $",[Czas dostawy dni] AS Czas_dostawy_dni, Producent FROM CostRow ORDER BY {list.Sort}").ToList();
                    newBs.DataSource = typeof(CostRow);
                    newBs.DataSource = clinicList;
                    grid.DataSource = newBs;
                }
            }
            else
            {
                MessageBox.Show(null, "Nalezy zaznaczyc po czym filtrowac", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
