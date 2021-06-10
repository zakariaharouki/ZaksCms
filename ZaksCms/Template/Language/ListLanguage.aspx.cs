using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ZaksCms.UserControl.Template.Language
{
    public partial class ListLanguage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Languages dc = new Languages();
            rptLanguages.DataSource = dc.GetLanguages();
            rptLanguages.DataBind();
        }
        protected void Edit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int LanguageID = int.Parse(btn.CommandArgument);
            Response.Redirect("/admin/EditLanguage/" + LanguageID);
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int LanguageID = int.Parse(btn.CommandArgument);
            Languages dc = new Languages();
            dc.DeleteLanguage(LanguageID);
            rptLanguages.DataSource = dc.GetLanguages();
            rptLanguages.DataBind();
        }
        protected void Insert_Redirect(object sender, EventArgs e)
        {
            Response.Redirect("/admin/AddLanguage");
        }
    }
}