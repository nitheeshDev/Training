using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Helllowebclient
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebSoapClient webSoapClient = new ServiceReference1.WebSoapClient();
            Label1.Text = webSoapClient.HelloWorld(TextBox1.Text);
        }
    }
}