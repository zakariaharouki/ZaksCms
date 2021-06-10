using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ZaksCms.UserControl.Template.Content
{
    public partial class EditContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Menus mc = new Menus();
                ddlMenuID.DataSource = mc.GetMenus();
                ddlMenuID.DataTextField = "Title";
                ddlMenuID.DataValueField = "MenuID";
                ddlMenuID.DataBind();
                ddlMenuID.Items.Insert(0, new ListItem("Root Menus", "0"));

                Album ac = new Album();
                ddlAlbumID.DataSource = ac.GetAlbums();
                ddlAlbumID.DataTextField = "EnglishAlbumName";
                ddlAlbumID.DataValueField = "AlbumID";
                ddlAlbumID.DataBind();
                ddlAlbumID.Items.Insert(0, new ListItem("Select Album", "0"));

                Languages lc = new Languages();
                ddlLanguageID.DataSource = lc.GetLanguages();
                ddlLanguageID.DataTextField = "LanguageTitle";
                ddlLanguageID.DataValueField = "LanguageID";
                ddlLanguageID.DataBind();
                ddlLanguageID.Items.Insert(0, new ListItem("Select Language", "0"));

                Categories cc = new Categories();
                ddlCategoryID.DataSource = cc.GetParentCategory();
                ddlCategoryID.DataTextField = "CategoryName";
                ddlCategoryID.DataValueField = "CategoryID";
                ddlCategoryID.DataBind();
                ddlCategoryID.Items.Insert(0, new ListItem("Root Category", "0"));

                Author auc = new Author();
                ddlAuthorID.DataSource = auc.GetAuthors();
                ddlAuthorID.DataTextField = "AuthorName";
                ddlAuthorID.DataValueField = "AuthorID";
                ddlAuthorID.DataBind();
                ddlAuthorID.Items.Insert(0, new ListItem("Select Author", "0"));

                Contents oc = new Contents();
                //Check if no paratmeter exist, redirect to list page. 
                string ContentID = (string)this.RouteData.Values["ID"];
                if (ContentID == null)
                {
                    Response.Redirect("/admin/ListContent");
                }
                else
                {
                    oc.GetContent(int.Parse(ContentID));
                    txtContentTitle.Text = oc.ContentTitle;
                    txtContentSubTitle.Text = oc.ContentSubTitle;
                    PublishedDate.Text = Convert.ToDateTime(oc.PublishedDate).Date.ToString("yyyy-MM-ddTHH:mm");
                    chkPublished.Checked = oc.IsPublished;
                    ddlMenuID.SelectedValue = oc.MenuID.ToString();
                    ddlAlbumID.SelectedValue = oc.AlbumID.ToString();
                    ddlLanguageID.SelectedValue = oc.LanguageID.ToString();
                    txtStartDateTime.Text = Convert.ToDateTime(oc.StartDateTime).Date.ToString("yyyy-MM-ddTHH:mm");
                    txtEndDateTime.Text = Convert.ToDateTime(oc.EndDateTime).Date.ToString("yyyy-MM-ddTHH:mm");
                    ddlAuthorID.SelectedValue = oc.AuthorID.ToString();
                    ddlCategoryID.SelectedValue = oc.ContentCategoryID.ToString();
                    txtMetaTitle.Text = oc.MetaTitle;
                    txtMetaKeyword.Text = oc.MetaKeyword;
                    MetaDescription.Value = oc.MetaDescription;
                    lblFileUploadContentImagePath.Text = oc.UploadContentImage;
                    lblFileUploadContentFilePath.Text = oc.UploadContentFile;
                    lblFileUploadThumbnailContentPath.Text = oc.UploadThumbnailContentImage;
                    txtSummary.Text = oc.Summary;
                    txtCustomText1.Text = oc.CustomText1;
                    txtCustomText2.Text = oc.CustomText2;
                    txtCustomText3.Text = oc.CustomText3;
                    Description.Value = oc.Description;
                }
            }
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            if (FileUploadContentImage.HasFile) //ContentImage
            {
                string fileName = FileUploadContentImage.FileName;
                string folderPath = Server.MapPath("~/Files/Images/");
                string storeImage = folderPath + fileName;
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                FileUploadContentImage.SaveAs(storeImage);

                lblFileUploadContentImage.Text = "Image upload successfully";
                lblFileUploadContentImagePath.Text = Request.UrlReferrer + storeImage;
                lblFileUploadContentImage.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                lblFileUploadContentImage.ForeColor = System.Drawing.Color.Red;
                lblFileUploadContentImage.Text = "Please select Image";
            }

            if (FileUploadContentFile.HasFile) //ContentFile
            {
                string fileName = FileUploadContentFile.FileName;
                string folderPath = Server.MapPath("~/Files/Images/");
                string storeImage = folderPath + fileName;
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                FileUploadContentImage.SaveAs(storeImage);

                lblFileUploadContentFile.Text = "File upload successfully";
                lblFileUploadContentFilePath.Text = HttpContext.Current.Request.Url.Host + storeImage;
                lblFileUploadContentFile.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                lblFileUploadContentFile.ForeColor = System.Drawing.Color.Red;
                lblFileUploadContentFile.Text = "Please select File";
            }

            if (FileUploadThumbnailContent.HasFile) //Thumbnail
            {
                string fileName = FileUploadThumbnailContent.FileName;
                string folderPath = Server.MapPath("~/Files/Images/");
                string storeImage = folderPath + fileName;
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                FileUploadThumbnailContent.SaveAs(storeImage);

                lblFileUploadThumbnailContent.Text = "Image upload successfully";
                lblFileUploadThumbnailContentPath.Text = HttpContext.Current.Request.Url.Host + storeImage;
                lblFileUploadThumbnailContent.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                lblFileUploadThumbnailContent.ForeColor = System.Drawing.Color.Red;
                lblFileUploadThumbnailContent.Text = "Please select Image";
            }

            string ContentID = (string)this.RouteData.Values["ID"];
            Contents dc = new Contents();
            dc.Update(int.Parse(ContentID), txtContentTitle.Text, txtContentSubTitle.Text, DateTime.Parse(PublishedDate.Text), chkPublished.Checked,
                      int.Parse(ddlLanguageID.Text), int.Parse(ddlMenuID.Text), int.Parse(ddlAlbumID.Text), DateTime.Parse(txtStartDateTime.Text),
                      DateTime.Parse(txtEndDateTime.Text), int.Parse(ddlAuthorID.Text), int.Parse(ddlCategoryID.Text),
                      txtMetaTitle.Text, txtMetaKeyword.Text, MetaDescription.Value, lblFileUploadContentImagePath.Text,
                      lblFileUploadContentFilePath.Text, lblFileUploadThumbnailContentPath.Text, txtSummary.Text,
                      txtCustomText1.Text, txtCustomText2.Text, txtCustomText3.Text, Description.Value.ToString());
            Response.Redirect("/admin/ListContent");
        }
    }
}