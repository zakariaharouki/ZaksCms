using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ZaksCms.UserControl.Template.Directions
{
    public partial class ListDirection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Direction dc = new Direction();
            rptDirections.DataSource = dc.GetDirections();
            rptDirections.DataBind();

        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int DirectionID = int.Parse(btn.CommandArgument);
            Response.Redirect("/admin/EditDirection/" + DirectionID);
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int DirectionID = int.Parse(btn.CommandArgument);
            Direction dc = new Direction();
            dc.DeleteDirection(DirectionID);
            rptDirections.DataSource = dc.GetDirections();
            rptDirections.DataBind();
        }
        protected void Insert_Redirect(object sender, EventArgs e)
        {
            Response.Redirect("/admin/AddDirection");
        }
    }
}