using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.DataAccessLayer
{
    public partial class Data
    {
        public string FullName => Name + " " + Surname;
    }
}
