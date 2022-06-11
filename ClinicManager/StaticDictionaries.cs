using ClinicManager.DataAccessLayer;
using ClinicManager.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager
{
    public class StaticDictionaries
    {
        #region Lazy Dictionaries

        public Lazy<Dictionary<int, EmployeeRow>> EmployeeList { get; set; } = new Lazy<Dictionary<int, EmployeeRow>>(InitializeDictionary<EmployeeRow>);
        public Lazy<Dictionary<int, LocalizationRow>> LocalizationList { get; set; } = new Lazy<Dictionary<int, LocalizationRow>>(InitializeDictionary<LocalizationRow>);
        public Lazy<Dictionary<int, OperationRow>> OperationList { get; set; } = new Lazy<Dictionary<int, OperationRow>>(InitializeDictionary<OperationRow>);
        public Lazy<Dictionary<int, PatientRow>> PatientList { get; set; } = new Lazy<Dictionary<int, PatientRow>>(InitializeDictionary<PatientRow>);
        public Lazy<Dictionary<int, ToolRow>> ToolList { get; set; } = new Lazy<Dictionary<int, ToolRow>>(InitializeDictionary<ToolRow>);
        public Lazy<Dictionary<int, DrugRow>> DrugList { get; set; } = new Lazy<Dictionary<int, DrugRow>>(InitializeDictionary<DrugRow>);
        public Lazy<Dictionary<int, ProducentRow>> ProducentList { get; set; } = new Lazy<Dictionary<int, ProducentRow>>(InitializeDictionary<ProducentRow>);
        public Lazy<Dictionary<int, ClinicRow>> ClinicList { get; set; } = new Lazy<Dictionary<int, ClinicRow>>(InitializeDictionary<ClinicRow>);
        public Lazy<Dictionary<int, Data>> DataList { get; set; } = new Lazy<Dictionary<int, Data>>(InitializeDictionary<Data>);

        #endregion

        #region Binary Dictionaries

        public Dictionary<int, string> TypeOperationList { get; set; } = new Dictionary<int, string>();
        public Dictionary<int, string> UnitList { get; set; } = new Dictionary<int, string>();

        #endregion

        const string typePath = @"..\..\BinaryEnums\type.bin";
        const string operationPath = @"..\..\BinaryEnums\operation.bin";

        public StaticDictionaries()
        {
            InitializeEnumDictionary();
        }

        private void InitializeEnumDictionary()
        {
            var i = 1;
            using (var bw = new BinaryReader(File.Open(typePath, FileMode.Open)))
            {
                while (bw.PeekChar() > -1)
                {
                    UnitList.Add(i, bw.ReadString());
                    i++;
                }
            }
            i = 1;

            using(var bw = new BinaryReader(File.Open(operationPath, FileMode.Open)))
            {
                while(bw.PeekChar() > -1)
                {
                    TypeOperationList.Add(i, bw.ReadString());
                    i++;
                }
            }
        }

        public void AddUnit(string newUnit)
        {
            using (var bw = new BinaryWriter(File.Open(typePath, FileMode.Append)))
            {
                bw.Write(newUnit);
            }
        }

        public void AddOperationType(string newOperation)
        {
            using (var bw = new BinaryWriter(File.Open(operationPath, FileMode.Append)))
            {
                bw.Write(newOperation);
            }
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
