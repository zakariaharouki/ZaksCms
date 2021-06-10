using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ZaksCms.UserControl.Template.Widget
{
    public partial class ListWidget : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WidgetClass dc = new WidgetClass();
            rptWidgets.DataSource = dc.GetWidgets();
            rptWidgets.DataBind();
        }
        protected void Edit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int WidgetID = int.Parse(btn.CommandArgument);
            Response.Redirect("/admin/EditWidget" + WidgetID);
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int WidgetID = int.Parse(btn.CommandArgument);
            WidgetClass dc = new WidgetClass();
            dc.DeleteWidget(WidgetID);
            rptWidgets.DataSource = dc.GetWidgets();
            rptWidgets.DataBind();
        }
    }
}