namespace PressureUpper
{
    partial class FormMainMenu
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 系统生成

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainMenu));
            panelContenedorPrincipal = new Panel();
            panelContentForm = new Panel();
            panelMenu = new Panel();
            btnLevel = new PictureBox();
            lblCurrentStatus = new Label();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            lblStatus = new Label();
            btnAboutUs = new FontAwesome.Sharp.IconButton();
            lblUser = new Label();
            lblTime = new Label();
            btnHelp = new FontAwesome.Sharp.IconButton();
            btnSetting = new FontAwesome.Sharp.IconButton();
            pictureBoxUser = new PictureBox();
            btnMenu = new PictureBox();
            btnCheck = new FontAwesome.Sharp.IconButton();
            btnReport = new FontAwesome.Sharp.IconButton();
            btnRecord = new FontAwesome.Sharp.IconButton();
            btnIndex = new FontAwesome.Sharp.IconButton();
            btnPatient = new FontAwesome.Sharp.IconButton();
            btnCloud = new FontAwesome.Sharp.IconButton();
            PanelTitle = new Panel();
            panelLogo = new Panel();
            lblTigleChildForm = new Label();
            btnMin = new Button();
            btnMax = new Button();
            btnClose = new Button();
            iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            btnNormal = new Button();
            tmDateTime = new System.Windows.Forms.Timer(components);
            panelContenedorPrincipal.SuspendLayout();
            panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnLevel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnMenu).BeginInit();
            PanelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconCurrentChildForm).BeginInit();
            SuspendLayout();
            // 
            // panelContenedorPrincipal
            // 
            panelContenedorPrincipal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelContenedorPrincipal.BackColor = Color.FromArgb(226, 225, 232);
            panelContenedorPrincipal.Controls.Add(panelContentForm);
            panelContenedorPrincipal.Controls.Add(panelMenu);
            panelContenedorPrincipal.Controls.Add(PanelTitle);
            panelContenedorPrincipal.Location = new Point(0, 0);
            panelContenedorPrincipal.Margin = new Padding(6, 5, 6, 5);
            panelContenedorPrincipal.Name = "panelContenedorPrincipal";
            panelContenedorPrincipal.Size = new Size(2560, 1461);
            panelContenedorPrincipal.TabIndex = 0;
            // 
            // panelContentForm
            // 
            panelContentForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelContentForm.BackColor = Color.FromArgb(226, 225, 232);
            panelContentForm.Location = new Point(286, 135);
            panelContentForm.Margin = new Padding(6, 5, 6, 5);
            panelContentForm.Name = "panelContentForm";
            panelContentForm.Size = new Size(2446, 1320);
            panelContentForm.TabIndex = 6;
            // 
            // panelMenu
            // 
            panelMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelMenu.BackColor = Color.FromArgb(116, 89, 255);
            panelMenu.BorderStyle = BorderStyle.FixedSingle;
            panelMenu.Controls.Add(btnLevel);
            panelMenu.Controls.Add(lblCurrentStatus);
            panelMenu.Controls.Add(label2);
            panelMenu.Controls.Add(label1);
            panelMenu.Controls.Add(label3);
            panelMenu.Controls.Add(lblStatus);
            panelMenu.Controls.Add(btnAboutUs);
            panelMenu.Controls.Add(lblUser);
            panelMenu.Controls.Add(lblTime);
            panelMenu.Controls.Add(btnHelp);
            panelMenu.Controls.Add(btnSetting);
            panelMenu.Controls.Add(pictureBoxUser);
            panelMenu.Controls.Add(btnMenu);
            panelMenu.Controls.Add(btnCheck);
            panelMenu.Controls.Add(btnReport);
            panelMenu.Controls.Add(btnRecord);
            panelMenu.Controls.Add(btnIndex);
            panelMenu.Controls.Add(btnPatient);
            panelMenu.Controls.Add(btnCloud);
            panelMenu.Location = new Point(0, 135);
            panelMenu.Margin = new Padding(6, 5, 6, 5);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(285, 1325);
            panelMenu.TabIndex = 2;
            // 
            // btnLevel
            // 
            btnLevel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLevel.Cursor = Cursors.Hand;
            btnLevel.Image = (Image)resources.GetObject("btnLevel.Image");
            btnLevel.Location = new Point(141, 1256);
            btnLevel.Margin = new Padding(6, 5, 6, 5);
            btnLevel.Name = "btnLevel";
            btnLevel.Size = new Size(71, 41);
            btnLevel.SizeMode = PictureBoxSizeMode.CenterImage;
            btnLevel.TabIndex = 17;
            btnLevel.TabStop = false;
            // 
            // lblCurrentStatus
            // 
            lblCurrentStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCurrentStatus.AutoSize = true;
            lblCurrentStatus.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblCurrentStatus.ForeColor = Color.White;
            lblCurrentStatus.Location = new Point(133, 1215);
            lblCurrentStatus.Margin = new Padding(6, 0, 6, 0);
            lblCurrentStatus.Name = "lblCurrentStatus";
            lblCurrentStatus.Size = new Size(56, 18);
            lblCurrentStatus.TabIndex = 4;
            lblCurrentStatus.Text = "已断开";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(139, 155, 170);
            label2.Location = new Point(103, 1109);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(54, 19);
            label2.TabIndex = 6;
            label2.Text = "医生：";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(139, 155, 170);
            label1.Location = new Point(103, 1155);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(54, 19);
            label1.TabIndex = 6;
            label1.Text = "时间：";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(139, 155, 170);
            label3.Location = new Point(24, 1264);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(84, 19);
            label3.TabIndex = 6;
            label3.Text = "电池状态：";
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblStatus.ForeColor = Color.FromArgb(139, 155, 170);
            lblStatus.Location = new Point(24, 1214);
            lblStatus.Margin = new Padding(6, 0, 6, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(84, 19);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "设备状态：";
            // 
            // btnAboutUs
            // 
            btnAboutUs.FlatAppearance.BorderSize = 0;
            btnAboutUs.FlatStyle = FlatStyle.Flat;
            btnAboutUs.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnAboutUs.ForeColor = Color.White;
            btnAboutUs.IconChar = FontAwesome.Sharp.IconChar.AddressBook;
            btnAboutUs.IconColor = Color.White;
            btnAboutUs.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAboutUs.IconSize = 42;
            btnAboutUs.ImageAlign = ContentAlignment.MiddleLeft;
            btnAboutUs.Location = new Point(3, 460);
            btnAboutUs.Margin = new Padding(4);
            btnAboutUs.Name = "btnAboutUs";
            btnAboutUs.Padding = new Padding(14, 0, 29, 0);
            btnAboutUs.Size = new Size(286, 70);
            btnAboutUs.TabIndex = 15;
            btnAboutUs.Text = " 关于我们";
            btnAboutUs.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAboutUs.UseVisualStyleBackColor = true;
            btnAboutUs.Click += BtnAboutUs_Click;
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblUser.ForeColor = Color.White;
            lblUser.Location = new Point(171, 1109);
            lblUser.Margin = new Padding(6, 0, 6, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(54, 19);
            lblUser.TabIndex = 5;
            lblUser.Text = "管理员";
            // 
            // lblTime
            // 
            lblTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblTime.ForeColor = Color.White;
            lblTime.Location = new Point(171, 1155);
            lblTime.Margin = new Padding(6, 0, 6, 0);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(71, 19);
            lblTime.TabIndex = 1;
            lblTime.Text = "21:49:45";
            // 
            // btnHelp
            // 
            btnHelp.FlatAppearance.BorderSize = 0;
            btnHelp.FlatStyle = FlatStyle.Flat;
            btnHelp.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnHelp.ForeColor = Color.White;
            btnHelp.IconChar = FontAwesome.Sharp.IconChar.Hive;
            btnHelp.IconColor = Color.FromArgb(58, 116, 166);
            btnHelp.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnHelp.IconSize = 42;
            btnHelp.ImageAlign = ContentAlignment.MiddleLeft;
            btnHelp.Location = new Point(3, 460);
            btnHelp.Margin = new Padding(4);
            btnHelp.Name = "btnHelp";
            btnHelp.Padding = new Padding(14, 0, 29, 0);
            btnHelp.Size = new Size(286, 70);
            btnHelp.TabIndex = 16;
            btnHelp.Text = " 帮助";
            btnHelp.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Click += BtnHelp_Click;
            // 
            // btnSetting
            // 
            btnSetting.FlatAppearance.BorderSize = 0;
            btnSetting.FlatStyle = FlatStyle.Flat;
            btnSetting.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnSetting.ForeColor = Color.White;
            btnSetting.IconChar = FontAwesome.Sharp.IconChar.Sellcast;
            btnSetting.IconColor = Color.White;
            btnSetting.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSetting.IconSize = 42;
            btnSetting.ImageAlign = ContentAlignment.MiddleLeft;
            btnSetting.Location = new Point(3, 384);
            btnSetting.Margin = new Padding(4);
            btnSetting.Name = "btnSetting";
            btnSetting.Padding = new Padding(14, 0, 29, 0);
            btnSetting.Size = new Size(286, 70);
            btnSetting.TabIndex = 14;
            btnSetting.Text = " 系统设置";
            btnSetting.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSetting.UseVisualStyleBackColor = true;
            btnSetting.Click += BtnSetting_Click;
            // 
            // pictureBoxUser
            // 
            pictureBoxUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBoxUser.BackgroundImage = (Image)resources.GetObject("pictureBoxUser.BackgroundImage");
            pictureBoxUser.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxUser.Location = new Point(6, 1092);
            pictureBoxUser.Margin = new Padding(6, 5, 6, 5);
            pictureBoxUser.Name = "pictureBoxUser";
            pictureBoxUser.Size = new Size(94, 89);
            pictureBoxUser.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxUser.TabIndex = 3;
            pictureBoxUser.TabStop = false;
            // 
            // btnMenu
            // 
            btnMenu.BackgroundImage = (Image)resources.GetObject("btnMenu.BackgroundImage");
            btnMenu.BackgroundImageLayout = ImageLayout.None;
            btnMenu.Cursor = Cursors.Hand;
            btnMenu.Location = new Point(29, 0);
            btnMenu.Margin = new Padding(6, 5, 6, 5);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(50, 42);
            btnMenu.SizeMode = PictureBoxSizeMode.CenterImage;
            btnMenu.TabIndex = 12;
            btnMenu.TabStop = false;
            btnMenu.Click += BtnMenu_Click;
            // 
            // btnCheck
            // 
            btnCheck.FlatAppearance.BorderSize = 0;
            btnCheck.FlatStyle = FlatStyle.Flat;
            btnCheck.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnCheck.ForeColor = Color.White;
            btnCheck.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
            btnCheck.IconColor = Color.FromArgb(58, 116, 166);
            btnCheck.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCheck.IconSize = 42;
            btnCheck.ImageAlign = ContentAlignment.MiddleLeft;
            btnCheck.Location = new Point(3, 460);
            btnCheck.Margin = new Padding(4);
            btnCheck.Name = "btnCheck";
            btnCheck.Padding = new Padding(14, 0, 29, 0);
            btnCheck.Size = new Size(286, 70);
            btnCheck.TabIndex = 10;
            btnCheck.Text = " 统计";
            btnCheck.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCheck.UseVisualStyleBackColor = true;
            btnCheck.Click += BtnCheck_Click;
            // 
            // btnReport
            // 
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnReport.ForeColor = Color.White;
            btnReport.IconChar = FontAwesome.Sharp.IconChar.RoadLock;
            btnReport.IconColor = Color.FromArgb(58, 116, 166);
            btnReport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReport.IconSize = 42;
            btnReport.ImageAlign = ContentAlignment.MiddleLeft;
            btnReport.Location = new Point(3, 384);
            btnReport.Margin = new Padding(4);
            btnReport.Name = "btnReport";
            btnReport.Padding = new Padding(14, 0, 29, 0);
            btnReport.Size = new Size(286, 70);
            btnReport.TabIndex = 8;
            btnReport.Text = " 报告";
            btnReport.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReport.UseVisualStyleBackColor = true;
            btnReport.Click += BtnReport_Click;
            // 
            // btnRecord
            // 
            btnRecord.FlatAppearance.BorderSize = 0;
            btnRecord.FlatStyle = FlatStyle.Flat;
            btnRecord.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnRecord.ForeColor = Color.White;
            btnRecord.IconChar = FontAwesome.Sharp.IconChar.Readme;
            btnRecord.IconColor = Color.White;
            btnRecord.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRecord.IconSize = 42;
            btnRecord.ImageAlign = ContentAlignment.MiddleLeft;
            btnRecord.Location = new Point(3, 308);
            btnRecord.Margin = new Padding(4);
            btnRecord.Name = "btnRecord";
            btnRecord.Padding = new Padding(14, 0, 29, 0);
            btnRecord.Size = new Size(286, 70);
            btnRecord.TabIndex = 6;
            btnRecord.Text = " 手术记录";
            btnRecord.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRecord.UseVisualStyleBackColor = true;
            btnRecord.Click += BtnRecord_Click;
            // 
            // btnIndex
            // 
            btnIndex.FlatAppearance.BorderSize = 0;
            btnIndex.FlatStyle = FlatStyle.Flat;
            btnIndex.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnIndex.ForeColor = Color.White;
            btnIndex.IconChar = FontAwesome.Sharp.IconChar.UsersSlash;
            btnIndex.IconColor = Color.White;
            btnIndex.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnIndex.IconSize = 42;
            btnIndex.ImageAlign = ContentAlignment.MiddleLeft;
            btnIndex.Location = new Point(3, 233);
            btnIndex.Margin = new Padding(4);
            btnIndex.Name = "btnIndex";
            btnIndex.Padding = new Padding(14, 0, 29, 0);
            btnIndex.Size = new Size(286, 70);
            btnIndex.TabIndex = 4;
            btnIndex.Text = " 医生信息";
            btnIndex.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnIndex.UseVisualStyleBackColor = true;
            btnIndex.Click += BtnDoctor_Click;
            // 
            // btnPatient
            // 
            btnPatient.FlatAppearance.BorderSize = 0;
            btnPatient.FlatStyle = FlatStyle.Flat;
            btnPatient.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnPatient.ForeColor = Color.White;
            btnPatient.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            btnPatient.IconColor = Color.White;
            btnPatient.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPatient.IconSize = 42;
            btnPatient.ImageAlign = ContentAlignment.MiddleLeft;
            btnPatient.Location = new Point(3, 157);
            btnPatient.Margin = new Padding(4);
            btnPatient.Name = "btnPatient";
            btnPatient.Padding = new Padding(14, 0, 29, 0);
            btnPatient.Size = new Size(286, 70);
            btnPatient.TabIndex = 2;
            btnPatient.Text = " 患者管理";
            btnPatient.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPatient.UseVisualStyleBackColor = true;
            btnPatient.Click += BtnPatient_Click;
            // 
            // btnCloud
            // 
            btnCloud.FlatAppearance.BorderSize = 0;
            btnCloud.FlatStyle = FlatStyle.Flat;
            btnCloud.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnCloud.ForeColor = Color.White;
            btnCloud.IconChar = FontAwesome.Sharp.IconChar.Skyatlas;
            btnCloud.IconColor = Color.White;
            btnCloud.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCloud.IconSize = 42;
            btnCloud.ImageAlign = ContentAlignment.MiddleLeft;
            btnCloud.Location = new Point(3, 77);
            btnCloud.Margin = new Padding(4);
            btnCloud.Name = "btnCloud";
            btnCloud.Padding = new Padding(14, 0, 29, 0);
            btnCloud.Size = new Size(286, 70);
            btnCloud.TabIndex = 0;
            btnCloud.Text = " 手术图像";
            btnCloud.TextAlign = ContentAlignment.MiddleLeft;
            btnCloud.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCloud.UseVisualStyleBackColor = true;
            btnCloud.Click += BtnCloud_Click;
            // 
            // PanelTitle
            // 
            PanelTitle.BackColor = Color.FromArgb(116, 89, 255);
            PanelTitle.Controls.Add(panelLogo);
            PanelTitle.Controls.Add(lblTigleChildForm);
            PanelTitle.Controls.Add(btnMin);
            PanelTitle.Controls.Add(btnMax);
            PanelTitle.Controls.Add(btnClose);
            PanelTitle.Controls.Add(iconCurrentChildForm);
            PanelTitle.Controls.Add(btnNormal);
            PanelTitle.Dock = DockStyle.Top;
            PanelTitle.Location = new Point(0, 0);
            PanelTitle.Margin = new Padding(6, 5, 6, 5);
            PanelTitle.Name = "PanelTitle";
            PanelTitle.Size = new Size(2560, 1080);
            PanelTitle.TabIndex = 1;
            PanelTitle.MouseDown += PanelTitle_MouseDown;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.Transparent;
            panelLogo.BackgroundImage = (Image)resources.GetObject("panelLogo.BackgroundImage");
            panelLogo.BackgroundImageLayout = ImageLayout.None;
            panelLogo.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            panelLogo.Location = new Point(29, 16);
            panelLogo.Margin = new Padding(4);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(910, 101);
            panelLogo.TabIndex = 147;
            panelLogo.Click += PanelLogo_Click;
            // 
            // lblTigleChildForm
            // 
            lblTigleChildForm.AutoSize = true;
            lblTigleChildForm.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblTigleChildForm.ForeColor = Color.White;
            lblTigleChildForm.Location = new Point(1060, 49);
            lblTigleChildForm.Margin = new Padding(0);
            lblTigleChildForm.Name = "lblTigleChildForm";
            lblTigleChildForm.Size = new Size(39, 19);
            lblTigleChildForm.TabIndex = 6;
            lblTigleChildForm.Text = "首页";
            lblTigleChildForm.Visible = false;
            // 
            // btnMin
            // 
            btnMin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMin.BackgroundImage = (Image)resources.GetObject("btnMin.BackgroundImage");
            btnMin.BackgroundImageLayout = ImageLayout.Stretch;
            btnMin.Cursor = Cursors.Hand;
            btnMin.FlatAppearance.BorderSize = 0;
            btnMin.FlatStyle = FlatStyle.Flat;
            btnMin.Location = new Point(2415, 5);
            btnMin.Margin = new Padding(6, 5, 6, 5);
            btnMin.Name = "btnMin";
            btnMin.Size = new Size(63, 64);
            btnMin.TabIndex = 2;
            btnMin.UseVisualStyleBackColor = true;
            btnMin.Click += BtnMin_Click;
            // 
            // btnMax
            // 
            btnMax.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMax.BackgroundImage = (Image)resources.GetObject("btnMax.BackgroundImage");
            btnMax.BackgroundImageLayout = ImageLayout.Stretch;
            btnMax.Cursor = Cursors.Hand;
            btnMax.FlatAppearance.BorderSize = 0;
            btnMax.FlatStyle = FlatStyle.Flat;
            btnMax.Location = new Point(2587, 49);
            btnMax.Margin = new Padding(6, 5, 6, 5);
            btnMax.Name = "btnMax";
            btnMax.Size = new Size(61, 50);
            btnMax.TabIndex = 1;
            btnMax.UseVisualStyleBackColor = true;
            btnMax.Visible = false;
            btnMax.Click += BtnMax_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackgroundImage = (Image)resources.GetObject("btnClose.BackgroundImage");
            btnClose.BackgroundImageLayout = ImageLayout.Stretch;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(2490, 5);
            btnClose.Margin = new Padding(6, 5, 6, 5);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(64, 64);
            btnClose.TabIndex = 0;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // iconCurrentChildForm
            // 
            iconCurrentChildForm.BackColor = Color.FromArgb(116, 89, 255);
            iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.House;
            iconCurrentChildForm.IconColor = Color.White;
            iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconCurrentChildForm.IconSize = 57;
            iconCurrentChildForm.Location = new Point(980, 35);
            iconCurrentChildForm.Margin = new Padding(4);
            iconCurrentChildForm.Name = "iconCurrentChildForm";
            iconCurrentChildForm.Size = new Size(60, 57);
            iconCurrentChildForm.TabIndex = 0;
            iconCurrentChildForm.TabStop = false;
            iconCurrentChildForm.Visible = false;
            // 
            // btnNormal
            // 
            btnNormal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNormal.BackgroundImage = (Image)resources.GetObject("btnNormal.BackgroundImage");
            btnNormal.BackgroundImageLayout = ImageLayout.Stretch;
            btnNormal.Cursor = Cursors.Hand;
            btnNormal.FlatAppearance.BorderSize = 0;
            btnNormal.FlatStyle = FlatStyle.Flat;
            btnNormal.Location = new Point(2587, 47);
            btnNormal.Margin = new Padding(6, 5, 6, 5);
            btnNormal.Name = "btnNormal";
            btnNormal.Size = new Size(74, 58);
            btnNormal.TabIndex = 3;
            btnNormal.UseVisualStyleBackColor = true;
            btnNormal.Visible = false;
            btnNormal.Click += BtnNormal_Click;
            // 
            // tmDateTime
            // 
            tmDateTime.Enabled = true;
            tmDateTime.Tick += TmDateTime_Tick;
            // 
            // FormMainMenu
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(2560, 1461);
            Controls.Add(panelContenedorPrincipal);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(6, 5, 6, 5);
            Name = "FormMainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "主窗体";
            Load += FormMainMenu_Load;
            panelContenedorPrincipal.ResumeLayout(false);
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnLevel).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMenu).EndInit();
            PanelTitle.ResumeLayout(false);
            PanelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconCurrentChildForm).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContenedorPrincipal;
        private Panel PanelTitle;
        private Button btnNormal;
        private Button btnMin;
        private Button btnMax;
        private Button btnClose;
        private Panel panelContentForm;
        private Label label5;
        private Label label4;
        public Label lblCurrentStatus;
        private PictureBox pictureBoxUser;
        private Label lblTime;
        private Panel panelMenu;
        private PictureBox btnMenu;
        private FontAwesome.Sharp.IconButton btnCheck;
        private FontAwesome.Sharp.IconButton btnReport;
        private FontAwesome.Sharp.IconButton btnRecord;
        private FontAwesome.Sharp.IconButton btnIndex;
        private FontAwesome.Sharp.IconButton btnPatient;
        private FontAwesome.Sharp.IconButton btnCloud;
        private System.Windows.Forms.Timer tmDateTime;
        private FontAwesome.Sharp.IconButton btnHelp;
        private FontAwesome.Sharp.IconButton btnAboutUs;
        private FontAwesome.Sharp.IconButton btnSetting;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private Label lblTigleChildForm;
        private Panel panelLogo;
        private Label lblStatus;
        private Label lblUser;
        private Label label2;
        private Label label1;
        private PictureBox btnLevel;
        private Label label3;
    }
}

