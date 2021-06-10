using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ZaksCms.UserControl.Template.Language
{
    public partial class EditLanguage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Languages lc = new Languages();
                string LanguageID = (string)this.RouteData.Values["ID"];
                if (LanguageID == null)
                {
                    Response.Redirect("/admin/ListLanguage");
                }
                lc.GetLanguage(int.Parse(LanguageID));
                txtLanguageTitle.Text = lc.LanguageTitle;
                txtLanguageSuffix.Text = lc.LanguageSuffix;
                chkDefault.Checked = lc.DefaultLanguage;
            }
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            string LanguageID = (string)this.RouteData.Values["ID"];
            Languages lc = new Languages();
            lc.Update(int.Parse(LanguageID), txtLanguageTitle.Text, txtLanguageSuffix.Text, chkDefault.Checked);
            Response.Redirect("ListLanguage.aspx");
        }
    }
}