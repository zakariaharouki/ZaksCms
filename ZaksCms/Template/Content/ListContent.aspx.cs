using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZaksCms.UserControl.Template.Content
{
    public partial class ListContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Contents dc = new Contents();
            rptContents.DataSource = dc.GetContents();
            rptContents.DataBind();
        }
        protected void Edit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int ContentID = int.Parse(btn.CommandArgument);

            Response.Redirect("/admin/EditContent/" + ContentID);
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int ContentID = int.Parse(btn.CommandArgument);
            Contents dc = new Contents();
            dc.DeleteContent(ContentID);
            rptContents.DataSource = dc.GetContents();
            rptContents.DataBind();
        }
        protected void Insert_Redirect(object sender, EventArgs e)
        {
            Response.Redirect("/admin/AddContent");
        }
    }
}