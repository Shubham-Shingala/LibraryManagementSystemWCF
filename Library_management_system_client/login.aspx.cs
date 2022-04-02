using Library_management_system_client.StudentServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_management_system_client
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StudentServiceClient client = new StudentServiceClient();
            client.Open();
            if (Request.Cookies["library token"] != null)
            {
                string value = Request.Cookies["library token"].Value;
                if (client.isValidToken(value))
                {
                    Response.Redirect("/home.aspx");
                }
                else
                {
                    Response.Cookies["library token"].Expires = DateTime.Now.AddDays(-1);
                }
            }
            client.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StudentServiceClient client = new StudentServiceClient();
            client.Open();
            try
            {
                Credentials credentials = new Credentials
                {
                    CollegeId = CollegeIdField.Text,
                    Password = PasswordField.Text
                };
                string token = client.Login(credentials);
                HttpCookie cookie = new HttpCookie("library token");
                cookie.Value = token;
                cookie.Expires = DateTime.Now.AddHours(3);
                Response.SetCookie(cookie);
                Response.Redirect("/book.aspx");
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
            finally
            {
                client.Close();

            }
        }
    }
}