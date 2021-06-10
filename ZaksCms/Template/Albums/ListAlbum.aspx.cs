using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZaksCms;

namespace ZaksCms.UserControl.Template.Albums
{
    public partial class ListAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Album ac = new Album();
            rptAlbums.DataSource = ac.GetAlbums();
            rptAlbums.DataBind();
        }
        protected void Edit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int AlbumID = int.Parse(btn.CommandArgument);
            Response.Redirect("/admin/EditAlbum" + AlbumID);
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int AlbumID = int.Parse(btn.CommandArgument);
            Album dc = new Album();
            dc.DeleteAlbum(AlbumID);
            rptAlbums.DataSource = dc.GetAlbums();
            rptAlbums.DataBind();
        }

        protected void Insert_Redirect(object sender, EventArgs e)
        {
            Response.Redirect("/admin/AddAlbum");
        }
    }
}