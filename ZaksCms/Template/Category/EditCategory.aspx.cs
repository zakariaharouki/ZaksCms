using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ZaksCms.UserControl.Template.Category
{
    public partial class EditCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Categories cc = new Categories();

                string CategoryId = (string)this.RouteData.Values["ID"];

                /*int CategoryId = int.Parse(Session["ID"].ToString());*/
                if (CategoryId == null)
                {
                    Response.Redirect("/admin/ListCategory");
                }
                cc.GetCategory(int.Parse(CategoryId));
                txtCategoryName.Text = cc.CategoryName;
                if (cc.IsPublished == false)
                {
                    IsPublished.Checked = false;
                }
                else
                {
                    IsPublished.Checked = true;
                }
                txtOrder.Text = cc.OrderNum.ToString();
                ddlParentId.DataSource = cc.GetParentCategory();
                ddlParentId.DataTextField = "CategoryName";
                ddlParentId.DataValueField = "CategoryID";
                ddlParentId.DataBind();
                ddlParentId.SelectedValue = cc.CategoryID.ToString();

                if (FileUploadCategoryPicture.HasFile)
                {
                    string FileName = FileUploadCategoryPicture.FileName;
                    string folderPath = Server.MapPath("~/Admin/Files/Images/");
                    /*string Image = "/Admin/Files/Images/" + FileName;*/
                    string StoreImage = folderPath + FileName;
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    FileUploadCategoryPicture.SaveAs(StoreImage);
                    lblFileUploadCategoryPicture.Text = "Image upload successfully";
                    lblFileUploadCategoryPicturePath.Text = Request.UrlReferrer + StoreImage;
                    lblFileUploadCategoryPicture.ForeColor = System.Drawing.Color.Green;

                }

                if (FileUploadCategoryIcon.HasFile)
                {
                    string FileNameIcon = FileUploadCategoryIcon.FileName;
                    string folderPathIcon = Server.MapPath("~/Admin/Files/Images/");
                    /*string Image = "/Admin/Files/Images/" + FileName;*/
                    string StoreIcon = folderPathIcon + FileNameIcon;
                    if (!Directory.Exists(folderPathIcon))
                    {
                        Directory.CreateDirectory(folderPathIcon);
                    }
                    FileUploadCategoryIcon.SaveAs(StoreIcon);
                    lblFileUploadCategoryIcon.Text = "Image upload successfully";
                    lblFileUploadCategoryIconPath.Text = Request.UrlReferrer + StoreIcon;
                    lblFileUploadCategoryIcon.ForeColor = System.Drawing.Color.Green;

                }

                Languages lc = new Languages();
                ddlLanguageId.DataSource = lc.GetLanguages();
                ddlLanguageId.DataTextField = "LanguageTitle";
                ddlLanguageId.DataValueField = "LanguageID";
                ddlLanguageId.DataBind();
                ddlLanguageId.SelectedValue = cc.LanguageID.ToString();

            }
        }
        protected void Update_Click(object sender, EventArgs e)
        {

            string CategoryId = (string)this.RouteData.Values["ID"];
            /*int CategoryId = int.Parse(Session["ID"].ToString());*/
            Categories cc = new Categories();
            cc.Update(int.Parse(CategoryId), txtCategoryName.Text, int.Parse(ddlParentId.SelectedValue), IsPublished.Checked, int.Parse(txtOrder.Text)
                , lblFileUploadCategoryPicturePath.Text, lblFileUploadCategoryIconPath.Text, int.Parse(ddlLanguageId.SelectedValue));
            Response.Redirect("/admin/ListCategory");
        }
    }
}