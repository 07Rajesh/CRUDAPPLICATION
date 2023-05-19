using CRUDAPI.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAPI.DBAccess
{
    public class AdminDbAccess
    {
        ConnectDb db = new ConnectDb();
        public string LoginAdmin(AdminLogin admin)
        {
            string message = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_login_user", db.connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (db.connection.State == System.Data.ConnectionState.Closed)
                    db.connection.Open();

                cmd.Parameters.AddWithValue("@Email", admin.Email);
                cmd.Parameters.AddWithValue("@Password", admin.Password);


                int i = (int)cmd.ExecuteScalar();
                if (i == 1)
                {
                    message = "ok";
                }
                else
                {
                    message = "fail";
                }
                db.connection.Close();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
        public string SignUp(SignUp sign)
        {
            string message = string.Empty;
            SqlCommand cmd = new SqlCommand("sp_insert_emp_Detail", db.connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@name", sign.Name);
            cmd.Parameters.AddWithValue("@Email", sign.Email);
            cmd.Parameters.AddWithValue("@Password", sign.Password);
            cmd.Parameters.AddWithValue("@Gender", sign.Gender);
            cmd.Parameters.AddWithValue("@Mobile", sign.Mobile);
            cmd.Parameters.AddWithValue("@Address", sign.Address);
            cmd.Parameters.AddWithValue("@IsActive", sign.isActive);

            if (db.connection.State == System.Data.ConnectionState.Closed)
            {
                db.connection.Open();
            }
            cmd.ExecuteNonQuery();
            message = "Record saved successfully";
            return message;
        }

    }
}
