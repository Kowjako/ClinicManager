using ClinicManager.Controls;
using ClinicManager.DataAccessLayer;
using ClinicManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test;
using static Test.Form1;

namespace ClinicManager.ViewModels
{
    public class ClinicViewModel : IClinicDetailsViewModel
    {
        public void AddClinic()
        {
            var form = new ClinicDetails(DetailsMode.Add);
            form.ShowDialog();
        }

        public void AddOpinion()
        {
            var form = new OpinionDetails();
            form.ShowDialog();
        }

        public void EditClinic(ClinicRow row)
        {
            var form = new ClinicDetails(DetailsMode.Edit);
            form.ShowDialog();
        }

        public List<ClinicRow> Filter()
        {
            var parameters = new string[] { "[Nazwa]", "[Data otwarcia]", "[Prywatna]", "[Ocena]", "[Lokalizacja]", "[Kierownik]" };
            var form = new FilterForm(parameters);
            if(form.ShowDialog() == DialogResult.OK)
            {

            }
            return null;
        }


        public void MakeOrder()
        {
            var form = new OrderDetails(DetailsMode.Add);
            form.ShowDialog();
        }

        public void MakeOrderTool()
        {
            var form = new OrderToolDetails(DetailsMode.Add);
            form.ShowDialog();
        }

        public BindingSource RefreshClinics()
        {
            var bsMain = new BindingSource();
            using (var context = new ClinicDataEntities())
            {
                var clinicList = context.ClinicRow.ToList();
                bsMain.DataSource = typeof(ClinicRow);
                bsMain.DataSource = clinicList;
                return bsMain;
            }
        }

       
        public void SaveOrder(Orders order)
        {
            using(var context = new ClinicDataEntities())
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }

        public void SaveOrderTools(OrdersTools order)
        {
            using(var context = new ClinicDataEntities())
            {
                context.OrdersTools.Add(order);
                context.SaveChanges();
            }
        }

        public void ShowHierarchy(ClinicRow row)
        {
            var form = new HierarchyControl();
            form.ShowDialog();
        }

        public void Sort(DataGridView grid, BindingSource list)
        {
            var form = new SortDetails();
            form.ShowDialog();
        }

    }
}
