using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string Insert(Insert insert)
        {
            
            SqlConnection con = new SqlConnection("Data Source=SYSLP948;Initial Catalog=WCF;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into wcf(UserName,Password,Country,Email) values(@UserName,@Password,@Country,@Email)", con);
            cmd.Parameters.AddWithValue("@UserName", insert.Username);
            cmd.Parameters.AddWithValue("@Password", insert.Password);
            cmd.Parameters.AddWithValue("@Country", insert.Country);
            cmd.Parameters.AddWithValue("@Email", insert.Email);
            int result = cmd.ExecuteNonQuery();
            con.Close();

            if (result == 1)
            {
                return insert.Username + " Details inserted successfully";
            }
            else
            {
                return insert.Username + " Details not inserted successfully";
            }
        }
        public string Update(Update update)
        {

            SqlConnection con = new SqlConnection("Data Source=SYSLP948;Initial Catalog=WCF;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update wcf set Password=@Password,Country=@Country, Email=@Email where UserName=@UserName", con);
            cmd.Parameters.AddWithValue("@UserName", update.Username);
            cmd.Parameters.AddWithValue("@Password", update.Password);
            cmd.Parameters.AddWithValue("@Country", update.Country);
            cmd.Parameters.AddWithValue("@Email", update.Email);
            int result =cmd.ExecuteNonQuery();
            con.Close();

            if (result == 1)
            {
                return update.Username + " Details updated successfully";
            }
            else
            {
                return update.Username + " Details not updated successfully";
            }
        }
        public string Delete(Delete delete)
        {

            SqlConnection con = new SqlConnection("Data Source=SYSLP948;Initial Catalog=WCF;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from wcf where Username=@Username", con);
            cmd.Parameters.AddWithValue("@Username", delete.Username);
            
            int result = cmd.ExecuteNonQuery();
            con.Close();

            if (result == 1)
            {
                return delete.Username + " Details deleted successfully";
            }
            else
            {
                return delete.Username + " Details not deleted successfully";
            }
        }
    }
    
}
