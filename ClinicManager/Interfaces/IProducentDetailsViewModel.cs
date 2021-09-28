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
    interface IProducentDetailsViewModel
    {
        void SaveProducent(Producents prod, Data producentData, DetailsMode mode);
        void DeleteProducent(ProducentRow prod);
        BindingSource RefreshProducents();
        List<ProducentRow> Filter();
        void EditProducent(ProducentRow row);
        void AddProducent();
        void ShowContact(ProducentRow row);
        void Sort(DataGridView grid, BindingSource list);
        BindingSource GetRelatedOrders(ProducentRow row);
    }
}
