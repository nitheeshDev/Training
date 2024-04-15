using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAPI.Models;

namespace WebAPI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            User newUser = new User
            {
                Username = TextBox1.Text,
                Password = TextBox2.Text,
                Email = TextBox4.Text,
                Country = TextBox3.Text
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44390/api/values");

                var response = client.PostAsJsonAsync("api/ValuesController", newUser).Result;

                if (response.IsSuccessStatusCode)
                {
                    Label1.Text = "Data successfully added";
                }
                else
                {
                    Label1.Text = "Data not successfully added";
                }
            }
        }
    }
}