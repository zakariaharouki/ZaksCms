using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ZaksCms
{
    public class Languages
    {
        private int _LanguageID;
        private string _LanguageTitle;
        private string _LanguageSuffix;
        private bool _DefaultLanguage;

        public int LanguageID { get { return _LanguageID; } set { _LanguageID = value; } }
        public string LanguageTitle { get { return _LanguageTitle; } set { _LanguageTitle = value; } }
        public string LanguageSuffix { get { return _LanguageSuffix; } set { _LanguageSuffix = value; } }
        public bool DefaultLanguage { get { return _DefaultLanguage; } set { _DefaultLanguage = value; } }

        public void Insert(string LanguageTitle, string LanguageSuffix, bool DefaultLanguage)
        {
            if (DefaultLanguage)
            {
                ResetDefaultLanguages();
            }
            string query = "INSERT INTO Language (LanguageTitle, LanguageSuffix, DefaultLanguage) " + "VALUES(@LanguageTitle, @LanguageSuffix, @DefaultLanguage)";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LanguageTitle", LanguageTitle);
            cmd.Parameters.AddWithValue("@LanguageSuffix", LanguageSuffix);
            cmd.Parameters.AddWithValue("@DefaultLanguage", DefaultLanguage);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(int LanguageID, string LanguageTitle, string LanguageSuffix, bool DefaultLanguage)
        {
            if (DefaultLanguage)
            {
                ResetDefaultLanguages();
            }
            string query = "UPDATE Language SET LanguageTitle = @LanguageTitle, LanguageSuffix = @LanguageSuffix, DefaultLanguage = @DefaultLanguage WHERE LanguageID = @LanguageID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LanguageID", LanguageID);
            cmd.Parameters.AddWithValue("@LanguageTitle", LanguageTitle);
            cmd.Parameters.AddWithValue("@LanguageSuffix", LanguageSuffix);
            cmd.Parameters.AddWithValue("@DefaultLanguage", DefaultLanguage);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteLanguage(int LanguageID)
        {
            if (IsDefaultLanguage(LanguageID))
            {
                ResetDefaultLanguages();
            }
            else
            {
                string query = "DELETE FROM Language WHERE LanguageID = @LanguageID";
                var connection = new SqlConnection(Global.MyConn);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@LanguageID", LanguageID);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void ResetDefaultLanguages()
        {
            string query = "UPDATE Language SET DefaultLanguage = 'false'";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void MakeDefault(int LanguageID)
        {
            ResetDefaultLanguages();

        }

        public bool IsDefaultLanguage(int LanguageID)
        {
            return false;
        }

        public DataTable GetLanguages()
        {
            string Query = "SELECT * FROM Language";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void GetLanguage(int LanguageID)
        {
            string Query = "SELECT * FROM Language WHERE LanguageID = @LanguageID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(Query, connection);
            Cmd.Parameters.AddWithValue("@LanguageID", LanguageID);
            connection.Open();
            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                LanguageID = int.Parse(reader["LanguageID"].ToString());
                LanguageTitle = reader["LanguageTitle"].ToString();
                LanguageSuffix = reader["LanguageSuffix"].ToString();
                DefaultLanguage = bool.Parse(reader["DefaultLanguage"].ToString());
            }
            connection.Close();
        }

        public DataTable GetDefaultLanguage()
        {
            string Query = "SELECT * FROM Language WHERE DefaultLanguage = 'true'";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}