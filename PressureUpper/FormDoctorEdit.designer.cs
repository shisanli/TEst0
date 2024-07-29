namespace PressureUpper
{
    partial class FormDoctorEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDoctorEdit));
            panTitle = new Panel();
            pictureBoxIcon = new PictureBox();
            label7 = new Label();
            lblTitle = new Label();
            txtName = new TextBox();
            lblName = new Label();
            lblCreateTime = new Label();
            btnOk = new FontAwesome.Sharp.IconButton();
            btnCancel = new FontAwesome.Sharp.IconButton();
            dtpCreateTime = new DateTimePicker();
            lblAccountNum = new Label();
            txtAccountNum = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblPasswordAgain = new Label();
            txtPasswordAgain = new TextBox();
            groupBox1 = new GroupBox();
            rdbWoman = new RadioButton();
            rdbMan = new RadioButton();
            lblSex = new Label();
            lblDepartment = new Label();
            txtDepartment = new TextBox();
            lblAdmin = new Label();
            cmbBoxAdmin = new ComboBox();
            panTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panTitle
            // 
            panTitle.BackColor = Color.FromArgb(233, 235, 244);
            panTitle.Controls.Add(pictureBoxIcon);
            panTitle.Controls.Add(label7);
            panTitle.Controls.Add(lblTitle);
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
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.DodgerBlue;
            lblTitle.Location = new Point(305, 9);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(68, 17);
            lblTitle.TabIndex = 15;
            lblTitle.Text = "医生信息";
            // 
            // txtName
            // 
            txtName.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtName.Location = new Point(216, 193);
            txtName.Margin = new Padding(4);
            txtName.Name = "txtName";
            txtName.Size = new Size(284, 23);
            txtName.TabIndex = 3;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblName.ForeColor = Color.FromArgb(64, 64, 64);
            lblName.Location = new Point(158, 196);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(50, 17);
            lblName.TabIndex = 7;
            lblName.Text = "姓名：";
            // 
            // lblCreateTime
            // 
            lblCreateTime.AutoSize = true;
            lblCreateTime.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblCreateTime.ForeColor = Color.FromArgb(64, 64, 64);
            lblCreateTime.Location = new Point(131, 319);
            lblCreateTime.Margin = new Padding(4, 0, 4, 0);
            lblCreateTime.Name = "lblCreateTime";
            lblCreateTime.Size = new Size(78, 17);
            lblCreateTime.TabIndex = 8;
            lblCreateTime.Text = "创建时间：";
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.FromArgb(116, 89, 255);
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnOk.ForeColor = Color.White;
            btnOk.IconChar = FontAwesome.Sharp.IconChar.AddressBook;
            btnOk.IconColor = Color.White;
            btnOk.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnOk.IconSize = 22;
            btnOk.ImageAlign = ContentAlignment.MiddleLeft;
            btnOk.Location = new Point(216, 400);
            btnOk.Margin = new Padding(4);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(90, 33);
            btnOk.TabIndex = 11;
            btnOk.Text = "确定";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += BtnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(116, 89, 255);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.White;
            btnCancel.IconChar = FontAwesome.Sharp.IconChar.ArrowRightRotate;
            btnCancel.IconColor = Color.White;
            btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancel.IconSize = 22;
            btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancel.Location = new Point(410, 400);
            btnCancel.Margin = new Padding(4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 33);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // dtpCreateTime
            // 
            dtpCreateTime.Checked = false;
            dtpCreateTime.Location = new Point(216, 314);
            dtpCreateTime.Name = "dtpCreateTime";
            dtpCreateTime.Size = new Size(284, 23);
            dtpCreateTime.TabIndex = 13;
            dtpCreateTime.ValueChanged += DtpCreateTime_ValueChanged;
            // 
            // lblAccountNum
            // 
            lblAccountNum.AutoSize = true;
            lblAccountNum.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblAccountNum.ForeColor = Color.FromArgb(64, 64, 64);
            lblAccountNum.Location = new Point(158, 76);
            lblAccountNum.Margin = new Padding(4, 0, 4, 0);
            lblAccountNum.Name = "lblAccountNum";
            lblAccountNum.Size = new Size(50, 17);
            lblAccountNum.TabIndex = 15;
            lblAccountNum.Text = "账号：";
            // 
            // txtAccountNum
            // 
            txtAccountNum.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtAccountNum.Location = new Point(216, 73);
            txtAccountNum.Margin = new Padding(4);
            txtAccountNum.Name = "txtAccountNum";
            txtAccountNum.Size = new Size(284, 23);
            txtAccountNum.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.ForeColor = Color.FromArgb(64, 64, 64);
            lblPassword.Location = new Point(158, 116);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(50, 17);
            lblPassword.TabIndex = 17;
            lblPassword.Text = "密码：";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(216, 113);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(284, 23);
            txtPassword.TabIndex = 2;
            // 
            // lblPasswordAgain
            // 
            lblPasswordAgain.AutoSize = true;
            lblPasswordAgain.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblPasswordAgain.ForeColor = Color.FromArgb(64, 64, 64);
            lblPasswordAgain.Location = new Point(130, 156);
            lblPasswordAgain.Margin = new Padding(4, 0, 4, 0);
            lblPasswordAgain.Name = "lblPasswordAgain";
            lblPasswordAgain.Size = new Size(78, 17);
            lblPasswordAgain.TabIndex = 19;
            lblPasswordAgain.Text = "密码确认：";
            // 
            // txtPasswordAgain
            // 
            txtPasswordAgain.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtPasswordAgain.Location = new Point(216, 153);
            txtPasswordAgain.Margin = new Padding(4);
            txtPasswordAgain.Name = "txtPasswordAgain";
            txtPasswordAgain.PasswordChar = '*';
            txtPasswordAgain.Size = new Size(284, 23);
            txtPasswordAgain.TabIndex = 18;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdbWoman);
            groupBox1.Controls.Add(rdbMan);
            groupBox1.Location = new Point(216, 223);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(284, 39);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            // 
            // rdbWoman
            // 
            rdbWoman.AutoSize = true;
            rdbWoman.Location = new Point(62, 12);
            rdbWoman.Name = "rdbWoman";
            rdbWoman.Size = new Size(38, 21);
            rdbWoman.TabIndex = 18;
            rdbWoman.TabStop = true;
            rdbWoman.Text = "女";
            rdbWoman.UseVisualStyleBackColor = true;
            // 
            // rdbMan
            // 
            rdbMan.AutoSize = true;
            rdbMan.Location = new Point(6, 12);
            rdbMan.Name = "rdbMan";
            rdbMan.Size = new Size(38, 21);
            rdbMan.TabIndex = 17;
            rdbMan.TabStop = true;
            rdbMan.Text = "男";
            rdbMan.UseVisualStyleBackColor = true;
            // 
            // lblSex
            // 
            lblSex.AutoSize = true;
            lblSex.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblSex.ForeColor = Color.FromArgb(64, 64, 64);
            lblSex.Location = new Point(158, 239);
            lblSex.Margin = new Padding(4, 0, 4, 0);
            lblSex.Name = "lblSex";
            lblSex.Size = new Size(50, 17);
            lblSex.TabIndex = 20;
            lblSex.Text = "性别：";
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDepartment.ForeColor = Color.FromArgb(64, 64, 64);
            lblDepartment.Location = new Point(158, 277);
            lblDepartment.Margin = new Padding(4, 0, 4, 0);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(50, 17);
            lblDepartment.TabIndex = 23;
            lblDepartment.Text = "科室：";
            // 
            // txtDepartment
            // 
            txtDepartment.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDepartment.Location = new Point(216, 274);
            txtDepartment.Margin = new Padding(4);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new Size(284, 23);
            txtDepartment.TabIndex = 22;
            // 
            // lblAdmin
            // 
            lblAdmin.AutoSize = true;
            lblAdmin.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblAdmin.ForeColor = Color.FromArgb(64, 64, 64);
            lblAdmin.Location = new Point(116, 356);
            lblAdmin.Margin = new Padding(4, 0, 4, 0);
            lblAdmin.Name = "lblAdmin";
            lblAdmin.Size = new Size(92, 17);
            lblAdmin.TabIndex = 24;
            lblAdmin.Text = "是否管理员：";
            // 
            // cmbBoxAdmin
            // 
            cmbBoxAdmin.FormattingEnabled = true;
            cmbBoxAdmin.Items.AddRange(new object[] { "否", "是" });
            cmbBoxAdmin.Location = new Point(216, 353);
            cmbBoxAdmin.Name = "cmbBoxAdmin";
            cmbBoxAdmin.Size = new Size(284, 25);
            cmbBoxAdmin.TabIndex = 25;
            // 
            // FormDoctorEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(226, 225, 232);
            ClientSize = new Size(673, 464);
            Controls.Add(cmbBoxAdmin);
            Controls.Add(lblAdmin);
            Controls.Add(lblDepartment);
            Controls.Add(txtDepartment);
            Controls.Add(groupBox1);
            Controls.Add(lblSex);
            Controls.Add(lblPasswordAgain);
            Controls.Add(txtPasswordAgain);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblAccountNum);
            Controls.Add(txtAccountNum);
            Controls.Add(dtpCreateTime);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(lblCreateTime);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(panTitle);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "FormDoctorEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormMantCliente";
            Load += FormDoctorEdit_Load;
            panTitle.ResumeLayout(false);
            panTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCreateTime;
        private FontAwesome.Sharp.IconButton btnOk;
        private FontAwesome.Sharp.IconButton btnCancel;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblTitle;
        private PictureBox pictureBoxIcon;
        private Label label7;
        public DateTimePicker dtpCreateTime;
        private Label lblAccountNum;
        public TextBox txtAccountNum;
        private Label lblPassword;
        public TextBox txtPassword;
        private Label lblPasswordAgain;
        public TextBox txtPasswordAgain;
        private GroupBox groupBox1;
        public RadioButton rdbWoman;
        public RadioButton rdbMan;
        private Label lblSex;
        private Label lblDepartment;
        public TextBox txtDepartment;
        private Label lblAdmin;
        public ComboBox cmbBoxAdmin;
    }
}