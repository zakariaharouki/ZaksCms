using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using ZaksCms.App_Start;

namespace ZaksCms
{
    public class Global : System.Web.HttpApplication
    {

        public static string MyConn = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                Response.Redirect("/Home");
                Session.Timeout = 5;
            }
            else
            {
                //
                Response.Redirect("/Loginpage");
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}