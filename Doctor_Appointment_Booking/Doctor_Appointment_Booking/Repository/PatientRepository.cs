using Doctor_Appointment_Booking.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Doctor_Appointment_Booking.Repository
{
    public class PatientRepository
    {
        public SqlConnection connection;
        public object admin;

        public void Connect()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            connection = new SqlConnection(connectionstring);

        }
        /// <summary>
        /// insert patient and validate
        /// </summary>

        int i = 0;
        public bool Insert_Patient(PatientModel patientModel, string username, string id)
        {
            Connect();
            string status = "Waiting";
            int dateExists = 0;
            int timeExists = 0;
            int doctor = 0;

            try
            {
                using (SqlCommand doctorCommand = new SqlCommand("SP_ValidateDoctor", connection))
                {

                    doctorCommand.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using(SqlDataReader doctorReader = doctorCommand.ExecuteReader())
                    { 
                        while(doctorReader.Read())
                        {
                            string doctorid = doctorReader["docid"] != DBNull.Value ? (string)doctorReader["docid"] : null;
                            if (doctorid == id) 
                            {
                                doctor = 1;
                            }
                        }
                        doctorReader.Close();
                        if(doctor==1)
                        { 
                    using (SqlCommand dateCommand = new SqlCommand("SP_Date", connection))
                    {
                        dateCommand.CommandType = CommandType.StoredProcedure;
                                dateCommand.Parameters.AddWithValue("@docid", id);


                                using (SqlDataReader dateReader = dateCommand.ExecuteReader())
                                {
                                    while (dateReader.Read())
                                    {
                                        object dbVisitDateObj = dateReader["visitdate"];
                                        DateTime? dbVisitDate = dbVisitDateObj == DBNull.Value ? null : (DateTime?)dbVisitDateObj;

                                        if (dbVisitDate == patientModel.visitDate)
                                        {
                                            dateExists = 1;
                                            break;
                                        }
                                    }
                                    dateReader.Close();
                                }
                            if (dateExists == 1)
                            {
                                using (SqlCommand timeCommand = new SqlCommand("SP_Time", connection))
                                {
                                    timeCommand.CommandType = CommandType.StoredProcedure;

                                        timeCommand.Parameters.AddWithValue("@visitdate", patientModel.visitDate);

                                    using (SqlDataReader timeReader = timeCommand.ExecuteReader())
                                    {
                                        patientModel.VisitTime = patientModel.VisitTime + ":00.0000000";
                                        while (timeReader.Read())
                                        {
                                            //object dbVisitTimeObj = timeReader["visittime"];
                                            //string dbVisitTime = dbVisitTimeObj == DBNull.Value ? null : dbVisitTimeObj.ToString();

                                            string dbVisitTime = (string)timeReader["visittime"];


                                            if (dbVisitTime == patientModel.VisitTime)
                                            {
                                                timeExists = 1;
                                                break;
                                            }
                                        }
                                        timeReader.Close();


                                    }
                                }
                            }
                        }
                    }
                }
                }
                if (timeExists != 1 && dateExists == 1 && doctor ==1)
                {
                    using (SqlCommand insertCommand = new SqlCommand("SPI_patient", connection))
                    {
                        insertCommand.CommandType = CommandType.StoredProcedure;

                        insertCommand.Parameters.AddWithValue("@Email", username);
                        insertCommand.Parameters.AddWithValue("@patientissue", patientModel.patientissue);
                        insertCommand.Parameters.AddWithValue("@visitdate", patientModel.visitDate);
                        insertCommand.Parameters.AddWithValue("@visittime", patientModel.VisitTime);
                        insertCommand.Parameters.AddWithValue("@status", status);
                        insertCommand.Parameters.AddWithValue("@docid", id);

                        i = insertCommand.ExecuteNonQuery();
                    }
                }
                else if (timeExists != 1 && dateExists != 1 && doctor == 1)
                {
                    using (SqlCommand insertCommand = new SqlCommand("SPI_patient", connection))
                    {
                        insertCommand.CommandType = CommandType.StoredProcedure;

                        insertCommand.Parameters.AddWithValue("@Email", username);
                        insertCommand.Parameters.AddWithValue("@patientissue", patientModel.patientissue);
                        insertCommand.Parameters.AddWithValue("@visitdate", patientModel.visitDate);
                        insertCommand.Parameters.AddWithValue("@visittime", patientModel.VisitTime);
                        insertCommand.Parameters.AddWithValue("@status", status);
                        insertCommand.Parameters.AddWithValue("@docid", id);

                        i = insertCommand.ExecuteNonQuery();
                    }
                }
                else if(doctor==0)
                {
                    using (SqlCommand insertCommand = new SqlCommand("SPI_patient", connection))
                    {
                        insertCommand.CommandType = CommandType.StoredProcedure;

                        insertCommand.Parameters.AddWithValue("@Email", username);
                        insertCommand.Parameters.AddWithValue("@patientissue", patientModel.patientissue);
                        insertCommand.Parameters.AddWithValue("@visitdate", patientModel.visitDate);
                        insertCommand.Parameters.AddWithValue("@visittime", patientModel.VisitTime);
                        insertCommand.Parameters.AddWithValue("@status", status);
                        insertCommand.Parameters.AddWithValue("@docid", id);

                        i = insertCommand.ExecuteNonQuery();
                    }
                }
               
                connection.Close();
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
        public int get()
        {

            return i;
        }
        /// <summary>
        /// Get all patient
        /// </summary>
        /// <param name="doctorid"></param>
        /// <returns></returns>
        public List<PatientModel> GetAllPatient(string doctorid)
        {
            try
            {
                Connect();
                List<PatientModel> getAllParient = new List<PatientModel>();


                SqlCommand command = new SqlCommand("SP_SelectPatient", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@docid", doctorid);
                SqlDataAdapter dataadapter = new SqlDataAdapter(command);
                DataTable datatable = new DataTable();

                connection.Open();
                dataadapter.Fill(datatable);
               

                foreach (DataRow dr in datatable.Rows)
                {
                    getAllParient.Add(

                        new PatientModel
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Username = Convert.ToString(dr["email"]),
                            patientissue = Convert.ToString(dr["patientIssue"]),
                            visitDate = Convert.ToDateTime(dr["visitDate"]),
                            VisitTime = Convert.ToString(dr["visittime"]),
                            doctorSpecialitty = Convert.ToString(dr["doctorSpecialitty"]),
                            Status = Convert.ToString(dr["Status"]),
                            DocId = Convert.ToString(dr["docid"])
                        }
                        );
                }

                return getAllParient;
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Get approval patient
        /// </summary>
        /// <param name="doctorid"></param>
        /// <returns></returns>
        public List<PatientModel> GetApprovalPatient(string doctorid)
        {
            try { 
            Connect();
            List<PatientModel> getAllParient = new List<PatientModel>();


            SqlCommand command = new SqlCommand("SP_SelectapprovalPatient", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@docid", doctorid);
            SqlDataAdapter dataadapter = new SqlDataAdapter(command);
            DataTable datatable = new DataTable();

            connection.Open();
            dataadapter.Fill(datatable);
            

            foreach (DataRow dr in datatable.Rows)
            {
                getAllParient.Add(

                    new PatientModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Username = Convert.ToString(dr["email"]),
                        patientissue = Convert.ToString(dr["patientIssue"]),
                        visitDate = Convert.ToDateTime(dr["visitDate"]),
                        VisitTime = Convert.ToString(dr["visittime"]),
                        doctorSpecialitty = Convert.ToString(dr["doctorSpecialitty"]),
                        Status = Convert.ToString(dr["Status"]),
                        DocId = Convert.ToString(dr["docid"])
                    }
                    );
            }

            return getAllParient;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool DeletePatient(int Id)
        {

            Connect();
            SqlCommand command = new SqlCommand("SPDelete_patient", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", Id);

            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
     /// <summary>
     /// Update patient
     /// </summary>
     /// <param name="status"></param>
     /// <param name="username"></param>
     /// <returns></returns>
            public bool UpdatePatientStatus(string status,string username)
        {
            try { 
                Connect();
                
                    using (SqlCommand command = new SqlCommand("SPU_status", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@email", username);
                        command.Parameters.AddWithValue("@status", status);

                        connection.Open();
                        int i = command.ExecuteNonQuery();
                if(i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                    
                }
            }
            finally
            {
                connection.Close() ;
            }
            }
        /// <summary>
        /// get status
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public List<PatientModel> GetStatus(string username)
        {
            try { 
            Connect();
            List<PatientModel> getAllParient = new List<PatientModel>();


            SqlCommand command = new SqlCommand("SP_GetStatus", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@email",username);
            SqlDataAdapter dataadapter = new SqlDataAdapter(command);
            DataTable datatable = new DataTable();

            connection.Open();
            dataadapter.Fill(datatable);
            connection.Close();

            foreach (DataRow dr in datatable.Rows)
            {
                getAllParient.Add(

                    new PatientModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Username = Convert.ToString(dr["email"]),
                        patientissue = Convert.ToString(dr["patientIssue"]),
                        visitDate = Convert.ToDateTime(dr["visitDate"]),
                        VisitTime = Convert.ToString(dr["visittime"]),
                        doctorSpecialitty = Convert.ToString(dr["doctorSpecialitty"]),
                        Status = Convert.ToString(dr["Status"]),
                        DocId = Convert.ToString(dr["docid"])
                    }
                    );
            }

            return getAllParient;
            }
            finally { connection.Close(); }
        }

    }

    }
