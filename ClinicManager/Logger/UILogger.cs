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
    public partial class UILogger : Form
    {
        private static UILoggerViewModel ViewModel;
        public UILogger()
        {
            InitializeComponent();
            ViewModel = new UILoggerViewModel();
        }

        public void LogMessage(string message, MessageSeverity severity)
        {
            ViewModel.CreateMessage(message, severity);
            mainPanel.Controls.Add(ViewModel.CreateUIControl());
            this.Invalidate();
        }

        private void mainPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            mainPanel.ScrollControlIntoView(e.Control);
        }
    }
}
