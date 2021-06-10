using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZaksCms.App_Code;

namespace ZaksCms.Template.Zones
{
    public partial class AddZone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddZonebtn_Click(object sender, EventArgs e)
        {
            WebsiteZones websiteZones = new WebsiteZones();
            websiteZones.AddZone(zonenametxt.Text);
            Response.Redirect("/admin/ListZones");
        }
    }
}