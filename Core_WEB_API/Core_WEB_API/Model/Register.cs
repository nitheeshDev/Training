using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Core_CRUD.Models
{
    public class Register
    {
        public int Id { get; set; }

        [Display(Name = "Student name")]
        public string StudentName { get; set; }

        [Display(Name = "Roll number")]
        public string RollNumber { get; set; }

        [Display(Name = "Level")]
        public string Level { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        [Display(Name = "Contact number")]
        public string ContactNumber { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        public string Password { get; set; }

        public IFormFile FormFile { get; set; }
        public byte[] Profile { get; set; }

    }
}
