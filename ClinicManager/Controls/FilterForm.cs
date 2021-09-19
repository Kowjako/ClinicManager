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
    public partial class FilterForm : Form
    {
        public FilterForm(string[] parameters)
        {
            InitializeComponent();
            firstLogic.SelectedIndex = 0;
            secondLogic.SelectedIndex = 0;
            thirdLogic.SelectedIndex = 0;
            this.parameters.Items.AddRange(parameters);
        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public string ReturnFilterString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("WHERE ");
            if(!String.IsNullOrEmpty(firstCondition.Text))
            {
                sb.Append(firstCondition.Text + " ");
            }
            if(!String.IsNullOrEmpty(secondCondition.Text))
            {
                sb.Append(firstLogic.SelectedItem + " ");
                sb.Append(secondCondition.Text + " ");
            }
            if (!String.IsNullOrEmpty(thirdCondition.Text))
            {
                sb.Append(secondLogic.SelectedItem + " ");
                sb.Append(thirdCondition.Text + " ");
            }
            if (!String.IsNullOrEmpty(fourthCondition.Text))
            {
                sb.Append(thirdLogic.SelectedItem + " ");
                sb.Append(fourthCondition.Text + " ");
            }
            return sb.ToString();
        }
    }
}
