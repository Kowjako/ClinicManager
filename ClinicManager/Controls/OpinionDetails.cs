using ClinicManager.DataAccessLayer;
using ClinicManager.Properties;
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

namespace ClinicManager.Controls
{
    public partial class OpinionDetails : Form
    {
        public OpinionDetails()
        {
            InitializeComponent();
        }

        private void star1_MouseEnter(object sender, EventArgs e)
        {
            for (int i = 1; i <= 5; i++)
            {
                ((PictureBox)(this.Controls.Find($"star{i}", true)[0])).Image = (Image)Resources.unstar;
            }
            var star = ((PictureBox)sender);
            for (int i = 1; i <= Int32.Parse(star.Name.Substring(4,1)); i++)
            {
                ((PictureBox)(this.Controls.Find($"star{i}", true)[0])).Image = (Image)Resources.star;
            }
        }
    }
}
