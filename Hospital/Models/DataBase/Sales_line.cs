//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hospital.Models.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sales_line
    {
        public int idSales_line { get; set; }
        public Nullable<int> type { get; set; }
        public string no { get; set; }
        public string description { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public Nullable<decimal> amount { get; set; }
        public int Sales_header_idSales_header { get; set; }
    
        public virtual Sales_header Sales_header { get; set; }
    }
}
