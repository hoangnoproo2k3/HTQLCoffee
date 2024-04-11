using HTQLCoffee.Controller;
using HTQLCoffee.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTQLCoffee.View
{
    public partial class TaiKhoanView : Form
    {
        private TaiKhoanController taiKhoanController;
        private SqlConnection con = new SqlConnection();
        public TaiKhoanView()
        {
            InitializeComponent();
            taiKhoanController = new TaiKhoanController();
        }
        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            taikhoan();
             btn_chinh.Enabled = false;
            btn_xoa.Enabled = false;
        }
        private void taikhoan()
        {
            this.taiKhoanController.dulieuCBController("Select PK_iPhanquyenID, sTenquyen from tblPhanquyen ", "sTenquyen", "PK_iPhanquyenID", cb_quyen);
            this.taiKhoanController.dulieuCBController("Select PK_iNhanvienID, sTenNhanvien from tblNhanvien", "sTenNhanvien", "PK_iNhanvienID", cb_maNV);
            this.taiKhoanController.layDuLieuController(dgv_TaiKhoan);

        }      

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            this.taiKhoanController.layDuLieuController(dgv_TaiKhoan);
            tbMatkhau.Text = "";
            MessageBox.Show("Dữ liệu làm mới thành công");
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            string quyen = cb_quyen.SelectedValue.ToString();
            string maNhanVien = cb_maNV.SelectedValue.ToString();
            string matKhau = tbMatkhau.Text.Trim();
            if ( maNhanVien == "" || matKhau == "" || quyen == "")
            {
                MessageBox.Show("Thiếu thông tin bắt buộc");
            }
            else
            {
                this.taiKhoanController.ThemTaiKhoanController( maNhanVien, matKhau, quyen, dgv_TaiKhoan);
                this.taiKhoanController.layDuLieuController(dgv_TaiKhoan);
            }
      
}

        private void btn_chinh_Click(object sender, EventArgs e)
        {

                this.taiKhoanController.suaTaiKhoanController(Convert.ToInt32(cb_maNV.SelectedValue),tbMatkhau.Text, Convert.ToInt32(cb_quyen.SelectedValue), dgv_TaiKhoan);
                cb_maNV.Enabled = true;
                tbMatkhau.Text = null;
        }

        private void dgv_TaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow dr = dgv_TaiKhoan.Rows[index];
            tbMatkhau.Text = dr.Cells["sMatkhau"].Value.ToString();
            cb_quyen.SelectedValue = dr.Cells["PK_iPhanquyenID"].Value.ToString();
            cb_maNV.SelectedValue = dr.Cells["PK_iNhanvienID"].Value.ToString();
            cb_maNV.Enabled = false;
            btn_chinh.Enabled = true;
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            string filterMK = tbMatkhau.Text;
            string filterMaNV = cb_maNV.SelectedValue.ToString();
            string filterQuyen = cb_quyen.SelectedValue.ToString();
            this.taiKhoanController.timKiemController(filterMK, filterMaNV, filterQuyen, dgv_TaiKhoan);
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {

            this.taiKhoanController.xoaController( cb_maNV.SelectedIndex, dgv_TaiKhoan);

           
        }
    }
}
