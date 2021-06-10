using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ZaksCms
{
    public class Direction
    {

        private int _DirectionID;
        private string _DirectionTitle;
        private bool _DefaultDirection;

        public int DirectionID { get { return _DirectionID; } set { _DirectionID = value; } }
        public string DirectionTitle { get { return _DirectionTitle; } set { _DirectionTitle = value; } }
        public bool DefaultDirection { get { return _DefaultDirection; } set { _DefaultDirection = value; } }

        public void Insert(string DirectionTitle, bool DefaultDirection)
        {
            if (DefaultDirection)
            {
                ResetDefaultDirections();
            }
            string query = "INSERT INTO Direction (DirectionTitle, DefaultDirection) " + "VALUES(@DirectionTitle, @DefaultDirection)";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@DirectionTitle", DirectionTitle);
            cmd.Parameters.AddWithValue("@DefaultDirection", DefaultDirection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(int DirectionID, string DirectionTitle, bool DefaultDirection)
        {
            if (DefaultDirection)
            {
                ResetDefaultDirections();
            }
            string query = "UPDATE Direction SET DirectionTitle = @DirectionTitle, DefaultDirection = @DefaultDirection WHERE DirectionID = @DirectionID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@DirectionID", DirectionID);
            cmd.Parameters.AddWithValue("@DirectionTitle", DirectionTitle);
            cmd.Parameters.AddWithValue("@DefaultDirection", DefaultDirection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteDirection(int DirectionID)
        {
            if (IsDefaultDirection(DirectionID))
            {
                ResetDefaultDirections();
            }
            else
            {
                string query = "DELETE FROM Direction WHERE DirectionID = @DirectionID";
                var connection = new SqlConnection(Global.MyConn);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@DirectionID", DirectionID);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void ResetDefaultDirections()
        {
            string query = "UPDATE Direction SET DefaultDirection = 'false'";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            connection.Open();
            Cmd.ExecuteNonQuery();
            connection.Close();
        }

        public bool IsDefaultDirection(int DirectionID)
        {
            return false;
        }

        public void MakeDefault(int DirectionID)
        {
            ResetDefaultDirections();
        }

        public DataTable GetDirections()
        {
            string Query = "SELECT * FROM Direction";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void GetDirection(int DirectionID)
        {
            string Query = "SELECT * FROM Direction WHERE DirectionID = @DirectionID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(Query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@DirectionID", DirectionID);
            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                DirectionID = int.Parse(reader["DirectionID"].ToString());
                DirectionTitle = reader["DirectionTitle"].ToString();
                DefaultDirection = bool.Parse(reader["DefaultDirection"].ToString());
            }
            connection.Close();
        }

        public DataTable GetDefaultDirections()
        {
            string Query = "SELECT * FROM Language WHERE DefaultDirection = 'true'";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}