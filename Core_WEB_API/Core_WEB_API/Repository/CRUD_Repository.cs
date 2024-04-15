﻿using NuGet.Protocol.Plugins;
using System.Data.SqlClient;
using System.Data;
using Core_WEB_API.Model;

namespace Core_WEB_API.Repository
{
    public class CRUD_Repository
    {
        private readonly IConfiguration _configuration;
        private SqlConnection connection;

        public CRUD_Repository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Connect()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection1");
            connection = new SqlConnection(connectionString);
        }
        public bool Insert(User user)
        {

            Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("SPI_details", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", user.Username);
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
                Connect();
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
                            Username = Convert.ToString(dr["username"]),
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
                Connect();
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
                            Username = Convert.ToString(dr["username"]),
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
        public bool Update(User user,int id)
        {
            Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("SPu_details", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Userid",id);
            cmd.Parameters.AddWithValue("@UserName", user.Username);
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
        public bool Delete(int id)
        {
            Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("SPD_deatils", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Userid", id);
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
    
