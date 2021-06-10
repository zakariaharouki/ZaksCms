using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZaksCms.UserControl.Template.Directions
{
    public partial class AddDirection1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            chkDefault.Checked = true;
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            Direction dc = new Direction();
            dc.Insert(txtDirectionTitle.Text, chkDefault.Checked);
            Response.Redirect("/admin/ListDirection");
        }
    }
}