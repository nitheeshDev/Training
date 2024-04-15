using Doctor_Appointment_Booking.Models;
using Doctor_Appointment_Booking.Repository;
using System;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Doctor_Appointment_Booking.Controllers
{
    public class DoctorController : Controller
    {
        private readonly Doctor_and_Admin_Repository repository;
        [Authorize]
        public ActionResult DoctorRegister()
        {
            return View();
        }
        [Route("DoctorRegister")]
        [HttpPost]
        [Authorize]
        public ActionResult DoctorRegister(Doctor_Register_Model doctor_Register_Model,string Password)
        {
            Doctor_and_Admin_Repository insert = new Doctor_and_Admin_Repository();
            HttpPostedFileBase File = Request.Files["imageData"];
            
            insert.DoctorInsert(doctor_Register_Model, File, Password);
            int i = insert.getemail();
            int j=insert.size();
            int z = insert.fileextenssions();

            
            if(j==1)
            {
                ViewBag.size = "Maximum size is 1MP";
            }
            else if (z == 1)
            {
                ViewBag.ex = "Image format is .jpg, .jpeg , .png ,.gif";
            }
            else if (i != 1)
            {
                ViewBag.Message = "Email already exists";
                return View();
            }
            else
            {
                return RedirectToAction("GetAllDoctorDetails");
            }
            return View();
        }

        [Authorize]
        public ActionResult GetAllDoctorDetails()
        {
            Doctor_and_Admin_Repository doctor_Registration = new Doctor_and_Admin_Repository();
            var allDoctors = doctor_Registration.GetAllDoctor();
            return View(allDoctors);
        }

        //admin
        [Authorize]
        public ActionResult adminRegister()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult adminRegister(AdminModel adminModel,string Password)
        {
            try
            {
                    Doctor_and_Admin_Repository admin_Registration = new Doctor_and_Admin_Repository();
                    admin_Registration.adminInsert(adminModel, Password);
                    int i = admin_Registration.getemail();
                    if(i == 1)
                    {
                        return RedirectToAction("GetAllAdminDetails");
                    }
                    else
                    {
                        ViewBag.Message = "Email already exists";
                    }
                        
                    
                
                return View();
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        public ActionResult GetonedoctorDetails(int id)
        {

            Doctor_and_Admin_Repository admin_Registration = new Doctor_and_Admin_Repository();
            ModelState.Clear();
            return View(admin_Registration.GetOneDoctor(id));
        }
        [Authorize]
        public ActionResult EditDoctor(int id)
        {
            Doctor_and_Admin_Repository Update = new Doctor_and_Admin_Repository();
            return View(Update.GetOneDoctor(id).Find(e => e.Id == id));

        }

        [HttpPost]
        public ActionResult EditDoctor(Doctor_Register_Model doctor_Register_Model,int id, string Password)
        {
            Doctor_and_Admin_Repository insert = new Doctor_and_Admin_Repository();
            HttpPostedFileBase File = Request.Files["imageData"];
            int i = 0;
            while (i == 0)
            {
                insert.EditDoctor(doctor_Register_Model, File,id,Password);
                i++;
            }
            if (i == 1)
            {
                return RedirectToAction("GetonedoctorDetails", new { id = id });
            }
            return View(doctor_Register_Model);
        }
        public ActionResult DeleteDoctor(int id)
        {

            Doctor_and_Admin_Repository Update = new Doctor_and_Admin_Repository();
            return View(Update.GetAllDoctor().Find(Emp => Emp.Id == id));

        }

        [HttpPost]
        public ActionResult DeleteDoctor(Doctor_Register_Model doctor_Register_Model,int id)
        {
            try
            {
                Doctor_and_Admin_Repository delete = new Doctor_and_Admin_Repository();
                delete.DeleteDoctor(doctor_Register_Model,id);

                return RedirectToAction("GetAllDoctorDetails");
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        public ActionResult GetAllAdminDetails()
        {

            Doctor_and_Admin_Repository admin_Registration = new Doctor_and_Admin_Repository();
            ModelState.Clear();
            return View(admin_Registration.GetAllAdmin());
        }
        public ActionResult GetoneAdminDetails(int id)
        {

            Doctor_and_Admin_Repository admin_Registration = new Doctor_and_Admin_Repository();
            ModelState.Clear();
            return View(admin_Registration.GetoneAdmin(id));
        }
        public ActionResult EditAdmin(int id)
        {
            Doctor_and_Admin_Repository Update = new Doctor_and_Admin_Repository();
            return View(Update.GetoneAdmin(id).Find(aid => aid.Id == id));
        }

        [HttpPost]
        public ActionResult EditAdmin(AdminModel adminModel,int id,string Password)
        {
            try
            {
                Doctor_and_Admin_Repository Update = new Doctor_and_Admin_Repository();
                Update.EditAdmin(adminModel, id,Password);
                return RedirectToAction("Login","Login");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeleteAdmin(int id)
        {
            Doctor_and_Admin_Repository Update = new Doctor_and_Admin_Repository();
            return View(Update.GetAllAdmin().Find(Emp => Emp.Id == id));

        }

        [HttpPost]
        public ActionResult DeleteAdmin(AdminModel adminModel)
        {
            try
            {
                Doctor_and_Admin_Repository delete = new Doctor_and_Admin_Repository();
                delete.DeleteAdmin(adminModel);
                return RedirectToAction("GetAllAdminDetails");
            }
            catch
            {
                return View();
            }
        }
    }
}
