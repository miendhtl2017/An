namespace QuanLyQuanCafe
{
    partial class fQLTable
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numFood = new System.Windows.Forms.NumericUpDown();
            this.cbfood = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txbTotalPrice = new System.Windows.Forms.TextBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.cbCban = new System.Windows.Forms.ComboBox();
            this.btnCban = new System.Windows.Forms.Button();
            this.numdiscount = new System.Windows.Forms.NumericUpDown();
            this.btnGG = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lstBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fpnlTable = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFood)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numdiscount)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(803, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.AdminToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem1,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem1
            // 
            this.thôngTinCáNhânToolStripMenuItem1.Name = "thôngTinCáNhânToolStripMenuItem1";
            this.thôngTinCáNhânToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.thôngTinCáNhânToolStripMenuItem1.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem1.Click += new System.EventHandler(this.ThôngTinCáNhânToolStripMenuItem1_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.ĐăngXuấtToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.numFood);
            this.panel2.Controls.Add(this.cbfood);
            this.panel2.Controls.Add(this.cbCategory);
            this.panel2.Controls.Add(this.btnAddFood);
            this.panel2.Location = new System.Drawing.Point(12, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 57);
            this.panel2.TabIndex = 2;
            // 
            // numFood
            // 
            this.numFood.Location = new System.Drawing.Point(94, 19);
            this.numFood.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numFood.Name = "numFood";
            this.numFood.Size = new System.Drawing.Size(57, 20);
            this.numFood.TabIndex = 3;
            this.numFood.Tag = "";
            this.numFood.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numFood.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbfood
            // 
            this.cbfood.FormattingEnabled = true;
            this.cbfood.Location = new System.Drawing.Point(169, 30);
            this.cbfood.Name = "cbfood";
            this.cbfood.Size = new System.Drawing.Size(214, 21);
            this.cbfood.TabIndex = 2;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(169, 3);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(214, 21);
            this.cbCategory.TabIndex = 1;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.CbCategory_SelectedIndexChanged);
            // 
            // btnAddFood
            // 
            this.btnAddFood.Location = new System.Drawing.Point(3, 6);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(75, 48);
            this.btnAddFood.TabIndex = 0;
            this.btnAddFood.Text = "Thêm đồ";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.BtnAddFood_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txbTotalPrice);
            this.panel3.Controls.Add(this.btnPay);
            this.panel3.Controls.Add(this.cbCban);
            this.panel3.Controls.Add(this.btnCban);
            this.panel3.Controls.Add(this.numdiscount);
            this.panel3.Controls.Add(this.btnGG);
            this.panel3.Location = new System.Drawing.Point(12, 399);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(386, 51);
            this.panel3.TabIndex = 3;
            // 
            // txbTotalPrice
            // 
            this.txbTotalPrice.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotalPrice.Location = new System.Drawing.Point(87, 17);
            this.txbTotalPrice.Name = "txbTotalPrice";
            this.txbTotalPrice.ReadOnly = true;
            this.txbTotalPrice.Size = new System.Drawing.Size(100, 22);
            this.txbTotalPrice.TabIndex = 7;
            this.txbTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(6, 0);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(75, 51);
            this.btnPay.TabIndex = 1;
            this.btnPay.Text = "Thanh toán";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.BtnPay_Click);
            // 
            // cbCban
            // 
            this.cbCban.FormattingEnabled = true;
            this.cbCban.Location = new System.Drawing.Point(298, 30);
            this.cbCban.Name = "cbCban";
            this.cbCban.Size = new System.Drawing.Size(85, 21);
            this.cbCban.TabIndex = 6;
            // 
            // btnCban
            // 
            this.btnCban.Location = new System.Drawing.Point(298, 3);
            this.btnCban.Name = "btnCban";
            this.btnCban.Size = new System.Drawing.Size(85, 23);
            this.btnCban.TabIndex = 5;
            this.btnCban.Text = "Chuyển bàn";
            this.btnCban.UseVisualStyleBackColor = true;
            this.btnCban.Click += new System.EventHandler(this.BtnCban_Click);
            // 
            // numdiscount
            // 
            this.numdiscount.Location = new System.Drawing.Point(188, 28);
            this.numdiscount.Name = "numdiscount";
            this.numdiscount.Size = new System.Drawing.Size(89, 20);
            this.numdiscount.TabIndex = 4;
            this.numdiscount.Tag = "";
            this.numdiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnGG
            // 
            this.btnGG.Location = new System.Drawing.Point(188, 3);
            this.btnGG.Name = "btnGG";
            this.btnGG.Size = new System.Drawing.Size(89, 23);
            this.btnGG.TabIndex = 2;
            this.btnGG.Text = "Giảm giá";
            this.btnGG.UseVisualStyleBackColor = true;
            this.btnGG.Click += new System.EventHandler(this.BtnGG_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lstBill);
            this.panel4.Location = new System.Drawing.Point(12, 90);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(386, 303);
            this.panel4.TabIndex = 4;
            // 
            // lstBill
            // 
            this.lstBill.AutoArrange = false;
            this.lstBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lstBill.GridLines = true;
            this.lstBill.HideSelection = false;
            this.lstBill.Location = new System.Drawing.Point(0, 0);
            this.lstBill.Name = "lstBill";
            this.lstBill.Size = new System.Drawing.Size(386, 303);
            this.lstBill.TabIndex = 0;
            this.lstBill.UseCompatibleStateImageBehavior = false;
            this.lstBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên đồ uống";
            this.columnHeader1.Width = 139;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 67;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.Width = 85;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 88;
            // 
            // fpnlTable
            // 
            this.fpnlTable.AutoScroll = true;
            this.fpnlTable.Location = new System.Drawing.Point(404, 27);
            this.fpnlTable.Name = "fpnlTable";
            this.fpnlTable.Size = new System.Drawing.Size(399, 420);
            this.fpnlTable.TabIndex = 5;
            // 
            // fQLTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 450);
            this.Controls.Add(this.fpnlTable);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fQLTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý quán cà phê";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numFood)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numdiscount)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListView lstBill;
        private System.Windows.Forms.NumericUpDown numFood;
        private System.Windows.Forms.ComboBox cbfood;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.FlowLayoutPanel fpnlTable;
        private System.Windows.Forms.Button btnCban;
        private System.Windows.Forms.NumericUpDown numdiscount;
        private System.Windows.Forms.ComboBox cbCban;
        private System.Windows.Forms.TextBox txbTotalPrice;
        private System.Windows.Forms.Button btnGG;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}