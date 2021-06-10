using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZaksCms.UserControl.Template.Color
{
    public partial class EditColor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Colors cc = new Colors();
                string ColorId = (string)this.RouteData.Values["ID"];
                if (ColorId == null)
                {
                    Response.Redirect("admin/ListColors");
                }
                cc.GetColor(int.Parse(ColorId));
                Color.Text = cc.Color;
                if (cc.IsPublished == false)
                {
                    IsPublished.Checked = false;
                }
                else
                {
                    IsPublished.Checked = true;
                }
                Languages lc = new Languages();
                ddlLanguageId.DataSource = lc.GetLanguages();
                ddlLanguageId.DataTextField = "LanguageTitle";
                ddlLanguageId.DataValueField = "LanguageID";
                ddlLanguageId.DataBind();
                ddlLanguageId.SelectedValue = cc.LanguageID.ToString();

            }
        }
        protected void Edit_Click(object sender, EventArgs e)
        {
            string ColorId = (string)this.RouteData.Values["ID"];
            Colors cc = new Colors();
            cc.Update(int.Parse(ColorId), Color.Text, IsPublished.Checked, int.Parse(ddlLanguageId.SelectedValue));
            Response.Redirect("/admin/ListColors");
        }
    }
}