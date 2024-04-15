using Doctor_Appointment_Booking.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Doctor_Appointment_Booking.Repository
{
    public class LoginRepository
    {
        private SqlConnection connection;

        private void Connect()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            connection = new SqlConnection(connectionString);
        }
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginModel"></param>
        /// <param name="errorMessage"></param>
        /// <param name="username"></param>
        /// <param name="role"></param>
        /// <param name="id"></param>
        /// <param name="doctorSpecilization"></param>
        /// <param name="fullname"></param>
        /// <param name="doctorid"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool Login(LoginModel loginModel, out string errorMessage, out string username, out string role, out int id, out string doctorSpecilization, out string fullname, out string doctorid, string Password)
        {


            try
            {
                Connect();
                SqlCommand command = new SqlCommand("SP_Login", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@email", loginModel.Username);
                command.Parameters.AddWithValue("@password", Encrypt(Password));

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    username = loginModel.Username;
                    role = reader["role"].ToString();
                    id = Convert.ToInt32(reader["id"]);
                    doctorSpecilization = reader["doctorSpecilization"].ToString();
                    fullname = reader["fullname"].ToString();
                    doctorid = reader["doctorid"].ToString();


                    FormsAuthentication.SetAuthCookie(username, true);

                    errorMessage = null;
                    HttpContext.Current.Session["username"] = username;
                    HttpContext.Current.Session["id"] = id;
                    HttpContext.Current.Session["doctorSpecilization"] = doctorSpecilization;
                    HttpContext.Current.Session["doctorid"] = doctorid;
                    HttpContext.Current.Session["fullname"] = fullname;
                

                    return true;
                }
                else
                {
                    role = null;
                    username = null;
                    id = 0;
                    doctorSpecilization = null;
                    fullname = null;
                    errorMessage = "Invalid username or password.";
                    doctorid = null;
                    return false;
                }
            }
            catch
            {
                role = null;
                username = null;
                id = 0;
                doctorSpecilization = null;
                fullname = null;
                doctorid= null;
                errorMessage = "An error occurred while processing the login request.";
                return false;
            }
            finally
            {
                connection.Close();
            }
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

    }
}
