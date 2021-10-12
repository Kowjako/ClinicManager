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

            using (SqlConnection connection = new SqlConnection(Resources.ConnectionString))
            {
                connection.Open();
                var loginParam = new SqlParameter("@login", loginBox.Text);
                var passParam = new SqlParameter("@pass", passBox.Text);
                var sqlCommand = new SqlCommand("SELECT * FROM Users WHERE Login = @login AND Password = @pass", connection);
                sqlCommand.Parameters.Add(loginParam);
                sqlCommand.Parameters.Add(passParam);

                using(var reader = sqlCommand.ExecuteReader())
                {
                    if(reader.HasRows) isLoginSuccess = true;
                    reader.Close();
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
                form.ShowDialog();
                this.Close();
            }
        }
    }
}
