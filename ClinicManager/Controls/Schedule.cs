using ClinicManager.DataAccessLayer;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (startDate.Value.Date >= endDate.Value.Date)
            {
                MessageBox.Show(null, "Data poczatkowa musi byc mniejsza niz koncowa", "Błąd");
                return;
            }
            scheduleChart.Visible = true;

            List<Registrations> regs = null;
            using (var context = new ClinicDataEntities())
            {
                regs = context.Registrations.ToList();
            }
            scheduleChart.Series["SeriesData"].Points.AddXY("Poniedziałek",
                                                            regs.Where(p => ((p.Date.Date <= endDate.Value && p.Date.Date >= startDate.Value)
                                                            && p.Date.Date.DayOfWeek == DayOfWeek.Monday)).Count());
            scheduleChart.Series["SeriesData"].Points[0].Color = Color.Red;
            scheduleChart.Series["SeriesData"].Points[0].Label = Convert.ToString(scheduleChart.Series["SeriesData"].Points[0].YValues.First());
            scheduleChart.Series["SeriesData"].Points.AddXY("Wtorek",
                                                            regs.Where(p => ((p.Date.Date <= endDate.Value && p.Date.Date >= startDate.Value)
                                                            && p.Date.Date.DayOfWeek == DayOfWeek.Tuesday)).Count());
            scheduleChart.Series["SeriesData"].Points[1].Color = Color.Blue;
            scheduleChart.Series["SeriesData"].Points[1].Label = Convert.ToString(scheduleChart.Series["SeriesData"].Points[1].YValues.First());
            scheduleChart.Series["SeriesData"].Points.AddXY("Środa",
                                                            regs.Where(p => ((p.Date.Date <= endDate.Value && p.Date.Date >= startDate.Value)
                                                            && p.Date.Date.DayOfWeek == DayOfWeek.Wednesday)).Count());
            scheduleChart.Series["SeriesData"].Points[2].Color = Color.Green;
            scheduleChart.Series["SeriesData"].Points[2].Label = Convert.ToString(scheduleChart.Series["SeriesData"].Points[2].YValues.First());
            scheduleChart.Series["SeriesData"].Points.AddXY("Czwartek",
                                                            regs.Where(p => ((p.Date.Date <= endDate.Value && p.Date.Date >= startDate.Value)
                                                            && p.Date.Date.DayOfWeek == DayOfWeek.Thursday)).Count());
            scheduleChart.Series["SeriesData"].Points[3].Color = Color.Orange;
            scheduleChart.Series["SeriesData"].Points[3].Label = Convert.ToString(scheduleChart.Series["SeriesData"].Points[3].YValues.First());
            scheduleChart.Series["SeriesData"].Points.AddXY("Piątek",
                                                            regs.Where(p => ((p.Date.Date <= endDate.Value && p.Date.Date >= startDate.Value)
                                                            && p.Date.Date.DayOfWeek == DayOfWeek.Friday)).Count());
            scheduleChart.Series["SeriesData"].Points[4].Color = Color.Purple;
            scheduleChart.Series["SeriesData"].Points[4].Label = Convert.ToString(scheduleChart.Series["SeriesData"].Points[4].YValues.First());
            scheduleChart.Series["SeriesData"].Points.AddXY("Sobota",
                                                            regs.Where(p => ((p.Date.Date <= endDate.Value && p.Date.Date >= startDate.Value)
                                                            && p.Date.Date.DayOfWeek == DayOfWeek.Saturday)).Count());
            scheduleChart.Series["SeriesData"].Points[5].Color = Color.Gray;
            scheduleChart.Series["SeriesData"].Points[5].Label = Convert.ToString(scheduleChart.Series["SeriesData"].Points[5].YValues.First());
        }
    }
}
