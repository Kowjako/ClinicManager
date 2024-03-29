﻿using ClinicManager.Controls;
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
            var parameters = new string[] { "[Nazwa]", "[Ilosc dostepna]", "[Data produkcji]", "[Data waznosci]", "[Opis]" };
            var form = new FilterForm(parameters);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var sqlFilter = form.ReturnFilterString();
                var sqlQuery = $"SELECT Id, Nazwa,[Ilosc dostepna] as Ilosc_dostepna, [Data produkcji] AS Data_produkcji, [Data waznosci] AS Data_waznosci, Opis FROM ToolRow {sqlFilter}";
                using (var context = new ClinicDataEntities())
                {
                    try
                    {
                        var entites = context.Database.SqlQuery<ToolRow>(sqlQuery).ToList();
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

        public void Inventarize()
        {
            var dr = MessageBox.Show(null, "Po wykonaniu tej operacji zostana usuniete wszystkie narzedzia data waznosci ktorych juz minela", "Uwaga", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                using (var context = new ClinicDataEntities())
                {
                    var entites = context.Tools.Where(p => p.ExpireDate < DateTime.Now);
                    context.Tools.RemoveRange(entites);
                    context.SaveChanges();
                }
            }
            else
            {
                return;
            }
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
                catch (DbUpdateException)
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

            if (!string.IsNullOrEmpty(list.Sort))
            {
                using (var context = new ClinicDataEntities())
                {
                    var clinicList = context.ToolRow.SqlQuery($"SELECT Id, Nazwa,[Ilosc dostepna] as Ilosc_dostepna, [Data produkcji] AS Data_produkcji, [Data waznosci] AS Data_waznosci, Opis FROM ToolRow ORDER BY {list.Sort}").ToList();
                    newBs.DataSource = typeof(ClinicRow);
                    newBs.DataSource = clinicList;
                    grid.DataSource = newBs;
                }
            }
            else
            {
                MessageBox.Show(null, "Nalezy zaznaczyc po czym filtrowac", "Blad", MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
            
        }
    }
}
