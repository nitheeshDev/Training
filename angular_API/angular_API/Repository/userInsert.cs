using angular_API.Model;
using System.Data;
using System.Data.SqlClient;

namespace angular_API.Repository
{
    public class userInsert
    {
        private readonly IConfiguration _configuration;
        private SqlConnection connection;

        public userInsert(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Connect()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            connection = new SqlConnection(connectionString);
        }
        public bool Insert(Register user)
        {

            Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("usp_InsertBankRegistration", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@first_name", user.first_name);
            cmd.Parameters.AddWithValue("@last_name", user.last_name);
            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.Parameters.AddWithValue("@password", user.password);
            cmd.Parameters.AddWithValue("@phone", user.phone);
            cmd.Parameters.AddWithValue("@address", user.address);
            cmd.Parameters.AddWithValue("@city", user.city);
            cmd.Parameters.AddWithValue("@state", user.state);
            cmd.Parameters.AddWithValue("@zip", user.zip);
            cmd.Parameters.AddWithValue("@account_type", user.account_type);
            cmd.Parameters.AddWithValue("@initial_deposit", user.initial_deposit);
            

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
        public bool update(Register user,int id)
        {

            Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("usp_InsertBankRegistration", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@first_name",id);
            cmd.Parameters.AddWithValue("@first_name", user.first_name);
            cmd.Parameters.AddWithValue("@last_name", user.last_name);
            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.Parameters.AddWithValue("@password", user.password);
            cmd.Parameters.AddWithValue("@phone", user.phone);
            cmd.Parameters.AddWithValue("@address", user.address);
            cmd.Parameters.AddWithValue("@city", user.city);
            cmd.Parameters.AddWithValue("@state", user.state);
            cmd.Parameters.AddWithValue("@zip", user.zip);
            cmd.Parameters.AddWithValue("@account_type", user.account_type);
            cmd.Parameters.AddWithValue("@initial_deposit", user.initial_deposit);


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

        public List<Register> get()
        {
            Connect();
            List<Register> getAll = new List<Register>();
            //Register obj1 = new Register();
            SqlCommand command = new SqlCommand("SPA_getDeatails", connection);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@id",id);
            SqlDataAdapter dataadapter = new SqlDataAdapter(command);
            DataTable datatable = new DataTable();

            connection.Open();
            dataadapter.Fill(datatable);
            connection.Close();

            foreach (DataRow dr in datatable.Rows)
            {
                Register obj = new Register
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    first_name = Convert.ToString(dr["first_name"]),
                    last_name = Convert.ToString(dr["last_name"]),
                    email = Convert.ToString(dr["email"]),
                    password = Convert.ToString(dr["password"]),
                    phone = Convert.ToString(dr["phone"]),
                    address = Convert.ToString(dr["address"]),
                    city = Convert.ToString(dr["city"]),
                    state = Convert.ToString(dr["state"]),
                    zip = Convert.ToString(dr["zip"]),
                    account_type = Convert.ToString(dr["account_type"]),
                    initial_deposit = Convert.ToInt32(dr["initial_deposit"])
                };
                getAll.Add(obj);
            }

            return getAll;
        }
        public bool Del(int id)
        {

            Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("SPD_user", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
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
