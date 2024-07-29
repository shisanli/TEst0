namespace PressureUpper
{
    partial class FormDoctorQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDoctorQuery));
            panTitle = new Panel();
            pictureBoxIcon = new PictureBox();
            label7 = new Label();
            label6 = new Label();
            txtName = new TextBox();
            txtAccountNum = new TextBox();
            label2 = new Label();
            label1 = new Label();
            lblDepartment = new Label();
            label4 = new Label();
            btnOk = new FontAwesome.Sharp.IconButton();
            btnCancel = new FontAwesome.Sharp.IconButton();
            dtpCreateTime = new DateTimePicker();
            txtDepartment = new TextBox();
            panTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
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
            label6.Location = new Point(275, 17);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(128, 17);
            label6.TabIndex = 15;
            label6.Text = "医生查询条件录入";
            // 
            // txtName
            // 
            txtName.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtName.Location = new Point(243, 106);
            txtName.Margin = new Padding(4);
            txtName.Name = "txtName";
            txtName.Size = new Size(284, 23);
            txtName.TabIndex = 3;
            // 
            // txtAccountNum
            // 
            txtAccountNum.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtAccountNum.Location = new Point(243, 220);
            txtAccountNum.Margin = new Padding(4);
            txtAccountNum.Name = "txtAccountNum";
            txtAccountNum.Size = new Size(284, 23);
            txtAccountNum.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(157, 109);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(50, 17);
            label2.TabIndex = 7;
            label2.Text = "姓名：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(157, 147);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(78, 17);
            label1.TabIndex = 8;
            label1.Text = "创建时间：";
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDepartment.ForeColor = Color.FromArgb(64, 64, 64);
            lblDepartment.Location = new Point(157, 185);
            lblDepartment.Margin = new Padding(4, 0, 4, 0);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(50, 17);
            lblDepartment.TabIndex = 9;
            lblDepartment.Text = "科室：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(157, 223);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(50, 17);
            label4.TabIndex = 10;
            label4.Text = "账号：";
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.FromArgb(116, 89, 255);
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnOk.ForeColor = Color.White;
            btnOk.IconChar = FontAwesome.Sharp.IconChar.SearchLocation;
            btnOk.IconColor = Color.White;
            btnOk.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnOk.IconSize = 22;
            btnOk.ImageAlign = ContentAlignment.MiddleLeft;
            btnOk.Location = new Point(248, 292);
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
            btnCancel.Location = new Point(397, 292);
            btnCancel.Margin = new Padding(4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 33);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancelar_Click;
            // 
            // dtpCreateTime
            // 
            dtpCreateTime.Checked = false;
            dtpCreateTime.Location = new Point(243, 144);
            dtpCreateTime.Name = "dtpCreateTime";
            dtpCreateTime.Size = new Size(284, 23);
            dtpCreateTime.TabIndex = 13;
            dtpCreateTime.ValueChanged += DtpCreateTime_ValueChanged;
            // 
            // txtDepartment
            // 
            txtDepartment.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDepartment.Location = new Point(243, 182);
            txtDepartment.Margin = new Padding(4);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new Size(284, 23);
            txtDepartment.TabIndex = 14;
            // 
            // FormDoctorQuery
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(673, 384);
            Controls.Add(txtDepartment);
            Controls.Add(dtpCreateTime);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(label4);
            Controls.Add(lblDepartment);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(txtAccountNum);
            Controls.Add(txtName);
            Controls.Add(panTitle);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "FormDoctorQuery";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormMantCliente";
            Load += FormMantCliente_Load;
            panTitle.ResumeLayout(false);
            panTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton btnOk;
        private FontAwesome.Sharp.IconButton btnCancel;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.TextBox txtAccountNum;
        private System.Windows.Forms.Label label6;
        private PictureBox pictureBoxIcon;
        private Label label7;
        private DateTimePicker dtpCreateTime;
        public TextBox txtDepartment;
    }
}