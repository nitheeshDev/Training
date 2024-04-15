using API_TO_MVC.Model;
using System.Data;
using System.Data.SqlClient;

namespace API_TO_MVC.Repository
{
    public class studenRepository
    {
        private readonly IConfiguration _configuration;
        private SqlConnection connection;

        public studenRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Connect()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            connection = new SqlConnection(connectionString);
        }

        private byte[] ConvertToBytes(IFormFile imageFile)
        {
            byte[] imageBytes = null;
            using (var memoryStream = new MemoryStream())
            {
                imageFile.CopyTo(memoryStream);
                imageBytes = memoryStream.ToArray();
            }
            return imageBytes;
        }

        public void inserStudent(Register student, IFormFile imageFile)
        {
            Connect();
            SqlCommand cmd = new SqlCommand("SOI_student", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
            cmd.Parameters.AddWithValue("@RollNumber", student.RollNumber);
            cmd.Parameters.AddWithValue("@Level", student.Level);
            cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
            cmd.Parameters.AddWithValue("@Address", student.Address);
            cmd.Parameters.AddWithValue("@ContactNumber", student.ContactNumber);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            cmd.Parameters.AddWithValue("@Password", student.Password);
            using (var memoryStream = new MemoryStream())
            {
                imageFile.CopyTo(memoryStream);
                byte[] imageBytes = memoryStream.ToArray();
                cmd.Parameters.AddWithValue("@Profile", imageBytes);
            }

            connection.Open();
            int result = cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void updateStudent(Register student, IFormFile imageFile, int id)
        {
            Connect();
            SqlCommand cmd = new SqlCommand("SPU_student", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
            cmd.Parameters.AddWithValue("@RollNumber", student.RollNumber);
            cmd.Parameters.AddWithValue("@Level", student.Level);
            cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
            cmd.Parameters.AddWithValue("@Address", student.Address);
            cmd.Parameters.AddWithValue("@ContactNumber", student.ContactNumber);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            cmd.Parameters.AddWithValue("@Password", student.Password);
            using (var memoryStream = new MemoryStream())
            {
                imageFile.CopyTo(memoryStream);
                byte[] imageBytes = memoryStream.ToArray();
                cmd.Parameters.AddWithValue("@Profile", imageBytes);
            }

            connection.Open();
            int result = cmd.ExecuteNonQuery();
            connection.Close();
        }
        public List<Register> getStudents()
        {
            Connect();
            List<Register> getAll = new List<Register>();
            //Register obj1 = new Register();
            SqlCommand command = new SqlCommand("SPS_student", connection);
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
                    StudentName = Convert.ToString(dr["stuedentName"]),
                    RollNumber = Convert.ToString(dr["rollNumber"]),
                    Level = Convert.ToString(dr["level"]),
                    DateOfBirth = Convert.ToDateTime(dr["dateOfBirth"]),
                    Address = Convert.ToString(dr["Address"]),
                    ContactNumber = Convert.ToString(dr["contactNumber"]),
                    Email = Convert.ToString(dr["Email"]),
                    Password = Convert.ToString(dr["Password"]),
                    //Profile = (IFormFile)(dr["profile"] != DBNull.Value ? dr["profile"] : null)
                };
                getAll.Add(obj);
            }

            return getAll;
        }
        public void deleteStudent(int id)
        {
            Connect();
            SqlCommand cmd = new SqlCommand("SPD_student", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            connection.Open();
            int result = cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
