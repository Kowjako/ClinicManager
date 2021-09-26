using ClinicManager.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManager.Controls
{
    public partial class SortDetails : Form
    {
        private DataGridView _gridView;
        private BindingSource list;

        public SortDetails()
        {
            InitializeComponent();
        }

        public void SetParameters(DataGridView gv, BindingSource source)
        {
            _gridView = gv;
            list = source;
            foreach(var column in gv.Columns)
            {
                parametersList.Items.Add((column as DataGridViewColumn).HeaderText);
            }
        }

        private void PrepareParameters(out string[] parameters)
        {
            string[] paramArr = new string[] { };
            foreach (var param in parametersList.CheckedItems)
            {
                Array.Resize(ref paramArr, paramArr.Length + 1);
                paramArr[paramArr.Length - 1] = param as string;
            }
            parameters = paramArr;
        }

        private void PrepareFilterDefinition(string[] param, out string filter, SortOrder sort)
        {
            StringBuilder def = new StringBuilder();
            foreach (var singleParam in param)
            {
                if (sort == SortOrder.Ascending)
                {
                    def.Append(singleParam + " " + "ASC,");
                }
                else
                {
                    def.Append(singleParam + " " + "DESC,");
                }
            }
            def.Remove(def.Length - 1, 1);
            filter = def.ToString();
        }

        private void ascSort_Click(object sender, EventArgs e)
        {
            string[] sortParams = null;
            string filterDefinition = null;
            PrepareParameters(out sortParams);
            PrepareFilterDefinition(sortParams, out filterDefinition, SortOrder.Ascending);

            list.Sort = filterDefinition;
            this.Close();
        }

        private void descSort_Click(object sender, EventArgs e)
        {
            string[] sortParams = null;
            string filterDefinition = null;
            PrepareParameters(out sortParams);
            PrepareFilterDefinition(sortParams, out filterDefinition, SortOrder.Descending);

            list.Sort = filterDefinition;
            this.Close();
        }
    }
}
