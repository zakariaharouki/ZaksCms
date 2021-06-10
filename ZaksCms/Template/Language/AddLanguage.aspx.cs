using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ZaksCms.UserControl.Template.Language
{
    public partial class AddLanguage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            chkDefault.Checked = true;
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            Languages da = new Languages();
            da.Insert(txtLanguageTitle.Text, txtLanguageSuffix.Text, chkDefault.Checked);
            Response.Redirect("/admin/ListLanguage");
        }
    }
}