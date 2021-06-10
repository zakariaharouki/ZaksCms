using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZaksCms;

namespace ZaksCms.UserControl.Template.Authors
{
    public partial class AddAuthor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Languages lc = new Languages();
                ddlLanguageId.DataSource = lc.GetLanguages();
                ddlLanguageId.DataTextField = "LanguageTitle";
                ddlLanguageId.DataValueField = "LanguageID";
                ddlLanguageId.DataBind();
                ddlLanguageId.Items.Insert(0, new ListItem("Root Language", "0"));
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {

            if (FileUploadAuthorPicture.HasFile)
            {
                string fileName = FileUploadAuthorPicture.FileName;
                string folderPath = Server.MapPath("~/Admin/Files/Images/");
                string image = "/Admin/Files/Images/" + fileName;
                string storeImage = folderPath + fileName;
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                FileUploadAuthorPicture.SaveAs(storeImage);

                lblFileUploadAuthorPicture.Text = "Image upload successfully";
                lblFileUploadAuthorPicturePath.Text = Request.UrlReferrer + image;
                lblFileUploadAuthorPicture.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                lblFileUploadAuthorPicture.ForeColor = System.Drawing.Color.Red;
                lblFileUploadAuthorPicture.Text = "Please select Image";
            }

            Author ac = new Author();
            ac.Insert(txtAuthorName.Text, txtAuthorJobTitle.Text, txtAuthorAddress.Text, txtAuthorEmail.Text, txtAuthorWebsite.Text, lblFileUploadAuthorPicturePath.Text, txtAuthorLinkedIn.Text, txtAuthorFacebook.Text, txtAuthorTwitter.Text, txtAuthorInstagram.Text, int.Parse(ddlLanguageId.SelectedValue));
            Response.Redirect("/admin/ListAuthor");
        }
    }
}