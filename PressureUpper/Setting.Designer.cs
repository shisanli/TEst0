namespace PressureUpper
{
    partial class Setting
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
            skinPanel1 = new Panel();
            btnCancel = new Button();
            btnOk = new Button();
            txtPl = new TextBox();
            lblPl = new Label();
            comboZdNum = new ComboBox();
            lblZdNum = new Label();
            comboKbNum = new ComboBox();
            lblkbNum = new Label();
            comboBtl = new ComboBox();
            lblBtl = new Label();
            comboCom = new ComboBox();
            lblCom = new Label();
            button1 = new Button();
            skinPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // skinPanel1
            // 
            skinPanel1.BackColor = Color.Transparent;
            skinPanel1.Controls.Add(btnCancel);
            skinPanel1.Controls.Add(btnOk);
            skinPanel1.Controls.Add(txtPl);
            skinPanel1.Controls.Add(lblPl);
            skinPanel1.Controls.Add(comboZdNum);
            skinPanel1.Controls.Add(lblZdNum);
            skinPanel1.Controls.Add(comboKbNum);
            skinPanel1.Controls.Add(lblkbNum);
            skinPanel1.Controls.Add(comboBtl);
            skinPanel1.Controls.Add(lblBtl);
            skinPanel1.Controls.Add(comboCom);
            skinPanel1.Controls.Add(lblCom);
            skinPanel1.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            skinPanel1.Location = new Point(20, 31);
            skinPanel1.Name = "skinPanel1";
            skinPanel1.Size = new Size(495, 338);
            skinPanel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Transparent;
            btnCancel.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(242, 263);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(159, 30);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.Transparent;
            btnOk.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnOk.Image = Properties.Resources.LeftArrows;
            btnOk.ImageAlign = ContentAlignment.BottomLeft;
            btnOk.Location = new Point(61, 258);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(159, 40);
            btnOk.TabIndex = 14;
            btnOk.Text = "确定";
            btnOk.UseVisualStyleBackColor = false;
            // 
            // txtPl
            // 
            txtPl.BackColor = Color.Transparent;
            txtPl.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtPl.Location = new Point(143, 190);
            txtPl.Margin = new Padding(0);
            txtPl.MinimumSize = new Size(28, 28);
            txtPl.Name = "txtPl";
            txtPl.Padding = new Padding(5);
            txtPl.Size = new Size(258, 28);
            // 
            // 
            // 
            txtPl.BorderStyle = BorderStyle.None;
            txtPl.Dock = DockStyle.Fill;
            txtPl.Font = new Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtPl.Location = new Point(5, 5);
            txtPl.Name = "BaseText";
            txtPl.Size = new Size(248, 18);
            txtPl.TabIndex = 0;
            txtPl.TabIndex = 13;
            // 
            // lblPl
            // 
            lblPl.AutoSize = true;
            lblPl.BackColor = Color.Transparent;
            lblPl.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPl.Location = new Point(35, 201);
            lblPl.Name = "lblPl";
            lblPl.Size = new Size(105, 17);
            lblPl.TabIndex = 12;
            lblPl.Text = "采用频率(次/秒)：";
            // 
            // comboZdNum
            // 
            comboZdNum.DrawMode = DrawMode.OwnerDrawFixed;
            comboZdNum.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboZdNum.FormattingEnabled = true;
            comboZdNum.Location = new Point(143, 140);
            comboZdNum.Name = "comboZdNum";
            comboZdNum.Size = new Size(258, 24);
            comboZdNum.TabIndex = 11;
            // 
            // lblZdNum
            // 
            lblZdNum.AutoSize = true;
            lblZdNum.BackColor = Color.Transparent;
            lblZdNum.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblZdNum.Location = new Point(44, 147);
            lblZdNum.Name = "lblZdNum";
            lblZdNum.Size = new Size(80, 17);
            lblZdNum.TabIndex = 10;
            lblZdNum.Text = "坐垫通信号：";
            // 
            // comboKbNum
            // 
            comboKbNum.DrawMode = DrawMode.OwnerDrawFixed;
            comboKbNum.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboKbNum.FormattingEnabled = true;
            comboKbNum.Location = new Point(143, 99);
            comboKbNum.Name = "comboKbNum";
            comboKbNum.Size = new Size(258, 24);
            comboKbNum.TabIndex = 9;
            // 
            // lblkbNum
            // 
            lblkbNum.AutoSize = true;
            lblkbNum.BackColor = Color.Transparent;
            lblkbNum.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblkbNum.Location = new Point(44, 106);
            lblkbNum.Name = "lblkbNum";
            lblkbNum.Size = new Size(80, 17);
            lblkbNum.TabIndex = 8;
            lblkbNum.Text = "靠背通信号：";
            // 
            // comboBtl
            // 
            comboBtl.DrawMode = DrawMode.OwnerDrawFixed;
            comboBtl.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBtl.FormattingEnabled = true;
            comboBtl.Location = new Point(143, 60);
            comboBtl.Name = "comboBtl";
            comboBtl.Size = new Size(258, 24);
            comboBtl.TabIndex = 7;
            // 
            // lblBtl
            // 
            lblBtl.AutoSize = true;
            lblBtl.BackColor = Color.Transparent;
            lblBtl.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblBtl.Location = new Point(44, 67);
            lblBtl.Name = "lblBtl";
            lblBtl.Size = new Size(56, 17);
            lblBtl.TabIndex = 6;
            lblBtl.Text = "波特率：";
            // 
            // comboCom
            // 
            comboCom.DrawMode = DrawMode.OwnerDrawFixed;
            comboCom.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboCom.FormattingEnabled = true;
            comboCom.Location = new Point(143, 19);
            comboCom.Name = "comboCom";
            comboCom.Size = new Size(258, 24);
            comboCom.TabIndex = 5;
            // 
            // lblCom
            // 
            lblCom.AutoSize = true;
            lblCom.BackColor = Color.Transparent;
            lblCom.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblCom.Location = new Point(44, 26);
            lblCom.Name = "lblCom";
            lblCom.Size = new Size(56, 17);
            lblCom.TabIndex = 4;
            lblCom.Text = "串口号：";
            // 
            // button1
            // 
            button1.Location = new Point(412, 470);
            button1.Name = "button1";
            button1.Size = new Size(103, 37);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // Setting
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(647, 674);
            Controls.Add(button1);
            Controls.Add(skinPanel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Setting";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "端口设置";
            skinPanel1.ResumeLayout(false);
            skinPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel skinPanel1;
        private Button btnCancel;
        private Button btnOk;
        private TextBox txtPl;
        private Label lblPl;
        private ComboBox comboZdNum;
        private Label lblZdNum;
        private ComboBox comboKbNum;
        private Label lblkbNum;
        private ComboBox comboBtl;
        private Label lblBtl;
        private ComboBox comboCom;
        private Label lblCom;
        private Button button1;
    }
}