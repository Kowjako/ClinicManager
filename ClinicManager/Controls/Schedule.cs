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
        private readonly StaticDictionaries Dictionaries;
        public Schedule()
        {
            InitializeComponent();
            Dictionaries = new StaticDictionaries();
        }

        public void SetSpecificProperties()
        {
            var clinicsList = new List<ClinicRow>();
            foreach (var clinic in Dictionaries.ClinicList.Value)
            {
                clinicsList.Add(clinic.Value);
            }
            bsClinics.DataSource = clinicsList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (startDate.Value.Date >= endDate.Value.Date)
            {
                MessageBox.Show(null, "Data poczatkowa musi byc mniejsza niz koncowa", "Błąd");
                return;
            }
            Height = 595;
            scheduleChart.Visible = true;

            var random = new Random();
            var timeFrom = startDate.Value.Date;
            var timeTo = endDate.Value.Date;
            var clinicId = (cbClinics.SelectedItem as ClinicRow).Id;

            List<Tuple<DayOfWeek, int>> aggregatedRegistrations = new List<Tuple<DayOfWeek, int>>();

            using (var context = new ClinicDataEntities())
            {
                var regs = from registration in context.Registrations
                           join employee in context.Employees
                           on registration.EmployeeId equals employee.Id
                           join clinic in context.Clinics
                           on employee.ClinicId equals clinic.Id
                           where registration.Date <= timeTo && registration.Date >= timeFrom && clinic.Id == clinicId
                           select registration;

                aggregatedRegistrations = regs.AsEnumerable().GroupBy(p => p.Date.Value.DayOfWeek).Select(p => new Tuple<DayOfWeek, int>(p.Key, p.Count())).ToList();

            }

            foreach(var day in Enum.GetValues(typeof(DayOfWeek)))
            {
                if (aggregatedRegistrations.Any(p => p.Item1 == (DayOfWeek)day))
                {
                    var index = scheduleChart.Series["SeriesData"].Points.AddXY(day.ToString(), aggregatedRegistrations.FirstOrDefault(p => p.Item1 == (DayOfWeek)day)?.Item2);
                    scheduleChart.Series["SeriesData"].Points[index].Color = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                    scheduleChart.Series["SeriesData"].Points[index].Label = Convert.ToString(scheduleChart.Series["SeriesData"].Points[index].YValues.First());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
