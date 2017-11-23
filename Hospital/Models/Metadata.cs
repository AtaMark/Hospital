using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    /*
     This Class contains the metadata (Data Validation Rules) for all entities in the system
     It is linked to the PartialClasses class
    */
    public class PatientMetadata
    {
        [StringLength(50)]
        [Display(Name = "Name")]
        [Required]
        public string Name;

        [Display(Name = "File No.")]
        [Required]
        public int File_No;

        [StringLength(13)]
        [Display(Name = "Phone No.")]
        [Required]
        public string Phone_No;

        [StringLength(45)]
        [Display(Name = "Address")]
        public string Address;

        
        [Display(Name = "Sex")]
        [Range (0,1)]
        [Required]
        public string Sex;

        [Display(Name = "Date of Birth")]
        [Required]
        public Nullable<System.DateTime> DOB;

        [StringLength(50)]
        [Required]
        [Display(Name = "Next of Kin Name")]
        public string Name_NOK;

        [StringLength(13)]
        [Required]
        [Display(Name = "Next of Kin Phone No.")]
        public string Contact_NOK;

        [StringLength(45)]
        [Required]
        [Display(Name = "Relationship to Next of Kin")]
        public string NOK_Relationship;

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email;

    }
}