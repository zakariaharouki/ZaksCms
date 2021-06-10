using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ZaksCms
{
    public class Contents
    {
        private int _ContentID;
        private string _ContentTitle;
        private string _ContentSubTitle;
        private string _PublishedDate;
        private bool _IsPublished;
        private int _MenuID;
        private int _LanguageID;
        private int _AlbumID;
        private string _StartDateTime;
        private string _EndDateTime;
        private int _AuthorID;
        private int _ContentCategoryID;
        private string _MetaTitle;
        private string _MetaKeyword;
        private string _MetaDescription;
        private string _UploadContentImage;
        private string _UploadContentFile;
        private string _UploadThumbnailContentImage;
        private string _Summary;
        private string _CustomText1;
        private string _CustomText2;
        private string _CustomText3;
        private string _Description;


        public int ContentID { get { return _ContentID; } set { _ContentID = value; } }
        public string ContentTitle { get { return _ContentTitle; } set { _ContentTitle = value; } }
        public string ContentSubTitle { get { return _ContentSubTitle; } set { _ContentSubTitle = value; } }
        public string PublishedDate { get { return _PublishedDate; } set { _PublishedDate = value; } }
        public bool IsPublished { get { return _IsPublished; } set { _IsPublished = value; } }
        public int MenuID { get { return _MenuID; } set { _MenuID = value; } }
        public int LanguageID { get { return _LanguageID; } set { _LanguageID = value; } }
        public int AlbumID { get { return _AlbumID; } set { _AlbumID = value; } }
        public string StartDateTime { get { return _StartDateTime; } set { _StartDateTime = value; } }
        public string EndDateTime { get { return _EndDateTime; } set { _EndDateTime = value; } }
        public int ContentCategoryID { get { return _ContentCategoryID; } set { _ContentCategoryID = value; } }
        public int AuthorID { get { return _AuthorID; } set { _AuthorID = value; } }
        public string MetaTitle { get { return _MetaTitle; } set { _MetaTitle = value; } }
        public string MetaKeyword { get { return _MetaKeyword; } set { _MetaKeyword = value; } }
        public string MetaDescription { get { return _MetaDescription; } set { _MetaDescription = value; } }
        public string Summary { get { return _Summary; } set { _Summary = value; } }
        public string CustomText1 { get { return _CustomText1; } set { _CustomText1 = value; } }
        public string CustomText2 { get { return _CustomText2; } set { _CustomText2 = value; } }
        public string CustomText3 { get { return _CustomText3; } set { _CustomText3 = value; } }
        public string UploadContentImage { get { return _UploadContentImage; } set { _UploadContentImage = value; } }
        public string UploadContentFile { get { return _UploadContentFile; } set { _UploadContentFile = value; } }
        public string UploadThumbnailContentImage { get { return _UploadThumbnailContentImage; } set { _UploadThumbnailContentImage = value; } }
        public string Description { get { return _Description; } set { _Description = value; } }
        public int PreviousID { get; set; }
        public int NextContentID { get; set; }
        public string CoverImage { get; set; }
        public void Insert(string ContentTitle, string ContentSubTitle, DateTime PublishedDate, bool IsPublished, int LanguageID,
            int MenuID, int AlbumID, DateTime StartDateTime, DateTime EndDateTime, int AuthorID, int ContentCategoryID,
            string MetaTitle, string MetaKeyword, string MetaDescription, string UploadContentImage,
            string UploadContentFile, string UploadThumbnailContentImage, string Summary, string CustomText1,
            string CustomText2, string CustomText3, string Description,string CoverImage)
        {
            string query = "INSERT INTO Content (ContentTitle, ContentSubTitle, PublishedDate, IsPublished, MenuID,"
                + "LanguageID, AlbumID, StartDateTime, EndDateTime, AuthorID, ContentCategoryID, MetaTitle,MetaKeyword, MetaDescription,"
                + "UploadContentImage, UploadContentFile, UploadThumbnailContentImage, Summary,"
                + "CustomText1, CustomText2, CustomText3, Description,CoverImage) VALUES (@ContentTitle, @ContentSubTitle, @PublishedDate,"
                + "@IsPublished, @MenuID, @LanguageID , @AlbumID, @StartDateTime, @EndDateTime, @AuthorID, @ContentCategoryID, @MetaTitle,"
                + "@MetaKeyword, @MetaDescription, @UploadContentImage, @UploadContentFile, @UploadThumbnailContentImage,"
                + "@Summary, @CustomText1, @CustomText2, @CustomText3, @Description,@CoverImage)";
            var connection = new SqlConnection(Global.MyConn);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ContentTitle", ContentTitle);
            cmd.Parameters.AddWithValue("@ContentSubTitle", ContentSubTitle);
            cmd.Parameters.AddWithValue("@PublishedDate", PublishedDate);
            cmd.Parameters.AddWithValue("@IsPublished", IsPublished);
            cmd.Parameters.AddWithValue("@LanguageID", LanguageID);
            cmd.Parameters.AddWithValue("@MenuID", MenuID);
            cmd.Parameters.AddWithValue("@AlbumID", AlbumID);
            cmd.Parameters.AddWithValue("@StartDateTime", StartDateTime);
            cmd.Parameters.AddWithValue("@EndDateTime", EndDateTime);
            cmd.Parameters.AddWithValue("@AuthorID", AuthorID);
            cmd.Parameters.AddWithValue("@ContentCategoryID", ContentCategoryID);
            cmd.Parameters.AddWithValue("@MetaTitle", MetaTitle);
            cmd.Parameters.AddWithValue("@MetaKeyword", MetaKeyword);
            cmd.Parameters.AddWithValue("@MetaDescription", MetaDescription);
            cmd.Parameters.AddWithValue("@UploadContentImage", UploadContentImage);
            cmd.Parameters.AddWithValue("@UploadContentFile", UploadContentFile);
            cmd.Parameters.AddWithValue("@UploadThumbnailContentImage", UploadThumbnailContentImage);
            cmd.Parameters.AddWithValue("@Summary", Summary);
            cmd.Parameters.AddWithValue("@CustomText1", CustomText1);
            cmd.Parameters.AddWithValue("@CustomText2", CustomText2);
            cmd.Parameters.AddWithValue("@CustomText3", CustomText3);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@CoverImage", CoverImage);
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(int ContentID, string ContentTitle, string ContentSubTitle, DateTime PublishedDate, bool IsPublished,
            int LanguageID, int MenuID, int AlbumID, DateTime StartDateTime, DateTime EndDateTime, int AuthorID, int ContentCategoryID,
            string MetaTitle, string MetaKeyword, string MetaDescription, string UploadContentImage,
            string UploadContentFile, string UploadThumbnailContentImage, string Summary, string CustomText1,
            string CustomText2, string CustomText3, string Description)
        {
            string query = "UPDATE Content  SET " +
                "ContentTitle = @ContentTitle," +
                " ContentSubTitle = @ContentSubTitle,"
                 + " PublishedDate = @PublishedDate," +
                 " IsPublished = @IsPublished," +
                 " MenuID = @MenuID," +
                 " LanguageID = @LanguageID," +
                 " AlbumID = @AlbumID,"
                 + " StartDateTime = @StartDateTime," +
                 " EndDateTime = @EndDateTime," +
                 " AuthorID = @AuthorID,"
                 + " ContentCategoryID = @ContentCategoryID,  MetaTitle = @MetaTitle, MetaKeyword = @MetaKeyword,"
                 + " MetaDescription = @MetaDescription, UploadContentImage = @UploadContentImage, UploadContentFile = @UploadContentFile,"
                 + " UploadThumbnailContentImage = @UploadThumbnailContentImage, Summary = @Summary, CustomText1 = @CustomText1,"
                 + " CustomText2 = @CustomText2, CustomText3 = @CustomText3, Description = @Description WHERE ContentID = @ContentID";
            var connection = new SqlConnection(Global.MyConn);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ContentID", ContentID);
            cmd.Parameters.AddWithValue("@ContentTitle", ContentTitle);
            cmd.Parameters.AddWithValue("@ContentSubTitle", ContentSubTitle);
            cmd.Parameters.AddWithValue("@PublishedDate", PublishedDate);
            cmd.Parameters.AddWithValue("@IsPublished", IsPublished);
            cmd.Parameters.AddWithValue("@MenuID", MenuID);
            cmd.Parameters.AddWithValue("@LanguageID", LanguageID);
            cmd.Parameters.AddWithValue("@AlbumID", AlbumID);
            cmd.Parameters.AddWithValue("@StartDateTime", StartDateTime);
            cmd.Parameters.AddWithValue("@EndDateTime", EndDateTime);
            cmd.Parameters.AddWithValue("@AuthorID", AuthorID);
            cmd.Parameters.AddWithValue("@ContentCategoryID", ContentCategoryID);
            cmd.Parameters.AddWithValue("@MetaTitle", MetaTitle);
            cmd.Parameters.AddWithValue("@MetaKeyword", MetaKeyword);
            cmd.Parameters.AddWithValue("@MetaDescription", MetaDescription);
            cmd.Parameters.AddWithValue("@UploadContentImage", UploadContentImage);
            cmd.Parameters.AddWithValue("@UploadContentFile", UploadContentFile);
            cmd.Parameters.AddWithValue("@UploadThumbnailContentImage", UploadThumbnailContentImage);
            cmd.Parameters.AddWithValue("@Summary", Summary);
            cmd.Parameters.AddWithValue("@CustomText1", CustomText1);
            cmd.Parameters.AddWithValue("@CustomText2", CustomText2);
            cmd.Parameters.AddWithValue("@CustomText3", CustomText3);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            connection.Close();

        }

        public void DeleteContent(int ContentID)
        {
            string query = "DELETE FROM Content WHERE ContentID = @ContentID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ContentID", ContentID);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public DataTable GetContents()
        {
            string query = "SELECT * FROM [Content]";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            connection.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
            /**string Query = "SELECT * FROM Content";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;**/

        }
        public void GetContent(int ContentID)
        {
            string Query = "SELECT * FROM Content WHERE ContentID = @ContentID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(Query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@ContentID", ContentID);
            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                ContentID = int.Parse(reader["ContentID"].ToString());
                ContentTitle = reader["ContentTitle"].ToString();
                ContentSubTitle = reader["ContentSubTitle"].ToString();
                PublishedDate = reader["PublishedDate"].ToString();
                IsPublished = bool.Parse(reader["IsPublished"].ToString());
                MenuID = int.Parse(reader["MenuID"].ToString());
                LanguageID = int.Parse(reader["LanguageID"].ToString());
                AlbumID = int.Parse(reader["AlbumID"].ToString());
                StartDateTime = reader["StartDateTime"].ToString();
                EndDateTime = reader["EndDateTime"].ToString();
                AuthorID = int.Parse(reader["AuthorID"].ToString());
                ContentCategoryID = int.Parse(reader["ContentCategoryID"].ToString());
                MetaTitle = reader["MetaTitle"].ToString();
                MetaKeyword = reader["MetaKeyword"].ToString();
                MetaDescription = reader["MetaDescription"].ToString();
                UploadContentImage = reader["UploadContentImage"].ToString();
                UploadContentFile = reader["UploadContentFile"].ToString();
                UploadThumbnailContentImage = reader["UploadThumbnailContentImage"].ToString();
                Summary = reader["Summary"].ToString();
                CustomText1 = reader["CustomText1"].ToString();
                CustomText2 = reader["CustomText2"].ToString();
                CustomText3 = reader["CustomText3"].ToString();
                Description = reader["Description"].ToString();
            }
            connection.Close();
        }
        public DataTable GetMenuContent(int MenuID)
        {
            string query = "SELECT * FROM [Content] Where MenuID=@MenuID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@MenuID", MenuID);
            cmd.ExecuteNonQuery();
            connection.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }
        public DataTable GetBlogDetails(int ContentID)
        {
            string query = "SELECT 	ContentSubTitle, MetaTitle, MetaKeyword, MetaDescription, UploadContentImage, Summary, CustomText1, CustomText2, CustomText3, Description FROM [Content] Where ContentID=@ContentID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@ContentID", ContentID);
            cmd.ExecuteNonQuery();
            connection.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public void Getauthorid(int ContentID)
        {
            string Query = "SELECT AuthorID FROM [Content] Where ContentID=@ContentID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(Query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@ContentID", ContentID);
            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                AuthorID = int.Parse(reader["AuthorID"].ToString());
            }
            connection.Close();
        }
        public void PrevID(int ContentID, int MenuID, string PublishedDate)
        {
            string query = "SELECT ContentID FROM Content WHERE PublishedDate<=@PublishedDate AND ContentID NOT LIKE @ContentID AND MenuID=@MenuID ORDER BY PublishedDate DESC, ContentID ASC OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@ContentID", ContentID);
            Cmd.Parameters.AddWithValue("@PublishedDate", PublishedDate);
            Cmd.Parameters.AddWithValue("@MenuID", MenuID);
            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                PreviousID = int.Parse(reader["ContentID"].ToString());
            }
            connection.Close();


        }
        public void GetContentPublishedDate(int ContentID)
        {
            string Query = "SELECT PublishedDate FROM Content WHERE ContentID = @ContentID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(Query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@ContentID", ContentID);
            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                PublishedDate = reader["PublishedDate"].ToString();
            }
        }
        public void NextID(int ContentID, int MenuID, string PublishedDate)
        {
            string query = "SELECT ContentID FROM Content WHERE PublishedDate>=@PublishedDate AND ContentID NOT LIKE @ContentID AND MenuID=@MenuID ORDER BY PublishedDate ASC, ContentID ASC OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@ContentID", ContentID);
            Cmd.Parameters.AddWithValue("@PublishedDate", PublishedDate);
            Cmd.Parameters.AddWithValue("@MenuID", MenuID);
            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                NextContentID = int.Parse(reader["ContentID"].ToString());
            }
            connection.Close();


        }
        public DataTable GetZoneContents(int MenuID)
        {
            string query = "SELECT * FROM Content WHERE MenuID=@MenuID ORDER BY PublishedDate ASC OFFSET 0 ROWS FETCH NEXT 4 ROWS ONLY";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@MenuID", MenuID);
            cmd.ExecuteNonQuery();
            connection.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public void GetZoneContentsDetails(int MenuID)
        {
            string query = "SELECT * FROM Content WHERE MenuID = @MenuID ORDER BY PublishedDate DESC OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@MenuID", MenuID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                ContentID = int.Parse(reader["ContentID"].ToString());
                ContentTitle = reader["ContentTitle"].ToString();
                ContentSubTitle = reader["ContentSubTitle"].ToString();
                PublishedDate = reader["PublishedDate"].ToString();
                IsPublished = bool.Parse(reader["IsPublished"].ToString());
                MenuID = int.Parse(reader["MenuID"].ToString());
                LanguageID = int.Parse(reader["LanguageID"].ToString());
                AlbumID = int.Parse(reader["AlbumID"].ToString());
                StartDateTime = reader["StartDateTime"].ToString();
                EndDateTime = reader["EndDateTime"].ToString();
                AuthorID = int.Parse(reader["AuthorID"].ToString());
                ContentCategoryID = int.Parse(reader["ContentCategoryID"].ToString());
                MetaTitle = reader["MetaTitle"].ToString();
                MetaKeyword = reader["MetaKeyword"].ToString();
                MetaDescription = reader["MetaDescription"].ToString();
                UploadContentImage = reader["UploadContentImage"].ToString();
                UploadContentFile = reader["UploadContentFile"].ToString();
                UploadThumbnailContentImage = reader["UploadThumbnailContentImage"].ToString();
                Summary = reader["Summary"].ToString();
                CustomText1 = reader["CustomText1"].ToString();
                CustomText2 = reader["CustomText2"].ToString();
                CustomText3 = reader["CustomText3"].ToString();
                Description = reader["Description"].ToString();
            }
            connection.Close();
        }
        public DataTable GetZoneContentsLimitThree(int MenuID)
        {
            string query = "SELECT * FROM Content WHERE MenuID=@MenuID ORDER BY PublishedDate ASC OFFSET 0 ROWS FETCH NEXT 3 ROWS ONLY";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@MenuID", MenuID);
            cmd.ExecuteNonQuery();
            connection.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public DataTable GetAsideRecentArticles(int MenuID)
        {
            string query = "SELECT * FROM Content WHERE MenuID=@MenuID ORDER BY PublishedDate DESC OFFSET 0 ROWS FETCH NEXT 3 ROWS ONLY";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@MenuID", MenuID);
            cmd.ExecuteNonQuery();
            connection.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public DataTable GetRelatedPosts(int MenuID, int ContentCategoryID)
        {
            string query = "SELECT * FROM Content WHERE MenuID=@MenuID AND ContentCategoryID=@ContentCategoryID ORDER BY PublishedDate ASC OFFSET 0 ROWS FETCH NEXT 2 ROWS ONLY";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@MenuID", MenuID);
            cmd.Parameters.AddWithValue("@ContentCategoryID", ContentCategoryID);
            cmd.ExecuteNonQuery();
            connection.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public int GetCount(int MenuID, int ContentCategoryID)
        {
            string query = "SELECT COUNT (ContentID) FROM Content WHERE MenuID=@MenuID AND ContentCategoryID=@ContentCategoryID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@MenuID", MenuID);
            cmd.Parameters.AddWithValue("@ContentCategoryID", ContentCategoryID);
            Int32 count = (Int32)cmd.ExecuteScalar();
            connection.Close();
            return count;
        }
        public void GetZoneOneAboutUs(int MenuID)
        {
            string query = "SELECT * FROM Content WHERE MenuID=@MenuID ORDER BY PublishedDate ASC OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@MenuID", MenuID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                ContentID = int.Parse(reader["ContentID"].ToString());
                ContentTitle = reader["ContentTitle"].ToString();
                ContentSubTitle = reader["ContentSubTitle"].ToString();
                PublishedDate = reader["PublishedDate"].ToString();
                IsPublished = bool.Parse(reader["IsPublished"].ToString());
                MenuID = int.Parse(reader["MenuID"].ToString());
                LanguageID = int.Parse(reader["LanguageID"].ToString());
                AlbumID = int.Parse(reader["AlbumID"].ToString());
                StartDateTime = reader["StartDateTime"].ToString();
                EndDateTime = reader["EndDateTime"].ToString();
                AuthorID = int.Parse(reader["AuthorID"].ToString());
                ContentCategoryID = int.Parse(reader["ContentCategoryID"].ToString());
                MetaTitle = reader["MetaTitle"].ToString();
                MetaKeyword = reader["MetaKeyword"].ToString();
                MetaDescription = reader["MetaDescription"].ToString();
                UploadContentImage = reader["UploadContentImage"].ToString();
                UploadContentFile = reader["UploadContentFile"].ToString();
                UploadThumbnailContentImage = reader["UploadThumbnailContentImage"].ToString();
                Summary = reader["Summary"].ToString();
                CustomText1 = reader["CustomText1"].ToString();
                CustomText2 = reader["CustomText2"].ToString();
                CustomText3 = reader["CustomText3"].ToString();
                Description = reader["Description"].ToString();
            }
            connection.Close();
        }
        public DataTable GetZoneTwoAboutUs(int MenuID)
        {
            string query = "SELECT * FROM Content WHERE MenuID=@MenuID ORDER BY PublishedDate ASC OFFSET 1 ROWS FETCH NEXT 3 ROWS ONLY";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@MenuID", MenuID);
            cmd.ExecuteNonQuery();
            connection.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public void GetZoneThreeAboutUs(int MenuID)
        {
            string query = "SELECT * FROM Content WHERE MenuID=@MenuID ORDER BY PublishedDate ASC OFFSET 4 ROWS FETCH NEXT 1 ROWS ONLY";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@MenuID", MenuID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                ContentID = int.Parse(reader["ContentID"].ToString());
                ContentTitle = reader["ContentTitle"].ToString();
                ContentSubTitle = reader["ContentSubTitle"].ToString();
                PublishedDate = reader["PublishedDate"].ToString();
                IsPublished = bool.Parse(reader["IsPublished"].ToString());
                MenuID = int.Parse(reader["MenuID"].ToString());
                LanguageID = int.Parse(reader["LanguageID"].ToString());
                AlbumID = int.Parse(reader["AlbumID"].ToString());
                StartDateTime = reader["StartDateTime"].ToString();
                EndDateTime = reader["EndDateTime"].ToString();
                AuthorID = int.Parse(reader["AuthorID"].ToString());
                ContentCategoryID = int.Parse(reader["ContentCategoryID"].ToString());
                MetaTitle = reader["MetaTitle"].ToString();
                MetaKeyword = reader["MetaKeyword"].ToString();
                MetaDescription = reader["MetaDescription"].ToString();
                UploadContentImage = reader["UploadContentImage"].ToString();
                UploadContentFile = reader["UploadContentFile"].ToString();
                UploadThumbnailContentImage = reader["UploadThumbnailContentImage"].ToString();
                Summary = reader["Summary"].ToString();
                CustomText1 = reader["CustomText1"].ToString();
                CustomText2 = reader["CustomText2"].ToString();
                CustomText3 = reader["CustomText3"].ToString();
                Description = reader["Description"].ToString();
            }
            connection.Close();

        }
        public DataTable GetZoneFourAboutUs(int MenuID)
        {
            string query = "SELECT * FROM Content WHERE MenuID=@MenuID ORDER BY PublishedDate ASC OFFSET 5 ROWS FETCH NEXT 3 ROWS ONLY";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@MenuID", MenuID);
            cmd.ExecuteNonQuery();
            connection.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public DataTable GetZoneFiveAboutUs(int MenuID)
        {
            string query = "SELECT * FROM Content WHERE MenuID=@MenuID ORDER BY PublishedDate ASC OFFSET 8 ROWS FETCH NEXT 4 ROWS ONLY";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@MenuID", MenuID);
            cmd.ExecuteNonQuery();
            connection.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public void GetZoneSixAboutUs(int MenuID)
        {
            string query = "SELECT * FROM Content WHERE MenuID=@MenuID ORDER BY PublishedDate ASC OFFSET 12 ROWS FETCH NEXT 1 ROWS ONLY";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@MenuID", MenuID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                ContentID = int.Parse(reader["ContentID"].ToString());
                ContentTitle = reader["ContentTitle"].ToString();
                ContentSubTitle = reader["ContentSubTitle"].ToString();
                PublishedDate = reader["PublishedDate"].ToString();
                IsPublished = bool.Parse(reader["IsPublished"].ToString());
                MenuID = int.Parse(reader["MenuID"].ToString());
                LanguageID = int.Parse(reader["LanguageID"].ToString());
                AlbumID = int.Parse(reader["AlbumID"].ToString());
                StartDateTime = reader["StartDateTime"].ToString();
                EndDateTime = reader["EndDateTime"].ToString();
                AuthorID = int.Parse(reader["AuthorID"].ToString());
                ContentCategoryID = int.Parse(reader["ContentCategoryID"].ToString());
                MetaTitle = reader["MetaTitle"].ToString();
                MetaKeyword = reader["MetaKeyword"].ToString();
                MetaDescription = reader["MetaDescription"].ToString();
                UploadContentImage = reader["UploadContentImage"].ToString();
                UploadContentFile = reader["UploadContentFile"].ToString();
                UploadThumbnailContentImage = reader["UploadThumbnailContentImage"].ToString();
                Summary = reader["Summary"].ToString();
                CustomText1 = reader["CustomText1"].ToString();
                CustomText2 = reader["CustomText2"].ToString();
                CustomText3 = reader["CustomText3"].ToString();
                Description = reader["Description"].ToString();
            }
            connection.Close();
        }
        public DataTable GetZoneSevenAboutUs(int MenuID)
        {
            string query = "SELECT * FROM Content WHERE MenuID=@MenuID ORDER BY PublishedDate ASC OFFSET 13 ROWS FETCH NEXT 5 ROWS ONLY";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@MenuID", MenuID);
            cmd.ExecuteNonQuery();
            connection.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public DataTable GetZoneEightAboutUs(int MenuID)
        {
            string query = "SELECT * FROM Content WHERE MenuID=@MenuID ORDER BY PublishedDate ASC OFFSET 18 ROWS FETCH NEXT 10 ROWS ONLY";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@MenuID", MenuID);
            cmd.ExecuteNonQuery();
            connection.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public void GetMainContents(int MenuID)
        {
            string query = "SELECT * FROM Content WHERE MenuID=@MenuID ORDER BY PublishedDate DESC OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY ";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@MenuID", MenuID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                ContentID = int.Parse(reader["ContentID"].ToString());
                ContentTitle = reader["ContentTitle"].ToString();
                ContentSubTitle = reader["ContentSubTitle"].ToString();
                PublishedDate = reader["PublishedDate"].ToString();
                IsPublished = bool.Parse(reader["IsPublished"].ToString());
                MenuID = int.Parse(reader["MenuID"].ToString());
                LanguageID = int.Parse(reader["LanguageID"].ToString());
                AlbumID = int.Parse(reader["AlbumID"].ToString());
                StartDateTime = reader["StartDateTime"].ToString();
                EndDateTime = reader["EndDateTime"].ToString();
                AuthorID = int.Parse(reader["AuthorID"].ToString());
                ContentCategoryID = int.Parse(reader["ContentCategoryID"].ToString());
                MetaTitle = reader["MetaTitle"].ToString();
                MetaKeyword = reader["MetaKeyword"].ToString();
                MetaDescription = reader["MetaDescription"].ToString();
                UploadContentImage = reader["UploadContentImage"].ToString();
                UploadContentFile = reader["UploadContentFile"].ToString();
                UploadThumbnailContentImage = reader["UploadThumbnailContentImage"].ToString();
                Summary = reader["Summary"].ToString();
                CustomText1 = reader["CustomText1"].ToString();
                CustomText2 = reader["CustomText2"].ToString();
                CustomText3 = reader["CustomText3"].ToString();
                Description = reader["Description"].ToString();
            }
            connection.Close();
        }
        public void GetauthoridUsingMenuID(int MenuID)
        {
            string Query = "SELECT AuthorID FROM [Content] Where MenuID=@MenuID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(Query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@MenuID", MenuID);
            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                AuthorID = int.Parse(reader["AuthorID"].ToString());
            }
            connection.Close();
        }

        public DataTable GetBlogListingPageTwo(int MenuID)
        {
            string query = "SELECT * FROM Content WHERE MenuID=@MenuID ORDER BY PublishedDate DESC OFFSET 4 ROWS FETCH NEXT 4 ROWS ONLY";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@MenuID", MenuID);
            cmd.ExecuteNonQuery();
            connection.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public DataTable GetBlogListingPageThree(int MenuID)
        {
            string query = "SELECT * FROM Content WHERE MenuID=@MenuID ORDER BY PublishedDate DESC OFFSET 8 ROWS";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@MenuID", MenuID);
            cmd.ExecuteNonQuery();
            connection.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}