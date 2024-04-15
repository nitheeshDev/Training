using Doctor_Appointment_Booking.Models;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Doctor_Appointment_Booking.Controllers
{
    public class HomeController : Controller
    {
        public SqlConnection connection;
        public object admin;
        public ActionResult Index()
        {
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();

                FormsAuthentication.SignOut();


                this.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                this.Response.Cache.SetNoStore();

                return View();
            
           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize]
        public ActionResult UserPage(string username,int id,string fullname)
        {
            string welcomeMessage = $"Welcome, {fullname}!";
            ViewBag.Message = welcomeMessage;
            Session["Username"] = username;
            Session["Id"] = id;
            Session["fullname"] = fullname;


            string connectionstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            connection = new SqlConnection(connectionstring);
            SqlCommand command = new SqlCommand("SP_Status", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@email", username);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string Status = reader["status"].ToString();
                FormsAuthentication.SetAuthCookie(username, true);
                Session["status"] = Status;
                ViewBag.status = Status;
            }

                return View( );


        }
        public ActionResult DoctorPage(/*string username, int id, string fullname*/)
        {


            return View();
        }
    }
}