using ClinicManager.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Test.Form1;

namespace ClinicManager
{
    public partial class VisitDetails : Form
    {
        private StaticDictionaries Dictionaries;
        private DetailsMode Mode;
        private IVisitDetailsViewModel VisitViewModel;

        public VisitDetails(DetailsMode mode)
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
