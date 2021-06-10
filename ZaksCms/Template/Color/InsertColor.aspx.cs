using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ZaksCms.UserControl.Template.Color
{
    public partial class InsertColor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Languages lc = new Languages();
            ddlLanguageId.DataSource = lc.GetLanguages();
            ddlLanguageId.DataTextField = "LanguageTitle";
            ddlLanguageId.DataValueField = "LanguageID";
            ddlLanguageId.DataBind();
            ddlLanguageId.Items.Insert(0, new ListItem("Root Language", "0"));
            IsPublished.Checked = true;

        }
        protected void Insert_Click(object sender, EventArgs e)
        {
            Colors cc = new Colors();
            cc.Insert(Color.Text, IsPublished.Checked, int.Parse(ddlLanguageId.SelectedValue));
            Response.Redirect("/admin/ListColors");
        }
    }
}