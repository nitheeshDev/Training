using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Doctor_Appointment_Booking.Models
{
    public class AdminModel
    {
        public int Id { get; set; }
        public string Role { get; set; }

        [Display(Name = "Full name")]
        public string fullName { get; set; }
        [Display(Name = "Contact number")]
        public string contactNumber { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }

    }
}