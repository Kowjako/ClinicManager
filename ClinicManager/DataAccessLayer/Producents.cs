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
    
    public partial class Producents
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producents()
        {
            this.Costs = new HashSet<Costs>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime OpenDate { get; set; }
        public int LocalizationId { get; set; }
        public int DataId { get; set; }
        public string Email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Costs> Costs { get; set; }
        public virtual Data Data { get; set; }
        public virtual Localizations Localizations { get; set; }
    }
}