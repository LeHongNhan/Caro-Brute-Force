namespace GameCoCaro
{
    partial class frmCoCaro
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pVPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pVEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edirtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChoiVoiNguoi = new System.Windows.Forms.Button();
            this.btnChoiVoimay = new System.Windows.Forms.Button();
            this.ChoiMoi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnBanCo = new System.Windows.Forms.Panel();
            this.loadThongTin = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.edirtToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(901, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pVPToolStripMenuItem,
            this.pVEToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.newToolStripMenuItem.Text = "New";
            // 
            // pVPToolStripMenuItem
            // 
            this.pVPToolStripMenuItem.Name = "pVPToolStripMenuItem";
            this.pVPToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.pVPToolStripMenuItem.Text = "PVP";
            this.pVPToolStripMenuItem.Click += new System.EventHandler(this.pVPToolStripMenuItem_Click);
            // 
            // pVEToolStripMenuItem
            // 
            this.pVEToolStripMenuItem.Name = "pVEToolStripMenuItem";
            this.pVEToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.pVEToolStripMenuItem.Text = "PVE";
            this.pVEToolStripMenuItem.Click += new System.EventHandler(this.pVEToolStripMenuItem_Click);
            // 
            // edirtToolStripMenuItem
            // 
            this.edirtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.edirtToolStripMenuItem.Name = "edirtToolStripMenuItem";
            this.edirtToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.edirtToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 248);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 193);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 169);
            this.label1.TabIndex = 0;
            // 
            // btnChoiVoiNguoi
            // 
            this.btnChoiVoiNguoi.Location = new System.Drawing.Point(12, 447);
            this.btnChoiVoiNguoi.Name = "btnChoiVoiNguoi";
            this.btnChoiVoiNguoi.Size = new System.Drawing.Size(96, 39);
            this.btnChoiVoiNguoi.TabIndex = 0;
            this.btnChoiVoiNguoi.Text = "PVP";
            this.btnChoiVoiNguoi.UseVisualStyleBackColor = true;
            // 
            // btnChoiVoimay
            // 
            this.btnChoiVoimay.Location = new System.Drawing.Point(118, 447);
            this.btnChoiVoimay.Name = "btnChoiVoimay";
            this.btnChoiVoimay.Size = new System.Drawing.Size(96, 39);
            this.btnChoiVoimay.TabIndex = 0;
            this.btnChoiVoimay.Text = "PVC";
            this.btnChoiVoimay.UseVisualStyleBackColor = true;
            this.btnChoiVoimay.Click += new System.EventHandler(this.btnChoiVoimay_Click);
            // 
            // ChoiMoi
            // 
            this.ChoiMoi.Location = new System.Drawing.Point(12, 492);
            this.ChoiMoi.Name = "ChoiMoi";
            this.ChoiMoi.Size = new System.Drawing.Size(96, 39);
            this.ChoiMoi.TabIndex = 0;
            this.ChoiMoi.Text = "Chơi mới";
            this.ChoiMoi.UseVisualStyleBackColor = true;
            this.ChoiMoi.Click += new System.EventHandler(this.ChoiMoi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(118, 492);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(96, 39);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GameCoCaro.Properties.Resources.choi_co_caro_online;
            this.pictureBox1.Location = new System.Drawing.Point(12, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 211);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pnBanCo
            // 
            this.pnBanCo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnBanCo.Location = new System.Drawing.Point(220, 31);
            this.pnBanCo.Name = "pnBanCo";
            this.pnBanCo.Size = new System.Drawing.Size(670, 620);
            this.pnBanCo.TabIndex = 3;
            this.pnBanCo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnBanCo_Paint);
            this.pnBanCo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnBanCo_MouseClick);
            // 
            // loadThongTin
            // 
            this.loadThongTin.Interval = 50;
            this.loadThongTin.Tick += new System.EventHandler(this.loadThongTin_Tick);
            // 
            // frmCoCaro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 655);
            this.Controls.Add(this.pnBanCo);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.ChoiMoi);
            this.Controls.Add(this.btnChoiVoimay);
            this.Controls.Add(this.btnChoiVoiNguoi);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmCoCaro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cờ Caro";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pVPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pVEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edirtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnChoiVoiNguoi;
        private System.Windows.Forms.Button btnChoiVoimay;
        private System.Windows.Forms.Button ChoiMoi;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Panel pnBanCo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer loadThongTin;
    }
}

