using CRUDAPI.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAPI.DBAccess
{
    public class EmployeeDbAccess
    {
        public ConnectDb db = new ConnectDb();
        public List<Employee> GetEmployees()
        {
            SqlCommand cmd = new SqlCommand("sp_get_emp_Detail", db.connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (db.connection.State == System.Data.ConnectionState.Closed)
                db.connection.Open();            
            SqlDataReader dr = cmd.ExecuteReader();
            List<Employee> lstEmployees = new List<Employee>();
            while(dr.Read())
            {
                Employee emp = new Employee();
                emp.Id = (int)dr["Id"];
                emp.Name = dr["Name"].ToString();
                emp.Email = dr["Email"].ToString();
                emp.Password = dr["Password"].ToString();
                emp.Gender = dr["Gender"].ToString();
                emp.Mobile = dr["Mobile"].ToString();
                emp.Address = dr["Address"].ToString();
                emp.IsActive = Convert.ToBoolean(dr["IsActive"]);

                lstEmployees.Add(emp);
            }
            db.connection.Close();
            return lstEmployees;
        }
        public string CreateEmployee(Employee employee)
        {
            string message = string.Empty;
            try 
            {
                SqlCommand cmd = new SqlCommand("sp_insert_emp_Detail", db.connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (db.connection.State == System.Data.ConnectionState.Closed) 
                db.connection.Open();
                cmd.Parameters.AddWithValue("@Name",employee.Name);
                cmd.Parameters.AddWithValue("@Email",employee.Email);
                cmd.Parameters.AddWithValue("@Password",employee.Password);
                cmd.Parameters.AddWithValue("@Gender",employee.Gender);
                cmd.Parameters.AddWithValue("@Mobile",employee.Mobile);
                cmd.Parameters.AddWithValue("@Address",employee.Address);
                cmd.Parameters.AddWithValue("@IsActive", employee.IsActive);

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
        public string DeleteEmployee(int id)
        {
            string message = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_delete_emp_Detail", db.connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (db.connection.State == System.Data.ConnectionState.Closed)
                    db.connection.Open();
                cmd.Parameters.AddWithValue("@id", id);
         

                int i = (int)cmd.ExecuteNonQuery();
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
        public string UpdateEmployee(Employee employee)
        {
            string message = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_update_emp_Detail", db.connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (db.connection.State == System.Data.ConnectionState.Closed)
                    db.connection.Open();
                cmd.Parameters.AddWithValue("@Id",employee.Id);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@Password", employee.Password);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Mobile", employee.Mobile);
                cmd.Parameters.AddWithValue("@Address", employee.Address);
                cmd.Parameters.AddWithValue("@IsActive", employee.IsActive);

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


    }
}
