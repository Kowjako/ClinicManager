//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClinicManager.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class CostRow
    {
        public int Id { get; set; }
        public string Nazwa_leku { get; set; }
        public Nullable<int> Minimalna_cena { get; set; }
        public Nullable<int> Maksymalna_cena { get; set; }
        public Nullable<byte> Czas_dostawy__dni_ { get; set; }
        public string Producent { get; set; }
    }
}