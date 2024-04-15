using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForm_withWEB_API.Model;

namespace WebForm_withWEB_API
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGridView();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            User newUser = new User();
            newUser.UserName= TextBox1.Text;
            newUser.Password= TextBox2.Text;
            newUser.Email= TextBox4.Text;
            newUser.Country= TextBox3.Text;

            
            ValuesController1 valuesController1 = new ValuesController1();
            valuesController1.Post(newUser);
            BindGridView();
        }


        private void BindGridView()
        {
            ValuesController1 valuesController1 = new ValuesController1();
            List<User> users = valuesController1.Get();

            GridView1.DataSource = users;
            GridView1.DataBind();
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            User newUser = new User();
            newUser.Id = int.Parse(TextBox5.Text);
            newUser.UserName = TextBox1.Text;
            newUser.Password = TextBox2.Text;
            newUser.Email = TextBox4.Text;
            newUser.Country = TextBox3.Text;


            ValuesController1 valuesController1 = new ValuesController1();
            valuesController1.Put(newUser);
            BindGridView();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            User newUser = new User();
            newUser.Id = int.Parse(TextBox5.Text);
            newUser.UserName = TextBox1.Text;
            newUser.Password = TextBox2.Text;
            newUser.Email = TextBox4.Text;
            newUser.Country = TextBox3.Text;
            ValuesController1 valuesController1 = new ValuesController1();
            valuesController1.Delete(newUser);
            BindGridView();
        }

    }
}