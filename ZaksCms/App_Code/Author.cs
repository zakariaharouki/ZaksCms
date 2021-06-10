using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ZaksCms
{
    public class Author
    {
        private int _AuthorID;
        private string _AuthorName;
        private string _AuthorJobTitle;
        private string _AuthorAddress;
        private string _AuthorEmail;
        private string _AuthorWebsite;
        private string _AuthorPicture;
        private string _AuthorLinkedIn;
        private string _AuthorFacebook;
        private string _AuthorTwitter;
        private string _AuthorInstagram;

        public int AuthorID { get { return _AuthorID; } set { _AuthorID = value; } }
        public string AuthorName { get { return _AuthorName; } set { _AuthorName = value; } }
        public string AuthorJobTitle { get { return _AuthorJobTitle; } set { _AuthorJobTitle = value; } }
        public string AuthorAddress { get { return _AuthorAddress; } set { _AuthorAddress = value; } }
        public string AuthorEmail { get { return _AuthorEmail; } set { _AuthorEmail = value; } }
        public string AuthorWebsite { get { return _AuthorWebsite; } set { _AuthorWebsite = value; } }
        public string AuthorPicture { get { return _AuthorPicture; } set { _AuthorPicture = value; } }
        public string AuthorLinkedIn { get { return _AuthorLinkedIn; } set { _AuthorLinkedIn = value; } }
        public string AuthorFacebook { get { return _AuthorFacebook; } set { _AuthorFacebook = value; } }
        public string AuthorTwitter { get { return _AuthorTwitter; } set { _AuthorTwitter = value; } }
        public string AuthorInstagram { get { return _AuthorInstagram; } set { _AuthorInstagram = value; } }
        public int LanguageID { get; set; }

        public void Insert(string AuthorName, string AuthorJobTitle, string AuthorAddress, string AuthorEmail, string AuthorWebsite, string AuthorPicture, string AuthorLinkedIn, string AuthorFacebook, string AuthorTwitter, string AuthorInstagram, int LanguageID)
        {
            string query = "INSERT INTO Author (AuthorName, AuthorJobTitle, AuthorAddress, AuthorEmail, AuthorWebsite, AuthorPicture, AuthorLinkedIn, AuthorFacebook, AuthorTwitter, AuthorInstagram,LanguageID) " + "VALUES(@AuthorName, @AuthorJobTitle, @AuthorAddress, @AuthorEmail, @AuthorWebsite, @AuthorPicture, @AuthorLinkedIn, @AuthorFacebook, @AuthorTwitter, @AuthorInstagram,@LanguageID)";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@AuthorName", AuthorName);
            cmd.Parameters.AddWithValue("@AuthorJobTitle", AuthorJobTitle);
            cmd.Parameters.AddWithValue("@AuthorAddress", AuthorAddress);
            cmd.Parameters.AddWithValue("@AuthorEmail", AuthorEmail);
            cmd.Parameters.AddWithValue("@AuthorWebsite", AuthorWebsite);
            cmd.Parameters.AddWithValue("@AuthorPicture", AuthorPicture);
            cmd.Parameters.AddWithValue("@AuthorLinkedIn", AuthorLinkedIn);
            cmd.Parameters.AddWithValue("@Authorfacebook", AuthorFacebook);
            cmd.Parameters.AddWithValue("@AuthorTwitter", AuthorTwitter);
            cmd.Parameters.AddWithValue("@AuthorInstagram", AuthorInstagram);
            cmd.Parameters.AddWithValue("@LanguageID", LanguageID);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(int AuthorID, string AuthorName, string AuthorJobTitle, string AuthorAddress, string AuthorEmail, string AuthorWebsite, string AuthorPicture, string AuthorLinkedIn, string AuthorFacebook, string AuthorTwitter, string AuthorInstagram, int LanguageID)
        {
            try
            {
                string query = "UPDATE Author SET AuthorName = @AuthorName, AuthorJobTitle = @AuthorJobTitle, AuthorAddress = @AuthorAddress, AuthorEmail = @AuthorEmail, AuthorWebsite = @AuthorWebsite, AuthorPicture = @AuthorPicture, AuthorLinkedIn = @AuthorLinkedIn, AuthorFacebook = @AuthorFacebook, AuthorTwitter = @AuthorTwitter, AuthorInstagram = @AuthorInstagram,LanguageID=@LanguageID WHERE AuthorID = @AuthorID";
                var connection = new SqlConnection(Global.MyConn);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@AuthorID", AuthorID);
                cmd.Parameters.AddWithValue("@AuthorName", AuthorName);
                cmd.Parameters.AddWithValue("@AuthorJobTitle", AuthorJobTitle);
                cmd.Parameters.AddWithValue("@AuthorAddress", AuthorAddress);
                cmd.Parameters.AddWithValue("@AuthorEmail", AuthorEmail);
                cmd.Parameters.AddWithValue("@AuthorWebsite", AuthorWebsite);
                cmd.Parameters.AddWithValue("@AuthorPicture", AuthorPicture);
                cmd.Parameters.AddWithValue("@AuthorLinkedIn", AuthorLinkedIn);
                cmd.Parameters.AddWithValue("@AuthorFacebook", AuthorFacebook);
                cmd.Parameters.AddWithValue("@AuthorTwitter", AuthorTwitter);
                cmd.Parameters.AddWithValue("@AuthorInstagram", AuthorInstagram);
                cmd.Parameters.AddWithValue("@LanguageID", LanguageID);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteAuthor(int AuthorID)
        {
            string query = "DELETE FROM Author WHERE AuthorID = @AuthorID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@AuthorID", AuthorID);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable GetAuthors()
        {
            string Query = "SELECT * FROM Author";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void GetAuthor(int AuthorID)
        {
            string Query = "SELECT * FROM Author WHERE AuthorID = @AuthorID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(Query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@AuthorID", AuthorID);
            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                AuthorID = int.Parse(reader["AuthorID"].ToString());
                AuthorName = reader["AuthorName"].ToString();
                AuthorJobTitle = reader["AuthorJobTitle"].ToString();
                AuthorAddress = reader["AuthorAddress"].ToString();
                AuthorEmail = reader["AuthorEmail"].ToString();
                AuthorWebsite = reader["AuthorWebsite"].ToString();
                AuthorPicture = reader["AuthorPicture"].ToString();
                AuthorLinkedIn = reader["AuthorLinkedIn"].ToString();
                AuthorFacebook = reader["AuthorFacebook"].ToString();
                AuthorTwitter = reader["AuthorTwitter"].ToString();
                AuthorInstagram = reader["AuthorInstagram"].ToString();
                LanguageID = int.Parse(reader["LanguageID"].ToString());
            }
            connection.Close();
        }
        public DataTable GetAuthordetails(int AuthorID)
        {
            string query = "SELECT * FROM Author Where AuthorID=@AuthorID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@AuthorID", AuthorID);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public DataTable GetAdmin()
        {
            string query = "SELECT * FROM Author Where AuthorName='FullMarq'";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandText = query;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}