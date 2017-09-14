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
    using System.ComponentModel.DataAnnotations;

    public partial class Lab_test_lines
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lab_test_lines()
        {
            this.Lab_test_results = new HashSet<Lab_test_results>();
        }

        [Display(Name = "TestID")]
        public int idLab_test_lines { get; set; }
        [Display(Name = "Reagent")]
        public Nullable<int> Lab_test_reagentID { get; set; }
        [Display(Name = "Time")]
        public Nullable<System.TimeSpan> Lab_test_time { get; set; }
        [Display(Name = "Quantity of Reagent")]
        public Nullable<decimal> Lab_test_drug_quantity { get; set; }
        [Display(Name = "Unit of measure")]
        public string Lab_test_UOM { get; set; }
        [Display(Name = "Cost")]
        public Nullable<decimal> Lab_test_cost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lab_test_results> Lab_test_results { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
    }
}
