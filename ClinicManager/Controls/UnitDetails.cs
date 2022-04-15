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

namespace ClinicManager.Controls
{
    public partial class UnitDetails : Form
    {
        private AddValues Mode;
        public UnitDetails(AddValues mode)
        {
            InitializeComponent();
        }
    }
}
