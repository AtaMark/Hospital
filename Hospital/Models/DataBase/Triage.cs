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
    
    public partial class Triage
    {
        public int idTriage { get; set; }
        public Nullable<decimal> height { get; set; }
        public Nullable<decimal> mass { get; set; }
        public Nullable<decimal> blood_pressure { get; set; }
        public string Triagecol { get; set; }
        public int Visit_idVisit { get; set; }
        public Nullable<decimal> checkup_cost { get; set; }
    
        public virtual Visit Visit { get; set; }
    }
}