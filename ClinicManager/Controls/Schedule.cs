using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManager.Controls
{
    public partial class Schedule : Form
    {
        public Schedule()
        {
            InitializeComponent();
            startDate.Value = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            endDate.Value = startDate.Value.AddDays(7);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (startDate.Value.Date.DayOfWeek != DayOfWeek.Monday)
            {
                MessageBox.Show(null, "Nalezy wybrac poniedzialek aby wyswietlic rozklad na tydzien!", "Blad");
                startDate.Value = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
                endDate.Value = startDate.Value.AddDays(7);
            }
            else
            {
                endDate.Value = startDate.Value.AddDays(7);
            }
        }
    }
}
