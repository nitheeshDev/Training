using System.Web;
using System.Web.Mvc;

namespace Doctor_Appointment_Booking
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
