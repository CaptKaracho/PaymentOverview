//------------------------------------------------------------------------------
// <auto-generated>
//    Dieser Code wurde aus einer Vorlage generiert.
//
//    Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten Ihrer Anwendung.
//    Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PO.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class USER_ROLE_PAYMENT_GROUP
    {
        public int ID { get; set; }
        public Nullable<int> ROLE_ID { get; set; }
        public Nullable<int> PAYMENT_GROUP_ID { get; set; }
        public Nullable<int> USER_ID { get; set; }
    
        public virtual PAYMENT_GROUP PAYMENT_GROUP { get; set; }
        public virtual ROLE ROLE { get; set; }
        public virtual USER USER { get; set; }
    }
}
