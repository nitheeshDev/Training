using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Doctor_Appointment_Booking.Models
{
    public class Doctor_Register_Model
    {
        public int Id { get; set; }


        [Display(Name = "Full name")]
        public string fullName { get; set; }

        [Display(Name = "Doctor ID")]
        public string doctorID { get; set; }

        [Display(Name = "Doctor specialization")]
        public string doctorSpecialization { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

            
        public string Address { get; set; }

        [Display(Name = "Contact number")]
        public string contactNumber { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
        [DataType(DataType.Password)]

        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]

        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
       
        //public string ImagePath { get; set; }
        //[DisplayName("Profile")]
        //public byte [] Profile { get; set; }
        public byte[] Profile { get; set; }

        //public string ImageBase64 { get; set; }

        //public HttpPostedFileBase ProfileImageFile { get; set; }

        //[DisplayName("Profile")]
        //public HttpPostedFileBase ProfileImageFile { get; set; }
    }
}
