using ClinicManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHospitalAdd_Click(object sender, EventArgs e)
        {
            var form = new ClinicDetails();
            form.ShowDialog();
        }

        private void btnHospitalEdit_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDoctorsAdd_Click(object sender, EventArgs e)
        {
            var form = new DoctorDetails();
            form.ShowDialog();
        }

        private void btnClientsAdd_Click(object sender, EventArgs e)
        {
            var form = new PatientDetails();
            form.ShowDialog();
        }
    }
}
