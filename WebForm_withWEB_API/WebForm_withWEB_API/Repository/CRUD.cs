using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebForm_withWEB_API.Model;

namespace WebForm_withWEB_API.Repository
{
    public class CRUD
    {
        private SqlConnection connection;
        public void connect()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            connection = new SqlConnection(connectionString);
        }
        public bool Insert(User user)
        {
            
            connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("SPI_details", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", user.UserName);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Country", user.Country);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public List<User> GetAll()
        {
            try
            {
                connect();
                List<User> getAllcontact = new List<User>();


                SqlCommand command = new SqlCommand("SPs_details", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataadapter = new SqlDataAdapter(command);
                DataTable datatable = new DataTable();

                connection.Open();
                dataadapter.Fill(datatable);

                foreach (DataRow dr in datatable.Rows)
                {
                    getAllcontact.Add(

                        new User
                        {
                            Id = Convert.ToInt32(dr["userid"]),
                            UserName = Convert.ToString(dr["username"]),
                            Password = Convert.ToString(dr["password"]),
                            Country = Convert.ToString(dr["country"]),
                            Email = Convert.ToString(dr["email"])

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
        public List<User> Getone(int id)
        {
            try
            {
                connect();
                List<User> getAllcontact = new List<User>();


                SqlCommand command = new SqlCommand("SPO_details", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userid", id);
                SqlDataAdapter dataadapter = new SqlDataAdapter(command);
                DataTable datatable = new DataTable();

                connection.Open();
                dataadapter.Fill(datatable);

                foreach (DataRow dr in datatable.Rows)
                {
                    getAllcontact.Add(

                        new User
                        {
                            Id = Convert.ToInt32(dr["userid"]),
                            UserName = Convert.ToString(dr["username"]),
                            Password = Convert.ToString(dr["password"]),
                            Country = Convert.ToString(dr["country"]),
                            Email = Convert.ToString(dr["email"])

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
        public bool Update(User user)
        {
            connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("SPu_details", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Userid", user.Id);
            cmd.Parameters.AddWithValue("@UserName", user.UserName);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Country", user.Country);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool Delete(User user)
        {
            connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("SPD_deatils", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Userid", user.Id);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}