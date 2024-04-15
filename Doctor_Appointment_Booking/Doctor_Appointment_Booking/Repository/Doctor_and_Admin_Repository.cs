using Doctor_Appointment_Booking.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Web;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;
using System.Linq;

namespace Doctor_Appointment_Booking.Repository
{
    public class Doctor_and_Admin_Repository
    {
        public SqlConnection connection;
        public object admin;
       
        private void Connect()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            connection = new SqlConnection(connectionstring);

        }

        int i = 0;
        int j= 0;
        int z = 0;
        public bool DoctorInsert(Doctor_Register_Model doctor_Register_Model,HttpPostedFileBase imageFile,string Password)
        {
            try
            {
                Connect();
                connection.Open();

               
                if (imageFile != null && imageFile.ContentLength > 0)
                {
                   
                    int maxFileSizeInBytes = 1 * 1024 * 1024;
                    if (imageFile.ContentLength > maxFileSizeInBytes)
                    {
                        j = 1;
                       
                    }

                   
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
                    string fileExtension = Path.GetExtension(imageFile.FileName).ToLower();
                    if (j!=1&&!allowedExtensions.Contains(fileExtension))
                    {
                        z = 1;
                       
                    }
                }
           

                if (z != 1&&j!=1&&i!=1) {
                string Role = "Doctor";
                SqlCommand command = new SqlCommand("SPI_Doctor", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Role", Role);
                command.Parameters.AddWithValue("@Fullname", doctor_Register_Model.fullName);
                command.Parameters.AddWithValue("@doctorID", doctor_Register_Model.doctorID);
                command.Parameters.AddWithValue("@doctorSpecilization", doctor_Register_Model.doctorSpecialization);
                command.Parameters.AddWithValue("@gender", doctor_Register_Model.Gender);
                command.Parameters.AddWithValue("@DOB", doctor_Register_Model.DateOfBirth);
                command.Parameters.AddWithValue("@address", doctor_Register_Model.Address);
                command.Parameters.AddWithValue("@Email", doctor_Register_Model.Email);
                command.Parameters.AddWithValue("@contactnumber", doctor_Register_Model.contactNumber);
                command.Parameters.AddWithValue("@Password", Encrypt(Password));
                doctor_Register_Model.Profile = ConvertToBytes(imageFile);
                command.Parameters.AddWithValue("@Profile", doctor_Register_Model.Profile);

                i = command.ExecuteNonQuery();
                }
                else { return false; }
            }
            
            finally
            {
                connection.Close();
            }

            return i >= 1;
        }
        public int getemail()
        {
            return i;
        }
        public int size()
        {
            return j;
        }
        public int fileextenssions()
        {
            return z;
        }
        private byte[] ConvertToBytes(HttpPostedFileBase imageFile)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(imageFile.InputStream);
            imageBytes = reader.ReadBytes((int)imageFile.ContentLength);
            return imageBytes;
        }

       
    

    /// <summary>
    /// Getall doctor
    /// </summary>
    /// <returns></returns>
    public List<Doctor_Register_Model> GetAllDoctor()
        {
            try
            {
                Connect();
                List<Doctor_Register_Model> getAllDoctor = new List<Doctor_Register_Model>();
                Doctor_Register_Model obj1 = new Doctor_Register_Model();
                SqlCommand command = new SqlCommand("SPA_doctor", connection);
                command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.AddWithValue("@id",id);
                SqlDataAdapter dataadapter = new SqlDataAdapter(command);
                DataTable datatable = new DataTable();

                connection.Open();
                dataadapter.Fill(datatable);
                connection.Close();

                foreach (DataRow dr in datatable.Rows)
                {
                    Doctor_Register_Model obj = new Doctor_Register_Model
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        fullName = Convert.ToString(dr["Fullname"]),
                        Gender = Convert.ToString(dr["Genter"]),
                        DateOfBirth = Convert.ToDateTime(dr["Dob"]),
                        doctorID = Convert.ToString(dr["doctorid"]),
                        doctorSpecialization = Convert.ToString(dr["doctorSpecilization"]),
                        Address = Convert.ToString(dr["Address"]),
                        Email = Convert.ToString(dr["Email"]),
                        contactNumber = Convert.ToString(dr["Contactnumber"]),
                        Profile = dr["profile"] != DBNull.Value ? (byte[])dr["profile"] : null



                    };



                    getAllDoctor.Add(obj);
                }

                return getAllDoctor;
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Get one doctor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Doctor_Register_Model> GetOneDoctor(int id)
        {
            try
            {
                Connect();
                List<Doctor_Register_Model> getAllDoctor = new List<Doctor_Register_Model>();
                Doctor_Register_Model obj1 = new Doctor_Register_Model();
                SqlCommand command = new SqlCommand("SPO_Doctor", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                SqlDataAdapter dataadapter = new SqlDataAdapter(command);
                DataTable datatable = new DataTable();

                connection.Open();
                dataadapter.Fill(datatable);
                connection.Close();

                foreach (DataRow dr in datatable.Rows)
                {
                    Doctor_Register_Model obj = new Doctor_Register_Model
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        fullName = Convert.ToString(dr["Fullname"]),
                        Gender = Convert.ToString(dr["Genter"]),
                        DateOfBirth = Convert.ToDateTime(dr["Dob"]),
                        doctorID = Convert.ToString(dr["doctorid"]),
                        doctorSpecialization = Convert.ToString(dr["doctorSpecilization"]),
                        Address = Convert.ToString(dr["Address"]),
                        Email = Convert.ToString(dr["Email"]),
                        contactNumber = Convert.ToString(dr["Contactnumber"]),
                        Password = Decrypt(dr["Password"]),
                        Profile = dr["profile"] != DBNull.Value ? (byte[])dr["profile"] : null
                    };

                    getAllDoctor.Add(obj);
                }

                return getAllDoctor;
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Edit doctor
        /// </summary>
        /// <param name="doctor_Register_Model"></param>
        /// <param name="imageFile"></param>
        /// <param name="id"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool EditDoctor(Doctor_Register_Model doctor_Register_Model, HttpPostedFileBase imageFile, int id, string Password)
        {
            try
            {
                Connect();
                //string Role = "User";
                SqlCommand comment = new SqlCommand("SPU_Doctor", connection);
                comment.CommandType = System.Data.CommandType.StoredProcedure;
                //comment.Parameters.AddWithValue("@Role", Role);
                comment.Parameters.AddWithValue("@id", id);
                comment.Parameters.AddWithValue("@Fullname", doctor_Register_Model.fullName);
                comment.Parameters.AddWithValue("@doctorid", doctor_Register_Model.doctorID);
                comment.Parameters.AddWithValue("@doctorSpecilization", doctor_Register_Model.doctorSpecialization);
                comment.Parameters.AddWithValue("@gender", doctor_Register_Model.Gender);
                comment.Parameters.AddWithValue("@dob", doctor_Register_Model.DateOfBirth);
                comment.Parameters.AddWithValue("@Address", doctor_Register_Model.Address);
                comment.Parameters.AddWithValue("@contactnumber", doctor_Register_Model.contactNumber);
                comment.Parameters.AddWithValue("@Email", doctor_Register_Model.Email);
                comment.Parameters.AddWithValue("@Password", Encrypt(Password));
                doctor_Register_Model.Profile = ConvertToBytes(imageFile);
                comment.Parameters.AddWithValue("@Profile", doctor_Register_Model.Profile);

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

    //delete doctor

    public bool DeleteDoctor(Doctor_Register_Model doctor_Register_Model,int id)
        {
            try {
            Connect();
            //string Role = "User";
            SqlCommand comment = new SqlCommand("SPD_doctor", connection);
            comment.CommandType = System.Data.CommandType.StoredProcedure;
            comment.Parameters.AddWithValue("@id",id);
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
        /// admin insert
        /// </summary>
        /// <param name="adminModel"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        //admin
        public bool adminInsert(AdminModel adminModel, string Password)
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
                            string em = emailReader["email"] != DBNull.Value ? (string)emailReader["email"] : null;
                            if (em == adminModel.Email)
                            {
                                email = 1;
                            }
                        }
                        emailReader.Close();
                    }
                }
                if (email != 1)
                {
                    string Role = "Admin";
                    SqlCommand command = new SqlCommand("SPI_Admin", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Role", Role);
                    command.Parameters.AddWithValue("@Fullname", adminModel.fullName);
                    command.Parameters.AddWithValue("@contactnumber", adminModel.contactNumber);
                    command.Parameters.AddWithValue("@Email", adminModel.Email);
                    command.Parameters.AddWithValue("@Password", Encrypt(Password));

                    i = command.ExecuteNonQuery();
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
       
        /// <summary>
        /// edit admin
        /// </summary>
        /// <param name="adminModel"></param>
        /// <param name="id"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
    public bool EditAdmin(AdminModel adminModel,int id,string Password)
        {
            try
            {
                Connect();
                //string Role = "User";
                SqlCommand comment = new SqlCommand("SPU_Admin", connection);
                comment.CommandType = System.Data.CommandType.StoredProcedure;
                //comment.Parameters.AddWithValue("@Role", Role);
                comment.Parameters.AddWithValue("@id", id);
                comment.Parameters.AddWithValue("@Fullname", adminModel.fullName);
                comment.Parameters.AddWithValue("@contactnumber", adminModel.contactNumber);
                comment.Parameters.AddWithValue("@email", adminModel.Email);
                comment.Parameters.AddWithValue("@Password", Encrypt(Password));

                connection.Open();
                int i = comment.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                {
                    return true;
                }
                else { return false; }
            }
            finally { connection.Close(); }

        }
        /// <summary>
        /// get one admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<AdminModel> GetoneAdmin(int id)
        {
            try
            {
                Connect();
                List<AdminModel> getAllAdmin = new List<AdminModel>();


                SqlCommand command = new SqlCommand("SPO_Admin", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                SqlDataAdapter dataadapter = new SqlDataAdapter(command);
                DataTable datatable = new DataTable();

                connection.Open();
                dataadapter.Fill(datatable);
                connection.Close();

                foreach (DataRow dr in datatable.Rows)
                {
                    getAllAdmin.Add(

                        new AdminModel
                        {
                            Id = Convert.ToInt32(dr["ID"]),
                            fullName = Convert.ToString(dr["Fullname"]),
                            Email = Convert.ToString(dr["Email"]),
                            contactNumber = Convert.ToString(dr["Contactnumber"]),
                            Password = Decrypt(dr["Password"])
                        }
                        );
                }

                return getAllAdmin;
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// get all admin
        /// </summary>
        /// <returns></returns>
        public List<AdminModel> GetAllAdmin()
        {
            try
            {

                Connect();
                List<AdminModel> getAllAdmin = new List<AdminModel>();


                SqlCommand command = new SqlCommand("SPA_Admin", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataadapter = new SqlDataAdapter(command);
                DataTable datatable = new DataTable();

                connection.Open();
                dataadapter.Fill(datatable);
                connection.Close();

                foreach (DataRow dr in datatable.Rows)
                {
                    getAllAdmin.Add(

                        new AdminModel
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Role = Convert.ToString(dr["role"]),
                            fullName = Convert.ToString(dr["Fullname"]),
                            Email = Convert.ToString(dr["Email"]),
                            contactNumber = Convert.ToString(dr["Contactnumber"]),

                            //Confirmpassword = Convert.ToString(dr["Confirmpassword"])
                        }
                        );
                }

                return getAllAdmin;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// delete admin
        /// </summary>
        /// <param name="adminModel"></param>
        /// <returns></returns>
        public bool DeleteAdmin(AdminModel adminModel)
        {
            try { 
            Connect();
            //string Role = "User";
            SqlCommand comment = new SqlCommand("SPD_Admin", connection);
            comment.CommandType = System.Data.CommandType.StoredProcedure;
            comment.Parameters.AddWithValue("@id", adminModel.Id);
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

    }
}
