using Doctor_Appointment_Booking.Models;
using Doctor_Appointment_Booking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doctor_Appointment_Booking.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        /// <summary>
        /// contact details
        /// </summary>
        /// <param name="contactModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Contact(ContactModel contactModel)
        {
            try
            {
                Contact_Repository contact_Repository = new Contact_Repository();
                if (ModelState.IsValid)
                {
                    if (contact_Repository.Insert_Contact(contactModel))
                    {
                        return View(contactModel);
                    }
                }
                else
                {
                    ViewBag.Message = "Error";
                }

                return View();
            }
            catch(Exception ex)
            {
                ErrorLog errorLogger = new ErrorLog(ex);
                return View();
            }
        }
       
        public ActionResult GetAllcontactDetails()
        {

            try
            {
                Contact_Repository contact_Repository = new Contact_Repository();
                ModelState.Clear();
                return View(contact_Repository.GetAllContact());
            }
            catch (Exception ex)
            {
                ErrorLog errorLogger = new ErrorLog(ex);
                return View();
            }
        }
    }
}