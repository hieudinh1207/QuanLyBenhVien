namespace QUANLYBENHVIEN_PH2
{
    partial class Quanlyhethong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quanlyhethong));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgv_Thongtinchitiet_user = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtgv_chinhsachaudit = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tenad = new System.Windows.Forms.Label();
            this.btn_Dangxuat_qlht = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_ttchitiet = new System.Windows.Forms.Button();
            this.btn_xem = new System.Windows.Forms.Button();
            this.btn_xem_audituser = new System.Windows.Forms.Button();
            this.btn_ttctuser = new System.Windows.Forms.Button();
            this.dtgv_hosokhambenh = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Thongtinchitiet_user)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_chinhsachaudit)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_hosokhambenh)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgv_Thongtinchitiet_user);
            this.groupBox1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(26, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(816, 249);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin Audit";
            // 
            // dtgv_Thongtinchitiet_user
            // 
            this.dtgv_Thongtinchitiet_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_Thongtinchitiet_user.Location = new System.Drawing.Point(6, 30);
            this.dtgv_Thongtinchitiet_user.Name = "dtgv_Thongtinchitiet_user";
            this.dtgv_Thongtinchitiet_user.RowHeadersWidth = 51;
            this.dtgv_Thongtinchitiet_user.RowTemplate.Height = 24;
            this.dtgv_Thongtinchitiet_user.Size = new System.Drawing.Size(804, 213);
            this.dtgv_Thongtinchitiet_user.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(37, 97);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(897, 391);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_xem);
            this.tabPage1.Controls.Add(this.btn_ttchitiet);
            this.tabPage1.Controls.Add(this.dtgv_chinhsachaudit);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(889, 355);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Audit_FGA";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dtgv_chinhsachaudit
            // 
            this.dtgv_chinhsachaudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_chinhsachaudit.Location = new System.Drawing.Point(31, 90);
            this.dtgv_chinhsachaudit.Name = "dtgv_chinhsachaudit";
            this.dtgv_chinhsachaudit.RowHeadersWidth = 51;
            this.dtgv_chinhsachaudit.RowTemplate.Height = 24;
            this.dtgv_chinhsachaudit.Size = new System.Drawing.Size(809, 224);
            this.dtgv_chinhsachaudit.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_ttctuser);
            this.tabPage2.Controls.Add(this.btn_xem_audituser);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(889, 355);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Audit User";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(737, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 50);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // tenad
            // 
            this.tenad.AutoSize = true;
            this.tenad.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenad.Location = new System.Drawing.Point(810, 26);
            this.tenad.Name = "tenad";
            this.tenad.Size = new System.Drawing.Size(99, 23);
            this.tenad.TabIndex = 4;
            this.tenad.Text = "TEN USER";
            // 
            // btn_Dangxuat_qlht
            // 
            this.btn_Dangxuat_qlht.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Dangxuat_qlht.Location = new System.Drawing.Point(810, 62);
            this.btn_Dangxuat_qlht.Name = "btn_Dangxuat_qlht";
            this.btn_Dangxuat_qlht.Size = new System.Drawing.Size(120, 35);
            this.btn_Dangxuat_qlht.TabIndex = 5;
            this.btn_Dangxuat_qlht.Text = "Đăng xuất";
            this.btn_Dangxuat_qlht.UseVisualStyleBackColor = true;
            this.btn_Dangxuat_qlht.Click += new System.EventHandler(this.btn_Dangxuat_qlht_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(44, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(396, 51);
            this.label3.TabIndex = 6;
            this.label3.Text = "QUẢN LÝ HỆ THỐNG";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dtgv_hosokhambenh);
            this.tabPage3.Location = new System.Drawing.Point(4, 32);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(889, 355);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Audit hồ sơ khám bệnh";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btn_ttchitiet
            // 
            this.btn_ttchitiet.Location = new System.Drawing.Point(475, 6);
            this.btn_ttchitiet.Name = "btn_ttchitiet";
            this.btn_ttchitiet.Size = new System.Drawing.Size(186, 51);
            this.btn_ttchitiet.TabIndex = 1;
            this.btn_ttchitiet.Text = "Thông tin chi tiết";
            this.btn_ttchitiet.UseVisualStyleBackColor = true;
            this.btn_ttchitiet.Click += new System.EventHandler(this.btn_ttchitiet_Click);
            // 
            // btn_xem
            // 
            this.btn_xem.Location = new System.Drawing.Point(696, 6);
            this.btn_xem.Name = "btn_xem";
            this.btn_xem.Size = new System.Drawing.Size(132, 51);
            this.btn_xem.TabIndex = 2;
            this.btn_xem.Text = "Xem";
            this.btn_xem.UseVisualStyleBackColor = true;
            this.btn_xem.Click += new System.EventHandler(this.btn_xem_Click);
            // 
            // btn_xem_audituser
            // 
            this.btn_xem_audituser.Location = new System.Drawing.Point(712, 37);
            this.btn_xem_audituser.Name = "btn_xem_audituser";
            this.btn_xem_audituser.Size = new System.Drawing.Size(114, 49);
            this.btn_xem_audituser.TabIndex = 2;
            this.btn_xem_audituser.Text = "Xem";
            this.btn_xem_audituser.UseVisualStyleBackColor = true;
            this.btn_xem_audituser.Click += new System.EventHandler(this.btn_xem_audituser_Click);
            // 
            // btn_ttctuser
            // 
            this.btn_ttctuser.Location = new System.Drawing.Point(447, 33);
            this.btn_ttctuser.Name = "btn_ttctuser";
            this.btn_ttctuser.Size = new System.Drawing.Size(200, 53);
            this.btn_ttctuser.TabIndex = 3;
            this.btn_ttctuser.Text = "Thông tin chi tiết";
            this.btn_ttctuser.UseVisualStyleBackColor = true;
            this.btn_ttctuser.Click += new System.EventHandler(this.btn_ttctuser_Click);
            // 
            // dtgv_hosokhambenh
            // 
            this.dtgv_hosokhambenh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_hosokhambenh.Location = new System.Drawing.Point(36, 36);
            this.dtgv_hosokhambenh.Name = "dtgv_hosokhambenh";
            this.dtgv_hosokhambenh.RowHeadersWidth = 51;
            this.dtgv_hosokhambenh.RowTemplate.Height = 24;
            this.dtgv_hosokhambenh.Size = new System.Drawing.Size(832, 297);
            this.dtgv_hosokhambenh.TabIndex = 0;
            // 
            // Quanlyhethong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 514);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Dangxuat_qlht);
            this.Controls.Add(this.tenad);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Quanlyhethong";
            this.Text = "Quanlyhethong";
            this.Load += new System.EventHandler(this.Quanlyhethong_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Thongtinchitiet_user)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_chinhsachaudit)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_hosokhambenh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgv_Thongtinchitiet_user;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label tenad;
        private System.Windows.Forms.Button btn_Dangxuat_qlht;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dtgv_chinhsachaudit;
        private System.Windows.Forms.Button btn_xem;
        private System.Windows.Forms.Button btn_ttchitiet;
        private System.Windows.Forms.Button btn_ttctuser;
        private System.Windows.Forms.Button btn_xem_audituser;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dtgv_hosokhambenh;
    }
}