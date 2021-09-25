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
    public partial class ContactDetails : Form
    {
        public ContactDetails()
        {
            InitializeComponent();
        }

        public void InitializeData<T>(T person)
        {
            using(var context = new ClinicDataEntities())
            {
                var data = context.Data.Find(person.GetType().GetProperty("DataId").GetValue(person, null));
                bsData.DataSource = new List<Data> { data };
            }
        }
    }
}
