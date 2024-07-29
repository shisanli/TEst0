namespace PressureUpper
{
    partial class FormSetting
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
            label5 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            label6 = new Label();
            btnRefresh = new FontAwesome.Sharp.IconButton();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            btnClose = new FontAwesome.Sharp.IconButton();
            btnOk = new FontAwesome.Sharp.IconButton();
            btnTest = new FontAwesome.Sharp.IconButton();
            btnSetup = new FontAwesome.Sharp.IconButton();
            comboBoxPortTwo = new ComboBox();
            comboBoxPortOne = new ComboBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(110, 31);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 20;
            label5.Text = "坐垫串口号";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(110, 65);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 17;
            label2.Text = "靠背串口号";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.BackColor = Color.FromArgb(233, 235, 244);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnClose);
            groupBox1.Controls.Add(btnOk);
            groupBox1.Controls.Add(btnTest);
            groupBox1.Controls.Add(btnSetup);
            groupBox1.Controls.Add(comboBoxPortTwo);
            groupBox1.Controls.Add(comboBoxPortOne);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label2);
            groupBox1.ForeColor = Color.DodgerBlue;
            groupBox1.Location = new Point(31, 58);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(945, 317);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "初始设置";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(205, 213);
            label6.Name = "label6";
            label6.Size = new Size(265, 17);
            label6.TabIndex = 32;
            label6.Text = "3：正确连接设备后，端口未出现请点“刷新”按钮";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(116, 89, 255);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.IconChar = FontAwesome.Sharp.IconChar.None;
            btnRefresh.IconColor = Color.Black;
            btnRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRefresh.Location = new Point(556, 264);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 33);
            btnRefresh.TabIndex = 31;
            btnRefresh.Text = "刷新";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(203, 182);
            label4.Name = "label4";
            label4.Size = new Size(207, 17);
            label4.TabIndex = 30;
            label4.Text = "2：设备打开开关后，再插入USB端口";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(203, 147);
            label3.Name = "label3";
            label3.Size = new Size(481, 17);
            label3.TabIndex = 29;
            label3.Text = "1、请确认已经正确安装USB转串口驱动程序，如果未安装请点击“安装驱动”按钮进行安装";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(203, 111);
            label1.Name = "label1";
            label1.Size = new Size(51, 19);
            label1.TabIndex = 28;
            label1.Text = "备注：";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(116, 89, 255);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.IconChar = FontAwesome.Sharp.IconChar.None;
            btnClose.IconColor = Color.Black;
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.Location = new Point(656, 264);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 33);
            btnClose.TabIndex = 27;
            btnClose.Text = "关闭";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.FromArgb(116, 89, 255);
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.ForeColor = Color.White;
            btnOk.IconChar = FontAwesome.Sharp.IconChar.None;
            btnOk.IconColor = Color.Black;
            btnOk.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnOk.Location = new Point(446, 264);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 33);
            btnOk.TabIndex = 26;
            btnOk.Text = "设置完成";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += BtnOk_Click;
            // 
            // btnTest
            // 
            btnTest.BackColor = Color.FromArgb(116, 89, 255);
            btnTest.FlatAppearance.BorderSize = 0;
            btnTest.FlatStyle = FlatStyle.Flat;
            btnTest.ForeColor = Color.White;
            btnTest.IconChar = FontAwesome.Sharp.IconChar.None;
            btnTest.IconColor = Color.Black;
            btnTest.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTest.Location = new Point(336, 264);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(75, 33);
            btnTest.TabIndex = 25;
            btnTest.Text = "测试连接";
            btnTest.UseVisualStyleBackColor = false;
            btnTest.Click += btnTest_Click;
            // 
            // btnSetup
            // 
            btnSetup.BackColor = Color.FromArgb(116, 89, 255);
            btnSetup.FlatAppearance.BorderSize = 0;
            btnSetup.FlatStyle = FlatStyle.Flat;
            btnSetup.ForeColor = Color.White;
            btnSetup.IconChar = FontAwesome.Sharp.IconChar.None;
            btnSetup.IconColor = Color.Black;
            btnSetup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSetup.Location = new Point(226, 264);
            btnSetup.Name = "btnSetup";
            btnSetup.Size = new Size(75, 33);
            btnSetup.TabIndex = 24;
            btnSetup.Text = "安装驱动";
            btnSetup.UseVisualStyleBackColor = false;
            btnSetup.Click += btnSetup_Click;
            // 
            // comboBoxPortTwo
            // 
            comboBoxPortTwo.FormattingEnabled = true;
            comboBoxPortTwo.Location = new Point(203, 65);
            comboBoxPortTwo.Name = "comboBoxPortTwo";
            comboBoxPortTwo.Size = new Size(579, 25);
            comboBoxPortTwo.TabIndex = 23;
            // 
            // comboBoxPortOne
            // 
            comboBoxPortOne.FormattingEnabled = true;
            comboBoxPortOne.Location = new Point(203, 23);
            comboBoxPortOne.Name = "comboBoxPortOne";
            comboBoxPortOne.Size = new Size(579, 25);
            comboBoxPortOne.TabIndex = 22;
            // 
            // FormSetting
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(226, 225, 232);
            ClientSize = new Size(1015, 598);
            Controls.Add(groupBox1);
            Margin = new Padding(4);
            Name = "FormSetting";
            Text = "FormMembresia";
            Load += FormSetting_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComboBox comboBoxPortTwo;
        private ComboBox comboBoxPortOne;
        private Label label4;
        private Label label3;
        private Label label1;
        private FontAwesome.Sharp.IconButton btnClose;
        private FontAwesome.Sharp.IconButton btnOk;
        private FontAwesome.Sharp.IconButton btnTest;
        private FontAwesome.Sharp.IconButton btnSetup;
        private Label label6;
        private FontAwesome.Sharp.IconButton btnRefresh;
    }
}