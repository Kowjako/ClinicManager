using ClinicManager.Properties;
using ClinicManager.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private void bCreateDatabase_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.ConnectionStringInstance.ConnectionString))
            {
                try
                {
                    
                    StringBuilder sb = new StringBuilder();
                    connection.Open();
                    using (StreamReader sr = new StreamReader(@"../../SQL/ClinicBase.sql"))
                    {
                        sb.Append(sr.ReadToEnd());
                    }

                    var scripts = sb.ToString().Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries );
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = connection;
                        foreach (var script in scripts)
                        {
                            cmd.CommandText = script;
                            cmd.ExecuteNonQuery();
                        } 
                    }

                    sb.Clear();
                    using (StreamReader sr = new StreamReader(@"../../SQL/ClinicData.sql"))
                    {
                        sb.Append(sr.ReadToEnd());
                    }

                    scripts = sb.ToString().Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = connection;
                        foreach (var script in scripts)
                        {
                            cmd.CommandText = script;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    sb.Clear();
                    using (StreamReader sr = new StreamReader(@"../../SQL/ClinicTrigger.sql"))
                    {
                        sb.Append(sr.ReadToEnd());
                    }

                    scripts = sb.ToString().Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = connection;
                        foreach (var script in scripts)
                        {
                            cmd.CommandText = script;
                            cmd.ExecuteNonQuery();
                        }
                    }


                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
