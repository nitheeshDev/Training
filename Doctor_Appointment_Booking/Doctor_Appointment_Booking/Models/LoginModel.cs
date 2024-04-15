using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Doctor_Appointment_Booking.Models
{
    public class LoginModel
    {
        public int Id { get; set; }
        public string Role { get; set; }
        [DisplayName("Username")]

        public string Username  { get; set; }
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}