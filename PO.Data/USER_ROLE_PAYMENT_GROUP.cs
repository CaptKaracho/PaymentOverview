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
