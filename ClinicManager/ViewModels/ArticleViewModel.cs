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
    public class ArticleViewModel : IArticleDetailsViewModel
    {
        public void AddArticle()
        {
            var form = new ArticleDetails(DetailsMode.Add);
            form.ShowDialog();
        }

        public void AddUnit()
        {
            var form = new UnitDetails(AddValues.Unit);
            form.ShowDialog();
        }

        public void DeleteArticle(DrugRow drug)
        {
            using (var context = new ClinicDataEntities())
            {
                var deleteDrug = context.Drugs.Find(drug.Id);
                context.Drugs.Remove(deleteDrug);
                context.SaveChanges();
            }
        }

        public void EditArticle(DrugRow row)
        {
            var form = new ArticleDetails(DetailsMode.Edit);
            using (var context = new ClinicDataEntities())
            {
                var article = context.Drugs.Find(row.Id);
                form.BindingSource = new List<Drugs> { article };
            }
            form.SetSpecificProperties();
            form.ShowDialog();
        }

        public List<DrugRow> Filter()
        {
            var parameters = new string[] { "Name", "Percentage", "ProductionDate", "ExpireDate", "Unit", "AvailableAmount", "IsPsychotropic" };
            var form = new FilterForm(parameters);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var sqlFilter = form.ReturnFilterString();
                var sqlQuery = $"SELECT * FROM Drugs {sqlFilter}";
                using (var context = new ClinicDataEntities())
                {
                    try
                    {
                        var entites = context.Database.SqlQuery<Drugs>(sqlQuery).ToList();
                        var entityRows = new List<DrugRow>();
                        foreach (var obj in entites)
                        {
                            entityRows.Add(context.DrugRow.First(p => p.Id == obj.Id));
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

        public BindingSource RefreshArticles()
        {
            var bsMain = new BindingSource();
            using (var context = new ClinicDataEntities())
            {
                var articleList = context.DrugRow.ToList();
                bsMain.DataSource = typeof(DrugRow);
                bsMain.DataSource = articleList;
                return bsMain;
            }
        }

        public void SaveArticle(Drugs drug, Form1.DetailsMode Mode)
        {
            using (var context = new ClinicDataEntities())
            {
                if (Mode == DetailsMode.Add)
                {
                    drug.ProductionDate = DateTime.Parse(drug.ProductionDate.ToShortDateString());
                    drug.ExpireDate = DateTime.Parse(drug.ExpireDate.ToShortDateString());
                    context.Drugs.Add(drug);
                }
                else
                {
                    context.Entry(drug).State = System.Data.Entity.EntityState.Modified;
                }
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show(null, "Nie udalo sie zapisac artykulu", "Błąd!");
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
                var clinicList = context.DrugRow.SqlQuery($"SELECT Id, Nazwa, Dawka, [Data produkcji] AS Data_produkcji, [Data waznosci] AS Data_waznosci, Psychotropowe, " +
                                                          $"[Ilosc dostępna] AS Ilosc_dostepna, Jednostka FROM DrugRow ORDER BY {list.Sort}").ToList();
                newBs.DataSource = typeof(ClinicRow);
                newBs.DataSource = clinicList;
                grid.DataSource = newBs;
            }
        }
    }
}
