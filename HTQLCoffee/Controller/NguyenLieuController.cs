using HTQLCoffee.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQLCoffee.Controller
{
    internal class NguyenLieuController
    {
        private readonly string _connectionString;
        //hàm tạo(constructor)
        public NguyenLieuController(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<NguyenLieuModel> LayDanhSachNguyenLieu()
        {
            List<NguyenLieuModel> danhSachNguyenLieu = new List<NguyenLieuModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM tblNguyenlieu";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSachNguyenLieu.Add(new NguyenLieuModel
                            {
                                NguyenLieuID = Convert.ToInt32(reader["PK_iNguyenlieuID"]),
                                TenNguyenLieu = reader["sTenNguyenlieu"].ToString(),
                                SoLuong = Convert.ToSingle(reader["fSoluong"]),
                                DonViTinh = reader["sDonvitinh"].ToString(),
                            });
                        }
                    }
                }
            }
            return danhSachNguyenLieu;
        }
    }
}
