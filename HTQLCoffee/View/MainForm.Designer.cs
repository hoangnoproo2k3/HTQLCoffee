namespace HTQLCoffee.View
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNguyenLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.nccMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.doUongMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HDNhapMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.HDBanMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.danhMụcToolStripMenuItem,
            this.quảnLýHóaĐơnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1376, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNhanVien});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.hệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // menuNhanVien
            // 
            this.menuNhanVien.Name = "menuNhanVien";
            this.menuNhanVien.Size = new System.Drawing.Size(160, 26);
            this.menuNhanVien.Text = "Nhân Viên";
            this.menuNhanVien.Click += new System.EventHandler(this.menuNhanVien_Click);
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNguyenLieu,
            this.nccMenu,
            this.doUongMenu});
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.danhMụcToolStripMenuItem.Text = "Danh Mục";
            // 
            // menuNguyenLieu
            // 
            this.menuNguyenLieu.Name = "menuNguyenLieu";
            this.menuNguyenLieu.Size = new System.Drawing.Size(183, 26);
            this.menuNguyenLieu.Text = "Nguyên Liệu";
            this.menuNguyenLieu.Click += new System.EventHandler(this.menuNguyenLieu_Click);
            // 
            // nccMenu
            // 
            this.nccMenu.Name = "nccMenu";
            this.nccMenu.Size = new System.Drawing.Size(183, 26);
            this.nccMenu.Text = "Nhà cung cấp";
            this.nccMenu.Click += new System.EventHandler(this.nccMenu_Click);
            // 
            // doUongMenu
            // 
            this.doUongMenu.Name = "doUongMenu";
            this.doUongMenu.Size = new System.Drawing.Size(183, 26);
            this.doUongMenu.Text = "Đồ uống";
            this.doUongMenu.Click += new System.EventHandler(this.doUongMenu_Click);
            // 
            // quảnLýHóaĐơnToolStripMenuItem
            // 
            this.quảnLýHóaĐơnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HDNhapMenu,
            this.HDBanMenu});
            this.quảnLýHóaĐơnToolStripMenuItem.Name = "quảnLýHóaĐơnToolStripMenuItem";
            this.quảnLýHóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.quảnLýHóaĐơnToolStripMenuItem.Text = "Quản Lý Hóa Đơn";
            // 
            // HDNhapMenu
            // 
            this.HDNhapMenu.Name = "HDNhapMenu";
            this.HDNhapMenu.Size = new System.Drawing.Size(224, 26);
            this.HDNhapMenu.Text = "Hóa Đơn Nhập";
            this.HDNhapMenu.Click += new System.EventHandler(this.HDNhapMenu_Click);
            // 
            // HDBanMenu
            // 
            this.HDBanMenu.Name = "HDBanMenu";
            this.HDBanMenu.Size = new System.Drawing.Size(224, 26);
            this.HDBanMenu.Text = "Hóa Đơn Bán";
            this.HDBanMenu.Click += new System.EventHandler(this.HDBanMenu_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1376, 803);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuNhanVien;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuNguyenLieu;
        private System.Windows.Forms.ToolStripMenuItem quảnLýHóaĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HDNhapMenu;
        private System.Windows.Forms.ToolStripMenuItem HDBanMenu;
        private System.Windows.Forms.ToolStripMenuItem nccMenu;
        private System.Windows.Forms.ToolStripMenuItem doUongMenu;
    }
}