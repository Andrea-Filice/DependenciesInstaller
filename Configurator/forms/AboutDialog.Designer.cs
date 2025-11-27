namespace Configurator.forms
{
    partial class AboutDialog
    {
        private readonly System.ComponentModel.IContainer components = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
            this.appIcon = new System.Windows.Forms.PictureBox();
            this.appName = new System.Windows.Forms.Label();
            this.appVersion = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.appIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // appIcon
            // 
            this.appIcon.Image = global::Configurator.Properties.Resources.icon;
            this.appIcon.InitialImage = global::Configurator.Properties.Resources.icon;
            this.appIcon.Location = new System.Drawing.Point(26, 53);
            this.appIcon.Name = "appIcon";
            this.appIcon.Size = new System.Drawing.Size(53, 55);
            this.appIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.appIcon.TabIndex = 0;
            this.appIcon.TabStop = false;
            // 
            // appName
            // 
            this.appName.AutoSize = true;
            this.appName.Font = new System.Drawing.Font("Manrope", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appName.Location = new System.Drawing.Point(85, 53);
            this.appName.Name = "appName";
            this.appName.Size = new System.Drawing.Size(228, 27);
            this.appName.TabIndex = 1;
            this.appName.Text = "Dependencies Installer";
            // 
            // appVersion
            // 
            this.appVersion.AutoSize = true;
            this.appVersion.Font = new System.Drawing.Font("Manrope", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appVersion.Location = new System.Drawing.Point(85, 76);
            this.appVersion.Name = "appVersion";
            this.appVersion.Size = new System.Drawing.Size(159, 23);
            this.appVersion.TabIndex = 2;
            this.appVersion.Text = "2.1.0.0 (26112025A)";
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("Manrope", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Location = new System.Drawing.Point(391, 136);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(65, 30);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // AboutDialog
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuPopup;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 178);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.appVersion);
            this.Controls.Add(this.appName);
            this.Controls.Add(this.appIcon);
            this.Font = new System.Drawing.Font("Clash Display Medium", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "AboutDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dependencies Installer";
            ((System.ComponentModel.ISupportInitialize)(this.appIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox appIcon;
        private System.Windows.Forms.Label appName;
        private System.Windows.Forms.Label appVersion;
        private System.Windows.Forms.Button buttonOK;
    }
}