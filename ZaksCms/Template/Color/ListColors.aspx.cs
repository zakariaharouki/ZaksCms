using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ZaksCms.UserControl.Template.Color
{
    public partial class ListColors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Colors cc = new Colors();
                rptColor.DataSource = cc.GetColors();
                rptColor.DataBind();
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton b = (LinkButton)sender;
            int ColorId = int.Parse(b.CommandArgument);
            Colors cc = new Colors();
            cc.Delete(ColorId);
            rptColor.DataSource = cc.GetColors();
            rptColor.DataBind();
        }
        protected void Edit_Click(object sender, EventArgs e)
        {
            LinkButton b = (LinkButton)sender;
            /*Session["ID"] = int.Parse(b.CommandArgument);*/
            int NewsId = int.Parse(b.CommandArgument);
            Response.Redirect("admin/UpdateColor/" + NewsId);
        }
        protected void Insert_Redirect(object sender, EventArgs e)
        {
            Response.Redirect("admin/InsertColor");
        }
    }
}