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
    
    public partial class PAYMENT_DATA_SINGLE
    {
        public int ID { get; set; }
        public string DESCRIPTION { get; set; }
        public decimal PRICE { get; set; }
        public System.DateTime DATE { get; set; }
        public string ADDON_TEXT { get; set; }
        public Nullable<int> PAYMENT_GROUP_ID { get; set; }
        public Nullable<int> PAYMENT_TYPE_ID { get; set; }
        public Nullable<System.DateTime> INSERT_AT { get; set; }
        public string INSERT_BY { get; set; }
    
        public virtual PAYMENT_GROUP PAYMENT_GROUP { get; set; }
        public virtual PAYMENT_TYPE PAYMENT_TYPE { get; set; }
    }
}
