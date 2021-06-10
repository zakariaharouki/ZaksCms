using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ZaksCms.UserControl.Template.Widget
{
    public partial class EditWidget : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WidgetClass dc = new WidgetClass();
                //Check if no paratmeter exist, redirect to list page.           
                Uri myUri = new Uri(Request.Url.ToString());
                string WidgetID = HttpUtility.ParseQueryString(myUri.Query).Get("ID");
                if (WidgetID == null)
                {
                    Response.Redirect("/admin/ListWidget");
                }
                dc.GetWidget(int.Parse(WidgetID));
                txtWidgetTitle.Text = dc.WidgetTitle;
                chkPublished.Checked = dc.IsPublished;
            }
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            Uri myUri = new Uri(Request.Url.ToString());
            string WidgetID = HttpUtility.ParseQueryString(myUri.Query).Get("ID");
            WidgetClass dc = new WidgetClass();
            dc.Update(int.Parse(WidgetID), txtWidgetTitle.Text, chkPublished.Checked);
            Response.Redirect("/admin/ListWidget");
        }
    }
}