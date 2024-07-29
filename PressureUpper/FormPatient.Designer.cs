namespace PressureUpper
{
    partial class FormPatient
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPatient));
            dataView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column11 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column12 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            Column13 = new DataGridViewTextBoxColumn();
            Column14 = new DataGridViewTextBoxColumn();
            Column15 = new DataGridViewTextBoxColumn();
            Column16 = new DataGridViewTextBoxColumn();
            btnClose = new FontAwesome.Sharp.IconButton();
            panelData = new Panel();
            panelDataTool = new Panel();
            panelPageNum = new Panel();
            btnSelect = new FontAwesome.Sharp.IconButton();
            txtPageNum = new TextBox();
            btnJump = new FontAwesome.Sharp.IconButton();
            lblPageCount = new Label();
            lblYe = new Label();
            lblDi = new Label();
            btnFirst = new FontAwesome.Sharp.IconButton();
            btnLast = new FontAwesome.Sharp.IconButton();
            btnPrevious = new FontAwesome.Sharp.IconButton();
            btnNext = new FontAwesome.Sharp.IconButton();
            panelDataOperation = new Panel();
            btnQuery = new FontAwesome.Sharp.IconButton();
            btnEdit = new FontAwesome.Sharp.IconButton();
            btnNew = new FontAwesome.Sharp.IconButton();
            btnRefresh = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dataView).BeginInit();
            panelData.SuspendLayout();
            panelDataTool.SuspendLayout();
            panelPageNum.SuspendLayout();
            panelDataOperation.SuspendLayout();
            SuspendLayout();
            // 
            // dataView
            // 
            dataView.AllowUserToAddRows = false;
            dataView.AllowUserToDeleteRows = false;
            dataView.AllowUserToResizeColumns = false;
            dataView.AllowUserToResizeRows = false;
            dataView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataView.BackgroundColor = Color.White;
            dataView.BorderStyle = BorderStyle.None;
            dataView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(171, 155, 254);
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(171, 155, 254);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataView.ColumnHeadersHeight = 30;
            dataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataView.Columns.AddRange(new DataGridViewColumn[] { ID, Column1, Column7, Column8, Column2, Column3, Column4, Column11, Column9, Column12, Column5, Column6, Column10, Column13, Column14, Column15, Column16 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataView.DefaultCellStyle = dataGridViewCellStyle3;
            dataView.EnableHeadersVisualStyles = false;
            dataView.GridColor = Color.FromArgb(206, 197, 255);
            dataView.Location = new Point(8, 8);
            dataView.Margin = new Padding(4);
            dataView.Name = "dataView";
            dataView.ReadOnly = true;
            dataView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = Color.PaleVioletRed;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataView.RowHeadersVisible = false;
            dataView.RowHeadersWidth = 50;
            dataView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.Padding = new Padding(3);
            dataView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dataView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
            dataView.RowTemplate.Height = 25;
            dataView.RowTemplate.Resizable = DataGridViewTriState.False;
            dataView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataView.Size = new Size(1090, 636);
            dataView.TabIndex = 2;
            dataView.CellDoubleClick += DataGridView_CellContentDoubleClick;
            dataView.CellFormatting += DataView_CellFormatting;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "序号";
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "Name";
            Column1.HeaderText = "姓名";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column7
            // 
            Column7.DataPropertyName = "MedicalRecordNum";
            Column7.HeaderText = "病历号";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            // 
            // Column8
            // 
            Column8.DataPropertyName = "Sex";
            Column8.HeaderText = "性别";
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.DataPropertyName = "Weight";
            Column2.HeaderText = "体重";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.DataPropertyName = "Height";
            Column3.HeaderText = "身高";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.DataPropertyName = "Age";
            Column4.HeaderText = "年龄";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column11
            // 
            Column11.DataPropertyName = "DoctorID";
            Column11.HeaderText = "医生ID";
            Column11.Name = "Column11";
            Column11.ReadOnly = true;
            Column11.Visible = false;
            // 
            // Column9
            // 
            Column9.DataPropertyName = "Doctor";
            dataGridViewCellStyle2.Format = "D";
            dataGridViewCellStyle2.NullValue = null;
            Column9.DefaultCellStyle = dataGridViewCellStyle2;
            Column9.HeaderText = "医生";
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
            // 
            // Column12
            // 
            Column12.DataPropertyName = "AnesthesiologistID";
            Column12.HeaderText = "麻醉医生ID";
            Column12.Name = "Column12";
            Column12.ReadOnly = true;
            Column12.Visible = false;
            // 
            // Column5
            // 
            Column5.DataPropertyName = "Anesthesiologist";
            Column5.HeaderText = "麻醉医生";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column6
            // 
            Column6.DataPropertyName = "EnterTime";
            Column6.HeaderText = "入院时间";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // Column10
            // 
            Column10.DataPropertyName = "Score";
            Column10.HeaderText = "评分";
            Column10.Name = "Column10";
            Column10.ReadOnly = true;
            // 
            // Column13
            // 
            Column13.DataPropertyName = "MedicalHistory";
            Column13.HeaderText = "病史";
            Column13.Name = "Column13";
            Column13.ReadOnly = true;
            Column13.Visible = false;
            // 
            // Column14
            // 
            Column14.DataPropertyName = "DrugAllergy";
            Column14.HeaderText = "药物过敏";
            Column14.Name = "Column14";
            Column14.ReadOnly = true;
            Column14.Visible = false;
            // 
            // Column15
            // 
            Column15.DataPropertyName = "DiagnosticResult";
            Column15.HeaderText = "诊断结果";
            Column15.Name = "Column15";
            Column15.ReadOnly = true;
            Column15.Visible = false;
            // 
            // Column16
            // 
            Column16.DataPropertyName = "OtherInformation";
            Column16.HeaderText = "其他信息";
            Column16.Name = "Column16";
            Column16.ReadOnly = true;
            Column16.Visible = false;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(116, 89, 255);
            btnClose.BackgroundImageLayout = ImageLayout.None;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            btnClose.IconColor = Color.White;
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.IconSize = 20;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(327, 5);
            btnClose.Margin = new Padding(4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(70, 33);
            btnClose.TabIndex = 3;
            btnClose.Text = "  关闭";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // 
            // panelData
            // 
            panelData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelData.BackColor = Color.White;
            panelData.Controls.Add(dataView);
            panelData.Location = new Point(12, 12);
            panelData.Name = "panelData";
            panelData.Size = new Size(1107, 657);
            panelData.TabIndex = 7;
            // 
            // panelDataTool
            // 
            panelDataTool.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelDataTool.BackColor = Color.White;
            panelDataTool.Controls.Add(panelPageNum);
            panelDataTool.Controls.Add(panelDataOperation);
            panelDataTool.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            panelDataTool.Location = new Point(12, 675);
            panelDataTool.Margin = new Padding(0);
            panelDataTool.Name = "panelDataTool";
            panelDataTool.Size = new Size(1108, 41);
            panelDataTool.TabIndex = 8;
            // 
            // panelPageNum
            // 
            panelPageNum.Anchor = AnchorStyles.Right;
            panelPageNum.BackColor = Color.Transparent;
            panelPageNum.Controls.Add(btnSelect);
            panelPageNum.Controls.Add(txtPageNum);
            panelPageNum.Controls.Add(btnJump);
            panelPageNum.Controls.Add(lblPageCount);
            panelPageNum.Controls.Add(lblYe);
            panelPageNum.Controls.Add(lblDi);
            panelPageNum.Controls.Add(btnFirst);
            panelPageNum.Controls.Add(btnLast);
            panelPageNum.Controls.Add(btnPrevious);
            panelPageNum.Controls.Add(btnNext);
            panelPageNum.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            panelPageNum.ForeColor = Color.Black;
            panelPageNum.Location = new Point(421, 0);
            panelPageNum.Name = "panelPageNum";
            panelPageNum.Size = new Size(685, 41);
            panelPageNum.TabIndex = 9;
            // 
            // btnSelect
            // 
            btnSelect.BackColor = Color.FromArgb(116, 89, 255);
            btnSelect.BackgroundImageLayout = ImageLayout.None;
            btnSelect.Cursor = Cursors.Hand;
            btnSelect.FlatAppearance.BorderSize = 0;
            btnSelect.FlatStyle = FlatStyle.Flat;
            btnSelect.ForeColor = Color.White;
            btnSelect.IconChar = FontAwesome.Sharp.IconChar.Check;
            btnSelect.IconColor = Color.White;
            btnSelect.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSelect.IconSize = 20;
            btnSelect.ImageAlign = ContentAlignment.MiddleLeft;
            btnSelect.Location = new Point(5, 5);
            btnSelect.Margin = new Padding(4);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(70, 33);
            btnSelect.TabIndex = 12;
            btnSelect.Text = "  选定";
            btnSelect.UseVisualStyleBackColor = false;
            btnSelect.Visible = false;
            btnSelect.Click += BtnSelect_Click;
            // 
            // txtPageNum
            // 
            txtPageNum.Location = new Point(543, 13);
            txtPageNum.Name = "txtPageNum";
            txtPageNum.Size = new Size(27, 23);
            txtPageNum.TabIndex = 10;
            // 
            // btnJump
            // 
            btnJump.Anchor = AnchorStyles.None;
            btnJump.BackColor = Color.FromArgb(116, 89, 255);
            btnJump.BackgroundImageLayout = ImageLayout.None;
            btnJump.FlatAppearance.BorderSize = 0;
            btnJump.FlatStyle = FlatStyle.Flat;
            btnJump.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnJump.ForeColor = Color.White;
            btnJump.IconChar = FontAwesome.Sharp.IconChar.HandPointRight;
            btnJump.IconColor = Color.White;
            btnJump.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnJump.IconSize = 20;
            btnJump.ImageAlign = ContentAlignment.MiddleLeft;
            btnJump.Location = new Point(608, 5);
            btnJump.Name = "btnJump";
            btnJump.Size = new Size(70, 33);
            btnJump.TabIndex = 9;
            btnJump.Text = "  跳转";
            btnJump.UseVisualStyleBackColor = false;
            btnJump.Click += BtnJump_Click;
            // 
            // lblPageCount
            // 
            lblPageCount.AutoSize = true;
            lblPageCount.BackColor = Color.Transparent;
            lblPageCount.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPageCount.ForeColor = Color.Black;
            lblPageCount.Location = new Point(82, 13);
            lblPageCount.Name = "lblPageCount";
            lblPageCount.Size = new Size(103, 17);
            lblPageCount.TabIndex = 8;
            lblPageCount.Text = "共100条，共10页";
            // 
            // lblYe
            // 
            lblYe.AutoSize = true;
            lblYe.BackColor = Color.Transparent;
            lblYe.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblYe.ForeColor = Color.Black;
            lblYe.Location = new Point(576, 16);
            lblYe.Name = "lblYe";
            lblYe.Size = new Size(20, 17);
            lblYe.TabIndex = 7;
            lblYe.Text = "页";
            // 
            // lblDi
            // 
            lblDi.AutoSize = true;
            lblDi.BackColor = Color.Transparent;
            lblDi.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblDi.ForeColor = Color.Black;
            lblDi.Location = new Point(517, 16);
            lblDi.Name = "lblDi";
            lblDi.Size = new Size(20, 17);
            lblDi.TabIndex = 6;
            lblDi.Text = "第";
            // 
            // btnFirst
            // 
            btnFirst.Anchor = AnchorStyles.None;
            btnFirst.BackColor = Color.FromArgb(116, 89, 255);
            btnFirst.BackgroundImageLayout = ImageLayout.None;
            btnFirst.FlatAppearance.BorderSize = 0;
            btnFirst.FlatStyle = FlatStyle.Flat;
            btnFirst.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnFirst.ForeColor = Color.White;
            btnFirst.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleLeft;
            btnFirst.IconColor = Color.White;
            btnFirst.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFirst.IconSize = 20;
            btnFirst.ImageAlign = ContentAlignment.MiddleLeft;
            btnFirst.Location = new Point(213, 5);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(70, 33);
            btnFirst.TabIndex = 0;
            btnFirst.Text = " 首页";
            btnFirst.UseVisualStyleBackColor = false;
            btnFirst.Click += BtnFirst_Click;
            // 
            // btnLast
            // 
            btnLast.Anchor = AnchorStyles.None;
            btnLast.BackColor = Color.FromArgb(116, 89, 255);
            btnLast.BackgroundImageLayout = ImageLayout.None;
            btnLast.FlatAppearance.BorderSize = 0;
            btnLast.FlatStyle = FlatStyle.Flat;
            btnLast.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnLast.ForeColor = Color.White;
            btnLast.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleRight;
            btnLast.IconColor = Color.White;
            btnLast.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLast.IconSize = 20;
            btnLast.ImageAlign = ContentAlignment.MiddleRight;
            btnLast.Location = new Point(441, 5);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(70, 33);
            btnLast.TabIndex = 3;
            btnLast.Text = "末页  ";
            btnLast.UseVisualStyleBackColor = false;
            btnLast.Click += BtnLast_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Anchor = AnchorStyles.None;
            btnPrevious.BackColor = Color.FromArgb(116, 89, 255);
            btnPrevious.BackgroundImageLayout = ImageLayout.None;
            btnPrevious.FlatAppearance.BorderSize = 0;
            btnPrevious.FlatStyle = FlatStyle.Flat;
            btnPrevious.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnPrevious.ForeColor = Color.White;
            btnPrevious.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            btnPrevious.IconColor = Color.White;
            btnPrevious.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPrevious.IconSize = 20;
            btnPrevious.ImageAlign = ContentAlignment.MiddleLeft;
            btnPrevious.Location = new Point(289, 5);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(70, 33);
            btnPrevious.TabIndex = 1;
            btnPrevious.Text = "  上一页";
            btnPrevious.UseVisualStyleBackColor = false;
            btnPrevious.Click += BtnPrevious_Click;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.None;
            btnNext.BackColor = Color.FromArgb(116, 89, 255);
            btnNext.BackgroundImageLayout = ImageLayout.None;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnNext.ForeColor = Color.White;
            btnNext.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            btnNext.IconColor = Color.White;
            btnNext.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNext.IconSize = 20;
            btnNext.ImageAlign = ContentAlignment.MiddleRight;
            btnNext.Location = new Point(365, 5);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(70, 33);
            btnNext.TabIndex = 2;
            btnNext.Text = "下一页  ";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += BtnNext_Click;
            // 
            // panelDataOperation
            // 
            panelDataOperation.Anchor = AnchorStyles.Left;
            panelDataOperation.BackColor = Color.Transparent;
            panelDataOperation.Controls.Add(btnQuery);
            panelDataOperation.Controls.Add(btnEdit);
            panelDataOperation.Controls.Add(btnNew);
            panelDataOperation.Controls.Add(btnClose);
            panelDataOperation.Controls.Add(btnRefresh);
            panelDataOperation.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            panelDataOperation.Location = new Point(0, 0);
            panelDataOperation.Name = "panelDataOperation";
            panelDataOperation.Size = new Size(415, 41);
            panelDataOperation.TabIndex = 7;
            // 
            // btnQuery
            // 
            btnQuery.BackColor = Color.FromArgb(116, 89, 255);
            btnQuery.BackgroundImageLayout = ImageLayout.None;
            btnQuery.Cursor = Cursors.Hand;
            btnQuery.FlatAppearance.BorderSize = 0;
            btnQuery.FlatStyle = FlatStyle.Flat;
            btnQuery.ForeColor = Color.White;
            btnQuery.IconChar = FontAwesome.Sharp.IconChar.Question;
            btnQuery.IconColor = Color.White;
            btnQuery.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnQuery.IconSize = 20;
            btnQuery.ImageAlign = ContentAlignment.MiddleLeft;
            btnQuery.Location = new Point(253, 5);
            btnQuery.Margin = new Padding(4);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(70, 33);
            btnQuery.TabIndex = 8;
            btnQuery.Text = " 查询";
            btnQuery.UseVisualStyleBackColor = false;
            btnQuery.Click += BtnQuery_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.None;
            btnEdit.BackColor = Color.FromArgb(116, 89, 255);
            btnEdit.BackgroundImageLayout = ImageLayout.None;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnEdit.ForeColor = Color.White;
            btnEdit.IconChar = FontAwesome.Sharp.IconChar.SoccerBall;
            btnEdit.IconColor = Color.White;
            btnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEdit.IconSize = 20;
            btnEdit.ImageAlign = ContentAlignment.MiddleLeft;
            btnEdit.Location = new Point(177, 5);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(72, 33);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "  编辑";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnNew
            // 
            btnNew.Anchor = AnchorStyles.None;
            btnNew.BackColor = Color.FromArgb(116, 89, 255);
            btnNew.BackgroundImageLayout = ImageLayout.None;
            btnNew.FlatAppearance.BorderSize = 0;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnNew.ForeColor = Color.White;
            btnNew.IconChar = FontAwesome.Sharp.IconChar.Film;
            btnNew.IconColor = Color.White;
            btnNew.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNew.IconSize = 20;
            btnNew.ImageAlign = ContentAlignment.MiddleLeft;
            btnNew.Location = new Point(90, 5);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(83, 33);
            btnNew.TabIndex = 6;
            btnNew.Text = "新建";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += BtnNew_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.None;
            btnRefresh.BackColor = Color.FromArgb(116, 89, 255);
            btnRefresh.BackgroundImageLayout = ImageLayout.None;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.IconChar = FontAwesome.Sharp.IconChar.ReplyAll;
            btnRefresh.IconColor = Color.White;
            btnRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRefresh.IconSize = 20;
            btnRefresh.ImageAlign = ContentAlignment.MiddleLeft;
            btnRefresh.Location = new Point(8, 5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(78, 33);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "刷新";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // FormPatient
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(226, 225, 232);
            ClientSize = new Size(1131, 725);
            Controls.Add(panelDataTool);
            Controls.Add(panelData);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "FormPatient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "患者";
            Load += FormPatient_Load;
            ((System.ComponentModel.ISupportInitialize)dataView).EndInit();
            panelData.ResumeLayout(false);
            panelDataTool.ResumeLayout(false);
            panelPageNum.ResumeLayout(false);
            panelPageNum.PerformLayout();
            panelDataOperation.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.DataGridView dataView;
        private FontAwesome.Sharp.IconButton btnClose;
        private Panel panelData;
        private Panel panelDataTool;
        private Panel panelPageNum;
        private FontAwesome.Sharp.IconButton btnJump;
        private Label lblPageCount;
        private Label lblYe;
        private Label lblDi;
        private FontAwesome.Sharp.IconButton btnFirst;
        private FontAwesome.Sharp.IconButton btnLast;
        private FontAwesome.Sharp.IconButton btnPrevious;
        private FontAwesome.Sharp.IconButton btnNext;
        private Panel panelDataOperation;
        private FontAwesome.Sharp.IconButton btnEdit;
        private FontAwesome.Sharp.IconButton btnNew;
        private FontAwesome.Sharp.IconButton btnRefresh;
        private TextBox txtPageNum;
        private FontAwesome.Sharp.IconButton btnQuery;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column12;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column13;
        private DataGridViewTextBoxColumn Column14;
        private DataGridViewTextBoxColumn Column15;
        private DataGridViewTextBoxColumn Column16;
        private FontAwesome.Sharp.IconButton btnSelect;
    }
}