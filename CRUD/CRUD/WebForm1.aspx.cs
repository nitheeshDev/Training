using CRUD.ServiceReference2;
using System;
using System.Data;

namespace CRUD
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ServiceReference1.Service1Client objService = new ServiceReference1.Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }

        }

        private void BindGridView()
        {
            DataSet ds = objService.SelectUserDetails();
            if (ds != null && ds.Tables.Count > 0)
            {
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            else
            {
                // Handle the case where no data is returned.
            }
        }
        ServiceReference2.Service1Client obj = new ServiceReference2.Service1Client();
        protected void Button1_Click1(object sender, EventArgs e)
        {
            
            Insert objuserdetail = new Insert();
            objuserdetail.Username = TextBox1.Text;
            objuserdetail.Password = TextBox2.Text;
            objuserdetail.Country = TextBox3.Text;
            objuserdetail.Email = TextBox4.Text;

            string message = obj.Insert(objuserdetail);
            Label5.Text = message;

            BindGridView();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Update objuserdetail = new Update();
            objuserdetail.Username = TextBox1.Text;
            objuserdetail.Password = TextBox2.Text;
            objuserdetail.Country = TextBox3.Text;
            objuserdetail.Email = TextBox4.Text;

            string message = obj.Update(objuserdetail);
            Label5.Text = message;

            BindGridView();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Delete objuserdetail = new Delete();
            objuserdetail.Username = TextBox1.Text;
            string message = obj.Delete(objuserdetail);
            Label5.Text = message;

            BindGridView();
        }

     
    }
}
