namespace Đồ_án_OOP
{
    partial class fmGame1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelGoc = new System.Windows.Forms.Panel();
            this.lblDown = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.Label();
            this.lblLeft = new System.Windows.Forms.Label();
            this.lblUp = new System.Windows.Forms.Label();
            this.pbAnhGoc = new System.Windows.Forms.PictureBox();
            this.gbAnhGoc = new System.Windows.Forms.GroupBox();
            this.panelNen = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnMo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTronAnh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDoKho = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDoKho1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDoKho2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDoKho3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDoKho4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnChoiLai = new System.Windows.Forms.ToolStripMenuItem();
            this.mnThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnhGoc)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelGoc);
            this.panel1.Controls.Add(this.lblDown);
            this.panel1.Controls.Add(this.lblRight);
            this.panel1.Controls.Add(this.lblLeft);
            this.panel1.Controls.Add(this.lblUp);
            this.panel1.Controls.Add(this.pbAnhGoc);
            this.panel1.Controls.Add(this.gbAnhGoc);
            this.panel1.Controls.Add(this.panelNen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 523);
            this.panel1.TabIndex = 0;
            // 
            // panelGoc
            // 
            this.panelGoc.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelGoc.Location = new System.Drawing.Point(361, 14);
            this.panelGoc.Name = "panelGoc";
            this.panelGoc.Size = new System.Drawing.Size(330, 266);
            this.panelGoc.TabIndex = 21;
            // 
            // lblDown
            // 
            this.lblDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDown.Font = new System.Drawing.Font("Wingdings", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblDown.Location = new System.Drawing.Point(785, 90);
            this.lblDown.Name = "lblDown";
            this.lblDown.Size = new System.Drawing.Size(30, 30);
            this.lblDown.TabIndex = 8;
            this.lblDown.Text = "â";
            this.lblDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDown.Click += new System.EventHandler(this.lblMove_Click);
            this.lblDown.MouseEnter += new System.EventHandler(this.lblMove_MouseEnter);
            this.lblDown.MouseLeave += new System.EventHandler(this.lblUp_MouseLeave);
            // 
            // lblRight
            // 
            this.lblRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRight.Font = new System.Drawing.Font("Wingdings", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblRight.Location = new System.Drawing.Point(814, 61);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(30, 30);
            this.lblRight.TabIndex = 10;
            this.lblRight.Text = "à";
            this.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRight.Click += new System.EventHandler(this.lblMove_Click);
            this.lblRight.MouseEnter += new System.EventHandler(this.lblMove_MouseEnter);
            this.lblRight.MouseLeave += new System.EventHandler(this.lblUp_MouseLeave);
            // 
            // lblLeft
            // 
            this.lblLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLeft.Font = new System.Drawing.Font("Wingdings", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblLeft.Location = new System.Drawing.Point(756, 61);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(30, 30);
            this.lblLeft.TabIndex = 9;
            this.lblLeft.Text = "ß";
            this.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLeft.Click += new System.EventHandler(this.lblMove_Click);
            this.lblLeft.MouseEnter += new System.EventHandler(this.lblMove_MouseEnter);
            this.lblLeft.MouseLeave += new System.EventHandler(this.lblUp_MouseLeave);
            // 
            // lblUp
            // 
            this.lblUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUp.Font = new System.Drawing.Font("Wingdings", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblUp.Location = new System.Drawing.Point(785, 32);
            this.lblUp.Name = "lblUp";
            this.lblUp.Size = new System.Drawing.Size(30, 30);
            this.lblUp.TabIndex = 7;
            this.lblUp.Text = "á";
            this.lblUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUp.Click += new System.EventHandler(this.lblMove_Click);
            this.lblUp.MouseEnter += new System.EventHandler(this.lblMove_MouseEnter);
            this.lblUp.MouseLeave += new System.EventHandler(this.lblUp_MouseLeave);
            // 
            // pbAnhGoc
            // 
            this.pbAnhGoc.Location = new System.Drawing.Point(712, 158);
            this.pbAnhGoc.Name = "pbAnhGoc";
            this.pbAnhGoc.Size = new System.Drawing.Size(150, 150);
            this.pbAnhGoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbAnhGoc.TabIndex = 16;
            this.pbAnhGoc.TabStop = false;
            // 
            // gbAnhGoc
            // 
            this.gbAnhGoc.Font = new System.Drawing.Font("Magneto", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAnhGoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gbAnhGoc.Location = new System.Drawing.Point(0, 314);
            this.gbAnhGoc.Name = "gbAnhGoc";
            this.gbAnhGoc.Size = new System.Drawing.Size(881, 215);
            this.gbAnhGoc.TabIndex = 15;
            this.gbAnhGoc.TabStop = false;
            this.gbAnhGoc.Text = "Ảnh Gốc";
            // 
            // panelNen
            // 
            this.panelNen.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelNen.Location = new System.Drawing.Point(12, 14);
            this.panelNen.Name = "panelNen";
            this.panelNen.Size = new System.Drawing.Size(259, 237);
            this.panelNen.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(874, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnMo,
            this.mnTronAnh,
            this.mnDoKho,
            this.mnChoiLai,
            this.mnThoat});
            this.gameToolStripMenuItem.Font = new System.Drawing.Font("Magneto", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(74, 25);
            this.gameToolStripMenuItem.Text = "&Game";
            // 
            // mnMo
            // 
            this.mnMo.Name = "mnMo";
            this.mnMo.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mnMo.Size = new System.Drawing.Size(204, 26);
            this.mnMo.Text = "&Mở";
            this.mnMo.Click += new System.EventHandler(this.MnMo_Click);
            // 
            // mnTronAnh
            // 
            this.mnTronAnh.Enabled = false;
            this.mnTronAnh.Name = "mnTronAnh";
            this.mnTronAnh.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.mnTronAnh.Size = new System.Drawing.Size(204, 26);
            this.mnTronAnh.Text = "&Trộn ảnh ";
            this.mnTronAnh.Click += new System.EventHandler(this.MnTronAnh_Click);
            // 
            // mnDoKho
            // 
            this.mnDoKho.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnDoKho1,
            this.mnDoKho2,
            this.mnDoKho3,
            this.mnDoKho4});
            this.mnDoKho.Name = "mnDoKho";
            this.mnDoKho.Size = new System.Drawing.Size(204, 26);
            this.mnDoKho.Text = "&Chọn độ khó";
            // 
            // mnDoKho1
            // 
            this.mnDoKho1.Name = "mnDoKho1";
            this.mnDoKho1.Size = new System.Drawing.Size(114, 26);
            this.mnDoKho1.Text = "4x4";
            this.mnDoKho1.Click += new System.EventHandler(this.MnDoKho1_Click);
            // 
            // mnDoKho2
            // 
            this.mnDoKho2.Name = "mnDoKho2";
            this.mnDoKho2.Size = new System.Drawing.Size(114, 26);
            this.mnDoKho2.Text = "5x5";
            this.mnDoKho2.Click += new System.EventHandler(this.MnDoKho2_Click);
            // 
            // mnDoKho3
            // 
            this.mnDoKho3.Name = "mnDoKho3";
            this.mnDoKho3.Size = new System.Drawing.Size(114, 26);
            this.mnDoKho3.Text = "6x6";
            this.mnDoKho3.Click += new System.EventHandler(this.MnDoKho3_Click);
            // 
            // mnDoKho4
            // 
            this.mnDoKho4.Name = "mnDoKho4";
            this.mnDoKho4.Size = new System.Drawing.Size(114, 26);
            this.mnDoKho4.Text = "8x8";
            this.mnDoKho4.Click += new System.EventHandler(this.MnDoKho4_Click);
            // 
            // mnChoiLai
            // 
            this.mnChoiLai.Name = "mnChoiLai";
            this.mnChoiLai.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.mnChoiLai.Size = new System.Drawing.Size(204, 26);
            this.mnChoiLai.Text = "&Chơi lại";
            this.mnChoiLai.Click += new System.EventHandler(this.ChoiToolStripMenuItem_Click);
            // 
            // mnThoat
            // 
            this.mnThoat.Name = "mnThoat";
            this.mnThoat.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnThoat.Size = new System.Drawing.Size(204, 26);
            this.mnThoat.Text = "&Thoát";
            this.mnThoat.Click += new System.EventHandler(this.ThoátToolStripMenuItem_Click);
            // 
            // fmGame1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 552);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fmGame1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Ghép Hình 1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnhGoc)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox gbAnhGoc;
        private System.Windows.Forms.Panel panelNen;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnMo;
        private System.Windows.Forms.ToolStripMenuItem mnTronAnh;
        private System.Windows.Forms.ToolStripMenuItem mnDoKho;
        private System.Windows.Forms.ToolStripMenuItem mnDoKho1;
        private System.Windows.Forms.ToolStripMenuItem mnDoKho2;
        private System.Windows.Forms.ToolStripMenuItem mnDoKho3;
        private System.Windows.Forms.ToolStripMenuItem mnDoKho4;
        private System.Windows.Forms.PictureBox pbAnhGoc;
        private System.Windows.Forms.Label lblDown;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Label lblUp;
        private System.Windows.Forms.Panel panelGoc;
        private System.Windows.Forms.ToolStripMenuItem mnChoiLai;
        private System.Windows.Forms.ToolStripMenuItem mnThoat;
    }
}

