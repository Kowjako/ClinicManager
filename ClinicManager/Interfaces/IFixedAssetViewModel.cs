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
    interface IFixedAssetViewModel
    {
        void SaveFixedAsset(Tools tool, DetailsMode mode);
        void DeleteFixedAsset(ToolRow tool);
        BindingSource RefreshFixedAssets();
        List<ToolRow> Filter();
        void EditFixedAsset(ToolRow row);
        void AddFixedAsset();
        void Sort(DataGridView grid, BindingSource list);
        void Inventarize();
    }
}
