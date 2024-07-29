using NPOI.SS.Formula.Functions;

namespace PressureUpper
{
    partial class FormCloud
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
            if (disposing && (formPressureMock != null))
            {
                formPressureMock.Close();
            }
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCloud));
            timerRealTime = new System.Windows.Forms.Timer(components);
            panelRight = new Panel();
            panel6 = new Panel();
            cartesianChartDiff = new LiveCharts.WinForms.CartesianChart();
            panelAngle = new Panel();
            cartesianChartAngle = new LiveCharts.WinForms.CartesianChart();
            btn120 = new FontAwesome.Sharp.IconButton();
            btn90 = new FontAwesome.Sharp.IconButton();
            btn60 = new FontAwesome.Sharp.IconButton();
            btn45 = new FontAwesome.Sharp.IconButton();
            btn30 = new FontAwesome.Sharp.IconButton();
            btn0 = new FontAwesome.Sharp.IconButton();
            btnCatch = new FontAwesome.Sharp.IconButton();
            btnChartSwitchRealTime = new FontAwesome.Sharp.IconButton();
            panelCloudInput = new Panel();
            txtNum = new TextBox();
            txtCloudHeight = new TextBox();
            txtSex = new TextBox();
            lblSex = new Label();
            lblNum = new Label();
            btnSelectPatient = new FontAwesome.Sharp.IconButton();
            lblHuanZhe = new Label();
            txtCloudAge = new TextBox();
            txtCloudWeight = new TextBox();
            lblAge = new Label();
            lblWeight = new Label();
            lblHeight = new Label();
            txtCloudName = new TextBox();
            lblName = new Label();
            panelRealTime = new Panel();
            btnChartSwitchAngle = new FontAwesome.Sharp.IconButton();
            cartesianChartRealTime = new LiveCharts.WinForms.CartesianChart();
            btnShowOutside = new FontAwesome.Sharp.IconButton();
            btnShowInside = new FontAwesome.Sharp.IconButton();
            btnShowSum = new FontAwesome.Sharp.IconButton();
            btnShwoDiff = new FontAwesome.Sharp.IconButton();
            panelContent = new Panel();
            btnCloudEnd = new FontAwesome.Sharp.IconButton();
            panel2 = new Panel();
            lblPressureTwo = new Label();
            panel4 = new Panel();
            lblPressureSum = new Label();
            panel3 = new Panel();
            lblPressureDiff = new Label();
            panelPressureOne = new Panel();
            lblPressureOne = new Label();
            lblDirectionTwo = new Label();
            label5 = new Label();
            label4 = new Label();
            lblDirectionOne = new Label();
            btnCloudLeft = new FontAwesome.Sharp.IconButton();
            btnCloudExit = new FontAwesome.Sharp.IconButton();
            btnCloudRight = new FontAwesome.Sharp.IconButton();
            btnRegister = new FontAwesome.Sharp.IconButton();
            pictureBoxOne = new PictureBox();
            btnCloudStartTest = new FontAwesome.Sharp.IconButton();
            draw2dShowOne = new DrawFunctionLib.DrawFunction2DShow();
            draw3dShowOne = new DrawFunctionLib.DrawFunction3DShow();
            panelRight.SuspendLayout();
            panel6.SuspendLayout();
            panelAngle.SuspendLayout();
            panelCloudInput.SuspendLayout();
            panelRealTime.SuspendLayout();
            panelContent.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panelPressureOne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOne).BeginInit();
            SuspendLayout();
            // 
            // timerRealTime
            // 
            timerRealTime.Interval = 1000;
            timerRealTime.Tick += TimerRealTime_Tick;
            // 
            // panelRight
            // 
            panelRight.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelRight.BackgroundImageLayout = ImageLayout.Stretch;
            panelRight.Controls.Add(panel6);
            panelRight.Controls.Add(panelAngle);
            panelRight.Controls.Add(panelCloudInput);
            panelRight.Location = new Point(1380, 9);
            panelRight.Margin = new Padding(4);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(1029, 1303);
            panelRight.TabIndex = 10;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel6.BackgroundImage = (Image)resources.GetObject("panel6.BackgroundImage");
            panel6.BackgroundImageLayout = ImageLayout.Stretch;
            panel6.Controls.Add(cartesianChartDiff);
            panel6.Location = new Point(7, 805);
            panel6.Margin = new Padding(4);
            panel6.Name = "panel6";
            panel6.Size = new Size(1003, 438);
            panel6.TabIndex = 0;
            // 
            // cartesianChartDiff
            // 
            cartesianChartDiff.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cartesianChartDiff.BackColor = Color.Transparent;
            cartesianChartDiff.ForeColor = Color.White;
            cartesianChartDiff.Location = new Point(37, 41);
            cartesianChartDiff.Margin = new Padding(4);
            cartesianChartDiff.Name = "cartesianChartDiff";
            cartesianChartDiff.Size = new Size(961, 352);
            cartesianChartDiff.TabIndex = 25;
            cartesianChartDiff.Text = "cartesianChart1";
            // 
            // panelAngle
            // 
            panelAngle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelAngle.BackgroundImage = (Image)resources.GetObject("panelAngle.BackgroundImage");
            panelAngle.BackgroundImageLayout = ImageLayout.Stretch;
            panelAngle.Controls.Add(cartesianChartAngle);
            panelAngle.Controls.Add(btn120);
            panelAngle.Controls.Add(btn90);
            panelAngle.Controls.Add(btn60);
            panelAngle.Controls.Add(btn45);
            panelAngle.Controls.Add(btn30);
            panelAngle.Controls.Add(btn0);
            panelAngle.Controls.Add(btnCatch);
            panelAngle.Controls.Add(btnChartSwitchRealTime);
            panelAngle.Location = new Point(7, 388);
            panelAngle.Margin = new Padding(4);
            panelAngle.Name = "panelAngle";
            panelAngle.Size = new Size(1003, 398);
            panelAngle.TabIndex = 2;
            // 
            // cartesianChartAngle
            // 
            cartesianChartAngle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cartesianChartAngle.BackColor = Color.Transparent;
            cartesianChartAngle.ForeColor = Color.White;
            cartesianChartAngle.Location = new Point(20, 69);
            cartesianChartAngle.Margin = new Padding(4);
            cartesianChartAngle.Name = "cartesianChartAngle";
            cartesianChartAngle.Size = new Size(961, 302);
            cartesianChartAngle.TabIndex = 24;
            cartesianChartAngle.Text = "cartesianChart1";
            // 
            // btn120
            // 
            btn120.BackColor = Color.FromArgb(213, 231, 243);
            btn120.FlatAppearance.BorderSize = 0;
            btn120.FlatStyle = FlatStyle.Flat;
            btn120.ForeColor = Color.FromArgb(101, 143, 185);
            btn120.IconChar = FontAwesome.Sharp.IconChar.None;
            btn120.IconColor = Color.Black;
            btn120.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btn120.Location = new Point(611, 16);
            btn120.Margin = new Padding(4);
            btn120.Name = "btn120";
            btn120.Size = new Size(107, 38);
            btn120.TabIndex = 23;
            btn120.Text = "120度";
            btn120.UseVisualStyleBackColor = false;
            btn120.Click += Angle_Click;
            // 
            // btn90
            // 
            btn90.BackColor = Color.FromArgb(213, 231, 243);
            btn90.FlatAppearance.BorderSize = 0;
            btn90.FlatStyle = FlatStyle.Flat;
            btn90.ForeColor = Color.FromArgb(101, 143, 185);
            btn90.IconChar = FontAwesome.Sharp.IconChar.None;
            btn90.IconColor = Color.Black;
            btn90.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btn90.Location = new Point(497, 16);
            btn90.Margin = new Padding(4);
            btn90.Name = "btn90";
            btn90.Size = new Size(107, 38);
            btn90.TabIndex = 22;
            btn90.Text = "90度";
            btn90.UseVisualStyleBackColor = false;
            btn90.Click += Angle_Click;
            // 
            // btn60
            // 
            btn60.BackColor = Color.FromArgb(213, 231, 243);
            btn60.FlatAppearance.BorderSize = 0;
            btn60.FlatStyle = FlatStyle.Flat;
            btn60.ForeColor = Color.FromArgb(101, 143, 185);
            btn60.IconChar = FontAwesome.Sharp.IconChar.None;
            btn60.IconColor = Color.Black;
            btn60.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btn60.Location = new Point(383, 16);
            btn60.Margin = new Padding(4);
            btn60.Name = "btn60";
            btn60.Size = new Size(107, 38);
            btn60.TabIndex = 21;
            btn60.Text = "60度";
            btn60.UseVisualStyleBackColor = false;
            btn60.Click += Angle_Click;
            // 
            // btn45
            // 
            btn45.BackColor = Color.FromArgb(213, 231, 243);
            btn45.FlatAppearance.BorderSize = 0;
            btn45.FlatStyle = FlatStyle.Flat;
            btn45.ForeColor = Color.FromArgb(101, 143, 185);
            btn45.IconChar = FontAwesome.Sharp.IconChar.None;
            btn45.IconColor = Color.Black;
            btn45.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btn45.Location = new Point(269, 16);
            btn45.Margin = new Padding(4);
            btn45.Name = "btn45";
            btn45.Size = new Size(107, 38);
            btn45.TabIndex = 20;
            btn45.Text = "45度";
            btn45.UseVisualStyleBackColor = false;
            btn45.Click += Angle_Click;
            // 
            // btn30
            // 
            btn30.BackColor = Color.FromArgb(213, 231, 243);
            btn30.FlatAppearance.BorderSize = 0;
            btn30.FlatStyle = FlatStyle.Flat;
            btn30.ForeColor = Color.FromArgb(101, 143, 185);
            btn30.IconChar = FontAwesome.Sharp.IconChar.None;
            btn30.IconColor = Color.Black;
            btn30.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btn30.Location = new Point(154, 16);
            btn30.Margin = new Padding(4);
            btn30.Name = "btn30";
            btn30.Size = new Size(107, 38);
            btn30.TabIndex = 19;
            btn30.Text = "30度";
            btn30.UseVisualStyleBackColor = false;
            btn30.Click += Angle_Click;
            // 
            // btn0
            // 
            btn0.BackColor = Color.FromArgb(213, 231, 243);
            btn0.FlatAppearance.BorderSize = 0;
            btn0.FlatStyle = FlatStyle.Flat;
            btn0.ForeColor = Color.FromArgb(101, 143, 185);
            btn0.IconChar = FontAwesome.Sharp.IconChar.None;
            btn0.IconColor = Color.Black;
            btn0.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btn0.Location = new Point(40, 16);
            btn0.Margin = new Padding(4);
            btn0.Name = "btn0";
            btn0.Size = new Size(107, 38);
            btn0.TabIndex = 18;
            btn0.Tag = "0";
            btn0.Text = "0度";
            btn0.UseVisualStyleBackColor = false;
            btn0.Click += Angle_Click;
            // 
            // btnCatch
            // 
            btnCatch.BackColor = Color.FromArgb(116, 89, 255);
            btnCatch.BackgroundImageLayout = ImageLayout.None;
            btnCatch.FlatAppearance.BorderSize = 0;
            btnCatch.FlatStyle = FlatStyle.Flat;
            btnCatch.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCatch.ForeColor = Color.White;
            btnCatch.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            btnCatch.IconColor = Color.White;
            btnCatch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCatch.IconSize = 22;
            btnCatch.ImageAlign = ContentAlignment.MiddleLeft;
            btnCatch.Location = new Point(726, 9);
            btnCatch.Margin = new Padding(4);
            btnCatch.Name = "btnCatch";
            btnCatch.Size = new Size(143, 45);
            btnCatch.TabIndex = 14;
            btnCatch.Text = "     抓取角度";
            btnCatch.UseVisualStyleBackColor = false;
            btnCatch.Click += BtnCatch_Click;
            // 
            // btnChartSwitchRealTime
            // 
            btnChartSwitchRealTime.BackColor = Color.FromArgb(66, 148, 204);
            btnChartSwitchRealTime.FlatAppearance.BorderSize = 0;
            btnChartSwitchRealTime.FlatStyle = FlatStyle.Flat;
            btnChartSwitchRealTime.ForeColor = Color.White;
            btnChartSwitchRealTime.IconChar = FontAwesome.Sharp.IconChar.MoneyBillWave;
            btnChartSwitchRealTime.IconColor = Color.White;
            btnChartSwitchRealTime.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnChartSwitchRealTime.IconSize = 15;
            btnChartSwitchRealTime.ImageAlign = ContentAlignment.MiddleLeft;
            btnChartSwitchRealTime.Location = new Point(754, 16);
            btnChartSwitchRealTime.Margin = new Padding(4);
            btnChartSwitchRealTime.Name = "btnChartSwitchRealTime";
            btnChartSwitchRealTime.Size = new Size(133, 38);
            btnChartSwitchRealTime.TabIndex = 25;
            btnChartSwitchRealTime.Text = "  实时数据";
            btnChartSwitchRealTime.UseVisualStyleBackColor = false;
            btnChartSwitchRealTime.Visible = false;
            btnChartSwitchRealTime.Click += BtnChartSwitchRealTim_Click;
            // 
            // panelCloudInput
            // 
            panelCloudInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCloudInput.BackColor = Color.FromArgb(226, 225, 232);
            panelCloudInput.BackgroundImage = (Image)resources.GetObject("panelCloudInput.BackgroundImage");
            panelCloudInput.BackgroundImageLayout = ImageLayout.Stretch;
            panelCloudInput.Controls.Add(txtNum);
            panelCloudInput.Controls.Add(txtCloudHeight);
            panelCloudInput.Controls.Add(txtSex);
            panelCloudInput.Controls.Add(lblSex);
            panelCloudInput.Controls.Add(lblNum);
            panelCloudInput.Controls.Add(btnSelectPatient);
            panelCloudInput.Controls.Add(lblHuanZhe);
            panelCloudInput.Controls.Add(txtCloudAge);
            panelCloudInput.Controls.Add(txtCloudWeight);
            panelCloudInput.Controls.Add(lblAge);
            panelCloudInput.Controls.Add(lblWeight);
            panelCloudInput.Controls.Add(lblHeight);
            panelCloudInput.Controls.Add(txtCloudName);
            panelCloudInput.Controls.Add(lblName);
            panelCloudInput.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            panelCloudInput.Location = new Point(7, 3);
            panelCloudInput.Margin = new Padding(4);
            panelCloudInput.Name = "panelCloudInput";
            panelCloudInput.Size = new Size(1003, 360);
            panelCloudInput.TabIndex = 1;
            // 
            // txtNum
            // 
            txtNum.BackColor = Color.FromArgb(226, 225, 232);
            txtNum.BorderStyle = BorderStyle.None;
            txtNum.Font = new Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtNum.Location = new Point(160, 80);
            txtNum.Margin = new Padding(0);
            txtNum.MinimumSize = new Size(40, 28);
            txtNum.Name = "txtNum";
            txtNum.Size = new Size(160, 28);
            txtNum.TabIndex = 44;
            // 
            // txtCloudHeight
            // 
            txtCloudHeight.BackColor = Color.FromArgb(226, 225, 232);
            txtCloudHeight.BorderStyle = BorderStyle.None;
            txtCloudHeight.Font = new Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtCloudHeight.Location = new Point(160, 143);
            txtCloudHeight.Margin = new Padding(0);
            txtCloudHeight.MinimumSize = new Size(40, 28);
            txtCloudHeight.Name = "txtCloudHeight";
            txtCloudHeight.Size = new Size(160, 28);
            txtCloudHeight.TabIndex = 43;
            // 
            // txtSex
            // 
            txtSex.BackColor = Color.FromArgb(226, 225, 232);
            txtSex.BorderStyle = BorderStyle.None;
            txtSex.Font = new Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtSex.Location = new Point(441, 143);
            txtSex.Margin = new Padding(0);
            txtSex.MinimumSize = new Size(40, 28);
            txtSex.Name = "txtSex";
            txtSex.Size = new Size(160, 28);
            txtSex.TabIndex = 42;
            // 
            // lblSex
            // 
            lblSex.AutoSize = true;
            lblSex.BackColor = Color.Transparent;
            lblSex.Font = new Font("微软雅黑", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblSex.ForeColor = Color.DarkGray;
            lblSex.ImageAlign = ContentAlignment.MiddleLeft;
            lblSex.Location = new Point(360, 143);
            lblSex.Margin = new Padding(4, 0, 4, 0);
            lblSex.Name = "lblSex";
            lblSex.Size = new Size(54, 20);
            lblSex.TabIndex = 38;
            lblSex.Text = "性别：";
            // 
            // lblNum
            // 
            lblNum.AutoSize = true;
            lblNum.BackColor = Color.Transparent;
            lblNum.Font = new Font("微软雅黑", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblNum.ForeColor = Color.DarkGray;
            lblNum.ImageAlign = ContentAlignment.MiddleLeft;
            lblNum.Location = new Point(57, 88);
            lblNum.Margin = new Padding(4, 0, 4, 0);
            lblNum.Name = "lblNum";
            lblNum.Size = new Size(69, 20);
            lblNum.TabIndex = 37;
            lblNum.Text = "病历号：";
            // 
            // btnSelectPatient
            // 
            btnSelectPatient.BackColor = Color.FromArgb(116, 89, 255);
            btnSelectPatient.BackgroundImageLayout = ImageLayout.None;
            btnSelectPatient.FlatAppearance.BorderSize = 0;
            btnSelectPatient.FlatStyle = FlatStyle.Flat;
            btnSelectPatient.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSelectPatient.ForeColor = Color.White;
            btnSelectPatient.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            btnSelectPatient.IconColor = Color.White;
            btnSelectPatient.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSelectPatient.IconSize = 22;
            btnSelectPatient.ImageAlign = ContentAlignment.MiddleLeft;
            btnSelectPatient.Location = new Point(169, 22);
            btnSelectPatient.Margin = new Padding(4);
            btnSelectPatient.Name = "btnSelectPatient";
            btnSelectPatient.Size = new Size(140, 45);
            btnSelectPatient.TabIndex = 36;
            btnSelectPatient.Text = "  选择患者";
            btnSelectPatient.UseVisualStyleBackColor = false;
            btnSelectPatient.Click += BtnSelectPatient_Click;
            // 
            // lblHuanZhe
            // 
            lblHuanZhe.AutoSize = true;
            lblHuanZhe.BackColor = Color.Transparent;
            lblHuanZhe.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblHuanZhe.ForeColor = Color.DimGray;
            lblHuanZhe.Location = new Point(51, 27);
            lblHuanZhe.Margin = new Padding(4, 0, 4, 0);
            lblHuanZhe.Name = "lblHuanZhe";
            lblHuanZhe.Size = new Size(90, 22);
            lblHuanZhe.TabIndex = 8;
            lblHuanZhe.Text = "患者信息：";
            // 
            // txtCloudAge
            // 
            txtCloudAge.BackColor = Color.FromArgb(226, 225, 232);
            txtCloudAge.BorderStyle = BorderStyle.None;
            txtCloudAge.Font = new Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtCloudAge.Location = new Point(714, 80);
            txtCloudAge.Margin = new Padding(0);
            txtCloudAge.MinimumSize = new Size(40, 28);
            txtCloudAge.Name = "txtCloudAge";
            txtCloudAge.Size = new Size(115, 28);
            txtCloudAge.TabIndex = 7;
            // 
            // txtCloudWeight
            // 
            txtCloudWeight.BackColor = Color.FromArgb(226, 225, 232);
            txtCloudWeight.BorderStyle = BorderStyle.None;
            txtCloudWeight.Font = new Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtCloudWeight.Location = new Point(160, 210);
            txtCloudWeight.Margin = new Padding(0);
            txtCloudWeight.MinimumSize = new Size(40, 28);
            txtCloudWeight.Name = "txtCloudWeight";
            txtCloudWeight.Size = new Size(669, 28);
            txtCloudWeight.TabIndex = 6;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.BackColor = Color.Transparent;
            lblAge.Font = new Font("微软雅黑", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblAge.ForeColor = Color.DarkGray;
            lblAge.ImageAlign = ContentAlignment.MiddleLeft;
            lblAge.Location = new Point(633, 88);
            lblAge.Margin = new Padding(4, 0, 4, 0);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(54, 20);
            lblAge.TabIndex = 4;
            lblAge.Text = "年龄：";
            // 
            // lblWeight
            // 
            lblWeight.AutoSize = true;
            lblWeight.BackColor = Color.Transparent;
            lblWeight.Font = new Font("微软雅黑", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblWeight.ForeColor = Color.DarkGray;
            lblWeight.ImageAlign = ContentAlignment.MiddleLeft;
            lblWeight.Location = new Point(44, 212);
            lblWeight.Margin = new Padding(4, 0, 4, 0);
            lblWeight.Name = "lblWeight";
            lblWeight.Size = new Size(84, 20);
            lblWeight.TabIndex = 3;
            lblWeight.Text = "诊断结果：";
            // 
            // lblHeight
            // 
            lblHeight.AutoSize = true;
            lblHeight.BackColor = Color.Transparent;
            lblHeight.Font = new Font("微软雅黑", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblHeight.ForeColor = Color.DarkGray;
            lblHeight.ImageAlign = ContentAlignment.MiddleLeft;
            lblHeight.Location = new Point(56, 143);
            lblHeight.Margin = new Padding(4, 0, 4, 0);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new Size(69, 20);
            lblHeight.TabIndex = 2;
            lblHeight.Text = "麻醉师：";
            // 
            // txtCloudName
            // 
            txtCloudName.BackColor = Color.FromArgb(226, 225, 232);
            txtCloudName.BorderStyle = BorderStyle.None;
            txtCloudName.Font = new Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtCloudName.Location = new Point(441, 80);
            txtCloudName.Margin = new Padding(0);
            txtCloudName.MinimumSize = new Size(40, 28);
            txtCloudName.Name = "txtCloudName";
            txtCloudName.Size = new Size(160, 28);
            txtCloudName.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("微软雅黑", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblName.ForeColor = Color.DarkGray;
            lblName.ImageAlign = ContentAlignment.MiddleLeft;
            lblName.Location = new Point(360, 89);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(54, 20);
            lblName.TabIndex = 0;
            lblName.Text = "姓名：";
            // 
            // panelRealTime
            // 
            panelRealTime.BackgroundImage = (Image)resources.GetObject("panelRealTime.BackgroundImage");
            panelRealTime.BackgroundImageLayout = ImageLayout.Stretch;
            panelRealTime.Controls.Add(btnChartSwitchAngle);
            panelRealTime.Controls.Add(cartesianChartRealTime);
            panelRealTime.Controls.Add(btnShowOutside);
            panelRealTime.Controls.Add(btnShowInside);
            panelRealTime.Controls.Add(btnShowSum);
            panelRealTime.Controls.Add(btnShwoDiff);
            panelRealTime.Location = new Point(23, 814);
            panelRealTime.Margin = new Padding(4);
            panelRealTime.Name = "panelRealTime";
            panelRealTime.Size = new Size(1349, 438);
            panelRealTime.TabIndex = 9;
            // 
            // btnChartSwitchAngle
            // 
            btnChartSwitchAngle.BackColor = Color.FromArgb(66, 148, 204);
            btnChartSwitchAngle.FlatAppearance.BorderSize = 0;
            btnChartSwitchAngle.FlatStyle = FlatStyle.Flat;
            btnChartSwitchAngle.ForeColor = Color.White;
            btnChartSwitchAngle.IconChar = FontAwesome.Sharp.IconChar.MoneyBillWave;
            btnChartSwitchAngle.IconColor = Color.White;
            btnChartSwitchAngle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnChartSwitchAngle.IconSize = 15;
            btnChartSwitchAngle.ImageAlign = ContentAlignment.MiddleLeft;
            btnChartSwitchAngle.Location = new Point(1174, 16);
            btnChartSwitchAngle.Margin = new Padding(4);
            btnChartSwitchAngle.Name = "btnChartSwitchAngle";
            btnChartSwitchAngle.Size = new Size(133, 38);
            btnChartSwitchAngle.TabIndex = 25;
            btnChartSwitchAngle.Text = "  角度数据";
            btnChartSwitchAngle.UseVisualStyleBackColor = false;
            btnChartSwitchAngle.Visible = false;
            btnChartSwitchAngle.Click += BtnChartSwitchAngle_Click;
            // 
            // cartesianChartRealTime
            // 
            cartesianChartRealTime.BackColor = Color.Transparent;
            cartesianChartRealTime.ForeColor = Color.White;
            cartesianChartRealTime.Location = new Point(40, 92);
            cartesianChartRealTime.Margin = new Padding(4);
            cartesianChartRealTime.Name = "cartesianChartRealTime";
            cartesianChartRealTime.Size = new Size(1267, 326);
            cartesianChartRealTime.TabIndex = 24;
            cartesianChartRealTime.Text = "cartesianChart1";
            // 
            // btnShowOutside
            // 
            btnShowOutside.BackColor = Color.FromArgb(66, 148, 204);
            btnShowOutside.FlatAppearance.BorderSize = 0;
            btnShowOutside.FlatStyle = FlatStyle.Flat;
            btnShowOutside.ForeColor = Color.White;
            btnShowOutside.IconChar = FontAwesome.Sharp.IconChar.None;
            btnShowOutside.IconColor = Color.Black;
            btnShowOutside.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnShowOutside.Location = new Point(674, 32);
            btnShowOutside.Margin = new Padding(4);
            btnShowOutside.Name = "btnShowOutside";
            btnShowOutside.Size = new Size(107, 38);
            btnShowOutside.TabIndex = 21;
            btnShowOutside.Tag = "show";
            btnShowOutside.Text = "外力";
            btnShowOutside.UseVisualStyleBackColor = false;
            btnShowOutside.Visible = false;
            btnShowOutside.Click += BtnShowOutside_Click;
            // 
            // btnShowInside
            // 
            btnShowInside.BackColor = Color.FromArgb(66, 148, 204);
            btnShowInside.FlatAppearance.BorderSize = 0;
            btnShowInside.FlatStyle = FlatStyle.Flat;
            btnShowInside.ForeColor = Color.White;
            btnShowInside.IconChar = FontAwesome.Sharp.IconChar.None;
            btnShowInside.IconColor = Color.Black;
            btnShowInside.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnShowInside.Location = new Point(524, 32);
            btnShowInside.Margin = new Padding(4);
            btnShowInside.Name = "btnShowInside";
            btnShowInside.Size = new Size(107, 38);
            btnShowInside.TabIndex = 20;
            btnShowInside.Tag = "show";
            btnShowInside.Text = "内力";
            btnShowInside.UseVisualStyleBackColor = false;
            btnShowInside.Visible = false;
            btnShowInside.Click += BtnShowInside_Click;
            // 
            // btnShowSum
            // 
            btnShowSum.BackColor = Color.FromArgb(66, 148, 204);
            btnShowSum.FlatAppearance.BorderSize = 0;
            btnShowSum.FlatStyle = FlatStyle.Flat;
            btnShowSum.ForeColor = Color.White;
            btnShowSum.IconChar = FontAwesome.Sharp.IconChar.None;
            btnShowSum.IconColor = Color.Black;
            btnShowSum.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnShowSum.Location = new Point(374, 32);
            btnShowSum.Margin = new Padding(4);
            btnShowSum.Name = "btnShowSum";
            btnShowSum.Size = new Size(107, 38);
            btnShowSum.TabIndex = 19;
            btnShowSum.Tag = "show";
            btnShowSum.Text = "合力";
            btnShowSum.UseVisualStyleBackColor = false;
            btnShowSum.Visible = false;
            btnShowSum.Click += BtnShowSum_Click;
            // 
            // btnShwoDiff
            // 
            btnShwoDiff.BackColor = Color.FromArgb(66, 148, 204);
            btnShwoDiff.FlatAppearance.BorderSize = 0;
            btnShwoDiff.FlatStyle = FlatStyle.Flat;
            btnShwoDiff.ForeColor = Color.White;
            btnShwoDiff.IconChar = FontAwesome.Sharp.IconChar.None;
            btnShwoDiff.IconColor = Color.Black;
            btnShwoDiff.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnShwoDiff.Location = new Point(224, 32);
            btnShwoDiff.Margin = new Padding(4);
            btnShwoDiff.Name = "btnShwoDiff";
            btnShwoDiff.Size = new Size(107, 38);
            btnShwoDiff.TabIndex = 18;
            btnShwoDiff.Tag = "show";
            btnShwoDiff.Text = "力差";
            btnShwoDiff.UseVisualStyleBackColor = false;
            btnShwoDiff.Visible = false;
            btnShwoDiff.Click += BtnShwoDiff_Click;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(226, 225, 232);
            panelContent.BackgroundImage = (Image)resources.GetObject("panelContent.BackgroundImage");
            panelContent.BackgroundImageLayout = ImageLayout.Stretch;
            panelContent.Controls.Add(btnCloudEnd);
            panelContent.Controls.Add(panel2);
            panelContent.Controls.Add(panel4);
            panelContent.Controls.Add(panel3);
            panelContent.Controls.Add(panelPressureOne);
            panelContent.Controls.Add(lblDirectionTwo);
            panelContent.Controls.Add(label5);
            panelContent.Controls.Add(label4);
            panelContent.Controls.Add(lblDirectionOne);
            panelContent.Controls.Add(btnCloudLeft);
            panelContent.Controls.Add(btnCloudExit);
            panelContent.Controls.Add(btnCloudRight);
            panelContent.Controls.Add(btnRegister);
            panelContent.Controls.Add(pictureBoxOne);
            panelContent.Controls.Add(btnCloudStartTest);
            panelContent.Controls.Add(draw2dShowOne);
            panelContent.Controls.Add(draw3dShowOne);
            panelContent.Location = new Point(23, 8);
            panelContent.Margin = new Padding(4);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1349, 796);
            panelContent.TabIndex = 8;
            // 
            // btnCloudEnd
            // 
            btnCloudEnd.Anchor = AnchorStyles.None;
            btnCloudEnd.BackColor = Color.FromArgb(116, 89, 255);
            btnCloudEnd.BackgroundImageLayout = ImageLayout.None;
            btnCloudEnd.FlatAppearance.BorderSize = 0;
            btnCloudEnd.FlatStyle = FlatStyle.Flat;
            btnCloudEnd.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCloudEnd.ForeColor = Color.White;
            btnCloudEnd.IconChar = FontAwesome.Sharp.IconChar.EnvelopeCircleCheck;
            btnCloudEnd.IconColor = Color.White;
            btnCloudEnd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCloudEnd.IconSize = 22;
            btnCloudEnd.ImageAlign = ContentAlignment.MiddleLeft;
            btnCloudEnd.Location = new Point(653, 687);
            btnCloudEnd.Margin = new Padding(4);
            btnCloudEnd.Name = "btnCloudEnd";
            btnCloudEnd.Size = new Size(123, 45);
            btnCloudEnd.TabIndex = 11;
            btnCloudEnd.Tag = "Cloud";
            btnCloudEnd.Text = "    结束测试";
            btnCloudEnd.UseVisualStyleBackColor = false;
            btnCloudEnd.Click += BtnCloudEnd_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.None;
            panel2.Controls.Add(lblPressureTwo);
            panel2.Location = new Point(594, 589);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(127, 46);
            panel2.TabIndex = 18;
            // 
            // lblPressureTwo
            // 
            lblPressureTwo.AutoSize = true;
            lblPressureTwo.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblPressureTwo.ForeColor = Color.Black;
            lblPressureTwo.Location = new Point(43, 0);
            lblPressureTwo.Margin = new Padding(4, 0, 4, 0);
            lblPressureTwo.Name = "lblPressureTwo";
            lblPressureTwo.Size = new Size(45, 22);
            lblPressureTwo.TabIndex = 16;
            lblPressureTwo.Text = "0.00";
            // 
            // panel4
            // 
            panel4.BackColor = Color.Transparent;
            panel4.BackgroundImage = (Image)resources.GetObject("panel4.BackgroundImage");
            panel4.BackgroundImageLayout = ImageLayout.None;
            panel4.Controls.Add(lblPressureSum);
            panel4.Location = new Point(1111, 258);
            panel4.Margin = new Padding(4);
            panel4.Name = "panel4";
            panel4.Size = new Size(196, 46);
            panel4.TabIndex = 17;
            // 
            // lblPressureSum
            // 
            lblPressureSum.AutoSize = true;
            lblPressureSum.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblPressureSum.ForeColor = Color.Black;
            lblPressureSum.Location = new Point(43, 0);
            lblPressureSum.Margin = new Padding(4, 0, 4, 0);
            lblPressureSum.Name = "lblPressureSum";
            lblPressureSum.Size = new Size(45, 22);
            lblPressureSum.TabIndex = 16;
            lblPressureSum.Text = "0.00";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.BackgroundImage = (Image)resources.GetObject("panel3.BackgroundImage");
            panel3.BackgroundImageLayout = ImageLayout.None;
            panel3.Controls.Add(lblPressureDiff);
            panel3.Location = new Point(1111, 161);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new Size(196, 46);
            panel3.TabIndex = 17;
            // 
            // lblPressureDiff
            // 
            lblPressureDiff.AutoSize = true;
            lblPressureDiff.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblPressureDiff.ForeColor = Color.Black;
            lblPressureDiff.Location = new Point(43, 0);
            lblPressureDiff.Margin = new Padding(4, 0, 4, 0);
            lblPressureDiff.Name = "lblPressureDiff";
            lblPressureDiff.Size = new Size(45, 22);
            lblPressureDiff.TabIndex = 16;
            lblPressureDiff.Text = "0.00";
            // 
            // panelPressureOne
            // 
            panelPressureOne.BackColor = Color.Transparent;
            panelPressureOne.BackgroundImage = (Image)resources.GetObject("panelPressureOne.BackgroundImage");
            panelPressureOne.BackgroundImageLayout = ImageLayout.None;
            panelPressureOne.Controls.Add(lblPressureOne);
            panelPressureOne.Location = new Point(434, 589);
            panelPressureOne.Margin = new Padding(4);
            panelPressureOne.Name = "panelPressureOne";
            panelPressureOne.Size = new Size(127, 46);
            panelPressureOne.TabIndex = 17;
            // 
            // lblPressureOne
            // 
            lblPressureOne.AutoSize = true;
            lblPressureOne.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblPressureOne.ForeColor = Color.Black;
            lblPressureOne.Location = new Point(43, 0);
            lblPressureOne.Margin = new Padding(4, 0, 4, 0);
            lblPressureOne.Name = "lblPressureOne";
            lblPressureOne.Size = new Size(45, 22);
            lblPressureOne.TabIndex = 16;
            lblPressureOne.Text = "0.00";
            // 
            // lblDirectionTwo
            // 
            lblDirectionTwo.AutoSize = true;
            lblDirectionTwo.BackColor = Color.Transparent;
            lblDirectionTwo.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblDirectionTwo.ForeColor = Color.Black;
            lblDirectionTwo.Location = new Point(637, 541);
            lblDirectionTwo.Margin = new Padding(4, 0, 4, 0);
            lblDirectionTwo.Name = "lblDirectionTwo";
            lblDirectionTwo.Size = new Size(26, 22);
            lblDirectionTwo.TabIndex = 15;
            lblDirectionTwo.Text = "外";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(1111, 127);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(42, 22);
            label5.TabIndex = 15;
            label5.Text = "力差";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(1111, 225);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(42, 22);
            label4.TabIndex = 15;
            label4.Text = "合力";
            // 
            // lblDirectionOne
            // 
            lblDirectionOne.AutoSize = true;
            lblDirectionOne.BackColor = Color.Transparent;
            lblDirectionOne.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblDirectionOne.ForeColor = Color.Black;
            lblDirectionOne.Location = new Point(477, 541);
            lblDirectionOne.Margin = new Padding(4, 0, 4, 0);
            lblDirectionOne.Name = "lblDirectionOne";
            lblDirectionOne.Size = new Size(26, 22);
            lblDirectionOne.TabIndex = 15;
            lblDirectionOne.Text = "内";
            // 
            // btnCloudLeft
            // 
            btnCloudLeft.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCloudLeft.BackColor = Color.FromArgb(116, 89, 255);
            btnCloudLeft.BackgroundImageLayout = ImageLayout.None;
            btnCloudLeft.FlatAppearance.BorderSize = 0;
            btnCloudLeft.FlatStyle = FlatStyle.Flat;
            btnCloudLeft.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCloudLeft.ForeColor = Color.White;
            btnCloudLeft.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCloudLeft.IconColor = Color.Black;
            btnCloudLeft.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCloudLeft.ImageAlign = ContentAlignment.MiddleLeft;
            btnCloudLeft.ImageIndex = 0;
            btnCloudLeft.Location = new Point(1094, 61);
            btnCloudLeft.Margin = new Padding(4);
            btnCloudLeft.Name = "btnCloudLeft";
            btnCloudLeft.Size = new Size(109, 38);
            btnCloudLeft.TabIndex = 10;
            btnCloudLeft.Tag = "Cloud";
            btnCloudLeft.Text = "左膝";
            btnCloudLeft.UseVisualStyleBackColor = false;
            // 
            // btnCloudExit
            // 
            btnCloudExit.Anchor = AnchorStyles.None;
            btnCloudExit.BackColor = Color.FromArgb(30, 75, 106);
            btnCloudExit.BackgroundImageLayout = ImageLayout.None;
            btnCloudExit.FlatAppearance.BorderSize = 0;
            btnCloudExit.FlatStyle = FlatStyle.Flat;
            btnCloudExit.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCloudExit.ForeColor = Color.White;
            btnCloudExit.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            btnCloudExit.IconColor = Color.White;
            btnCloudExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCloudExit.IconSize = 22;
            btnCloudExit.ImageAlign = ContentAlignment.MiddleLeft;
            btnCloudExit.Location = new Point(1413, 1348);
            btnCloudExit.Margin = new Padding(4);
            btnCloudExit.Name = "btnCloudExit";
            btnCloudExit.Size = new Size(123, 45);
            btnCloudExit.TabIndex = 12;
            btnCloudExit.Text = "关闭";
            btnCloudExit.UseVisualStyleBackColor = false;
            btnCloudExit.Visible = false;
            btnCloudExit.Click += BtnCloudExit_Click;
            // 
            // btnCloudRight
            // 
            btnCloudRight.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCloudRight.BackColor = Color.FromArgb(116, 89, 255);
            btnCloudRight.BackgroundImageLayout = ImageLayout.None;
            btnCloudRight.FlatAppearance.BorderSize = 0;
            btnCloudRight.FlatStyle = FlatStyle.Flat;
            btnCloudRight.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCloudRight.ForeColor = Color.White;
            btnCloudRight.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCloudRight.IconColor = Color.Black;
            btnCloudRight.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCloudRight.ImageAlign = ContentAlignment.MiddleLeft;
            btnCloudRight.ImageIndex = 0;
            btnCloudRight.Location = new Point(1203, 61);
            btnCloudRight.Margin = new Padding(4);
            btnCloudRight.Name = "btnCloudRight";
            btnCloudRight.Size = new Size(104, 38);
            btnCloudRight.TabIndex = 13;
            btnCloudRight.Text = "右膝";
            btnCloudRight.UseVisualStyleBackColor = false;
            // 
            // btnRegister
            // 
            btnRegister.Anchor = AnchorStyles.None;
            btnRegister.BackColor = Color.FromArgb(116, 89, 255);
            btnRegister.BackgroundImageLayout = ImageLayout.None;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegister.ForeColor = Color.White;
            btnRegister.IconChar = FontAwesome.Sharp.IconChar.Person;
            btnRegister.IconColor = Color.White;
            btnRegister.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRegister.IconSize = 22;
            btnRegister.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegister.Location = new Point(359, 687);
            btnRegister.Margin = new Padding(4);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(123, 45);
            btnRegister.TabIndex = 12;
            btnRegister.Tag = "Flat";
            btnRegister.Text = "    激活设备";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += BtnRegister_Click;
            // 
            // pictureBoxOne
            // 
            pictureBoxOne.Anchor = AnchorStyles.None;
            pictureBoxOne.BackColor = Color.White;
            pictureBoxOne.BackgroundImage = (Image)resources.GetObject("pictureBoxOne.BackgroundImage");
            pictureBoxOne.BackgroundImageLayout = ImageLayout.Center;
            pictureBoxOne.Location = new Point(157, 61);
            pictureBoxOne.Margin = new Padding(0);
            pictureBoxOne.Name = "pictureBoxOne";
            pictureBoxOne.Size = new Size(833, 574);
            pictureBoxOne.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxOne.TabIndex = 2;
            pictureBoxOne.TabStop = false;
            pictureBoxOne.Visible = false;
            // 
            // btnCloudStartTest
            // 
            btnCloudStartTest.Anchor = AnchorStyles.None;
            btnCloudStartTest.BackColor = Color.FromArgb(116, 89, 255);
            btnCloudStartTest.BackgroundImageLayout = ImageLayout.None;
            btnCloudStartTest.FlatAppearance.BorderSize = 0;
            btnCloudStartTest.FlatStyle = FlatStyle.Flat;
            btnCloudStartTest.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCloudStartTest.ForeColor = Color.White;
            btnCloudStartTest.IconChar = FontAwesome.Sharp.IconChar.SquareVirus;
            btnCloudStartTest.IconColor = Color.White;
            btnCloudStartTest.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCloudStartTest.IconSize = 22;
            btnCloudStartTest.ImageAlign = ContentAlignment.MiddleLeft;
            btnCloudStartTest.Location = new Point(506, 687);
            btnCloudStartTest.Margin = new Padding(4);
            btnCloudStartTest.Name = "btnCloudStartTest";
            btnCloudStartTest.Size = new Size(123, 45);
            btnCloudStartTest.TabIndex = 8;
            btnCloudStartTest.Tag = "Cloud";
            btnCloudStartTest.Text = "    开始测试";
            btnCloudStartTest.UseVisualStyleBackColor = false;
            btnCloudStartTest.Click += BtnCloudStartTest_Click;
            // 
            // draw2dShowOne
            // 
            draw2dShowOne.BackColor = Color.White;
            draw2dShowOne.EnableUsePoints = false;
            draw2dShowOne.Font = new Font("微软雅黑", 7.5F, FontStyle.Regular, GraphicsUnit.Point);
            draw2dShowOne.IndexDrawFunction = null;
            draw2dShowOne.Location = new Point(1010, 61);
            draw2dShowOne.Margin = new Padding(4, 5, 4, 5);
            draw2dShowOne.MaxDistanceInSearch = 15F;
            draw2dShowOne.Name = "draw2dShowOne";
            draw2dShowOne.Size = new Size(61, 574);
            draw2dShowOne.TabIndex = 0;
            // 
            // draw3dShowOne
            // 
            draw3dShowOne.Anchor = AnchorStyles.None;
            draw3dShowOne.BackColor = Color.White;
            draw3dShowOne.EnableUsePoints = true;
            draw3dShowOne.EnableUseTurn = true;
            draw3dShowOne.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            draw3dShowOne.IndexDrawFunction = null;
            draw3dShowOne.Location = new Point(157, 61);
            draw3dShowOne.Margin = new Padding(4, 5, 4, 5);
            draw3dShowOne.MaxDistanceInSearch = 15F;
            draw3dShowOne.Name = "draw3dShowOne";
            draw3dShowOne.Size = new Size(833, 580);
            draw3dShowOne.TabIndex = 1;
            // 
            // FormCloud
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(226, 225, 232);
            ClientSize = new Size(2431, 1320);
            Controls.Add(panelRight);
            Controls.Add(panelRealTime);
            Controls.Add(panelContent);
            Margin = new Padding(6, 5, 6, 5);
            Name = "FormCloud";
            Text = "云图";
            Load += FormCloud_Load;
            panelRight.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panelAngle.ResumeLayout(false);
            panelCloudInput.ResumeLayout(false);
            panelCloudInput.PerformLayout();
            panelRealTime.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panelPressureOne.ResumeLayout(false);
            panelPressureOne.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOne).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label lblBack;
        private System.Windows.Forms.Timer timerRealTime;
        private Panel panelRight;
        private Panel panel6;
        private LiveCharts.WinForms.CartesianChart cartesianChartDiff;
        private Panel panelAngle;
        private LiveCharts.WinForms.CartesianChart cartesianChartAngle;
        private FontAwesome.Sharp.IconButton btn120;
        private FontAwesome.Sharp.IconButton btn90;
        private FontAwesome.Sharp.IconButton btn60;
        private FontAwesome.Sharp.IconButton btn45;
        private FontAwesome.Sharp.IconButton btn30;
        private FontAwesome.Sharp.IconButton btn0;
        private FontAwesome.Sharp.IconButton btnCatch;
        private FontAwesome.Sharp.IconButton btnChartSwitchRealTime;
        private Panel panelCloudInput;
        private TextBox txtSex;
        private Label lblSex;
        private Label lblNum;
        private FontAwesome.Sharp.IconButton btnSelectPatient;
        private Label lblHuanZhe;
        private TextBox txtCloudAge;
        private TextBox txtCloudWeight;
        private Label lblAge;
        private Label lblWeight;
        private Label lblHeight;
        private TextBox txtCloudName;
        private Label lblName;
        private Panel panelRealTime;
        private FontAwesome.Sharp.IconButton btnChartSwitchAngle;
        private LiveCharts.WinForms.CartesianChart cartesianChartRealTime;
        private FontAwesome.Sharp.IconButton btnShowOutside;
        private FontAwesome.Sharp.IconButton btnShowInside;
        private FontAwesome.Sharp.IconButton btnShowSum;
        private FontAwesome.Sharp.IconButton btnShwoDiff;
        private Panel panelContent;
        private FontAwesome.Sharp.IconButton btnCloudEnd;
        private Panel panel2;
        private Label lblPressureTwo;
        private Panel panel4;
        private Label lblPressureSum;
        private Panel panel3;
        private Label lblPressureDiff;
        private Panel panelPressureOne;
        private Label lblPressureOne;
        private Label lblDirectionTwo;
        private Label label5;
        private Label label4;
        private Label lblDirectionOne;
        private FontAwesome.Sharp.IconButton btnCloudLeft;
        private FontAwesome.Sharp.IconButton btnCloudExit;
        private FontAwesome.Sharp.IconButton btnCloudRight;
        private FontAwesome.Sharp.IconButton btnRegister;
        private PictureBox pictureBoxOne;
        private FontAwesome.Sharp.IconButton btnCloudStartTest;
        private DrawFunctionLib.DrawFunction2DShow draw2dShowOne;
        private DrawFunctionLib.DrawFunction3DShow draw3dShowOne;
        private TextBox txtNum;
        private TextBox txtCloudHeight;
    }
}