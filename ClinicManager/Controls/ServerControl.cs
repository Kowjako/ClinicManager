using ClinicManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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
            IList<XmlElement> connectionStrings = new List<XmlElement>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"../../ClinicManager.config");

            XmlElement xRoot = xDoc.DocumentElement;

            foreach(XmlElement elem in xRoot)
            {
                connectionStrings.Add(elem);
            }

            foreach(var item in connectionStrings)
            {
                MessageBox.Show(item.Attributes.GetNamedItem("value").Value);
                int idx = item.Attributes.GetNamedItem("value").Value.IndexOf("data source=");
                int lastIdx = item.Attributes.GetNamedItem("value").Value.IndexOf(';', idx);
                string newCS = item.Attributes.GetNamedItem("value").Value.Remove(idx, lastIdx - idx);
                newCS = newCS.Insert(idx, "data source=" + tbServer.Text);
                item.Attributes.GetNamedItem("value").Value = newCS;
            }

            xRoot.RemoveAll();
            xRoot.AppendChild(connectionStrings[0]);
            xRoot.AppendChild(connectionStrings[1]);
            xDoc.Save(@"../../ClinicManager.config");
        }
    }
}
