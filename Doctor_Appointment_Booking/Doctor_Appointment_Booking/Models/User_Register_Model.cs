using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Microsoft.OData.Edm;

namespace Doctor_Appointment_Booking.Models
{
    public class User_Register_Model
    {
        public int Id { get; set; }

        [Display(Name ="Full name")]
        public string Fullname { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Contact number")]
        public string Contact_number { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string Confirmpassword { get; set; }

    }
}
