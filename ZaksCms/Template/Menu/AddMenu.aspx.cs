using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ZaksCms.UserControl.Template.Menu
{
    public partial class AddMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Languages lc = new Languages();
                ddlLanguageID.DataSource = lc.GetLanguages();
                ddlLanguageID.DataTextField = "LanguageTitle";
                ddlLanguageID.DataValueField = "LanguageID";
                ddlLanguageID.DataBind();
                ddlLanguageID.Items.Insert(0, new ListItem("Root Language", "0"));

                Direction dc = new Direction();
                ddlDirectionID.DataSource = dc.GetDirections();
                ddlDirectionID.DataTextField = "DirectionTitle";
                ddlDirectionID.DataValueField = "DirectionID";
                ddlDirectionID.DataBind();
                ddlDirectionID.Items.Insert(0, new ListItem("Root Direction", "0"));

                Menus cc = new Menus();
                ddlParentID.DataSource = cc.GetParentMenus();
                ddlParentID.DataTextField = "Title";
                ddlParentID.DataValueField = "MenuID";
                ddlParentID.DataBind();
                ddlParentID.Items.Insert(0, new ListItem("Root Menu", "0"));
                int num = 0;
                chkPublished.Checked = true;
                txtMenuOrder.Text = num.ToString();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (FileUploadMenuPicture.HasFile)
            {
                string fileName = FileUploadMenuPicture.FileName;
                  string folderPath = Server.MapPath("~/Files/Images/"+txtMenuTitle.Text+"/1/");
                 string image = "/Files/Images/" + txtMenuTitle.Text+"/1/"+ fileName;
                 string storeImage = folderPath + fileName;
                 if (!Directory.Exists(folderPath))
                 {
                     Directory.CreateDirectory(folderPath);
                 }
                 FileUploadMenuPicture.SaveAs(storeImage);
                Menus ac = new Menus();
                ac.Insert(txtMenuTitle.Text,image.Trim(),int.Parse(ddlLanguageID.SelectedValue), int.Parse(ddlDirectionID.SelectedValue), int.Parse(ddlParentID.SelectedValue),
                    chkPublished.Checked, int.Parse(txtMenuOrder.Text), txtMetaTitle.Text, txtMetaKeyword.Text, txtCKEditor.Text);
                Response.Redirect("/admin/ListMenu");
            }
            //if (FileUploadMenuPicture.HasFile)
            //{
            //    string fileName = FileUploadMenuPicture.FileName;
            //    string folderPath = Server.MapPath("~/Files/Images/"+txtMenuTitle.Text+"1/");
            //    string image = "/Files/Images/" + fileName;
            //    string storeImage = folderPath + fileName;
            //    if (!Directory.Exists(folderPath))
            //    {
            //        Directory.CreateDirectory(folderPath);
            //    }
            //    FileUploadMenuPicture.SaveAs(storeImage);

            //    lblFileUploadMenuPicture.Text = "Image upload successfully";
            //    lblFileUploadMenuPicturePath.Text = Request.UrlReferrer + image;
            //    lblFileUploadMenuPicture.ForeColor = System.Drawing.Color.Green;

            //}
            //else
            //{
            //    lblFileUploadMenuPicture.ForeColor = System.Drawing.Color.Red;
            //    lblFileUploadMenuPicture.Text = "Please select Image";
            //}
            //if (FileUploadMenuPicture2.HasFile)
            //{
            //    string fileName2 = FileUploadMenuPicture2.FileName;
            //    string folderPath2 = Server.MapPath("~/Files/Images/" + txtMenuTitle.Text+"2/");
            //    string image2 = "/Files/Images/" + txtMenuTitle.Text + "2/"+ fileName2;
            //    string storeImage2 = folderPath2 + fileName2;
            //    if (!Directory.Exists(folderPath2))
            //    {
            //        Directory.CreateDirectory(folderPath2);
            //    }
            //    FileUploadMenuPicture.SaveAs(storeImage2);

            //    lblFileUploadMenuPicture2.Text = "Image upload successfully";
            //    lblFileUploadMenuPicturePath2.Text = Request.UrlReferrer + image2;
            //    lblFileUploadMenuPicture2.ForeColor = System.Drawing.Color.Green;

            //}
            //else
            //{
            //    lblFileUploadMenuPicture2.ForeColor = System.Drawing.Color.Red;
            //    lblFileUploadMenuPicture2.Text = "Please select Image";
            //}

            
        }
    }
}