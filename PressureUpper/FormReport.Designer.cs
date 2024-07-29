namespace PressureUpper
{
    partial class FormReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReport));
            panelReport = new Panel();
            webReport = new WebBrowser();
            panelReport.SuspendLayout();
            SuspendLayout();
            // 
            // panelReport
            // 
            panelReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelReport.BackColor = Color.FromArgb(233, 235, 244);
            panelReport.Controls.Add(webReport);
            panelReport.Location = new Point(12, 12);
            panelReport.Name = "panelReport";
            panelReport.Size = new Size(906, 549);
            panelReport.TabIndex = 1;
            // 
            // webReport
            // 
            webReport.Dock = DockStyle.Fill;
            webReport.Location = new Point(0, 0);
            webReport.MinimumSize = new Size(20, 20);
            webReport.Name = "webReport";
            webReport.Size = new Size(906, 549);
            webReport.TabIndex = 7;
            // 
            // FormReport
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(226, 225, 232);
            ClientSize = new Size(930, 573);
            Controls.Add(panelReport);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormReport";
            Text = "报告";
            Load += FormReport_Load;
            panelReport.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelReport;
        private WebBrowser webReport;
    }
}