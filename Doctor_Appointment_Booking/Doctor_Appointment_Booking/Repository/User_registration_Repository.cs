using Doctor_Appointment_Booking.Models;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Doctor_Appointment_Booking.Repository
{
    public class User_registration_Repository
    {
        public SqlConnection connection;
        public object admin;

        private void Connect()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            connection = new SqlConnection(connectionstring);

        }
        int i = 0;

        /// <summary>
        /// User inser
        /// </summary>
        /// <param name="user_Register_Model"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool Insert_user(User_Register_Model user_Register_Model, string Password)
        {

            Connect();
            
            int email = 0;
            try
            {
                using (SqlCommand emailCommand = new SqlCommand("SP_ValidateEmail", connection))
                {

                    emailCommand.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader emailReader = emailCommand.ExecuteReader())
                    {
                        while (emailReader.Read())
                        {
                            string doctorid = emailReader["email"] != DBNull.Value ? (string)emailReader["email"] : null;
                            if (doctorid == user_Register_Model.Email)
                            {
                                email = 1;
                            }
                        }
                        emailReader.Close();
                    }
                }
                if (email != 1)
                {
                    string Role = "User";
                    SqlCommand comment = new SqlCommand("SPI_User", connection);
                    comment.CommandType = CommandType.StoredProcedure;
                    comment.Parameters.AddWithValue("@Role", Role);
                    comment.Parameters.AddWithValue("@Fullname", user_Register_Model.Fullname);
                    comment.Parameters.AddWithValue("@Gender", user_Register_Model.Gender);
                    comment.Parameters.AddWithValue("@DOB", user_Register_Model.DateOfBirth);
                    comment.Parameters.AddWithValue("@age", user_Register_Model.Age);
                    comment.Parameters.AddWithValue("@state", user_Register_Model.State);
                    comment.Parameters.AddWithValue("@city", user_Register_Model.City);
                    comment.Parameters.AddWithValue("@address", user_Register_Model.Address);
                    comment.Parameters.AddWithValue("@Email", user_Register_Model.Email);
                    comment.Parameters.AddWithValue("@contactnumber", user_Register_Model.Contact_number);
                    comment.Parameters.AddWithValue("@Password", Encrypt(Password));


                    i = comment.ExecuteNonQuery();
                    


                }
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
        public int getemail()
        {
            return i;
        }

        /// <summary>
        /// Encrypt
        /// </summary>
        /// <param name="clearText"></param>
        /// <returns></returns>
        public static string Encrypt(string clearText)
        {
            string encryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        /// <summary>
        /// alluser
        /// </summary>
        /// <returns></returns>
        public List<User_Register_Model> GetAllUser()
        {
            try
            {
                Connect();
                List<User_Register_Model> getAllUser = new List<User_Register_Model>();


                SqlCommand command = new SqlCommand("SPA_User", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataadapter = new SqlDataAdapter(command);
                DataTable datatable = new DataTable();

                connection.Open();
                dataadapter.Fill(datatable);
                connection.Close();

                foreach (DataRow dr in datatable.Rows)
                {
                    getAllUser.Add(

                        new User_Register_Model
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Fullname = Convert.ToString(dr["Fullname"]),
                            Gender = Convert.ToString(dr["Genter"]),
                            DateOfBirth = Convert.ToDateTime(dr["Dob"]),
                            Age = Convert.ToInt32(dr["Age"]),
                            State = Convert.ToString(dr["State"]),
                            City = Convert.ToString(dr["City"]),
                            Address = Convert.ToString(dr["Address"]),
                            Email = Convert.ToString(dr["Email"]),
                            Contact_number = Convert.ToString(dr["Contactnumber"]),
                            Password = Convert.ToString(dr["Password"]),
                            //Confirmpassword = Convert.ToString(dr["Confirmpassword"])
                        }
                        );
                }

                return getAllUser;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Getone user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<User_Register_Model> Getoneuser(int id)
        {
            try
            {
                Connect();
                List<User_Register_Model> getAllUser = new List<User_Register_Model>();


                SqlCommand command = new SqlCommand("SPO_User", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                SqlDataAdapter dataadapter = new SqlDataAdapter(command);
                DataTable datatable = new DataTable();

                connection.Open();
                dataadapter.Fill(datatable);
                connection.Close();

                foreach (DataRow dr in datatable.Rows)
                {
                    getAllUser.Add(

                        new User_Register_Model
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Fullname = Convert.ToString(dr["Fullname"]),
                            Gender = Convert.ToString(dr["Genter"]),
                            DateOfBirth = Convert.ToDateTime(dr["Dob"]),
                            Age = Convert.ToInt32(dr["Age"]),
                            State = Convert.ToString(dr["State"]),
                            City = Convert.ToString(dr["City"]),
                            Address = Convert.ToString(dr["Address"]),
                            Email = Convert.ToString(dr["Email"]),
                            Contact_number = Convert.ToString(dr["Contactnumber"]),
                            Password = Decrypt(dr["Password"])
                            //Confirmpassword = Convert.ToString(dr["Confirmpassword"])
                        }
                        );
                }

                return getAllUser;
            }
            finally { connection.Close(); }
        }

        /// <summary>
        /// Decrypt
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        private static string Decrypt(object cipherText)
        {
            string encryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String((string)cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return (string)cipherText;
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteUser(User_Register_Model user_Register_Model,int Id)
        {
            try { 
            Connect();
            SqlCommand command = new SqlCommand("SPD_User", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id",Id );

            connection.Open();
            int i = command.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="user_Register_Model"></param>
        /// <returns></returns>
        public bool Updateuser(User_Register_Model user_Register_Model)
        {
            try { 
            Connect();
            //string Role = "User";
            SqlCommand comment = new SqlCommand("SPU_User", connection);
            comment.CommandType = System.Data.CommandType.StoredProcedure;
            //comment.Parameters.AddWithValue("@Role", Role);
            comment.Parameters.AddWithValue("@id",user_Register_Model.Id);
            comment.Parameters.AddWithValue("@Fullname", user_Register_Model.Fullname);
            comment.Parameters.AddWithValue("@Gender", user_Register_Model.Gender);
            comment.Parameters.AddWithValue("@DOB", user_Register_Model.DateOfBirth);
            comment.Parameters.AddWithValue("@age", user_Register_Model.Age);
            comment.Parameters.AddWithValue("@state", user_Register_Model.State);
            comment.Parameters.AddWithValue("@city", user_Register_Model.City);
            comment.Parameters.AddWithValue("@address", user_Register_Model.Address);
            comment.Parameters.AddWithValue("@Email", user_Register_Model.Email);
            comment.Parameters.AddWithValue("@contactnumber", user_Register_Model.Contact_number);
            

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
        /// Updaate one usser
        /// </summary>
        /// <param name="user_Register_Model"></param>
        /// <param name="id"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool Updateoneuser(User_Register_Model user_Register_Model,int id,string Password)
        {
            try { 
            Connect();
            //string Role = "User";
            SqlCommand comment = new SqlCommand("SPU_User", connection);
            comment.CommandType = System.Data.CommandType.StoredProcedure;
            //comment.Parameters.AddWithValue("@Role", Role);
            comment.Parameters.AddWithValue("@id",id);
            comment.Parameters.AddWithValue("@Fullname", user_Register_Model.Fullname);
            comment.Parameters.AddWithValue("@Gender", user_Register_Model.Gender);
            comment.Parameters.AddWithValue("@DOB", user_Register_Model.DateOfBirth);
            comment.Parameters.AddWithValue("@age", user_Register_Model.Age);
            comment.Parameters.AddWithValue("@state", user_Register_Model.State);
            comment.Parameters.AddWithValue("@city", user_Register_Model.City);
            comment.Parameters.AddWithValue("@address", user_Register_Model.Address);
            comment.Parameters.AddWithValue("@Email", user_Register_Model.Email);
            comment.Parameters.AddWithValue("@contact_number", user_Register_Model.Contact_number);
            comment.Parameters.AddWithValue("@password", Encrypt(Password));

            connection.Open();
            int i = comment.ExecuteNonQuery();
            //connection.Close();
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
    }
}