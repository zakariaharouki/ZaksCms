using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using  ZaksCms;

namespace ZaksCms.UserControl.Template.Albums
{
    public partial class EditAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Album ac = new Album();
                //Check if no paratmeter exist, redirect to list page.           
                string AlbumID = (string)this.RouteData.Values["ID"];
                if (AlbumID == null)
                {
                    Response.Redirect("/admin/ListAlbum");
                }
                ac.GetAlbum(int.Parse(AlbumID));
                txtEnglishAlbumName.Text = ac.EnglishAlbumName;
                txtArabicAlbumName.Text = ac.ArabicAlbumName;
                txtOtherAlbumName.Text = ac.OtherAlbumName;
                txtAlbumOrder.Text = ac.AlbumOrder.ToString();
                chkPublished.Checked = ac.IsPublished;
            }
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            string AlbumID = (string)this.RouteData.Values["ID"];
            Album ac = new Album();
            ac.Update(int.Parse(AlbumID), txtEnglishAlbumName.Text, txtArabicAlbumName.Text, txtOtherAlbumName.Text, int.Parse(txtAlbumOrder.Text), chkPublished.Checked);
            Response.Redirect("/admin/ListAlbum");
        }
    }
}