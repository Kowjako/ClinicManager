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
    
    public partial class Orders
    {
        public int Id { get; set; }
        public int DrugId { get; set; }
        public int ClinicId { get; set; }
        public int ProducentId { get; set; }
        public Nullable<byte> Amount { get; set; }
        public string Unit { get; set; }
    
        public virtual Clinics Clinics { get; set; }
        public virtual Drugs Drugs { get; set; }
        public virtual Producents Producents { get; set; }
    }
}
