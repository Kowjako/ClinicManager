using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicManager.DataAccessLayer;
using ClinicManager.Interfaces;
using ClinicManager.ViewModels;
using static Test.Form1;

namespace ClinicManager
{
    public partial class ClinicDetails : Form
    {
        public ClinicDetails(DetailsMode mode)
        {
            InitializeComponent();
        }
    }
}
