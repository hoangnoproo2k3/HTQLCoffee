﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQLCoffee.Model
{
    class LoginModel
    {
        string connectionString;
        public LoginModel()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["HTQLCoffee"].ConnectionString;
        }

        public bool isCheckAccount(string id, string password)
        {

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("prGetAccoun", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@password", password);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string role;
                        int iMaNV;
                        {
                            role = reader.GetString(1);
                            iMaNV = reader.GetInt32(0);
                            Authorize.Instance.saveSession(role, iMaNV);
                            return true;
                        }
                    }
                    reader.Close();
                    return false;
                }

            }
        }
        public bool changePassword(int id, string oldPassword, string newPassword)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("prChangePassword", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@oldPassword", oldPassword);
                    cmd.Parameters.AddWithValue("@newPassword", newPassword);
                    cnn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0 ? true : false;
                }

            }
        }
          public bool CheckAccount(string id, string password)
        {

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string query = "SELECT COUNT(*) FROM tblTaikhoan WHERE PK_iNhanvienID = @id AND sMatkhau = @password";

                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = (int)cmd.ExecuteScalar();

                    return count >0;
                }

            }
        }

    }
}
