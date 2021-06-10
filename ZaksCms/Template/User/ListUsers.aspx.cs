using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ZaksCms.UserControl.Template.User
{
    public partial class ListUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserController userController = new UserController();
                UsersRepeater.DataSource = userController.getUsers();
                UsersRepeater.DataBind();
            }
        }

        protected void btnMoreinfo_Click(object sender, EventArgs e)
        {
            LinkButton btn1 = (LinkButton)sender;
            string id = (btn1.CommandArgument);
            Response.Redirect("admin/ViewMore/" + id);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton dltbtn = (LinkButton)sender;
            int UserId = int.Parse(dltbtn.CommandArgument);
            UserController us = new UserController();
            us.deleteuser(UserId);
            UsersRepeater.DataSource = us.getUsers();
            UsersRepeater.DataBind();

        }

        protected void Unlock_Click(object sender, EventArgs e)
        {
            LinkButton dltbtn = (LinkButton)sender;
            int UserId = int.Parse(dltbtn.CommandArgument);
            UserController us1 = new UserController();
            us1.UnlockAccount(UserId);
            UsersRepeater.DataSource = us1.getUsers();
            UsersRepeater.DataBind();
        }
    }
}