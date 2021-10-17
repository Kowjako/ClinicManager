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
    public partial class AddUserControl : Form
    {
        public AddUserControl()
        {
            InitializeComponent();
            InitializeRoles();
        }

        private void InitializeRoles()
        {
            typeBox.Items.Add("Zarząd systemu");
            typeBox.Items.Add("Lekarz");
            typeBox.Items.Add("Producent");
            typeBox.Items.Add("Klient");

            typeBox.SelectedIndex = 0;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Resources.ConnectionString))
            {
                connection.Open();
                var loginParam = new SqlParameter("@login", loginBox.Text);
                var passParam = new SqlParameter("@pass", passBox.Text);
                var permParam = new SqlParameter("perm", typeBox.SelectedIndex);

                var sqlCommand = new SqlCommand("INSERT INTO Users (Login, Password,Permission) VALUES (@login, @pass, @perm)", connection);
                sqlCommand.Parameters.Add(loginParam);
                sqlCommand.Parameters.Add(passParam);
                sqlCommand.Parameters.Add(permParam);

                int row = sqlCommand.ExecuteNonQuery();
                if (row == 1)
                    MessageBox.Show(null, "Pomyslnie utworzono uzytkownika", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
            }

            this.Close();
        }
    }
}
