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

        public void EditArticle(DrugRow row)
        {
            var form = new ArticleDetails(DetailsMode.Edit);
            form.ShowDialog();
        }

        public List<DrugRow> Filter()
        {
            
            var form = new FilterForm(new[] { string.Empty });
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
            return null;
        }

        public void Inventarize()
        {

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

        }

        public void Sort(DataGridView grid, BindingSource list)
        {
            var form = new SortDetails();
            form.ShowDialog();
        }
    }
}
