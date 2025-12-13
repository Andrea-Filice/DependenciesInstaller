using System.Xml;

namespace Configurator
{
    partial class Options
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.optionsText = new System.Windows.Forms.Label();
            this.selectOnStart = new System.Windows.Forms.CheckBox();
            this.onBuild = new System.Windows.Forms.CheckBox();
            this.eacVersions = new System.Windows.Forms.ComboBox();
            this.versionText = new System.Windows.Forms.Label();
            this.infoOpt1 = new System.Windows.Forms.PictureBox();
            this.infoOpt2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoOpt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoOpt2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(82, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // optionsText
            // 
            this.optionsText.AutoSize = true;
            this.optionsText.Font = new System.Drawing.Font("Clash Display Medium", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsText.Location = new System.Drawing.Point(128, 16);
            this.optionsText.Name = "optionsText";
            this.optionsText.Size = new System.Drawing.Size(125, 32);
            this.optionsText.TabIndex = 1;
            this.optionsText.Text = "Options";
            // 
            // selectOnStart
            // 
            this.selectOnStart.AutoSize = true;
            this.selectOnStart.Font = new System.Drawing.Font("Clash Display Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectOnStart.Location = new System.Drawing.Point(14, 70);
            this.selectOnStart.Name = "selectOnStart";
            this.selectOnStart.Size = new System.Drawing.Size(337, 27);
            this.selectOnStart.TabIndex = 2;
            this.selectOnStart.Text = "Enable \"Select Folder on Start\"";
            this.selectOnStart.UseVisualStyleBackColor = true;
            // 
            // onBuild
            // 
            this.onBuild.AutoSize = true;
            this.onBuild.Font = new System.Drawing.Font("Clash Display Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onBuild.Location = new System.Drawing.Point(14, 114);
            this.onBuild.Name = "onBuild";
            this.onBuild.Size = new System.Drawing.Size(285, 27);
            this.onBuild.TabIndex = 3;
            this.onBuild.Text = "Enable \"Execute on Build\"\r\n";
            this.onBuild.UseVisualStyleBackColor = true;
            // 
            // eacVersions
            // 
            this.eacVersions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eacVersions.Font = new System.Drawing.Font("Clash Display Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eacVersions.FormattingEnabled = true;
            this.eacVersions.Items.AddRange(new object[] {
            "v. Latest (November, da4a22a2247c38)",
            "v. October (2d6b9876e10f1b)"});
            this.eacVersions.Location = new System.Drawing.Point(14, 186);
            this.eacVersions.Name = "eacVersions";
            this.eacVersions.Size = new System.Drawing.Size(347, 23);
            this.eacVersions.TabIndex = 4;
            // 
            // versionText
            // 
            this.versionText.AutoSize = true;
            this.versionText.Font = new System.Drawing.Font("Clash Display Medium", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionText.Location = new System.Drawing.Point(124, 162);
            this.versionText.Name = "versionText";
            this.versionText.Size = new System.Drawing.Size(129, 21);
            this.versionText.TabIndex = 5;
            this.versionText.Text = "EAC Version:";
            // 
            // infoOpt1
            // 
            this.infoOpt1.Image = ((System.Drawing.Image)(resources.GetObject("infoOpt1.Image")));
            this.infoOpt1.Location = new System.Drawing.Point(348, 73);
            this.infoOpt1.Name = "infoOpt1";
            this.infoOpt1.Size = new System.Drawing.Size(18, 17);
            this.infoOpt1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.infoOpt1.TabIndex = 6;
            this.infoOpt1.TabStop = false;
            this.infoOpt1.Click += new System.EventHandler(this.infoOpt1_Click);
            // 
            // infoOpt2
            // 
            this.infoOpt2.Image = ((System.Drawing.Image)(resources.GetObject("infoOpt2.Image")));
            this.infoOpt2.Location = new System.Drawing.Point(297, 119);
            this.infoOpt2.Name = "infoOpt2";
            this.infoOpt2.Size = new System.Drawing.Size(18, 17);
            this.infoOpt2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.infoOpt2.TabIndex = 7;
            this.infoOpt2.TabStop = false;
            this.infoOpt2.Click += new System.EventHandler(this.infoOpt2_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 253);
            this.Controls.Add(this.infoOpt2);
            this.Controls.Add(this.infoOpt1);
            this.Controls.Add(this.versionText);
            this.Controls.Add(this.eacVersions);
            this.Controls.Add(this.onBuild);
            this.Controls.Add(this.selectOnStart);
            this.Controls.Add(this.optionsText);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Options_FormClosed);
            this.Load += new System.EventHandler(this.Options_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoOpt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoOpt2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label optionsText;
        public System.Windows.Forms.CheckBox selectOnStart;
        public System.Windows.Forms.CheckBox onBuild;
        public System.Windows.Forms.ComboBox eacVersions;
        private System.Windows.Forms.Label versionText;
        private System.Windows.Forms.PictureBox infoOpt1;
        private System.Windows.Forms.PictureBox infoOpt2;
    }
}