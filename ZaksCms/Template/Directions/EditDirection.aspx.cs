using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZaksCms.UserControl.Template.Directions
{
    public partial class EditDirection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Direction dc = new Direction();
                //Check if no paratmeter exist, redirect to list page.           
                string DirectionID = (string)this.RouteData.Values["ID"];
                if (DirectionID == null)
                {
                    Response.Redirect("/admin/ListDirection");
                }
                dc.GetDirection(int.Parse(DirectionID));
                txtDirectionTitle.Text = dc.DirectionTitle;
                chkDefault.Checked = dc.DefaultDirection;
            }
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            string DirectionID = (string)this.RouteData.Values["ID"];
            Direction dc = new Direction();
            dc.Update(int.Parse(DirectionID), txtDirectionTitle.Text, chkDefault.Checked);
            Response.Redirect("ListDirection.aspx");
        }
    }
}