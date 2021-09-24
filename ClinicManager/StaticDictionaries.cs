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
        public Dictionary<int, string> TypeOperationList { get; set; }
        public Dictionary<int, ToolRow> ToolList { get; set; }
        public Dictionary<int, DrugRow> DrugList { get; set; }
        public Dictionary<int, ProducentRow> ProducentList { get; set; }

        public StaticDictionaries()
        {
            LocalizationList = new Dictionary<int, LocalizationRow>();
            EmployeeList = new Dictionary<int, EmployeeRow>();
            OperationList = new Dictionary<int, OperationRow>();
            UnitList = new Dictionary<int, string>();
            PatientList = new Dictionary<int, PatientRow>();
            TypeOperationList = new Dictionary<int, string>();
            ToolList = new Dictionary<int, ToolRow>();
            DrugList = new Dictionary<int, DrugRow>();
            ProducentList = new Dictionary<int, ProducentRow>();

            using(var context = new ClinicDataEntities())
            {
                var tmpLocalizationList = context.LocalizationRow.ToList();
                var tmpEmployeeList = context.EmployeeRow.ToList();
                var tmpOperationList = context.OperationRow.ToList();
                var tmpPatientList = context.PatientRow.ToList();
                var tmpToolList = context.ToolRow.ToList();
                var tmpDrugList = context.DrugRow.ToList();
                var tmpProducentList = context.ProducentRow.ToList();

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
                foreach(var obj in tmpToolList)
                {
                    ToolList.Add(obj.Id, obj);
                }
                foreach (var obj in tmpDrugList)
                {
                    DrugList.Add(obj.Id, obj);
                }
                foreach (var obj in tmpProducentList)
                {
                    ProducentList.Add(obj.Id, obj);
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

            TypeOperationList.Add(1, "Chirurgia");
            TypeOperationList.Add(2, "Kardiologia");
            TypeOperationList.Add(3, "Kardiochirurgia");
            TypeOperationList.Add(4, "Neurochirurgia");
            TypeOperationList.Add(5, "Laryngologia");
            TypeOperationList.Add(6, "Ortopedia");
            TypeOperationList.Add(7, "Fizjoterapia");
            TypeOperationList.Add(8, "Kosmetologia");

        }
    }
}
