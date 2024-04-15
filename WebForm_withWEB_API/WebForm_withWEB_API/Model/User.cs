using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForm_withWEB_API.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
    }
}