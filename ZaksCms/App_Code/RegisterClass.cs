using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ZaksCms
{
    public class RegisterClass
    {
        public string message { get; set; }

        public string RegisterMethod(string txtFname, string txtLname, string txtPass, string txtEmail, string txtPhone)
        {

            SqlConnection con = new SqlConnection(Global.MyConn);
            SqlCommand command = new SqlCommand("Proc_AddUser", con);
            //string ins = "Insert into[users](name,email,password,phone)values('"+reg_name.Text+"','"+reg_email.Text+"','"+reg_password.Text+"','"+reg_phone.Text+"')";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            command.Parameters.AddWithValue("@Fname", txtFname);
            command.Parameters.AddWithValue("@Lname", txtLname);
            command.Parameters.AddWithValue("@Email", txtEmail);
            command.Parameters.AddWithValue("@PasswordHash", txtPass);
            command.Parameters.AddWithValue("@PhoneNumber", txtPhone);
            command.Parameters.Add("@responsemessage", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            //SqlDataReader rd = com.ExecuteReader();
            //con.Open();
            //command.ExecuteNonQuery();
            con.Close();
            String responsemessage = (string)command.Parameters["@responsemessage"].Value;
            return responsemessage;
        }


        public string checkifExists(string txtEmail)
        {
            string query = "Select 1 from Users Where Email=@Email";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@Email", txtEmail);
            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                string message = "Duplicate";
                return message;
            }
            else
            {
                string message = "No Duplicate";
                return message;

            }
        }
    }
}