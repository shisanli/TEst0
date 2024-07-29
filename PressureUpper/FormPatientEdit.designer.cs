namespace PressureUpper
{
    partial class FormPatientEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPatientEdit));
            panTitle = new Panel();
            pictureBoxIcon = new PictureBox();
            label7 = new Label();
            lblTitle = new Label();
            txtName = new TextBox();
            txtNum = new TextBox();
            lblName = new Label();
            lblSex = new Label();
            lblHeight = new Label();
            lblWeight = new Label();
            btnOk = new FontAwesome.Sharp.IconButton();
            btnCancel = new FontAwesome.Sharp.IconButton();
            lblNum = new Label();
            txtHeight = new TextBox();
            rdbMan = new RadioButton();
            groupBox1 = new GroupBox();
            rdbWoman = new RadioButton();
            txtWeight = new TextBox();
            lblAge = new Label();
            txtAge = new TextBox();
            txtDoctor = new TextBox();
            lblDoctor = new Label();
            txtAnesthesiologist = new TextBox();
            lblAnesthesiologist = new Label();
            dtpEnterTime = new DateTimePicker();
            lblEnterTime = new Label();
            txtScore = new TextBox();
            lblScore = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label8 = new Label();
            txtMedicalHistory = new TextBox();
            txtDrugAllergy = new TextBox();
            txtDiagnosticResult = new TextBox();
            txtOtherInformation = new TextBox();
            btnSelectDoctorOne = new FontAwesome.Sharp.IconButton();
            btnSelectDoctorTwo = new FontAwesome.Sharp.IconButton();
            txtDoctorID = new TextBox();
            txtAnesthesiologistID = new TextBox();
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
            panTitle.Size = new Size(933, 50);
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
            lblTitle.Location = new Point(391, 9);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(68, 17);
            lblTitle.TabIndex = 15;
            lblTitle.Text = "患者信息";
            // 
            // txtName
            // 
            txtName.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtName.Location = new Point(584, 65);
            txtName.Margin = new Padding(4);
            txtName.Name = "txtName";
            txtName.Size = new Size(284, 23);
            txtName.TabIndex = 2;
            // 
            // txtNum
            // 
            txtNum.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNum.Location = new Point(159, 68);
            txtNum.Margin = new Padding(4);
            txtNum.Name = "txtNum";
            txtNum.Size = new Size(284, 23);
            txtNum.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblName.ForeColor = Color.FromArgb(64, 64, 64);
            lblName.Location = new Point(526, 68);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(50, 17);
            lblName.TabIndex = 7;
            lblName.Text = "姓名：";
            // 
            // lblSex
            // 
            lblSex.AutoSize = true;
            lblSex.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblSex.ForeColor = Color.FromArgb(64, 64, 64);
            lblSex.Location = new Point(101, 110);
            lblSex.Margin = new Padding(4, 0, 4, 0);
            lblSex.Name = "lblSex";
            lblSex.Size = new Size(50, 17);
            lblSex.TabIndex = 8;
            lblSex.Text = "性别：";
            // 
            // lblHeight
            // 
            lblHeight.AutoSize = true;
            lblHeight.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblHeight.ForeColor = Color.FromArgb(64, 64, 64);
            lblHeight.Location = new Point(526, 110);
            lblHeight.Margin = new Padding(4, 0, 4, 0);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new Size(50, 17);
            lblHeight.TabIndex = 9;
            lblHeight.Text = "身高：";
            // 
            // lblWeight
            // 
            lblWeight.AutoSize = true;
            lblWeight.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblWeight.ForeColor = Color.FromArgb(64, 64, 64);
            lblWeight.Location = new Point(101, 144);
            lblWeight.Margin = new Padding(4, 0, 4, 0);
            lblWeight.Name = "lblWeight";
            lblWeight.Size = new Size(50, 17);
            lblWeight.TabIndex = 10;
            lblWeight.Text = "体重：";
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
            btnOk.Location = new Point(661, 646);
            btnOk.Margin = new Padding(4);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(90, 33);
            btnOk.TabIndex = 15;
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
            btnCancel.Location = new Point(778, 646);
            btnCancel.Margin = new Padding(4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 33);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancelar_Click;
            // 
            // lblNum
            // 
            lblNum.AutoSize = true;
            lblNum.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblNum.ForeColor = Color.FromArgb(64, 64, 64);
            lblNum.Location = new Point(87, 71);
            lblNum.Margin = new Padding(4, 0, 4, 0);
            lblNum.Name = "lblNum";
            lblNum.Size = new Size(64, 17);
            lblNum.TabIndex = 15;
            lblNum.Text = "病例号：";
            // 
            // txtHeight
            // 
            txtHeight.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtHeight.Location = new Point(584, 110);
            txtHeight.Margin = new Padding(4);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(284, 23);
            txtHeight.TabIndex = 4;
            // 
            // rdbMan
            // 
            rdbMan.AutoSize = true;
            rdbMan.Location = new Point(6, 12);
            rdbMan.Name = "rdbMan";
            rdbMan.Size = new Size(38, 21);
            rdbMan.TabIndex = 3;
            rdbMan.TabStop = true;
            rdbMan.Text = "男";
            rdbMan.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdbWoman);
            groupBox1.Controls.Add(rdbMan);
            groupBox1.Location = new Point(159, 98);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(284, 39);
            groupBox1.TabIndex = 18;
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
            // txtWeight
            // 
            txtWeight.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtWeight.Location = new Point(159, 144);
            txtWeight.Margin = new Padding(4);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(284, 23);
            txtWeight.TabIndex = 5;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblAge.ForeColor = Color.FromArgb(64, 64, 64);
            lblAge.Location = new Point(526, 147);
            lblAge.Margin = new Padding(4, 0, 4, 0);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(50, 17);
            lblAge.TabIndex = 20;
            lblAge.Text = "年龄：";
            // 
            // txtAge
            // 
            txtAge.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtAge.Location = new Point(584, 144);
            txtAge.Margin = new Padding(4);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(284, 23);
            txtAge.TabIndex = 6;
            // 
            // txtDoctor
            // 
            txtDoctor.Enabled = false;
            txtDoctor.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDoctor.Location = new Point(159, 185);
            txtDoctor.Margin = new Padding(4);
            txtDoctor.Name = "txtDoctor";
            txtDoctor.Size = new Size(284, 23);
            txtDoctor.TabIndex = 23;
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDoctor.ForeColor = Color.FromArgb(64, 64, 64);
            lblDoctor.Location = new Point(101, 188);
            lblDoctor.Margin = new Padding(4, 0, 4, 0);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(50, 17);
            lblDoctor.TabIndex = 22;
            lblDoctor.Text = "医生：";
            // 
            // txtAnesthesiologist
            // 
            txtAnesthesiologist.Enabled = false;
            txtAnesthesiologist.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtAnesthesiologist.Location = new Point(584, 182);
            txtAnesthesiologist.Margin = new Padding(4);
            txtAnesthesiologist.Name = "txtAnesthesiologist";
            txtAnesthesiologist.Size = new Size(284, 23);
            txtAnesthesiologist.TabIndex = 25;
            // 
            // lblAnesthesiologist
            // 
            lblAnesthesiologist.AutoSize = true;
            lblAnesthesiologist.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblAnesthesiologist.ForeColor = Color.FromArgb(64, 64, 64);
            lblAnesthesiologist.Location = new Point(498, 185);
            lblAnesthesiologist.Margin = new Padding(4, 0, 4, 0);
            lblAnesthesiologist.Name = "lblAnesthesiologist";
            lblAnesthesiologist.Size = new Size(78, 17);
            lblAnesthesiologist.TabIndex = 24;
            lblAnesthesiologist.Text = "麻醉医生：";
            // 
            // dtpEnterTime
            // 
            dtpEnterTime.Checked = false;
            dtpEnterTime.Location = new Point(159, 224);
            dtpEnterTime.Name = "dtpEnterTime";
            dtpEnterTime.Size = new Size(284, 23);
            dtpEnterTime.TabIndex = 9;
            dtpEnterTime.ValueChanged += DtpEnterTime_ValueChanged;
            // 
            // lblEnterTime
            // 
            lblEnterTime.AutoSize = true;
            lblEnterTime.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblEnterTime.ForeColor = Color.FromArgb(64, 64, 64);
            lblEnterTime.Location = new Point(73, 229);
            lblEnterTime.Margin = new Padding(4, 0, 4, 0);
            lblEnterTime.Name = "lblEnterTime";
            lblEnterTime.Size = new Size(78, 17);
            lblEnterTime.TabIndex = 26;
            lblEnterTime.Text = "入院时间：";
            // 
            // txtScore
            // 
            txtScore.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtScore.Location = new Point(584, 223);
            txtScore.Margin = new Padding(4);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(284, 23);
            txtScore.TabIndex = 10;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblScore.ForeColor = Color.FromArgb(64, 64, 64);
            lblScore.Location = new Point(526, 226);
            lblScore.Margin = new Padding(4, 0, 4, 0);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(50, 17);
            lblScore.TabIndex = 28;
            lblScore.Text = "评分：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(101, 288);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(50, 17);
            label3.TabIndex = 30;
            label3.Text = "病史：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(73, 390);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(78, 17);
            label4.TabIndex = 31;
            label4.Text = "药物过敏：";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(64, 64, 64);
            label5.Location = new Point(73, 483);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(78, 17);
            label5.TabIndex = 32;
            label5.Text = "诊断结果：";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.FromArgb(64, 64, 64);
            label8.Location = new Point(73, 576);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(78, 17);
            label8.TabIndex = 33;
            label8.Text = "其他信息：";
            // 
            // txtMedicalHistory
            // 
            txtMedicalHistory.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtMedicalHistory.Location = new Point(159, 268);
            txtMedicalHistory.Margin = new Padding(4);
            txtMedicalHistory.Multiline = true;
            txtMedicalHistory.Name = "txtMedicalHistory";
            txtMedicalHistory.Size = new Size(709, 93);
            txtMedicalHistory.TabIndex = 11;
            // 
            // txtDrugAllergy
            // 
            txtDrugAllergy.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDrugAllergy.Location = new Point(159, 369);
            txtDrugAllergy.Margin = new Padding(4);
            txtDrugAllergy.Multiline = true;
            txtDrugAllergy.Name = "txtDrugAllergy";
            txtDrugAllergy.Size = new Size(709, 90);
            txtDrugAllergy.TabIndex = 12;
            // 
            // txtDiagnosticResult
            // 
            txtDiagnosticResult.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDiagnosticResult.Location = new Point(159, 467);
            txtDiagnosticResult.Margin = new Padding(4);
            txtDiagnosticResult.Multiline = true;
            txtDiagnosticResult.Name = "txtDiagnosticResult";
            txtDiagnosticResult.Size = new Size(709, 82);
            txtDiagnosticResult.TabIndex = 13;
            // 
            // txtOtherInformation
            // 
            txtOtherInformation.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtOtherInformation.Location = new Point(159, 557);
            txtOtherInformation.Margin = new Padding(4);
            txtOtherInformation.Multiline = true;
            txtOtherInformation.Name = "txtOtherInformation";
            txtOtherInformation.Size = new Size(709, 81);
            txtOtherInformation.TabIndex = 14;
            // 
            // btnSelectDoctorOne
            // 
            btnSelectDoctorOne.BackColor = Color.FromArgb(116, 89, 255);
            btnSelectDoctorOne.FlatAppearance.BorderSize = 0;
            btnSelectDoctorOne.FlatStyle = FlatStyle.Flat;
            btnSelectDoctorOne.ForeColor = Color.White;
            btnSelectDoctorOne.IconChar = FontAwesome.Sharp.IconChar.User;
            btnSelectDoctorOne.IconColor = Color.White;
            btnSelectDoctorOne.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSelectDoctorOne.IconSize = 18;
            btnSelectDoctorOne.ImageAlign = ContentAlignment.MiddleLeft;
            btnSelectDoctorOne.Location = new Point(448, 185);
            btnSelectDoctorOne.Name = "btnSelectDoctorOne";
            btnSelectDoctorOne.Size = new Size(43, 23);
            btnSelectDoctorOne.TabIndex = 7;
            btnSelectDoctorOne.Text = "    ...";
            btnSelectDoctorOne.UseVisualStyleBackColor = false;
            btnSelectDoctorOne.Click += BtnSelectDoctorOne_Click;
            // 
            // btnSelectDoctorTwo
            // 
            btnSelectDoctorTwo.BackColor = Color.FromArgb(116, 89, 255);
            btnSelectDoctorTwo.FlatAppearance.BorderSize = 0;
            btnSelectDoctorTwo.FlatStyle = FlatStyle.Flat;
            btnSelectDoctorTwo.ForeColor = Color.White;
            btnSelectDoctorTwo.IconChar = FontAwesome.Sharp.IconChar.User;
            btnSelectDoctorTwo.IconColor = Color.White;
            btnSelectDoctorTwo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSelectDoctorTwo.IconSize = 18;
            btnSelectDoctorTwo.ImageAlign = ContentAlignment.MiddleLeft;
            btnSelectDoctorTwo.Location = new Point(872, 182);
            btnSelectDoctorTwo.Name = "btnSelectDoctorTwo";
            btnSelectDoctorTwo.Size = new Size(43, 23);
            btnSelectDoctorTwo.TabIndex = 8;
            btnSelectDoctorTwo.Text = "    ...";
            btnSelectDoctorTwo.UseVisualStyleBackColor = false;
            btnSelectDoctorTwo.Click += BtnSelectDoctorTwo_Click;
            // 
            // txtDoctorID
            // 
            txtDoctorID.Enabled = false;
            txtDoctorID.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDoctorID.Location = new Point(159, 652);
            txtDoctorID.Margin = new Padding(4);
            txtDoctorID.Name = "txtDoctorID";
            txtDoctorID.Size = new Size(146, 23);
            txtDoctorID.TabIndex = 40;
            txtDoctorID.Visible = false;
            // 
            // txtAnesthesiologistID
            // 
            txtAnesthesiologistID.Enabled = false;
            txtAnesthesiologistID.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtAnesthesiologistID.Location = new Point(313, 652);
            txtAnesthesiologistID.Margin = new Padding(4);
            txtAnesthesiologistID.Name = "txtAnesthesiologistID";
            txtAnesthesiologistID.Size = new Size(146, 23);
            txtAnesthesiologistID.TabIndex = 41;
            txtAnesthesiologistID.Visible = false;
            // 
            // FormPatientEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(226, 225, 232);
            ClientSize = new Size(933, 704);
            Controls.Add(txtAnesthesiologistID);
            Controls.Add(txtDoctorID);
            Controls.Add(btnSelectDoctorTwo);
            Controls.Add(btnSelectDoctorOne);
            Controls.Add(txtOtherInformation);
            Controls.Add(txtDiagnosticResult);
            Controls.Add(txtDrugAllergy);
            Controls.Add(txtMedicalHistory);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtScore);
            Controls.Add(lblScore);
            Controls.Add(dtpEnterTime);
            Controls.Add(lblEnterTime);
            Controls.Add(txtAnesthesiologist);
            Controls.Add(lblAnesthesiologist);
            Controls.Add(txtDoctor);
            Controls.Add(lblDoctor);
            Controls.Add(txtAge);
            Controls.Add(lblAge);
            Controls.Add(txtWeight);
            Controls.Add(groupBox1);
            Controls.Add(txtHeight);
            Controls.Add(lblNum);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(lblWeight);
            Controls.Add(lblHeight);
            Controls.Add(lblSex);
            Controls.Add(lblName);
            Controls.Add(txtNum);
            Controls.Add(txtName);
            Controls.Add(panTitle);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "FormPatientEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormMantCliente";
            Load += FormPatientEdit_Load;
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
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWeight;
        private FontAwesome.Sharp.IconButton btnOk;
        private FontAwesome.Sharp.IconButton btnCancel;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label lblTitle;
        private PictureBox pictureBoxIcon;
        private Label label7;
        private Label lblNum;
        public TextBox txtHeight;
        private RadioButton rdbMan;
        private GroupBox groupBox1;
        private RadioButton rdbWoman;
        public TextBox txtWeight;
        private Label lblAge;
        public TextBox txtAge;
        public TextBox txtDoctor;
        private Label lblDoctor;
        public TextBox txtAnesthesiologist;
        private Label lblAnesthesiologist;
        private DateTimePicker dtpEnterTime;
        private Label lblEnterTime;
        public TextBox txtScore;
        private Label lblScore;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label8;
        public TextBox txtMedicalHistory;
        public TextBox txtDrugAllergy;
        public TextBox txtDiagnosticResult;
        public TextBox txtOtherInformation;
        private FontAwesome.Sharp.IconButton btnSelectDoctorOne;
        private FontAwesome.Sharp.IconButton btnSelectDoctorTwo;
        public TextBox txtDoctorID;
        public TextBox txtAnesthesiologistID;
    }
}