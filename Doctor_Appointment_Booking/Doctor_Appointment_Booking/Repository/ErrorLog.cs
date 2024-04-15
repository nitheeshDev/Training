using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Doctor_Appointment_Booking.Repository
{
    public class ErrorLog
    {
        public ErrorLog(Exception ex) 
        {
            string logFilePath = "C:\\Users\\Admin\\Desktop\\Code\\ErrorLog.txt";

            try
            {
                
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"Timestamp: {DateTime.Now}");
                    writer.WriteLine($"Error Message: {ex.Message}");
                    writer.WriteLine($"Stack Trace: {ex.StackTrace}");
                    writer.WriteLine("---------------------------------------------------");
                }
            }
            catch
            {
                
            }
        }
    }
    
}