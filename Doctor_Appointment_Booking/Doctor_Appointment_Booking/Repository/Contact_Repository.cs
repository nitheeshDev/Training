using Doctor_Appointment_Booking.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Doctor_Appointment_Booking.Repository
{
    public class Contact_Repository
    {
        public SqlConnection connection;
        public object admin;

        private void Connect()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            connection = new SqlConnection(connectionstring);

        }
        /// <summary>
        /// Conatact
        /// </summary>
        /// <param name="contactModel"></param>
        /// <returns></returns>
        public bool Insert_Contact(ContactModel contactModel)
        {
            try {
            Connect();
            SqlCommand comment = new SqlCommand("SPI_Contact", connection);
            comment.CommandType = CommandType.StoredProcedure;
            comment.Parameters.AddWithValue("@Name", contactModel.Name);
            comment.Parameters.AddWithValue("@email", contactModel.Email);
            comment.Parameters.AddWithValue("@message", contactModel.Message);

            connection.Open();
            int i = comment.ExecuteNonQuery();
           
            if (i >= 1)
            {
                return true;
            }
            else { return false; }
            }
            finally
            {
                connection.Close();
            }

        }
        /// <summary>
        /// Get all contact
        /// </summary>
        /// <returns></returns>
        public List<ContactModel> GetAllContact()
        {
            try {
            Connect();
            List<ContactModel> getAllcontact = new List<ContactModel>();


            SqlCommand command = new SqlCommand("SPA_Contact", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataadapter = new SqlDataAdapter(command);
            DataTable datatable = new DataTable();

            connection.Open();
            dataadapter.Fill(datatable);

            foreach (DataRow dr in datatable.Rows)
            {
                getAllcontact.Add(

                    new ContactModel
                    {
                        Name = Convert.ToString(dr["name"]),
                        Email = Convert.ToString(dr["email"]),
                        Message = Convert.ToString(dr["message"])

                    }
                    );
                }
                return getAllcontact;
            }
            finally
            {
                connection.Close();
            }

           
        }

    }
}