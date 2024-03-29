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
    public class ProducentViewModel : IProducentDetailsViewModel
    {
        public void AddProducent()
        {
            var form = new ProducentDetails(DetailsMode.Add);
            form.ShowDialog();
        }

        public void DeleteProducent(ProducentRow prod)
        {
            using (var context = new ClinicDataEntities())
            {
                var deleteProd = context.Producents.Find(prod.Id);
                var deleteData = context.Data.Find(deleteProd.DataId); /* Usuwanie kaskadowe - usuniecie danych osobowych => usuniecie producenta */
                context.Data.Remove(deleteData);
                context.SaveChanges();
            }
        }

        public void EditProducent(ProducentRow row)
        {
            var form = new ProducentDetails(DetailsMode.Edit);
            using (var context = new ClinicDataEntities())
            {
                var prod = context.Producents.Find(row.Id);
                form.BindingSource = new List<Producents> { prod };
            }
            form.SetSpecificProperties();
            form.ShowDialog();
        }

        public List<ProducentRow> Filter()
        {
            var parameters = new string[] { "[Nazwa producenta]", "[Email]", "[Siedziba firmy]", "[Kierownik]" };
            var form = new FilterForm(parameters);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var sqlFilter = form.ReturnFilterString();
                var sqlQuery = $"SELECT Id, [Nazwa producenta] AS Nazwa_producenta, Email, [Siedziba firmy] AS Siedziba_firmy" +
                               $",Kierownik FROM ProducentRow {sqlFilter}";
                using (var context = new ClinicDataEntities())
                {
                    try
                    {
                        var entites = context.Database.SqlQuery<ProducentRow>(sqlQuery).ToList();
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

        public BindingSource GetRelatedOrders(ProducentRow row)
        {
            var bsMain = new BindingSource();
            using (var context = new ClinicDataEntities())
            {
                var orderList = context.OrderRow.Where(p => p.Producent == row.Nazwa_producenta).ToList();
                bsMain.DataSource = typeof(OrderRow);
                bsMain.DataSource = orderList;
                return bsMain;
            }
        }

        public BindingSource GetRelatedOrdersTools(ProducentRow row)
        {
            var bs = new BindingSource();
            using(var context = new ClinicDataEntities())
            {
                var orderToolsList = context.OrderToolRow.Where(p => p.Producent == row.Nazwa_producenta).ToList();
                bs.DataSource = typeof(OrderToolRow);
                bs.DataSource = orderToolsList;
                return bs;
            }
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

        public void SaveProducent(Producents prod, Data producentData, Form1.DetailsMode Mode)
        {
            using (var context = new ClinicDataEntities())
            {
                if (Mode == DetailsMode.Add)
                {
                    producentData.BirthDate = DateTime.Parse(producentData.BirthDate.ToShortDateString());
                    prod.OpenDate = DateTime.Parse(prod.OpenDate.ToShortDateString());
                    context.Data.Add(producentData);
                    context.SaveChanges();  /* zapisywanie danych osobowych */

                    prod.DataId = producentData.Id;  /* przypisanie danych osobowych do pracownika - ustawianie klucza obcego */
                    context.Producents.Add(prod);
                }
                else
                {
                    context.Entry(producentData).State = System.Data.Entity.EntityState.Modified;
                    context.Entry(prod).State = System.Data.Entity.EntityState.Modified;
                }
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    MessageBox.Show(null, "Błąd podczas zapisywania producenta", "Blad");
                }
            }
        }

        public void ShowContact(ProducentRow row)
        {
            Producents producent = null;
            using (var context = new ClinicDataEntities())
            {
                producent = context.Producents.Find(row.Id);
            }
            var form = new ContactDetails();
            form.InitializeData<Producents>(producent);
            form.ShowDialog();
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
                    var clinicList = context.ProducentRow.SqlQuery($"SELECT Id, [Nazwa producenta] AS Nazwa_producenta, Email, [Siedziba firmy] AS Siedziba_firmy" +
                                                              $",Kierownik FROM ProducentRow ORDER BY {list.Sort}").ToList();
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
