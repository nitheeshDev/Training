using Doctor_Appointment_Booking.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Doctor_Appointment_Booking.Repository
{
    public class DoctorBooking_Reposittory
    {

        public SqlConnection connection;
        public object admin;

        private void Connect()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            connection = new SqlConnection(connectionstring);

        }
        /// <summary>
        /// Doctordeatails
        /// </summary>
        /// <returns></returns>
        public List<DoctorBookingModel> Doctordetails()
        {
            try { 
            Connect();
            List<DoctorBookingModel> getdoctor = new List<DoctorBookingModel>();


            SqlCommand command = new SqlCommand("SP_getDoctor", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataadapter = new SqlDataAdapter(command);
            DataTable datatable = new DataTable();

            connection.Open();
            dataadapter.Fill(datatable);
           

            foreach (DataRow dr in datatable.Rows)
            {
                getdoctor.Add(

                    new DoctorBookingModel
                    {
                        fullName = Convert.ToString(dr["fullname"]),
                        doctorID = Convert.ToString(dr["DoctorID"]),
                        doctorSpecilization = Convert.ToString(dr["doctorSpecilization"]),
                        Profile = dr["profile"] != DBNull.Value ? (byte[])dr["profile"] : null
                        //Confirmpassword = Convert.ToString(dr["Confirmpassword"])
                    }
                    );
            }

            return getdoctor;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}