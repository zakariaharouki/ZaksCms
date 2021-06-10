using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZaksCms;
using ZaksCms.App_Code;

namespace ZaksCms.Template.Zones
{
    public partial class ListZones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebsiteZones websiteZones = new WebsiteZones();
            rptZones.DataSource=websiteZones.GetZones();
            rptZones.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int ZoneID = int.Parse(btn.CommandArgument);
            Response.Redirect("/EditZone/"+ZoneID);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int ZoneID = int.Parse(btn.CommandArgument);
            WebsiteZones websiteZones = new WebsiteZones();
            websiteZones.DeleteContent(ZoneID);
        }
    }
}