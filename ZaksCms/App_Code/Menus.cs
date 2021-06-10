using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ZaksCms
{
    public class Menus
    {
        private int _MenuID;
        private string _Title;
        private string _Picture;
        private int _LanguageID;
        private int _DirectionID;
        private int _ParentID;
        private bool _IsPublished;
        private int _MenuOrder;
        private string _MetaTitle;
        private string _MetaKeyword;
        private string _MetaDescription;


        public int MenuID { get; set;}
        public string Title { get; set;}
        public string Picture { get; set;}
        public int LanguageID { get; set;}
        public int DirectionID { get; set;}
        public int ParentID { get; set;}
        public bool IsPublished { get; set;}
        public int MenuOrder { get; set;}
        public string MetaTitle { get; set;}
        public string MetaKeyword { get; set;}
        public string MetaDescription { get; set;}
        public bool SubBool {get;set;}
        public string PrevUrl { get;set;}
        public string NextUrl { get;set;}


        public void Insert(string Title, string Picture, int LanguageID, int DirectionID, int ParentID, bool IsPublished, int MenuOrder, string MetaTitle, string MetaKeyword, string MetaDescription)
        {

            string query = "INSERT INTO Menu (Title, Picture, LanguageID, DirectionID, ParentID, IsPublished, MenuOrder, MetaTitle, MetaKeyword, MetaDescription) "
                + "VALUES (@Title, @Picture, @LanguageID, @DirectionID, @ParentID, @IsPublished, @MenuOrder, @MetaTitle, @MetaKeyword, @MetaDescription)";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            Cmd.Parameters.AddWithValue("@Title", Title);
            Cmd.Parameters.AddWithValue("@Picture", Picture);
            Cmd.Parameters.AddWithValue("@LanguageID", LanguageID);
            Cmd.Parameters.AddWithValue("@DirectionID", DirectionID);
            Cmd.Parameters.AddWithValue("@ParentID", ParentID);
            Cmd.Parameters.AddWithValue("@IsPublished", IsPublished);
            Cmd.Parameters.AddWithValue("@MenuOrder", MenuOrder);
            Cmd.Parameters.AddWithValue("@MetaTitle", MetaTitle);
            Cmd.Parameters.AddWithValue("@MetaKeyword", MetaKeyword);
            Cmd.Parameters.AddWithValue("@MetaDescription", MetaDescription);
            connection.Open();
            Cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(int MenuID, string Title, string Picture, int LanguageID, int DirectionID, int ParentID, bool IsPublished, int MenuOrder, string MetaTitle, string MetaKeyword, string MetaDescription)
        {
            string query = "UPDATE Menu SET Title = @Title, Picture = @Picture, LanguageID = @LanguageID,"
                + "DirectionID = @DirectionID, ParentID = @ParentID, IsPublished = @IsPublished, MenuOrder = @MenuOrder,"
                + "MetaTitle = @MetaTitle, MetaKeyword = @MetaKeyword, MetaDescription = @MetaDescription WHERE MenuID = @MenuID ";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            Cmd.Parameters.AddWithValue("@MenuID", MenuID);
            Cmd.Parameters.AddWithValue("@Title", Title);
            Cmd.Parameters.AddWithValue("@Picture", Picture);
            Cmd.Parameters.AddWithValue("@LanguageID", LanguageID);
            Cmd.Parameters.AddWithValue("@DirectionID", DirectionID);
            Cmd.Parameters.AddWithValue("@ParentID", ParentID);
            Cmd.Parameters.AddWithValue("@IsPublished", IsPublished);
            Cmd.Parameters.AddWithValue("@MenuOrder", MenuOrder);
            Cmd.Parameters.AddWithValue("@MetaTitle", MetaTitle);
            Cmd.Parameters.AddWithValue("@MetaKeyword", MetaKeyword);
            Cmd.Parameters.AddWithValue("@MetaDescription", MetaDescription);
            connection.Open();
            Cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteMenu(int MenuID)
        {
            string query = "DELETE Menu WHERE MenuID = @MenuID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            Cmd.Parameters.AddWithValue("@MenuID", MenuID);
            connection.Open();
            Cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Publish(int MenuID)
        {
            string query = "UPDATE Menu SET IsPublished = 'true' WHERE MenuID = @MenuID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            Cmd.Parameters.AddWithValue("@MenuID", MenuID);
            connection.Open();
            Cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Unpublish(int MenuID)
        {
            string query = "UPDATE Menu SET IsPublished = 'false' WHERE MenuID = @MenuID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            Cmd.Parameters.AddWithValue("@MenuID", MenuID);
            connection.Open();
            Cmd.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable GetMenus()
        {
            string Query = "SELECT * FROM Menu";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetParentMenus()
        {
            string Query = "select * from Menu where ParentID='0'";
            var connection = new SqlConnection(Global.MyConn);
            connection.Open();
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.CommandText = Query;
            cmd.ExecuteNonQuery();
            connection.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable GetSubMenus(string menuID)
        {
            string Query = "select * from Menu where ParentID =" + menuID;
            var connection = new SqlConnection(Global.MyConn);
            connection.Open();
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.CommandText = Query;
            cmd.ExecuteNonQuery();
            connection.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public DataTable GetPublishedMenus()
        {
            string Query = "SELECT * FROM Menu WHERE IsPublished ='true'";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetUnPublishedMenus()
        {
            string Query = "SELECT Title FROM Menu WHERE IsPublished = 'false'";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public string FormUrl(int MenuID)
        {
            string url = "";
            GetMenu(MenuID);
            string MenuTitle = Title;
            url = "/en/m/" + MenuID + "/" + MenuTitle; //Using En To Test
            return url.Trim();
        }

        public string FormUrl(int MenuID, int ContentID)
        {
            string url = "";
            GetMenu(MenuID);
            Contents cc = new Contents();
            cc.GetContent(ContentID);
            string ContentTitle = cc.ContentTitle;
            string MenuTitle = Title.Trim();
            url = "/en/m/" + MenuID + "/" + MenuTitle + "/c/" + ContentID + "/" + ContentTitle;
            url = url.Replace(':', '-').Replace('@', '-').Replace('%', '-').Replace('$', '-').Replace('!', '-').Replace('&', '-').Replace('*', '-').Replace('^', '-').Replace('~', '-').Replace('#', '-').Replace('+', '-').Replace('<', '-').Replace('>', '-').Replace('?', '-').Replace(']', '-').Replace('[', '-').Replace('{', '-').Replace('}', '-').Replace('|', '-').Replace(';', '-');
            return url.Trim();
        }

        public void GetMenu(int MenuID)
        {
            string Query = "SELECT * FROM Menu WHERE MenuID = @MenuID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(Query, connection);
            Cmd.Parameters.AddWithValue("@MenuID", MenuID);
            connection.Open();
            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                MenuID = int.Parse(reader["MenuID"].ToString());
                Title = reader["Title"].ToString();
                Picture = reader["Picture"].ToString();
                LanguageID = int.Parse(reader["LanguageID"].ToString());
                DirectionID = int.Parse(reader["DirectionID"].ToString());
                ParentID = int.Parse(reader["ParentID"].ToString());
                IsPublished = bool.Parse(reader["IsPublished"].ToString());
                MenuOrder = int.Parse(reader["MenuOrder"].ToString());
                MetaTitle = reader["MetaTitle"].ToString();
                MetaKeyword = reader["MetaKeyword"].ToString();
                MetaDescription = reader["MetaDescription"].ToString();
            }
            connection.Close();
        }

        public bool SubMenuExist(int MenuID)
        {
            string Query = "select * from Menu where ParentID =" + MenuID;
            var connection = new SqlConnection(Global.MyConn);
            connection.Open();
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.CommandText = Query;
            cmd.ExecuteNonQuery();
            connection.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                SubBool = true;
            }
            else
            {
                SubBool = false;
            }
            return SubBool;
        }
        public int GetParentID(int MenuID)
        {
            string Query = "SELECT ParentID FROM Menu WHERE MenuID = @MenuID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(Query, connection);
            Cmd.Parameters.AddWithValue("@MenuID", MenuID);
            connection.Open();
            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                ParentID = int.Parse(reader["ParentID"].ToString());
                return ParentID;
            }
            else
            {
                ParentID = 0;
                return ParentID;
            }

        }
    }
}
