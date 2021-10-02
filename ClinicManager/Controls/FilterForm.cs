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
            this.params1.Items.AddRange(parameters);
            this.params2.Items.AddRange(parameters);
            this.params3.Items.AddRange(parameters);
            this.params4.Items.AddRange(parameters);
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
                sb.Append(params1.SelectedItem + " " + firstCondition.Text + " ");
            }
            if(!String.IsNullOrEmpty(secondCondition.Text))
            {
                sb.Append(and1.Checked ? "AND " : "OR ");
                sb.Append(params2.SelectedItem + " " + secondCondition.Text + " ");
            }
            if (!String.IsNullOrEmpty(thirdCondition.Text))
            {
                sb.Append(and2.Checked ? "AND " : "OR ");
                sb.Append(params3.SelectedItem + " " + thirdCondition.Text + " "); 
            }
            if (!String.IsNullOrEmpty(fourthCondition.Text))
            {
                sb.Append(and3.Checked ? "AND " : "OR ");
                sb.Append(params4.SelectedItem + " ");
            }
            return sb.ToString();
        }
    }
}
