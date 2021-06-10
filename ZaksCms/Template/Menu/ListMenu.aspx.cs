using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ZaksCms.UserControl.Template.Menu
{
    public partial class ListMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Menus dc = new Menus();
            rptMenus.DataSource = dc.GetMenus();
            rptMenus.DataBind();
        }
        protected void Edit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int MenuID = int.Parse(btn.CommandArgument);
            Response.Redirect("/admin/EditMenu/" + MenuID);
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int MenuID = int.Parse(btn.CommandArgument);
            Menus dc = new Menus();
            dc.DeleteMenu(MenuID);
            rptMenus.DataSource = dc.GetMenus();
            rptMenus.DataBind();
        }
        protected void Insert_Redirect(object sender, EventArgs e)
        {
            Response.Redirect("/admin/AddMenu");
        }
    }
}