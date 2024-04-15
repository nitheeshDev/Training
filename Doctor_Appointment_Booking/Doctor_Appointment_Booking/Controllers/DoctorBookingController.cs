using Doctor_Appointment_Booking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doctor_Appointment_Booking.Controllers
{
    public class DoctorBookingController : Controller
    {
        // GET: DoctorBooking
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Book
        /// </summary>
        /// <returns></returns>
        /// 
        [Authorize]
        public ActionResult Bokingdoctor()
        {

            try
            {
                DoctorBooking_Reposittory admin_Registration = new DoctorBooking_Reposittory();
                ModelState.Clear();
                return View(admin_Registration.Doctordetails());
            }
            catch (Exception ex)
            {
                ErrorLog errorLogger = new ErrorLog(ex);
                return View();
            }
        }
    }
}