using Doctor_Appointment_Booking.Models;
using Doctor_Appointment_Booking.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doctor_Appointment_Booking.Controllers
{
    public class PatientController : Controller
    {

        public SqlConnection connection;
        public object admin;


       
        public void Connect()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            connection = new SqlConnection(connectionstring);

        }
        // GET: Patient

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Patient booking form
        /// </summary>
        /// <param name="username"></param>
        /// <param name="id"></param>
        /// <returns></returns>

        [Authorize]
        public ActionResult PatientBook(string username, string id)
        {
            PatientRepository patient = new PatientRepository();
            PatientModel patientModel = new PatientModel();
            patientModel.DocId = id;
            patientModel.Username = username;
            return View(patientModel);
        }



       
        [HttpPost]
        public ActionResult PatientBook(PatientModel patientModel, string username, string id)
        {
            try
            {
                PatientRepository patient = new PatientRepository();

                patient.Insert_Patient(patientModel, username, id);
                int i = patient.get();
                if (i == 1)
                {
                    ViewBag.message ="Succesfully appointmented";

                }
                else
                {
                    ViewBag.Patient = "Please Choose another date and time";
                }


                return View();
            }
            catch (Exception ex)
            {
                ErrorLog errorLogger = new ErrorLog(ex);
                return View();
            }

        }
        /// <summary>
        /// Get waiting details
        /// </summary>
        /// <param name="doctorid"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult GetPatientDetails(string doctorid)
        {
            try
            {
                PatientRepository Total = new PatientRepository();
                ModelState.Clear();
                return View(Total.GetAllPatient(doctorid));
            }
            catch (Exception ex)
            {
                ErrorLog errorLogger = new ErrorLog(ex);
                return View();
            }

        }

        /// <summary>
        /// patient status
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        /// 
        [Authorize]
        public ActionResult GetPatientStatus(string username)
        {
            try
            {
                PatientRepository Total = new PatientRepository();
                ModelState.Clear();
                return View(Total.GetStatus(username));
            }
            catch (Exception ex)
            {
                ErrorLog errorLogger = new ErrorLog(ex);
                return View();
            }

        }
        /// <summary>
        /// Approval patient
        /// </summary>
        /// <param name="doctorid"></param>
        /// <returns></returns>
        /// 
        [Authorize]
        public ActionResult GetApprovalPatientDetails(string doctorid)
        {

            try
            {
                PatientRepository Total = new PatientRepository();
                ModelState.Clear();
                return View(Total.GetApprovalPatient(doctorid));
            }
            catch (Exception ex)
            {
                ErrorLog errorLogger = new ErrorLog(ex);
                return View();
            }
        }
        [Authorize]
        public ActionResult Delete_UserRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult deletePatient(int Id)
        {
            try
            {
                PatientRepository delete = new PatientRepository();
                if (delete.DeletePatient(Id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";

                }
                return RedirectToAction("GetAllUserDetails");

            }
            catch (Exception ex)
            {
                ErrorLog errorLogger = new ErrorLog(ex);
                return View();
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult UpdateStatus(int id, string status)
        {
            try
            {
                string connectionstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                connection = new SqlConnection(connectionstring);
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    string sqlQuery = "UPDATE Patient SET Status = @status WHERE Id = @id";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@status", status);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                }

                return Json(new { success = true });
            
            }
            catch(Exception ex)
            {
                ErrorLog errorLogger = new ErrorLog(ex);
                return View();
    }
}

    //public SqlConnection connection;
    //public object admin;

    /// <summary>
    /// doctorSpecilization
    /// </summary>
    /// <returns></returns>


    private List<string> GetDoctorSpecializations()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SP_DS", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                var specializations = new List<string>();

                while (reader.Read())
                {
                    string specialization = reader["doctorSpecilization"].ToString();
                    specializations.Add(specialization);
                    //ViewBag.DoctorSpecialities = new SelectList(specializations);

                }

                connection.Close();

                return specializations;
            }
        }




        //public ActionResult Autocomplete()
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        var query = "SELECT DISTINCT doctorSpecilization FROM register"; 
        //        var cmd = new SqlCommand(query, connection);

        //        var doctorSpecilization = new List<string>();
        //        connection.Open();

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                doctorSpecilization.Add(reader["doctorSpecilization"].ToString());
        //            }
        //        }

        //        return Json(doctorSpecilization, JsonRequestBehavior.AllowGet);
        //    }
        //}


    }
}