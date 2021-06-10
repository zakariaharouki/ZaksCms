using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZaksCms;

namespace ZaksCms.UserControl.Template.Albums
{
    public partial class AddAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int num = 0;
            AlbumOrder.Text = num.ToString();
            chkPublished.Checked = true;
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
           Album ac = new Album();
            ac.Insert(txtEnglishAlbumName.Text, txtArabicAlbumName.Text, txtOtherAlbumName.Text, int.Parse(AlbumOrder.Text), chkPublished.Checked);
            Response.Redirect("/admin/ListAlbum");
        }
    }
}