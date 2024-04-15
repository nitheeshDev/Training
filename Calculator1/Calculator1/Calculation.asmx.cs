using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Calculator1
{
    /// <summary>
    /// Summary description for Calculation
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Calculation : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public int Addition(int x,int y)
        {
            int sum1 = x + y;
            return sum1;
            //List<string> calculations;

            //if (Session["CALCULATIONS"] == null)
            //{
            //    calculations = new List<string>();
            //}
            //else
            //{
            //    calculations = (List<string>)Session["CALCULATIONS"];
            //}
            //string sum = x.ToString() + "+"+ y.ToString() + "=" +(x+y).ToString();
            //calculations.Add(sum);
            //Session["CALCULATIONS"] = calculations;
            
        }
        [WebMethod(EnableSession = true)]
        public List<string> GetCalculations()
        {
            if (Session["CALCULATIONS"] == null)
            {
                List<string> calculations = new List<string>();
                calculations.Add("You have not performed any calculations");
                return calculations;
            }
            else
            {
                return (List<string>)Session["CALCULATIONS"];
            }
        }
        [WebMethod]
        public int Subtraction(int x, int y)
        {
            int sum = x - y;
            return sum;
        }
        [WebMethod]
        public int Muliplication(int x, int y)
        {
            int sum = x * y;
            return sum;
        }
        [WebMethod]
        public int Division(int x, int y)
        {
            int sum = x / y;
            return sum;
        }

    }
}
