using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Doctor_Appointment_Booking.Models
{
    public class DoctorBookingModel
    {
        public int Id { get; set; }

        public string Role { get; set; }
        //[DisplayName("Full name")]
        [Display(Name = "Full name")]
        public string fullName { get; set; }

        [Display(Name = "DoctorID")]
        public string doctorID { get; set; }
        [Display(Name = "Doctor specilization")]
        public string doctorSpecilization { get; set;}

        public byte[] Profile { get; set; }

    }
}