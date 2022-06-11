using ClinicManager.DataAccessLayer;
using ClinicManager.Properties;
using ClinicManager.ViewModels;
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

namespace ClinicManager.Controls
{
    public enum Role
    {
        Admin = 0,
        Doctor = 1,
        Consumer = 2,
        Client = 3
    }

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

            bsData.DataSource = new StaticDictionaries().DataList.Value.Values.ToList();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.ConnectionStringInstance.ConnectionString))
            {
                connection.Open();
                var loginParam = new SqlParameter("@login", loginBox.Text);
                var passParam = new SqlParameter("@pass", passBox.Text);
                var permParam = new SqlParameter("@perm", typeBox.SelectedIndex);
                var dataParam = new SqlParameter("@data", (dataBox.SelectedItem as Data).Id);

                var sqlCommand = new SqlCommand("INSERT INTO Users (Login, Password,Permission,DataId) VALUES (@login, @pass, @perm, @data)", connection);
                sqlCommand.Parameters.Add(loginParam);
                sqlCommand.Parameters.Add(passParam);
                sqlCommand.Parameters.Add(permParam);
                sqlCommand.Parameters.Add(dataParam);

                int row = sqlCommand.ExecuteNonQuery();
                if (row == 1)
                    MessageBox.Show(null, "Pomyslnie utworzono uzytkownika", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
            }

            this.Close();
        }
    }
}
