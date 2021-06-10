﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ZaksCms
{
    public class Subscriptions
    {
        public int SubscriptionID { get; set; }
        public string SubscriptionName { get; set; }
        public string SubscriptionType { get; set; }
        public DataTable getsubs()
        {
            string query = "Select * from Subscribe";
            SqlDataAdapter da = new SqlDataAdapter(query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void deletesubs(int SubscriptionID)
        {
            string query = "delete from Subscribe Where SubscriptionID=@SubscriptionID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@SubscriptionID", SubscriptionID);
            Cmd.CommandText = query;
            Cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}