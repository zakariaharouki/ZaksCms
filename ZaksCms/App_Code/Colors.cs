using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ZaksCms
{
    public class Colors
    {
        public int ColorId { get; set; }
        public string Color { get; set; }
        public bool IsPublished { get; set; }
        public int LanguageID { get; set; }

        public void Insert(string Color, bool IsPublished, int LanguageID)
        {
            string query = "INSERT INTO [Color] values(@Color,@IsPublished,@LanguageID)";
            var connection = new SqlConnection(Global.MyConn);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Color", Color);
            cmd.Parameters.AddWithValue("@IsPublished", IsPublished);
            cmd.Parameters.AddWithValue("@LanguageID", LanguageID);
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Update(int ColorId, string Color, bool IsPublished, int LanguageID)
        {
            string query = "UPDATE [Color] set Color=@Color,Published=@IsPublished,LanguageID=@LanguageId where ColorId=@ColorId";
            var connection = new SqlConnection(Global.MyConn);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ColorId", ColorId);
            cmd.Parameters.AddWithValue("@Color", Color);
            cmd.Parameters.AddWithValue("@IsPublished", IsPublished);
            cmd.Parameters.AddWithValue("@LanguageID", LanguageID);
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(int ColorId)
        {
            string query = "Delete from [Color] where ColorId=@ColorId";
            var connection = new SqlConnection(Global.MyConn);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ColorId", ColorId);
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable GetColors()
        {
            string query = "select * from [Color] left join Language on Color.LanguageID=Language.LanguageID";
            var connection = new SqlConnection(Global.MyConn);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            connection.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public void GetColor(int ColorId)
        {

            SqlDataReader dr = null;
            string query = "Select * from [Color] where ColorId=@ColorId";
            var connection = new SqlConnection(Global.MyConn);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ColorId", ColorId);
            cmd.CommandText = query;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Color = dr["Color"].ToString();
                IsPublished = bool.Parse(dr["Published"].ToString());

            }
            connection.Close();
        }
    }
}