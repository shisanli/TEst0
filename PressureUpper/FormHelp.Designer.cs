namespace PressureUpper
{
    partial class FormHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHelp));
            panelHelp = new Panel();
            webHelp = new WebBrowser();
            panelHelp.SuspendLayout();
            SuspendLayout();
            // 
            // panelHelp
            // 
            panelHelp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelHelp.BackColor = Color.FromArgb(233, 235, 244);
            panelHelp.Controls.Add(webHelp);
            panelHelp.Location = new Point(12, 12);
            panelHelp.Name = "panelHelp";
            panelHelp.Size = new Size(906, 549);
            panelHelp.TabIndex = 1;
            // 
            // webHelp
            // 
            webHelp.Dock = DockStyle.Fill;
            webHelp.Location = new Point(0, 0);
            webHelp.MinimumSize = new Size(20, 20);
            webHelp.Name = "webHelp";
            webHelp.Size = new Size(906, 549);
            webHelp.TabIndex = 7;
            // 
            // FormHelp
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(226, 225, 232);
            ClientSize = new Size(930, 573);
            Controls.Add(panelHelp);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormHelp";
            Text = "帮助";
            Load += FormHelp_Load;
            panelHelp.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHelp;
        private WebBrowser webHelp;
    }
}