using ClinicManager.DataAccessLayer;
using ClinicManager.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager
{
    public class StaticDictionaries
    {
        public Lazy<Dictionary<int, EmployeeRow>> EmployeeList { get; set; } = new Lazy<Dictionary<int, EmployeeRow>>(InitializeDictionary<EmployeeRow>);
        public Lazy<Dictionary<int, LocalizationRow>> LocalizationList { get; set; } = new Lazy<Dictionary<int, LocalizationRow>>(InitializeDictionary<LocalizationRow>);
        public Lazy<Dictionary<int, OperationRow>> OperationList { get; set; } = new Lazy<Dictionary<int, OperationRow>>(InitializeDictionary<OperationRow>);
        public Lazy<Dictionary<int, string>> UnitList { get; set; } = new Lazy<Dictionary<int, string>>(InitializeDictionary<string>);
        public Lazy<Dictionary<int, PatientRow>> PatientList { get; set; } = new Lazy<Dictionary<int, PatientRow>>(InitializeDictionary<PatientRow>);
        public Lazy<Dictionary<int, string>> TypeOperationList { get; set; } = new Lazy<Dictionary<int, string>>(InitializeDictionary<string>);
        public Lazy<Dictionary<int, ToolRow>> ToolList { get; set; } = new Lazy<Dictionary<int, ToolRow>>(InitializeDictionary<ToolRow>);
        public Lazy<Dictionary<int, DrugRow>> DrugList { get; set; } = new Lazy<Dictionary<int, DrugRow>>(InitializeDictionary<DrugRow>);
        public Lazy<Dictionary<int, ProducentRow>> ProducentList { get; set; } = new Lazy<Dictionary<int, ProducentRow>>(InitializeDictionary<ProducentRow>);
        public Lazy<Dictionary<int, ClinicRow>> ClinicList { get; set; } = new Lazy<Dictionary<int, ClinicRow>>(InitializeDictionary<ClinicRow>);

        public StaticDictionaries()
        {
            //using(var context = new ClinicDataEntities())
            //{
            //    var tmpLocalizationList = context.LocalizationRow.ToList();
            //    var tmpEmployeeList = context.EmployeeRow.ToList();
            //    var tmpOperationList = context.OperationRow.ToList();
            //    var tmpPatientList = context.PatientRow.ToList();
            //    var tmpToolList = context.ToolRow.ToList();
            //    var tmpDrugList = context.DrugRow.ToList();
            //    var tmpProducentList = context.ProducentRow.ToList();
            //    var tmpClinicList = context.ClinicRow.ToList();

            //    foreach(var obj in tmpLocalizationList)
            //    {
            //        LocalizationList.Value.Add(obj.Id, obj);
            //    }
            //    foreach(var obj in tmpEmployeeList)
            //    {
            //        EmployeeList.Value.Add(obj.Id, obj);
            //    }
            //    foreach(var obj in tmpOperationList)
            //    {
            //        OperationList.Value.Add(obj.Id, obj);
            //    }
            //    foreach(var obj in tmpPatientList)
            //    {
            //        PatientList.Value.Add(obj.Id, obj);
            //    }
            //    foreach(var obj in tmpToolList)
            //    {
            //        ToolList.Value.Add(obj.Id, obj);
            //    }
            //    foreach (var obj in tmpDrugList)
            //    {
            //        DrugList.Value.Add(obj.Id, obj);
            //    }
            //    foreach (var obj in tmpProducentList)
            //    {
            //        ProducentList.Value.Add(obj.Id, obj);
            //    }
            //    foreach(var obj in tmpClinicList)
            //    {
            //        ClinicList.Value.Add(obj.Id, obj);
            //    }
                
            //}

            InitializeEnumDictionary();
        }

        private void InitializeEnumDictionary()
        {
            //UnitList.Add(1, "opakowanie");
            //UnitList.Add(2, "tabletka");
            //UnitList.Add(3, "krem");
            //UnitList.Add(4, "butelka");
            //UnitList.Add(5, "gram");
            //UnitList.Add(6, "ml");

            //TypeOperationList.Add(1, "Chirurgia");
            //TypeOperationList.Add(2, "Kardiologia");
            //TypeOperationList.Add(3, "Kardiochirurgia");
            //TypeOperationList.Add(4, "Neurochirurgia");
            //TypeOperationList.Add(5, "Laryngologia");
            //TypeOperationList.Add(6, "Ortopedia");
            //TypeOperationList.Add(7, "Fizjoterapia");
            //TypeOperationList.Add(8, "Kosmetologia");
        }

        public void AddUnit(string newUnit)
        {
            int lastKey = UnitList.Value.Keys.Last();
            UnitList.Value.Add(lastKey + 1, newUnit);
        }

        public void AddOperationType(string newOperation)
        {
            int lastKey = TypeOperationList.Value.Keys.Last();
            TypeOperationList.Value.Add(lastKey + 1, newOperation);
        }

        private static Dictionary<int, T> InitializeDictionary<T>() where T : class
        {
            var tmpDictionary = new Dictionary<int, T>();
            using(var context = new ClinicDataEntities())
            {
                var tmpList = context.Set<T>().ToDictionary(p => (p.GetType().GetProperty("Id").GetValue(p, null) as int?).Value);
                return tmpList;
            }
        }
    }
}
