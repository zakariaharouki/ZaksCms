using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ZaksCms.UserControl.Template.Widget
{
    public partial class AddWidget : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            WidgetClass wc = new WidgetClass();
            wc.Insert(txtWidgetTitle.Text, chkPublished.Checked);
            Response.Redirect("/admin/ListWidget");
        }
    }
}