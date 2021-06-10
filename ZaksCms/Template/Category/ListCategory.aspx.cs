using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZaksCms.UserControl.Template.Category
{
    public partial class ListCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Categories cc = new Categories();
                rptCategories.DataSource = cc.GetCategories();
                rptCategories.DataBind();
            }
        }

        protected void SelectListOfCategories_Click(object sender, EventArgs e)
        {

        }

        protected void CategoryName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void IsPublished_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton b = (LinkButton)sender;
            int CategoryId = int.Parse(b.CommandArgument);
            Categories cc = new Categories();
            cc.Delete(CategoryId);
            rptCategories.DataSource = cc.GetCategories();
            rptCategories.DataBind();
        }
        protected void Edit_Click(object sender, EventArgs e)
        {
            LinkButton b = (LinkButton)sender;
            /*Session["ID"] = int.Parse(b.CommandArgument);*/
            int CategoryId = int.Parse(b.CommandArgument);
            Response.Redirect("/admin/EditCategory/" + CategoryId);
        }
        protected void Insert_Redirect(object sender, EventArgs e)
        {
            Response.Redirect("/admin/AddCategory");
        }
    }
}