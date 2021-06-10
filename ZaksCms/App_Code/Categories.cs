using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ZaksCms
{
    public class Categories
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int ParentId { get; set; }
        public bool IsPublished { get; set; }
        public int OrderNum { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }
        public string LanguageID { get; set; }

        public void Insert(string CategoryName, int ParentId, bool IsPublished, int OrderNum, string Image, string Icon, int LanguageID)
        {
            string query = "INSERT INTO [Categories] VALUES(@CategoryName,@ParentId,@IsPublished,@OrderNum,@Image,@Icon,@LanguageID)";
            var connection = new SqlConnection(Global.MyConn);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
            cmd.Parameters.AddWithValue("@ParentId", ParentId);
            cmd.Parameters.AddWithValue("@IsPublished", IsPublished);
            cmd.Parameters.AddWithValue("@OrderNum", OrderNum);
            cmd.Parameters.AddWithValue("@Image", Image);
            cmd.Parameters.AddWithValue("@Icon", Icon);
            cmd.Parameters.AddWithValue("@LanguageID", LanguageID);
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            connection.Close();


        }
        public void Update(int CategoryID, string CategoryName, int ParentId, bool IsPublished, int OrderNum, string Image, string Icon, int LanguageID)
        {
            string query = "UPDATE [Categories] set CategoryName=@CategoryName,ParentId=@ParentId,IsPublished=@IsPublished,OrderNum=@OrderNum," +
                "Image=@Image,Icon=@Icon,LanguageID=@LanguageID where CategoryId=@CategoryID";
            var connection = new SqlConnection(Global.MyConn);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CategoryId", CategoryID);
            cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
            cmd.Parameters.AddWithValue("@ParentId", ParentId);
            cmd.Parameters.AddWithValue("@IsPublished", IsPublished);
            cmd.Parameters.AddWithValue("@OrderNum", OrderNum);
            cmd.Parameters.AddWithValue("@Image", Image);
            cmd.Parameters.AddWithValue("@Icon", Icon);
            cmd.Parameters.AddWithValue("@LanguageID", LanguageID);
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(int CategoryId)
        {
            string query = "Delete from [Categories] where CategoryId=@CategoryId";
            var connection = new SqlConnection(Global.MyConn);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable GetCategories()
        {
            string query = "select * from [Categories]  left join Language on Categories.LanguageID=Language.LanguageID";
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

        public DataTable GetParentCategory()
        {
            string query = "select * from [Categories] where ParentId = 0";
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
        public void GetCategory(int CategoryID)
        {
            SqlDataReader dr = null;
            string query = "select * from [Categories] where CategoryId=@CategoryId";
            var connection = new SqlConnection(Global.MyConn);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CategoryId", CategoryID);
            cmd.CommandText = query;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                CategoryName = dr["CategoryName"].ToString();
                ParentId = int.Parse(dr["ParentId"].ToString());
                IsPublished = bool.Parse(dr["IsPublished"].ToString());
                OrderNum = int.Parse(dr["OrderNum"].ToString());
                Image = dr["Image"].ToString();
                Icon = dr["Icon"].ToString();
                LanguageID = dr["LanguageID"].ToString();
            }
            connection.Close();
        }
    }
}