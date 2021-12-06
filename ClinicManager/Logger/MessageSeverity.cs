using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Logger
{
    public enum MessageSeverity
    {
        [System.ComponentModel.Description("Informacja: ")]
        Information = 1,
        [System.ComponentModel.Description("Ostrzeżenie: ")]
        Warning = 2,
        [System.ComponentModel.Description("Błąd: ")]
        Error = 3,
        [System.ComponentModel.Description("Zakońcono pomyślnie")]
        Finish = 4
    }
}
