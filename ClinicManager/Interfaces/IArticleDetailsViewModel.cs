using ClinicManager.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Test.Form1;

namespace ClinicManager.Interfaces
{
    interface IArticleDetailsViewModel
    {
        void SaveArticle(Drugs drug, DetailsMode mode);
        void DeleteArticle(DrugRow drug);
        BindingSource RefreshArticles();
        List<DrugRow> Filter();
        void EditArticle(DrugRow row);
        void AddArticle();
        void AddUnit();
    }
}
