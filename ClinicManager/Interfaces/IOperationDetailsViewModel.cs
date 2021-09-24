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
    interface IOperationDetailsViewModel
    {
        void SaveOperation(Operations op, DetailsMode mode);
        void DeleteOperation(OperationRow op);
        BindingSource RefreshOperations();
        List<OperationRow> Filter();
        void EditOperation(OperationRow row);
        void AddOperation();
        void AddOperationType();
    }
}
