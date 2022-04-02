using Library_management_system_client.StudentServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_management_system_client
{
    public partial class register : System.Web.UI.Page
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
            if (IsValid)
            {
                StudentServiceClient client = new StudentServiceClient();
                client.Open();
                Student student = new Student
                {
                    FirstName = fName.Text,
                    LastName = lName.Text,
                    Branch = branch.Text,
                    DOB = DateTime.Parse(dob.Text),
                    EmailId = email.Text,
                    MobileNum = mobile.Text,
                    Password = password.Text,
                    RollNo = Convert.ToInt32(rollNo.Text)
                };
                try
                {
                    string collegeId= client.Register(student);
                    Label1.Text = collegeId;
                    //Response.Redirect("/home.aspx");
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

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            StudentServiceClient client = new StudentServiceClient();
            client.Open();
            try
            {
                StudentDto studentDto =client.getUser(Convert.ToInt32(rollNo.Text));
                if (studentDto != null)
                    args.IsValid = false;
                else
                    args.IsValid = true;
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
            client.Close();
        }
    }
}