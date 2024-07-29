namespace PressureUpper
{
    partial class FormRegisterInstrument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegisterInstrument));
            panTitle = new Panel();
            pictureBoxIcon = new PictureBox();
            label7 = new Label();
            label6 = new Label();
            panel1 = new Panel();
            btnRegister = new FontAwesome.Sharp.IconButton();
            lblNum = new Label();
            label2 = new Label();
            lblStatus = new Label();
            lblNumMark = new Label();
            btnRight = new FontAwesome.Sharp.IconButton();
            btnLeft = new FontAwesome.Sharp.IconButton();
            lblFanWei = new Label();
            lblLevel = new Label();
            lblOne = new Label();
            btnOne = new FontAwesome.Sharp.IconButton();
            btnCancel = new FontAwesome.Sharp.IconButton();
            btnOk = new FontAwesome.Sharp.IconButton();
            panTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panTitle
            // 
            panTitle.BackColor = Color.FromArgb(233, 235, 244);
            panTitle.Controls.Add(pictureBoxIcon);
            panTitle.Controls.Add(label7);
            panTitle.Controls.Add(label6);
            panTitle.Dock = DockStyle.Top;
            panTitle.Location = new Point(0, 0);
            panTitle.Margin = new Padding(4);
            panTitle.Name = "panTitle";
            panTitle.Size = new Size(673, 50);
            panTitle.TabIndex = 2;
            panTitle.MouseDown += BarraTitulo_MouseDown;
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.Image = (Image)resources.GetObject("pictureBoxIcon.Image");
            pictureBoxIcon.Location = new Point(2, 2);
            pictureBoxIcon.Margin = new Padding(4);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(20, 20);
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxIcon.TabIndex = 17;
            pictureBoxIcon.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.DodgerBlue;
            label7.Location = new Point(27, 2);
            label7.Margin = new Padding(0);
            label7.Name = "label7";
            label7.Size = new Size(56, 17);
            label7.TabIndex = 16;
            label7.Text = "管理系统";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.DodgerBlue;
            label6.Location = new Point(270, 9);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(68, 17);
            label6.TabIndex = 15;
            label6.Text = "注册设备";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnRegister);
            panel1.Controls.Add(lblNum);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblStatus);
            panel1.Controls.Add(lblNumMark);
            panel1.Controls.Add(btnRight);
            panel1.Controls.Add(btnLeft);
            panel1.Controls.Add(lblFanWei);
            panel1.Controls.Add(lblLevel);
            panel1.Controls.Add(lblOne);
            panel1.Controls.Add(btnOne);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnOk);
            panel1.Location = new Point(14, 49);
            panel1.Name = "panel1";
            panel1.Size = new Size(647, 323);
            panel1.TabIndex = 13;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(116, 89, 255);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegister.ForeColor = Color.White;
            btnRegister.IconChar = FontAwesome.Sharp.IconChar.None;
            btnRegister.IconColor = Color.Black;
            btnRegister.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRegister.Location = new Point(289, 275);
            btnRegister.Margin = new Padding(4);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(90, 33);
            btnRegister.TabIndex = 36;
            btnRegister.Text = "激活";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += BtnRegister_Click;
            // 
            // lblNum
            // 
            lblNum.AutoSize = true;
            lblNum.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblNum.ForeColor = Color.DodgerBlue;
            lblNum.Location = new Point(473, 226);
            lblNum.Name = "lblNum";
            lblNum.Size = new Size(122, 22);
            lblNum.TabIndex = 35;
            lblNum.Text = "点击激活后显示";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.DodgerBlue;
            label2.Location = new Point(372, 226);
            label2.Name = "label2";
            label2.Size = new Size(90, 22);
            label2.TabIndex = 34;
            label2.Text = "设备编号：";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblStatus.ForeColor = Color.DodgerBlue;
            lblStatus.Location = new Point(122, 275);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(58, 22);
            lblStatus.TabIndex = 33;
            lblStatus.Text = "未连接";
            // 
            // lblNumMark
            // 
            lblNumMark.AutoSize = true;
            lblNumMark.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblNumMark.ForeColor = Color.DodgerBlue;
            lblNumMark.Location = new Point(26, 275);
            lblNumMark.Name = "lblNumMark";
            lblNumMark.Size = new Size(90, 22);
            lblNumMark.TabIndex = 32;
            lblNumMark.Text = "设备状态：";
            // 
            // btnRight
            // 
            btnRight.BackColor = Color.FromArgb(233, 235, 244);
            btnRight.FlatAppearance.BorderSize = 0;
            btnRight.FlatStyle = FlatStyle.Flat;
            btnRight.IconChar = FontAwesome.Sharp.IconChar.None;
            btnRight.IconColor = Color.Black;
            btnRight.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRight.Location = new Point(270, 225);
            btnRight.Name = "btnRight";
            btnRight.Size = new Size(75, 32);
            btnRight.TabIndex = 31;
            btnRight.Text = "右膝";
            btnRight.UseVisualStyleBackColor = false;
            btnRight.Click += BtnRight_Click;
            // 
            // btnLeft
            // 
            btnLeft.BackColor = Color.FromArgb(233, 235, 244);
            btnLeft.FlatAppearance.BorderSize = 0;
            btnLeft.FlatStyle = FlatStyle.Flat;
            btnLeft.IconChar = FontAwesome.Sharp.IconChar.None;
            btnLeft.IconColor = Color.Black;
            btnLeft.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLeft.Location = new Point(173, 225);
            btnLeft.Name = "btnLeft";
            btnLeft.Size = new Size(75, 32);
            btnLeft.TabIndex = 30;
            btnLeft.Text = "左膝";
            btnLeft.UseVisualStyleBackColor = false;
            btnLeft.Click += BtnLeft_Click;
            // 
            // lblFanWei
            // 
            lblFanWei.AutoSize = true;
            lblFanWei.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblFanWei.ForeColor = Color.DodgerBlue;
            lblFanWei.Location = new Point(26, 226);
            lblFanWei.Name = "lblFanWei";
            lblFanWei.Size = new Size(122, 22);
            lblFanWei.TabIndex = 29;
            lblFanWei.Text = "设备使用范围：";
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblLevel.ForeColor = Color.DodgerBlue;
            lblLevel.Location = new Point(173, 188);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(42, 22);
            lblLevel.TabIndex = 25;
            lblLevel.Text = "电压";
            // 
            // lblOne
            // 
            lblOne.AutoSize = true;
            lblOne.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblOne.ForeColor = Color.DodgerBlue;
            lblOne.Location = new Point(173, 157);
            lblOne.Name = "lblOne";
            lblOne.Size = new Size(42, 22);
            lblOne.TabIndex = 25;
            lblOne.Text = "设备";
            // 
            // btnOne
            // 
            btnOne.BackColor = Color.FromArgb(233, 235, 244);
            btnOne.BackgroundImage = (Image)resources.GetObject("btnOne.BackgroundImage");
            btnOne.BackgroundImageLayout = ImageLayout.Stretch;
            btnOne.FlatAppearance.BorderSize = 0;
            btnOne.FlatStyle = FlatStyle.Flat;
            btnOne.IconChar = FontAwesome.Sharp.IconChar.None;
            btnOne.IconColor = Color.Black;
            btnOne.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnOne.Location = new Point(173, 8);
            btnOne.Name = "btnOne";
            btnOne.Size = new Size(151, 137);
            btnOne.TabIndex = 21;
            btnOne.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(116, 89, 255);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.White;
            btnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCancel.IconColor = Color.Black;
            btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancel.Location = new Point(505, 275);
            btnCancel.Margin = new Padding(4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 33);
            btnCancel.TabIndex = 20;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.FromArgb(116, 89, 255);
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnOk.ForeColor = Color.White;
            btnOk.IconChar = FontAwesome.Sharp.IconChar.None;
            btnOk.IconColor = Color.Black;
            btnOk.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnOk.Location = new Point(397, 275);
            btnOk.Margin = new Padding(4);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(90, 33);
            btnOk.TabIndex = 19;
            btnOk.Text = "完成";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += BtnOk_Click;
            // 
            // FormRegisterInstrument
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(226, 225, 232);
            ClientSize = new Size(673, 384);
            Controls.Add(panel1);
            Controls.Add(panTitle);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "FormRegisterInstrument";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormMantCliente";
            Load += FormMantCliente_Load;
            panTitle.ResumeLayout(false);
            panTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panTitle;
        private System.Windows.Forms.Label label6;
        private PictureBox pictureBoxIcon;
        private Label label7;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnCancel;
        private FontAwesome.Sharp.IconButton btnOk;
        private FontAwesome.Sharp.IconButton btnRight;
        private FontAwesome.Sharp.IconButton btnLeft;
        private Label lblFanWei;
        private Label lblOne;
        private FontAwesome.Sharp.IconButton btnOne;
        private FontAwesome.Sharp.IconButton btnRegister;
        private Label lblNum;
        private Label label2;
        private Label lblStatus;
        private Label lblNumMark;
        private Label lblLevel;
    }
}