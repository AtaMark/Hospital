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
        [StringLength(20)]
        [Display(Name = "PatientID")]
        [Required]
        public string idPatient;

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
        [StringLength(45)]
        [Display(Name = "Email")]
        public string Email;

    }
    public class AddressMetadata {
        [StringLength (13)]
        [Required]
        [Display (Name = "Phone Contact") ]
        public string contact;

        [StringLength(45)]
        [Required]
        [Display(Name = "Address1")]
        public string Address1;

        [StringLength(45)]
        [Display(Name = "Address2")]
        public string Address2;
        public string patientID;
    }
    public class AppointmentMetadata {
        public int idAppointment;
        public string patientID;
        [Display(Name = "Status")]
        public Nullable<int> status;

        [Required]
        [Display (Name = "Appointment Date")]
        public Nullable<System.DateTime> date;

        [Required]
        [Display (Name = "Appointment Time")]
        public Nullable<System.TimeSpan> time;

        [StringLength(45)]
        public string reason_for_missing_appointment;
        public int Visit_idVisit;
    }    
    public class DepartmentMetadata
    {
    }
    public class DiagnosisMetadata
    {
    }
    public class DoctorMetadata
    {
    }
    public class Follow_upMetadata
    {
    }
    public class HistoryMetadata
    {
    }
    public class Lab_headerMetadata
    {
    }
    public class Lab_test_linesMetadata
    {
    }
    public class Lab_test_resultsMetadata
    {
    }
    public class OperationMetadata
    {
    }
    public class PharmacyMetadata
    {
    }
    public class PrescriptionMetadata
    {
    }
    public class Radio_imageMetadata
    {
    }
    public class Sales_headerMetadata
    {
    }
    public class Sales_lineMetadata
    {
    }
    public class TriageMetadata
    {
    }
    public class UOM_Metadata
    {
    }
    public class UserMetadata
    {
    }
    public class VisitMetadata
    {
    }
    public class Ward_Metadata
    {
    }

}