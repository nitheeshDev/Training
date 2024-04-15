using Authentication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;

namespace Authentication.Controllers
{
    public class HomeController1 : Controller
    {
        private readonly IConfiguration _configuration;
        private SqlConnection connection;

        public HomeController1(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Connect()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            connection = new SqlConnection(connectionString);
        }
        public IActionResult admin()
        {
            return View();
        }
        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }
        public async Task<IActionResult> Authenticate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Authenticate(loginModel model)
        {

                Connect();
                connection.OpenAsync();

                using (var command = new SqlCommand("dbo.ValidateUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", model.UserName);
                    command.Parameters.AddWithValue("@Password", model.Password);

                    int result = (int)command.ExecuteScalar();

                    if (result != null && (int)result == 1)
                    {
                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.UserName),
                       
                    };

                        var identity = new ClaimsIdentity(claims, "custom");
                        var principal = new ClaimsPrincipal(identity);

                        HttpContext.SignInAsync(principal);

                        return RedirectToAction("Home");
                    }
                }
            return View();
        }

           
           
        }

      

    }




