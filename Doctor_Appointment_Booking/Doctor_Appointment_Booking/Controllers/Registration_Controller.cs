using Doctor_Appointment_Booking.Models;
using Doctor_Appointment_Booking.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Microsoft.Ajax.Utilities;
using System.Web.Services.Description;

namespace Doctor_Appointment_Booking.Controllers
{
    public class Registration_Controller : Controller
    {
       

        User_registration_Repository user_Registration = new User_registration_Repository();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// user in list
        /// </summary>
        /// <returns></returns>
        /// 
        [Authorize]
        public ActionResult GetAllUserDetails()
        {

            try
            {
                User_registration_Repository Total = new User_registration_Repository();
                ModelState.Clear();
                return View(Total.GetAllUser());
            }
            catch (Exception ex)
            {
                ErrorLog errorLogger = new ErrorLog(ex);
                return View();
            }
        }
        [AllowAnonymous]
        public ActionResult UserRegister() 
        {
            //ViewBag.GenderList = GetGenderList();
            //User_registration_Repository user_Registration = new User_registration_Repository();
            return View();
        }

        /// <summary>
        /// /user register
        /// </summary>
        /// <param name="user_Register_Model"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [HttpPost]
       
        public ActionResult UserRegister(User_Register_Model user_Register_Model, string Password)
        {
            try
            {
                User_registration_Repository user_Registration = new User_registration_Repository();
                user_Registration.Insert_user(user_Register_Model, Password);
                int i = user_Registration.getemail();


                if (i==1)
                    {
                        return RedirectToAction("Login","Login");
                    }
                    else
                    {
                        ViewBag.Message = "Email already exists";
                       return View();
                    }
                

                
               
            }
            catch (Exception ex)
            {
                ErrorLog errorLogger = new ErrorLog(ex);
                return View();
            }
        }
        /// <summary>
        /// delete user
        /// </summary>
        /// <returns></returns>

        [Authorize]
        public ActionResult Delete_UserRegister(int Id)
        {
            User_registration_Repository delete= new User_registration_Repository();
            return View(delete.GetAllUser().Find(du => du.Id == Id));
        }
        [HttpPost]
        [Authorize]
        public ActionResult Delete_UserRegister(User_Register_Model user_Register_Model,int Id)
        {
            try
            {
                User_registration_Repository user_Registration = new User_registration_Repository();
                if (user_Registration.DeleteUser(user_Register_Model,Id))
                {
                    return RedirectToAction("GetAllUserDetails");

                }

                return RedirectToAction("GetAllUserDetails");
            }
            catch (Exception ex)
            {
                ErrorLog errorLogger = new ErrorLog(ex);
                return View();
            }
        }
        [Authorize]
        public ActionResult EditUser(int id)
        {
            try
            {

                User_registration_Repository Update = new User_registration_Repository();
                return View(Update.Getoneuser(id).Find(uid => uid.Id == id));
            }
             catch (Exception ex)
            {
                ErrorLog errorLogger = new ErrorLog(ex);
                return View();
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditUser(User_Register_Model user_Register_Model, int id,string Password)
        {
            try
            {
                User_registration_Repository Update = new User_registration_Repository();
                Update.Updateoneuser(user_Register_Model,id,Password);
                return RedirectToAction("Login","Login");

            }
            catch (Exception ex)
            {
                ErrorLog errorLogger = new ErrorLog(ex);
                return View();
            }
        }
        [Authorize]
        public ActionResult GetsingleDetails(int id)
        {

            try
            {
                User_registration_Repository Total = new User_registration_Repository();
                ModelState.Clear();
                return View(Total.Getoneuser(id));
            }
             catch (Exception ex)
            {
                ErrorLog errorLogger = new ErrorLog(ex);
                return View();
            }
        }
       

    }
}