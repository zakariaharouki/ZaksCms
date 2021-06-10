using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZaksCms.App_Start;

namespace ZaksCms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void loginbtn_Click(object sender, EventArgs e)
        {
            LoginClass lc = new LoginClass();
            String usremail = emailtxt.Text;
            String usrpassword = txtPassword.Text;
            switch (lc.LoginMethod(usremail, usrpassword))
            {
                case 1:
                    LoginClass loginClass4 = new LoginClass();
                    loginClass4.checkiflocked(usremail);
                    if (loginClass4.IsLocked == "True")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent();", true);
                    }
                    else
                    {
                        Session["Email"] = usremail;
                        Response.Redirect("/Home");
                    }
                    break;
                case 0:
                    LoginClass loginClass3 = new LoginClass();
                    loginClass3.checkiflocked(usremail);
                    if (loginClass3.IsLocked == "1")
                    {
                        // string str = "function () { alert('Your Account is Locked'); }";
                        //Page.RegisterClientScriptBlock("nameofscript", str);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction",str, true);
                        Response.Write(@"<script Language='javascript'>alert('Your Account is Locked');</script>");
                    }
                    else
                    {
                        LoginClass loginClass = new LoginClass();
                        loginClass.getattempts(usremail);
                        if (loginClass.AttemptsCount < 4)
                        {
                            int AttemptsCount = loginClass.AttemptsCount + 1;
                            LoginClass loginClass1 = new LoginClass();
                            loginClass1.updateAttempts(AttemptsCount, usremail);
                            emailtxt.Text = "wrong email";
                            txtPassword.Text = "wrong pass";
                        }
                        else
                        {
                            LoginClass loginClass2 = new LoginClass();
                            loginClass2.lockaccount(usremail);
                        }
                    }

                    break;
                case -1:
                    emailtxt.Text = "invalid";
                    txtPassword.Text = "invalid";
                    break;
            }
        }

        protected void Registerbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Register");
        }
    }
}