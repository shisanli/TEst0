namespace PressureUpper
{
    partial class FormAboutUs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAboutUs));
            panelAbout = new Panel();
            webAbout = new WebBrowser();
            panelAbout.SuspendLayout();
            SuspendLayout();
            // 
            // panelAbout
            // 
            panelAbout.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelAbout.BackColor = Color.FromArgb(238, 235, 252);
            panelAbout.Controls.Add(webAbout);
            panelAbout.Location = new Point(12, 12);
            panelAbout.Name = "panelAbout";
            panelAbout.Size = new Size(906, 549);
            panelAbout.TabIndex = 0;
            // 
            // webAbout
            // 
            webAbout.Dock = DockStyle.Fill;
            webAbout.Location = new Point(0, 0);
            webAbout.MinimumSize = new Size(20, 20);
            webAbout.Name = "webAbout";
            webAbout.Size = new Size(906, 549);
            webAbout.TabIndex = 7;
            // 
            // FormAboutUs
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(226, 225, 232);
            ClientSize = new Size(930, 573);
            Controls.Add(panelAbout);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormAboutUs";
            Text = "关于我们";
            Load += FormAboutUs_Load;
            panelAbout.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelAbout;
        private System.Windows.Forms.WebBrowser webAbout;
    }
}