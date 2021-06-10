using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ZaksCms.App_Code
{


    public class WebsiteZones
    {
        public int ZoneID { get; set; }
        public string ZoneName { get; set; }
        public void AddZone(string zonename)
        {
            string query = "INSERT INTO Zones(ZoneName) " + "VALUES(@ZoneName)";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ZoneName", zonename);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public DataTable GetZones()
        {
            string Query = "SELECT * FROM Zones";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void DeleteContent(int ZoneID)
        {
            string query = "DELETE FROM Zones WHERE ZoneID=@ZoneID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ZoneID", ZoneID);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void GetZone(int ZoneID)
        {
            string query = "SELECT * FROM Zones WHERE ZoneID=@ZoneID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@ZoneID", ZoneID);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                ZoneName = reader["ZoneName"].ToString();

            }
        }
        public void UpdateZone(int ZoneID,string ZoneName)
        {
            string query = "UPDATE Zones SET ZoneName = @ZoneName WHERE ZoneID = @ZoneID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ZoneName", ZoneName);
            cmd.Parameters.AddWithValue("@ZoneID", ZoneID);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}