using HTQLCoffee.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTQLCoffee.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void menuNguyenLieu_Click(object sender, EventArgs e)
        {
            frmNguyenLieu customer = new frmNguyenLieu();
            customer.MdiParent = this;
            customer.Dock = DockStyle.Fill;
            customer.Show();
        }


        private void tạoTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaiKhoanView account = new TaiKhoanView();
            account.MdiParent = this;
            account.Dock = DockStyle.Fill;
            account.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassView pass = new ChangePassView();
            pass.MdiParent = this;
            pass.Dock = DockStyle.Fill;
            pass.Show();
        }
    }
}
