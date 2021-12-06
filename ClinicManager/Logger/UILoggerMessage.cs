using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManager.Logger
{
    public partial class UILoggerMessage : UserControl
    {
        public Image MessageSeverity
        {
            set => pbSeverity.Image = value;
        }

        public string Message
        {
            set => lblMessage.Text = value;
        }

        public UILoggerMessage()
        {
            InitializeComponent();
        }
    }
}
