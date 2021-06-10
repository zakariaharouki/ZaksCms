using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZaksCms.App_Code;

namespace ZaksCms.Template.Zones
{
    public partial class EditZones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                GetZone();
            }

        }

        protected void EditZonebtn_Click(object sender, EventArgs e)
        {
            string ZoneID = (string)this.RouteData.Values["ID"];
            string Zonename = zonenametxt.Text;
            WebsiteZones websiteZones = new WebsiteZones();
            websiteZones.UpdateZone(int.Parse(ZoneID), Zonename);
            Response.Redirect("/ListZones");
        }
        protected void GetZone()
        {
            string ZoneID = (string)this.RouteData.Values["ID"];
            WebsiteZones websiteZones = new WebsiteZones();
            websiteZones.GetZone(int.Parse(ZoneID));
            zonenametxt.Text = websiteZones.ZoneName;
        }
    }
}