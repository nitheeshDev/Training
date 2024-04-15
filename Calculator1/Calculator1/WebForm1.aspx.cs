using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calculator1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string selectedOperation = DropDownList1.SelectedValue;

            ServiceReference2.CalculationSoapClient addRequest = new ServiceReference2.CalculationSoapClient();
            if(selectedOperation == "Addition")
            {
                int result1 = addRequest.Addition(Convert.ToInt32(Text1.Text),
                Convert.ToInt32(Text2.Text));
                Result.Text = result1.ToString();

                //GridView1.DataSource = addRequest.GetCalculations();
                //GridView1.DataBind();
                //GridView1.HeaderRow.Cells[0].Text = "Recent Calculations";
            }
            else if(selectedOperation == "Subtraction")
            {
                int result2 = addRequest.Subtraction(Convert.ToInt32(Text1.Text),
                Convert.ToInt32(Text2.Text));
                Result.Text = result2.ToString();
            }
            else if (selectedOperation == "Muliplication")
            {
                int result3 = addRequest.Muliplication(Convert.ToInt32(Text1.Text),
            Convert.ToInt32(Text2.Text));
                Result.Text = result3.ToString();
            }
            else
            {
                int result4 = addRequest.Division(Convert.ToInt32(Text1.Text),
            Convert.ToInt32(Text2.Text));
                Result.Text = result4.ToString();
            }
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}