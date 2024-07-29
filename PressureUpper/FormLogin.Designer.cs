namespace PressureUpper
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            txtName = new TextBox();
            txtPassword = new TextBox();
            lblName = new Label();
            lblPassword = new Label();
            btnOk = new FontAwesome.Sharp.IconButton();
            btnCancel = new FontAwesome.Sharp.IconButton();
            loginPanel = new Panel();
            panelLoginInput = new Panel();
            panTitle = new Panel();
            pictureBoxIcon = new PictureBox();
            lblTitle = new Label();
            loginPanel.SuspendLayout();
            panelLoginInput.SuspendLayout();
            panTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.BorderStyle = BorderStyle.None;
            txtName.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point);
            txtName.Location = new Point(85, 125);
            txtName.Margin = new Padding(4);
            txtName.Name = "txtName";
            txtName.Size = new Size(300, 25);
            txtName.TabIndex = 3;
            txtName.KeyDown += TxtName_KeyDown;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(85, 195);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(300, 25);
            txtPassword.TabIndex = 6;
            txtPassword.KeyDown += TxtPassword_KeyDown;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblName.ForeColor = Color.FromArgb(64, 64, 64);
            lblName.Location = new Point(19, 130);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(43, 15);
            lblName.TabIndex = 7;
            lblName.Text = "账号：";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.ForeColor = Color.FromArgb(64, 64, 64);
            lblPassword.Location = new Point(19, 198);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(43, 15);
            lblPassword.TabIndex = 10;
            lblPassword.Text = "密码：";
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.FromArgb(116, 89, 255);
            btnOk.FlatAppearance.BorderColor = Color.FromArgb(116, 89, 255);
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatAppearance.MouseDownBackColor = Color.FromArgb(116, 89, 255);
            btnOk.FlatAppearance.MouseOverBackColor = Color.FromArgb(116, 89, 255);
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnOk.ForeColor = Color.White;
            btnOk.IconChar = FontAwesome.Sharp.IconChar.Clone;
            btnOk.IconColor = Color.White;
            btnOk.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnOk.IconSize = 22;
            btnOk.ImageAlign = ContentAlignment.MiddleLeft;
            btnOk.Location = new Point(85, 256);
            btnOk.Margin = new Padding(4);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(294, 33);
            btnOk.TabIndex = 11;
            btnOk.Text = "  确定";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += BtnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Transparent;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.DarkGray;
            btnCancel.IconChar = FontAwesome.Sharp.IconChar.Ad;
            btnCancel.IconColor = Color.Transparent;
            btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancel.IconSize = 22;
            btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancel.Location = new Point(85, 314);
            btnCancel.Margin = new Padding(0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(294, 33);
            btnCancel.TabIndex = 12;
            btnCancel.Text = " 取消";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancelar_Click;
            // 
            // loginPanel
            // 
            loginPanel.BackgroundImage = (Image)resources.GetObject("loginPanel.BackgroundImage");
            loginPanel.BackgroundImageLayout = ImageLayout.Stretch;
            loginPanel.Controls.Add(panelLoginInput);
            loginPanel.Controls.Add(panTitle);
            loginPanel.Dock = DockStyle.Fill;
            loginPanel.Location = new Point(0, 0);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(1289, 787);
            loginPanel.TabIndex = 13;
            // 
            // panelLoginInput
            // 
            panelLoginInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelLoginInput.BackgroundImage = (Image)resources.GetObject("panelLoginInput.BackgroundImage");
            panelLoginInput.BackgroundImageLayout = ImageLayout.Stretch;
            panelLoginInput.Controls.Add(btnCancel);
            panelLoginInput.Controls.Add(lblPassword);
            panelLoginInput.Controls.Add(txtName);
            panelLoginInput.Controls.Add(lblName);
            panelLoginInput.Controls.Add(btnOk);
            panelLoginInput.Controls.Add(txtPassword);
            panelLoginInput.Location = new Point(669, 224);
            panelLoginInput.Name = "panelLoginInput";
            panelLoginInput.Size = new Size(461, 430);
            panelLoginInput.TabIndex = 14;
            // 
            // panTitle
            // 
            panTitle.BackColor = Color.Transparent;
            panTitle.Controls.Add(pictureBoxIcon);
            panTitle.Controls.Add(lblTitle);
            panTitle.Dock = DockStyle.Top;
            panTitle.Location = new Point(0, 0);
            panTitle.Margin = new Padding(4);
            panTitle.Name = "panTitle";
            panTitle.Size = new Size(1289, 50);
            panTitle.TabIndex = 13;
            panTitle.MouseDown += Title_MouseDown;
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.Image = Properties.Resources._100;
            pictureBoxIcon.Location = new Point(2, 2);
            pictureBoxIcon.Margin = new Padding(4);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(20, 20);
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxIcon.TabIndex = 17;
            pictureBoxIcon.TabStop = false;
            pictureBoxIcon.Visible = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.FromArgb(167, 142, 122);
            lblTitle.Location = new Point(30, 5);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(68, 17);
            lblTitle.TabIndex = 15;
            lblTitle.Text = "用户登录";
            lblTitle.Visible = false;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1289, 787);
            Controls.Add(loginPanel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormMantCliente";
            loginPanel.ResumeLayout(false);
            panelLoginInput.ResumeLayout(false);
            panelLoginInput.PerformLayout();
            panTitle.ResumeLayout(false);
            panTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label lblName;
        private Label lblPassword;
        private FontAwesome.Sharp.IconButton btnOk;
        private FontAwesome.Sharp.IconButton btnCancel;
        public TextBox txtName;
        public TextBox txtPassword;
        private Panel loginPanel;
        private Panel panTitle;
        private PictureBox pictureBoxIcon;
        private Label lblTitle;
        private Panel panelLoginInput;
    }
}