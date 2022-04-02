using Library_management_system_client.BookServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_management_system_client
{
    public partial class AddBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Book book = new Book
                {
                    Name = TextBox2.Text,
                    Author = TextBox1.Text,
                    Edition = Convert.ToInt32(TextBox3.Text),
                    No_of_Total_Copy = Convert.ToInt32(TextBox6.Text),
                    No_of_Available_Copy = Convert.ToInt32(TextBox6.Text),
                    Category = TextBox5.Text,
                };
                BookServiceClient client = new BookServiceClient();
                client.Open();
                try
                {
                    client.AddBook(book);
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
}