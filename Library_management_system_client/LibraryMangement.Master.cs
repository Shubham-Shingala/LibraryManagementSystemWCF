using Library_management_system_client.StudentServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_management_system_client
{
    public partial class LibraryMangement : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StudentServiceClient client = new StudentServiceClient();
            client.Open();
            try
            {
                if (Request.Cookies["library token"] != null)
                {
                    string token = Request.Cookies["library token"].Value;
                    StudentDto userDto = client.GetUserByToken(token);
                    userName.Visible = true;
                    signoutLink.Visible = true;
                    userName.Text = userDto.FirstName;
                    signInLink.Visible = false;

                }
            }
            catch (Exception)
            {
                Response.Cookies["library token"].Expires = DateTime.Now.AddDays(-1);
                Response.Redirect("/login.aspx");
            }
            finally
            {
                client.Close();
            }
        }

        protected void logoutlink_Click(object sender, EventArgs e)
        {
            Response.Cookies["library token"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/login.aspx");
        }
    }
}