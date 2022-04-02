using Library_management_system_client.BookServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_management_system_client
{
    public partial class UpdateBook : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);

            if (!IsPostBack)
            {
                BookServiceClient client = new BookServiceClient();
                client.Open();
                try
                {
                    Book item = client.GetBook(id);
                    Label2.Text = id.ToString();
                    TextBox2.Text = item.Name;
                    TextBox1.Text = item.Author;
                    TextBox5.Text = item.Category;
                    TextBox3.Text = item.Edition.ToString();
                    TextBox4.Text = item.No_of_Available_Copy.ToString();
                    TextBox6.Text = item.No_of_Total_Copy.ToString();
                }
                catch (Exception)
                {
                    Response.Redirect("/admin/dashboard.aspx");
                }
                finally
                {
                    client.Close();
                }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            BookServiceClient client = new BookServiceClient();
            client.Open();
            try
            {
                Book item = new Book
                {
                    Id = id,
                    Name = TextBox2.Text,
                    Author = TextBox1.Text,
                    Edition = Convert.ToInt32(TextBox3.Text),
                    No_of_Total_Copy = Convert.ToInt32(TextBox6.Text),
                    No_of_Available_Copy = Convert.ToInt32(TextBox4.Text),
                    Category = TextBox5.Text,
                };
                client.UpdateBook(item);
                Response.Redirect("/book.aspx");
            }
            catch (Exception ex)
            {
                errPanel.Visible = true;

                Label1.Text = ex.Message;
            }
            finally
            {
                client.Close();
            }
        }
    }
}