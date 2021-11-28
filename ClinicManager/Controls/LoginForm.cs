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
using Test;

namespace ClinicManager.Controls
{
    public partial class LoginForm : Form
    {
        private Point lastpoint;
        private bool isLoginSuccess = false;
        private object permission;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void closeBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                connection.Open();
                var loginParam = new SqlParameter("@login", loginBox.Text);
                var passParam = new SqlParameter("@pass", passwordBox.Text);
                var sqlCommand = new SqlCommand("SELECT Id, Login, Password, Permission FROM Users WHERE Login = @login AND Password = @pass", connection);
                sqlCommand.Parameters.Add(loginParam);
                sqlCommand.Parameters.Add(passParam);

                using(var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows && reader.Read())
                    {
                        isLoginSuccess = true;
                        permission = reader.GetValue(3);
                    }
                }
                connection.Close();
            }

            CheckState();
        }

        private void CheckState()
        {
            if(isLoginSuccess)
            {
                Hide();
                var form = new Form1();
                form.SetPermissions(permission as byte?);
                form.ShowDialog();                
                this.Close();
            }
            else
            {
                MessageBox.Show(null, "Nie ma takiego uzytkownika", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
