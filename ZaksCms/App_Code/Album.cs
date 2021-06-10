using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ZaksCms
{
    public class Album
    {
        private int _AlbumID;
        private string _EnglishAlbumName;
        private string _ArabicAlbumName;
        private string _OtherAlbumName;
        private int _AlbumOrder;
        private bool _IsPublished;

        public int AlbumID { get { return _AlbumID; } set { _AlbumID = value; } }
        public string EnglishAlbumName { get { return _EnglishAlbumName; } set { _EnglishAlbumName = value; } }
        public string ArabicAlbumName { get { return _ArabicAlbumName; } set { _ArabicAlbumName = value; } }
        public string OtherAlbumName { get { return _OtherAlbumName; } set { _OtherAlbumName = value; } }
        public int AlbumOrder { get { return _AlbumOrder; } set { _AlbumOrder = value; } }
        public bool IsPublished { get { return _IsPublished; } set { _IsPublished = value; } }

        public void Insert(string EnglishAlbumName, string ArabicAlbumName, string OtherAlbumName, int AlbumOrder, bool IsPublished)
        {
            string query = "INSERT INTO Album (EnglishAlbumName, ArabicAlbumName, OtherAlbumName, AlbumOrder, IsPublished) " + "VALUES(@EnglishAlbumName, @ArabicAlbumName, @OtherAlbumName, @AlbumOrder, @ISPublished)";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@EnglishAlbumName", EnglishAlbumName);
            cmd.Parameters.AddWithValue("@OtherAlbumName", OtherAlbumName);
            cmd.Parameters.AddWithValue("@ArabicAlbumName", ArabicAlbumName);
            cmd.Parameters.AddWithValue("@AlbumOrder", AlbumOrder);
            cmd.Parameters.AddWithValue("@IsPublished", IsPublished);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(int AlbumID, string EnglishAlbumName, string ArabicAlbumName, string OtherAlbumName, int AlbumOrder, bool IsPublished)
        {
            string query = "UPDATE Album SET EnglishAlbumName = @EnglishAlbumName, ArabicAlbumName = @ArabicAlbumName, OtherAlbumName = @OtherAlbumName, AlbumOrder = @AlbumOrder, IsPublished = @IsPublished WHERE AlbumID = @AlbumID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@AlbumID", AlbumID);
            cmd.Parameters.AddWithValue("@EnglishAlbumName", EnglishAlbumName);
            cmd.Parameters.AddWithValue("@ArabicAlbumName", ArabicAlbumName);
            cmd.Parameters.AddWithValue("@OtherAlbumName", OtherAlbumName);
            cmd.Parameters.AddWithValue("@AlbumOrder", AlbumOrder);
            cmd.Parameters.AddWithValue("@IsPublished", IsPublished);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteAlbum(int AlbumID)
        {
            string query = "DELETE FROM Album WHERE AlbumID = @AlbumID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@AlbumID", AlbumID);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Unpublish(int AlbumID)
        {
            SqlConnection Con = new SqlConnection("ConnectionString");
            string query = "UPDATE Album SET IsPublished = 'false' WHERE AlbumID = @AlbumID";
            SqlCommand cmd = new SqlCommand(query, Con);
            Con.Open();
            cmd.ExecuteNonQuery();
            Con.Close();
        }

        //TODO:
        public DataTable GetPublishedAlbums()
        {
            string Query = "SELECT * FROM Album WHERE IsPublished ='true'";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetAlbums()
        {
            string Query = "SELECT * FROM Album";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void GetAlbum(int AlbumID)
        {
            string Query = "SELECT * FROM Album WHERE AlbumID = @AlbumID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(Query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@AlbumID", AlbumID);
            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                AlbumID = int.Parse(reader["AlbumID"].ToString());
                EnglishAlbumName = reader["EnglishAlbumName"].ToString();
                ArabicAlbumName = reader["ArabicAlbumName"].ToString();
                OtherAlbumName = reader["OtherAlbumName"].ToString();
                AlbumOrder = int.Parse(reader["AlbumOrder"].ToString());
                IsPublished = bool.Parse(reader["IsPublished"].ToString());
            }
            connection.Close();
        }

        //public void GetAlbum(int AlbumID)
        //{
        //    string Query = "SELECT * FROM Album WHERE AlbumID = @ALlbumID";
        //    var connection = new SqlConnection(Global.MyConn);
        //    SqlCommand Cmd = new SqlCommand(Query, connection);
        //    connection.Open();
        //    SqlDataReader reader = Cmd.ExecuteReader();
        //    if (reader.Read())
        //    {
        //        AlbumID = int.Parse(reader["AlbumID"].ToString());
        //        EnglishAlbumName = reader["EnglishAlbumName"].ToString();
        //        ArabicAlbumName = reader["ArabicAlbumName"].ToString();
        //        OtherAlbumName = reader["OtherAlbumName"].ToString();
        //        AlbumOrder = int.Parse(reader["AlbumOrder"].ToString());
        //        IsPublished = bool.Parse(reader["IsPublished"].ToString());
        //    }
        //    connection.Close();
        //}

        //public int GetRootAlbums(int ParentID)
        //{
        //    if (ParentID == 0)
        //        return 0;
        //    else
        //        return 1;
        //}

        //public string GetAlbumsOfAlbum(string EnglishAlbumName, int ParentID)
        //{
        //    if (ParentID == 0)
        //        return (EnglishAlbumName);
        //    return "";
        //}

        //public string GetUnPublishedAlbums(string EnglishAlbumName, bool IsPublished)
        //{
        //    if (IsPublished)
        //        return (EnglishAlbumName);
        //    return "";
        //}
    }
}