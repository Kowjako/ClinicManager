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
    public partial class ScriptForm : Form
    {
        public ScriptForm()
        {
            InitializeComponent();
        }

        public string ScriptText
        {
            set { dbMainScript.Text = value; }
        }

        public Color HeaderColor
        {
            set { headerLbl.ForeColor = value; }
        }

        public string HeaderText
        {
            set { headerLbl.Text = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string FormHeader
        {
            set { this.Text = value; }
        }
    }
}
