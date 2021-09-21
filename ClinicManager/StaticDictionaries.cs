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

        public StaticDictionaries()
        {
            LocalizationList = new Dictionary<int, LocalizationRow>();
            EmployeeList = new Dictionary<int, EmployeeRow>();
            OperationList = new Dictionary<int, OperationRow>();

            using(var context = new ClinicDataEntities())
            {
                var tmpLocalizationList = context.LocalizationRow.ToList();
                var tmpEmployeeList = context.EmployeeRow.ToList();
                var tmpOperationList = context.OperationRow.ToList();

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
            }
        }
    }
}
