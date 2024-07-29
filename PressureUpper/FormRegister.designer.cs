namespace PressureUpper
{
    partial class FormRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegister));
            panTitle = new Panel();
            pictureBoxIcon = new PictureBox();
            label7 = new Label();
            label6 = new Label();
            btnCancel = new FontAwesome.Sharp.IconButton();
            btnLoadFile = new FontAwesome.Sharp.IconButton();
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
            label6.Size = new Size(68, 17);
            label6.TabIndex = 15;
            label6.Text = "软件注册";
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
            btnCancel.Location = new Point(366, 128);
            btnCancel.Margin = new Padding(4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(137, 33);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "关闭";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancelar_Click;
            // 
            // btnLoadFile
            // 
            btnLoadFile.BackColor = Color.FromArgb(116, 89, 255);
            btnLoadFile.FlatAppearance.BorderSize = 0;
            btnLoadFile.FlatStyle = FlatStyle.Flat;
            btnLoadFile.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnLoadFile.ForeColor = Color.White;
            btnLoadFile.IconChar = FontAwesome.Sharp.IconChar.SearchLocation;
            btnLoadFile.IconColor = Color.White;
            btnLoadFile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLoadFile.IconSize = 22;
            btnLoadFile.ImageAlign = ContentAlignment.MiddleLeft;
            btnLoadFile.Location = new Point(152, 128);
            btnLoadFile.Margin = new Padding(4);
            btnLoadFile.Name = "btnLoadFile";
            btnLoadFile.Size = new Size(137, 33);
            btnLoadFile.TabIndex = 11;
            btnLoadFile.Text = "加载授权文件";
            btnLoadFile.UseVisualStyleBackColor = false;
            btnLoadFile.Click += BtnLoadFile_Click;
            // 
            // FormRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(226, 225, 232);
            ClientSize = new Size(673, 231);
            Controls.Add(btnCancel);
            Controls.Add(btnLoadFile);
            Controls.Add(panTitle);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "FormRegister";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormMantCliente";
            panTitle.ResumeLayout(false);
            panTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panTitle;
        private FontAwesome.Sharp.IconButton btnCancel;
        private System.Windows.Forms.Label label6;
        private PictureBox pictureBoxIcon;
        private Label label7;
        private FontAwesome.Sharp.IconButton btnLoadFile;
    }
}