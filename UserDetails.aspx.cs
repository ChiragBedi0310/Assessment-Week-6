using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using Entity;

namespace Assessment_On_Asp.net_using_Stored_Procedures
{
    public partial class UserDetails : System.Web.UI.Page
    {
        BusinessLogic obj = new BusinessLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
          

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TextBox1.Text);
            string name = TextBox2.Text;
            string author = TextBox3.Text;
            string publisher = TextBox4.Text;
            decimal price = Convert.ToDecimal(TextBox5.Text);
            Book book = new Book(id,name,author,publisher,price);
            if (obj.InsertData(book))
            {
                Response.Write("Book Added Successfully");
            }
            else
            {
                Response.Write("Failed To Add The Book");
            }
            ClearData();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TextBox1.Text);
            string name = TextBox2.Text;
            string author = TextBox3.Text;
            string publisher = TextBox4.Text;
            decimal price = Convert.ToDecimal(TextBox5.Text);
            Book book = new Book(id, name, author, publisher, price);
            if (obj.UpdateData(book))
            {
                Response.Write("Book Updated Successfully");
            }
            else
            {
                Response.Write("Failed To Update The Book");
            }
            ClearData();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TextBox1.Text);
            if (obj.DeleteData(id))
            {
                Response.Write("Book Deleted Successfully");
            }
            else
            {
                Response.Write("Failed To Delete The Book");
            }
            ClearData();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = obj.ShowData();
            GridView1.DataBind();
        }

        private void ClearData()
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
            TextBox5.Text = string.Empty;
        }
    }
}