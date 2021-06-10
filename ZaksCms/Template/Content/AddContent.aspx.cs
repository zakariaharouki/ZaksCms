using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZaksCms.App_Code;


namespace ZaksCms.UserControl.Template.Content
{
    public partial class AddContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetMenus();
                GetAlbums();
                GetLanguages();
                GetCats();
                GetAuthors();
                GetZones();
            }
        }
        protected void GetZones()
        {
            WebsiteZones websiteZones = new WebsiteZones();
            ZonesDropdown.DataSource = websiteZones.GetZones();
            ZonesDropdown.DataTextField = "ZoneName";
            ZonesDropdown.DataValueField = "ZoneID";
            ZonesDropdown.DataBind();

        }
        protected void GetMenus()
        {
            Menus mc = new Menus();
            ddlMenuID.DataSource = mc.GetMenus();
            ddlMenuID.DataTextField = "Title";
            ddlMenuID.DataValueField = "MenuId";
            ddlMenuID.DataBind();
            ddlMenuID.Items.Insert(0, new ListItem("Root Menus", "0"));
        }
        protected void GetAlbums()
        {
            Album ac = new Album();
            ddlAlbumID.DataSource = ac.GetAlbums();
            ddlAlbumID.DataTextField = "EnglishAlbumName";
            ddlAlbumID.DataValueField = "AlbumID";
            ddlAlbumID.DataBind();
            ddlAlbumID.Items.Insert(0, "Select Albums");
        }
        protected void GetLanguages()
        {
            Languages lc = new Languages();
            ddlLanguageID.DataSource = lc.GetLanguages();
            ddlLanguageID.DataTextField = "LanguageTitle";
            ddlLanguageID.DataValueField = "LanguageID";
            ddlLanguageID.DataBind();
            ddlLanguageID.Items.Insert(0, "Select Languages");
        }
        protected void GetCats()
        {
            Categories cc = new Categories();
            ddlCategoryID.DataSource = cc.GetParentCategory();
            ddlCategoryID.DataTextField = "CategoryName";
            ddlCategoryID.DataValueField = "CategoryID";
            ddlCategoryID.DataBind();
            ddlCategoryID.Items.Insert(0, new ListItem("Root Category", "0"));
        }
        protected void GetAuthors()
        {
            Author auc = new Author();
            ddlAuthorID.DataSource = auc.GetAuthors();
            ddlAuthorID.DataTextField = "AuthorName";
            ddlAuthorID.DataValueField = "AuthorID";
            ddlAuthorID.DataBind();
            ddlAuthorID.Items.Insert(0, "List Authors");

            chkPublished.Checked = true;
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            if (FileUploadContentImage1.HasFile) //ContentImage1
            {
                string fileName = FileUploadContentImage1.FileName;
                string folderPath = Server.MapPath("~/Files/Images/" + txtContentTitle.Text + "/1/");
                string image1 = "/Files/Images/" + txtContentTitle.Text + "/1/" + fileName;
                string storeImage = folderPath + fileName;
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                FileUploadContentImage1.SaveAs(storeImage);


                if (FileUploadContentImage2.HasFile) //ContentImage2
                {
                    string fileName2 = FileUploadContentImage2.FileName;
                    string folderPath2 = Server.MapPath("~/Files/Images/" + txtContentTitle.Text + "/2/");
                    string image2 = "/Files/Images/" + txtContentTitle.Text + "/2/" + fileName2;
                    string storeImage2 = folderPath2 + fileName2;
                    if (!Directory.Exists(folderPath2))
                    {
                        Directory.CreateDirectory(folderPath2);
                    }
                    FileUploadContentImage1.SaveAs(storeImage2);



                    if (FileUploadContentImage3.HasFile) //ContentImage3
                    {
                        string fileName3 = FileUploadContentImage3.FileName;
                        string folderPath3 = Server.MapPath("~/Files/Images/" + txtContentTitle.Text + "/3/");
                        string image3 = "/Files/Images/" + txtContentTitle.Text + "/3/" + fileName3;
                        string storeImage3 = folderPath3 + fileName3;
                        if (!Directory.Exists(folderPath3))
                        {
                            Directory.CreateDirectory(folderPath3);
                        }
                        FileUploadContentImage1.SaveAs(storeImage3);


                        if (FileUploadContentCoverImage.HasFile) //Content Cover Image
                        {
                            string fileNameCover = FileUploadContentCoverImage.FileName;
                            string folderPathCover = Server.MapPath("~/Files/Images/" + txtContentTitle.Text + "/Cover/");
                            string CoverImage = "/Files/Images/" + txtContentTitle.Text + "/Cover/" + fileNameCover;
                            string storeCoverImage = folderPathCover + fileNameCover;
                            if (!Directory.Exists(folderPathCover))
                            {
                                Directory.CreateDirectory(folderPathCover);
                            }
                            FileUploadContentImage1.SaveAs(storeCoverImage);


                            //    string fileName = FileUploadContentImage1.FileName;
                            //    string folderPath = Server.MapPath("~/Files/Images/");
                            //    string storeImage = folderPath + fileName;
                            //    if (!Directory.Exists(folderPath))
                            //    {
                            //        Directory.CreateDirectory(folderPath);
                            //    }
                            //    FileUploadContentImage1.SaveAs(storeImage);

                            //    lblFileUploadContentImage1.Text = "Image upload successfully";
                            //    lblFileUploadContentImagePath1.Text = HttpContext.Current.Request.Url.Host + storeImage;
                            //    lblFileUploadContentImage1.ForeColor = System.Drawing.Color.Green;

                            //}
                            //else
                            //{
                            //    lblFileUploadContentImage1.ForeColor = System.Drawing.Color.Red;
                            //    lblFileUploadContentImage1.Text = "Please select Image";
                            //}
                            Contents ccc = new Contents();
                            ccc.Insert(txtContentTitle.Text, txtContentSubTitle.Text, DateTime.Parse(PublishedDate.Text), chkPublished.Checked,
                            int.Parse(ddlLanguageID.SelectedValue), int.Parse(ddlMenuID.SelectedValue), int.Parse(ddlAlbumID.SelectedValue),
                            DateTime.Parse(txtStartDateTime.Text), DateTime.Parse(txtEndDateTime.Text), int.Parse(ddlAuthorID.SelectedValue),
                            int.Parse(ddlCategoryID.SelectedValue), txtMetaTitle.Text, txtMetaKeyword.Text, MetaDescription.Text,
                            image1.Trim(), image2.Trim(), image3.Trim(), txtSummary.Text, txtCustomText1.Text, txtCustomText2.Text, txtCustomText3.Text, Description.Text, CoverImage.Trim());
                            Response.Redirect("/admin/ListContent");
                        }
                    }
                }
            }
        }
    }
}
        