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

    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            this.Addresses = new HashSet<Address>();
            this.Appointments = new HashSet<Appointment>();
            this.Histories = new HashSet<History>();
            this.Prescriptions = new HashSet<Prescription>();
            this.Visits = new HashSet<Visit>();
        }
        /*This code has to be decorated with appropriate annotations*/
        [Display (Name = "PatientID")]
        public string idPatient { get; set; }
        public string Name { get; set; }
        [Display(Name = "File No.")]
        public Nullable<int> File_No { get; set; }
        [Display (Name = "Contact")]
        public string Phone_No { get; set; }
        public string Address { get; set; }
        public Nullable<int> Sex { get; set; }
        [Display (Name = "Date of Birth")]
        public Nullable<System.DateTime> DOB { get; set; }
        [Display (Name = "Next of kin")]
        public string Name_NOK { get; set; }
        [Display (Name = "Contact NOK")]
        public string Contact_NOK { get; set; }
        [Display (Name = "Relationship to NOK")]
        public string NOK_Relationship { get; set; }
        public string Email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Address> Addresses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<History> Histories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prescription> Prescriptions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
