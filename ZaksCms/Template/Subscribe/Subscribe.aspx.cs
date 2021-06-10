using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZaksCms.UserControl.Template.Subscribe
{
    public partial class Subscribe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Subscriptions subscriptionsClass = new Subscriptions();
                subsrepeater.DataSource = subscriptionsClass.getsubs();
                subsrepeater.DataBind();
            }

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            LinkButton dltbtn = (LinkButton)sender;
            int SubscriptionID = int.Parse(dltbtn.CommandArgument);
            Subscriptions subscriptionsClass = new Subscriptions();
            subsrepeater.DataSource = subscriptionsClass.getsubs();
            subsrepeater.DataBind();
        }
    }
}