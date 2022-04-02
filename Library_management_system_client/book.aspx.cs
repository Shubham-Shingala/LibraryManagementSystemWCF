using Library_management_system_client.BookServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_management_system_client
{
    public partial class book : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                updateItemTable();
            }
        }
        void updateItemTable()
        {
            BookServiceClient client = new BookServiceClient();
            client.Open();
            try
            {
                List<Book> items = client.GetBooks().ToList();
                Label1.Text = items.Count.ToString();
                itemtable.DataSource = items;
                itemtable.DataBind();
            }
            catch (Exception ex)
            {
                errPanel.Visible = true;
                Label2.Text = ex.Message;
            }
            finally
            {
                client.Close();
            }
        }
        protected void update_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("/UpdateBook.aspx?id=" + e.CommandArgument.ToString());
        }

        protected void delete_Command(object sender, CommandEventArgs e)
        {
            BookServiceClient client = new BookServiceClient();
            client.Open();
            client.DeleteBook(Convert.ToInt32(e.CommandArgument));
            client.Close();
            updateItemTable();
        }
       
    }
}