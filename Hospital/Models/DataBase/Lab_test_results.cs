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
    
    public partial class Lab_test_results
    {
        public int idLab_test { get; set; }
        public string Lab_test_description { get; set; }
        public Nullable<int> Lab_headerID { get; set; }
        public Nullable<int> Lab_test_linesID { get; set; }
    
        public virtual Lab_header Lab_header { get; set; }
        public virtual Lab_test_lines Lab_test_lines { get; set; }
    }
}
