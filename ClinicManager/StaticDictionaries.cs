using ClinicManager.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager
{
    public class StaticDictionaries
    {
        public Dictionary<int, EmployeeRow> EmployeeList { get; set; }
        public Dictionary<int, LocalizationRow> LocalizationList { get; set; }
        public Dictionary<int, OperationRow> OperationList { get; set; }
        public Dictionary<int, string> UnitList { get; set; }
        public Dictionary<int, PatientRow> PatientList { get; set; }

        public StaticDictionaries()
        {
            LocalizationList = new Dictionary<int, LocalizationRow>();
            EmployeeList = new Dictionary<int, EmployeeRow>();
            OperationList = new Dictionary<int, OperationRow>();
            UnitList = new Dictionary<int, string>();
            PatientList = new Dictionary<int, PatientRow>();

            using(var context = new ClinicDataEntities())
            {
                var tmpLocalizationList = context.LocalizationRow.ToList();
                var tmpEmployeeList = context.EmployeeRow.ToList();
                var tmpOperationList = context.OperationRow.ToList();
                var tmpPatientList = context.PatientRow.ToList();

                foreach(var obj in tmpLocalizationList)
                {
                    LocalizationList.Add(obj.Id, obj);
                }
                foreach(var obj in tmpEmployeeList)
                {
                    EmployeeList.Add(obj.Id, obj);
                }
                foreach(var obj in tmpOperationList)
                {
                    OperationList.Add(obj.Id, obj);
                }

                foreach(var obj in tmpPatientList)
                {
                    PatientList.Add(obj.Id, obj);
                }
            }

            InitializeEnumDictionary();
        }

        private void InitializeEnumDictionary()
        {
            UnitList.Add(1, "opakowanie");
            UnitList.Add(2, "tabletka");
            UnitList.Add(3, "krem");
            UnitList.Add(4, "butelka");
            UnitList.Add(5, "gram");
            UnitList.Add(6, "ml");
        }
    }
}
