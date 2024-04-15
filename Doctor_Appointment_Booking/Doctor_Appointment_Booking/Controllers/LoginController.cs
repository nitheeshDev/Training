using System;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using Doctor_Appointment_Booking.Models;
using Doctor_Appointment_Booking.Repository;

namespace Doctor_Appointment_Booking.Controllers
{
    public class LoginController : Controller
    {
        private LoginRepository loginRepository;

        public LoginController()
        {
            loginRepository = new LoginRepository();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginModel"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel loginModel,string Password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string errorMessage;
                    string username;
                    string role;
                    int id;
                    string doctorSpecilization;
                    string fullname;
                    string doctorid;

                    bool isAuthenticated = loginRepository.Login(loginModel, out errorMessage, out username, out role, out id, out doctorSpecilization, out fullname, out doctorid, Password);

                    if (isAuthenticated)
                    {
                        Session["username"] = username;
                        Session["role"] = role;
                        Session["id"] = id;
                        Session["doctorSpecilization"] = doctorSpecilization;
                        Session["fullname"] = fullname;
                        Session["doctorid"] = doctorid;

                        if (role == "User")
                        {
                            return RedirectToAction("UserPage", "Home", new { username = username, id = id, fullname = fullname });

                        }
                        else if (role == "Doctor")
                        {
                            return RedirectToAction("DoctorPage", "Home", new { username = username, id = id, doctorSpecilization = doctorSpecilization, fullname = fullname, doctorid = doctorid });
                        }
                        else if (role == "Admin")
                        {
                            return RedirectToAction("GetAllAdminDetails", "Doctor", new { username = username, id = id });
                        }
                        else
                        {
                            ViewBag.ErrorMessage = errorMessage;
                        }

                    }
                    else
                    {
                        ViewBag.ErrorMessage = errorMessage;
                    }
                }

                return View(loginModel);
            }
            catch (Exception ex)
            {
                ErrorLog errorLogger = new ErrorLog(ex);
                return View();
            }
        }

    }
}
