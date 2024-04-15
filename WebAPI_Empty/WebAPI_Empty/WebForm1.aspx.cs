using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAPI_Empty.Controllers;
using WebAPI_Empty.Models;

namespace WebAPI_Empty
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGridView();
        }

        protected void Button1_Click(object sender, EventArgs e)
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
                client.BaseAddress = new Uri("https://localhost:44354/");

                var response = client.PostAsJsonAsync("api/CRUD", newUser).Result;

                if (response.IsSuccessStatusCode)
                {
                    Label1.Text = "Data successfully added";
                    BindGridView();
                }
                else
                {
                    Label1.Text = "Data not successfully added";
                }
            }
        }
        private void BindGridView()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");

                var response = client.GetAsync("api/CRUD").Result;

                if (response.IsSuccessStatusCode)
                {
                    var users = response.Content.ReadAsAsync<IEnumerable<User>>().Result;

                    GridView1.DataSource = users;
                    GridView1.DataBind();
                }
            }
            }

        protected void Button2_Click(object sender, EventArgs e)
        {
            User newUser = new User
            {
                Username = TextBox1.Text,
                Password = TextBox2.Text,
                Email = TextBox4.Text,
                Country = TextBox3.Text,
                Id = int.Parse(TextBox5.Text),
        };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");

                var response = client.PutAsJsonAsync("api/CRUD", newUser).Result;

                if (response.IsSuccessStatusCode)
                {
                    Label1.Text = "Data successfully Updated";
                    BindGridView();
                }
                else
                {
                    Label1.Text = "Data not successfully Updated";
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(TextBox5.Text, out id))
            {
                User newUser = new User
                {
                    Id = id,
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44354/");

                    var response = client.DeleteAsync($"api/CRUD/{id}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Label1.Text = "Data successfully Deleted";
                        BindGridView();
                    }
                    else
                    {
                        Label1.Text = "Data not successfully Deleted";
                    }
                }
            }
            else
            {
                Label1.Text = "Invalid ID format";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridView();
            GridViewRow selectedRow = GridView1.SelectedRow;
            int id = Convert.ToInt32(GridView1.DataKeys[selectedRow.RowIndex].Values["Id"]);
            TextBox5.Text = id.ToString();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < GridView1.Rows.Count)
            {
                int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["Id"]);


                User newUser = new User
                {
                    Id = id,
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44354/");

                    var response = client.DeleteAsync($"api/CRUD/{id}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Label1.Text = "Data successfully Deleted";
                        BindGridView();
                    }
                    else
                    {
                        Label1.Text = "Data not successfully Deleted";
                    }
                }
            }
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];

            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["Id"]);
            //string updatedUsername = (string)GridView1.DataKeys[e.RowIndex].Values["Username"];
            //string updatedPassword = (string)GridView1.DataKeys[e.RowIndex].Values["Password"];
            //string updatedCountry = (string)GridView1.DataKeys[e.RowIndex].Values["Country"];
            //string updatedEmail = (string)GridView1.DataKeys[e.RowIndex].Values["Email"];

            string updatedUsername = (row.FindControl("TextBoxEditedUsername") as TextBox)?.Text;
            string updatedPassword = (row.FindControl("TextBoxEditedPassword") as TextBox)?.Text;
            string updatedCountry = (row.FindControl("TextBoxEditedCountry") as TextBox)?.Text;
            string updatedEmail = (row.FindControl("TextBoxEditedEmail") as TextBox)?.Text;

            User updatedUser = new User
            {
                Id = id,
                Username = updatedUsername,
                Password = updatedPassword,
                Country = updatedCountry,
                Email = updatedEmail
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");

                var response = client.PutAsJsonAsync("api/CRUD", updatedUser).Result;

                if (response.IsSuccessStatusCode)
                {
                    Label1.Text = "Data successfully Updated";
                    GridView1.EditIndex = -1;
                    BindGridView();
                }
                else
                {
                    Label1.Text = "Data not successfully Updated";
                }
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }


    }

}