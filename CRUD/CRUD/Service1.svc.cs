using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CRUD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public DataSet SelectUserDetails()
        {
            SqlConnection con = new SqlConnection("Data Source=SYSLP948;Initial Catalog=WCF;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from wcf", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }
        public void UpdateRegistrationTable(UserDetails userInfo)
        {
            SqlConnection con = new SqlConnection("Data Source=SYSLP948;Initial Catalog=WCF;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update wcf set UserName=@UserName,Password=@Password,Country=@Country, Email=@Email where UserID=@UserID", con);
            cmd.Parameters.AddWithValue("@UserID", userInfo.UserID);
            cmd.Parameters.AddWithValue("@UserName", userInfo.UserName);
            cmd.Parameters.AddWithValue("@Password", userInfo.Password);
            cmd.Parameters.AddWithValue("@Country", userInfo.Country);
            cmd.Parameters.AddWithValue("@Email", userInfo.Email);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public bool DeleteUserDetails(UserDetails userInfo)
        {
            SqlConnection con = new SqlConnection("Data Source=SYSLP948;Initial Catalog=WCF;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from wcf where UserID=@UserID", con);
            cmd.Parameters.AddWithValue("@UserID", userInfo.UserID);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
       public string InsertUserDetails()
        {
            UserDetails userInfo = new UserDetails();
            SqlConnection con = new SqlConnection("Data Source=SYSLP948;Initial Catalog=WCF;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into wcf(UserName,Password,Country,Email) values(@UserName,@Password,@Country,@Email)", con);
            cmd.Parameters.AddWithValue("@UserName", userInfo.UserName);
            cmd.Parameters.AddWithValue("@Password", userInfo.Password);
            cmd.Parameters.AddWithValue("@Country", userInfo.Country);
            cmd.Parameters.AddWithValue("@Email", userInfo.Email);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            
            if (result == 1)
            {
                return userInfo.UserName + " Details inserted successfully";
            }
            else
            {
                return userInfo.UserName + " Details not inserted successfully";
            }
        }

    }
}