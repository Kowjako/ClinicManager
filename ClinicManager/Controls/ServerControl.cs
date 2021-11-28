using ClinicManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManager.Controls
{
    public partial class ServerControl : Form
    {
        public ServerControl()
        {
            InitializeComponent();
            this.pbStatus.Image = (Image)Resources.fail;
        }

        private void btnCheckConnection_Click(object sender, EventArgs e)
        {
            var server = tbServer.Text;
            using (SqlConnection connection = new SqlConnection($@"Server={server};Integrated Security=SSPI"))
            {
                try
                {

                    connection.Open();
                    pbStatus.Image = (Image)Resources.ok;
                }
                catch
                {
                    pbStatus.Image = (Image)Resources.fail;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
