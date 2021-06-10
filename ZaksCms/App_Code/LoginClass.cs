using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ZaksCms
{
    public class LoginClass
    {
        public int UserId { get; set; }
        public int AttemptsCount { get; set; }
        public string IsLocked { get; set; }
        public string Email { get; set; }
        public int LoginMethod(string usremail, string usrpassword)
        {
            SqlConnection con = new SqlConnection(Global.MyConn);
            SqlCommand cmd = new SqlCommand("Proc_UserLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@Email", usremail);
            cmd.Parameters.AddWithValue("@Password", usrpassword);
            cmd.Parameters.Add("@responsemessage", SqlDbType.Int, 255).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            con.Close();
            String responsemessage = Convert.ToString(cmd.Parameters["@responsemessage"].Value);
            return int.Parse(responsemessage);
        }
        public void getattempts(string Email)
        {
            string query = "Select * from Users Where Email=@Email";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@Email", Email);
            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                AttemptsCount = int.Parse(reader["AttemptsCount"].ToString());
                UserId = int.Parse(reader["UserId"].ToString());
                Email = reader["Email"].ToString();
            }
        }

        public void lockaccount(string usremail)
        {
            string query = "Update Users set IsLocked='1' Where Email=@Email";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@Email", usremail);
            //Cmd.Parameters.AddWithValue("@IsLocked", IsLocked);
            Cmd.ExecuteNonQuery();
            connection.Close();

        }
        public void updateAttempts(int AttemptsCount, string usremail)
        {
            string query = "Update Users set AttemptsCount=@AttemptsCount Where Email=@Email";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@Email", usremail);
            Cmd.Parameters.AddWithValue("@AttemptsCount", AttemptsCount);
            Cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void checkiflocked(string usremail)
        {
            string query = "Select * from Users where Email=@Email";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@Email", usremail);
            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                IsLocked = reader["IsLocked"].ToString();
                UserId = int.Parse(reader["UserId"].ToString());
                Email = reader["Email"].ToString();
            }


        }
    }
}