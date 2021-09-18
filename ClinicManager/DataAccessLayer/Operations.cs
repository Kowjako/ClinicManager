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
    
    public partial class Operations
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Operations()
        {
            this.Employees = new HashSet<Employees>();
            this.Patients = new HashSet<Patients>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsAnesthesia { get; set; }
        public Nullable<int> ToolId { get; set; }
        public Nullable<int> DrugId { get; set; }
        public string Description { get; set; }
    
        public virtual Drugs Drugs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual Tools Tools { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patients> Patients { get; set; }
    }
}
