//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PO.Data.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class PAYMENT_DATA_RECURRENT
    {
        public int ID { get; set; }
        public string DESCRIPTION { get; set; }
        public decimal PRICE { get; set; }
        public string DUE_CODE { get; set; }
        public Nullable<int> PAYMENT_GROUP_ID { get; set; }
        public Nullable<int> PAYMENT_TYPE_ID { get; set; }
        public Nullable<System.DateTime> INSERT_AT { get; set; }
        public string INSERT_BY { get; set; }
    
        public virtual PAYMENT_GROUP PAYMENT_GROUP { get; set; }
        public virtual PAYMENT_TYPE PAYMENT_TYPE { get; set; }
    }
}
