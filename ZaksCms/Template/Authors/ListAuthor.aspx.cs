using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZaksCms;

namespace ZaksCms.UserControl.Template.Authors
{
    public partial class ListAuthor : System.Web.UI.Page
    {

            protected void Page_Load(object sender, EventArgs e)
            {
                Author ac = new Author();
                rptAuthors.DataSource = ac.GetAuthors();
                rptAuthors.DataBind();

            }
            protected void Edit_Click(object sender, EventArgs e)
            {
                LinkButton btn = (LinkButton)sender;
                int AuthorID = int.Parse(btn.CommandArgument);
                Response.Redirect("/admin/EditAuthor/" + AuthorID);
            }


            protected void Delete_Click(object sender, EventArgs e)
            {
                LinkButton btn = (LinkButton)sender;
                int AuthorID = int.Parse(btn.CommandArgument);
                Author ac = new Author();
                ac.DeleteAuthor(AuthorID);
                rptAuthors.DataSource = ac.GetAuthors();
                rptAuthors.DataBind();
            }

            protected void Insert_Redirect(object sender, EventArgs e)
            {
                Response.Redirect("/admin/AddAuthor");
            }
        }
    }
