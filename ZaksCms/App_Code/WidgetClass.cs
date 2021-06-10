using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ZaksCms
{
    public class WidgetClass
    {
        private int _WidgetID;
        private string _WidgetTitle;
        private bool _IsPublished;

        public int WidgetID { get; set; }
        public string WidgetTitle { get; set; }
        public bool IsPublished { get; set; }

        public void Insert(string WidgetTitle, bool IsPublished)
        {
            string query = "INSERT INTO Widget (WidgetTitle, IsPublished) " + "VALUES(@WidgetTitle, @IsPublished)";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@WidgetTitle", WidgetTitle);
            cmd.Parameters.AddWithValue("@IsPublished", IsPublished);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(int WidgetID, string WidgetTitle, bool IsPublished)
        {
            string query = "UPDATE Widget SET WidgetTitle = @WidgetTitle, IsPublished = @IsPublished WHERE WidgetID = @WidgetID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@WidgetID", WidgetID);
            cmd.Parameters.AddWithValue("@WidgetTitle", WidgetTitle);
            cmd.Parameters.AddWithValue("@IsPublished", IsPublished);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteWidget(int WidgetID)
        {
            string query = "DELETE FROM Widget WHERE WidgetID = @WidgetID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@WidgetID", WidgetID);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable GetWidgets()
        {
            string Query = "SELECT * FROM Widget";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void GetWidget(int WidgetID)
        {
            string Query = "SELECT * FROM Widget WHERE WidgetID = @WidgetID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(Query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@WidgetID", WidgetID);
            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                WidgetID = int.Parse(reader["WidgetID"].ToString());
                WidgetTitle = reader["WidgetTitle"].ToString();
                IsPublished = bool.Parse(reader["IsPublished"].ToString());
            }
            connection.Close();
        }

    }
}