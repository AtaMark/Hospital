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
    
    public partial class Sales_header
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sales_header()
        {
            this.Sales_line = new HashSet<Sales_line>();
        }
    
        public int idSales_header { get; set; }
        public string customerID { get; set; }
        public string customer_name { get; set; }
        public Nullable<System.DateTime> posting_date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sales_line> Sales_line { get; set; }
    }
}
