using MVC_Authentication.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

public class LoginController : Controller
{
    public SqlConnection connection;

    public void Connect()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        connection = new SqlConnection(connectionString);
    }

    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(loginModel loginModel)
    {
        Connect();

        using (var command = new SqlCommand("dbo.ValidateUser", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Username", loginModel.Email);
            command.Parameters.AddWithValue("@Password", loginModel.Password);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string role = reader["role"].ToString();

                if (!string.IsNullOrEmpty(role))
                {
                    // Create a new identity with the user's roles.
                    var authTicket = new FormsAuthenticationTicket(
                        1, // Version
                        loginModel.Email, // User name
                        DateTime.Now, // Issue time
                        DateTime.Now.AddMinutes(30), // Expiration time
                        true, // IsPersistent
                        role, // User data (role)
                        FormsAuthentication.FormsCookiePath);

                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                    // Create a new cookie and add the encrypted ticket to it.
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(cookie);

                    if (User.Identity.IsAuthenticated)
                    {
                       
                        if (role == "admin")
                        {
                           
                            return RedirectToAction("Admin", "Home");
                        }
                        else if (role == "user")
                        {
                            return RedirectToAction("User", "Home");
                        }
                    }
                }
            }

            //ViewData["ValidateMessage"] = "User not found";
            //return View("Login");
            return View();

        }
    }

    [Authorize]
    public ActionResult UserProfile()
    {
        return View();
    }

    [Authorize(Roles = "admin")]
    public ActionResult Admin()
    {
        return View();
    }

    public ActionResult Logout()
    {
        // Sign the user out and remove the authentication cookie.
        FormsAuthentication.SignOut();

        // Redirect to the login page or any other page as needed.
        return RedirectToAction("Login");
    }
}
