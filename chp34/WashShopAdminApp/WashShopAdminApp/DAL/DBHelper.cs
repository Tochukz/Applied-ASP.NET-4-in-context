using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WashShopAdminApp.DAL
{
    public class DBHelper
    {
       public static bool IsValidUser(string username, string password)
       {
            DataTable result = null;
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WashShopAdminApp"].ConnectionString))
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select password from Users where username = @uname";
                        cmd.Parameters.Add(new SqlParameter("@uname", username));
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                        {
                            result = new DataTable();
                            dataAdapter.Fill(result);
                        }
                        if (result.Rows.Count > 0 && password.Trim() == result.Rows[0]["password"].ToString().Trim())
                        {
                            return true;
                        }
                    }

                }
            }
            catch(IndexOutOfRangeException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public static string GetUserRoles(string username)
        {
            try
            {
                DataTable result = null;
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WashShopAdminApp"].ConnectionString))
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select roles from Users where username = @uname";
                        cmd.Parameters.Add(new SqlParameter("@uname", username));
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                        {
                            result = new DataTable();
                            dataAdapter.Fill(result);
                        }

                        if (result.Rows.Count == 1)
                        {
                            return result.Rows[0]["roles"].ToString().Trim();
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return "guest";
        }
    }
}