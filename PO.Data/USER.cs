//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PO.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER()
        {
            this.USER_ROLE_PAYMENT_GROUP = new HashSet<USER_ROLE_PAYMENT_GROUP>();
        }
    
        public int USER_ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string NAME { get; set; }
        public string LASTNAME { get; set; }
        public bool ACTIVE { get; set; }
        public Nullable<System.DateTime> INSERT_AT { get; set; }
        public string INSERT_BY { get; set; }
        public Nullable<System.DateTime> UPDATE_AT { get; set; }
        public string UPDATE_BY { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_ROLE_PAYMENT_GROUP> USER_ROLE_PAYMENT_GROUP { get; set; }
    }
}
