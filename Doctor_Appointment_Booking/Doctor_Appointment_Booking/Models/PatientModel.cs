using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Doctor_Appointment_Booking.Models
{
    public class PatientModel
    {

        public string DocId { get; set; }
        public int Id { get; set; }
        [Display(Name = "User name")]
        public string Username { get; set; }
        [Display(Name="Patient issue")]
        public string patientissue { get; set; }
        [Display(Name = "Visit date")]
        [DataType(DataType.Date)]
        public DateTime visitDate { get; set; }

        [Display(Name = "Visit Time")]
        
        public string VisitTime { get; set; }

        [Display(Name = "Doctor specialitty")]
        public string doctorSpecialitty { get; set; }
        public string Status { get; set; }


    }
}