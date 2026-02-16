using System.Xml;

namespace Configurator
{
    partial class Options
    {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.optionsText = new System.Windows.Forms.Label();
            this.selectOnStart = new System.Windows.Forms.CheckBox();
            this.onBuild = new System.Windows.Forms.CheckBox();
            this.eacVersions = new System.Windows.Forms.ComboBox();
            this.versionText = new System.Windows.Forms.Label();
            this.toolTipOptions = new System.Windows.Forms.ToolTip(this.components);
            this.versionIcon = new System.Windows.Forms.PictureBox();
            this.infoOpt2 = new System.Windows.Forms.PictureBox();
            this.infoOpt1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.versionIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoOpt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoOpt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // optionsText
            // 
            resources.ApplyResources(this.optionsText, "optionsText");
            this.optionsText.Name = "optionsText";
            this.toolTipOptions.SetToolTip(this.optionsText, resources.GetString("optionsText.ToolTip"));
            // 
            // selectOnStart
            // 
            resources.ApplyResources(this.selectOnStart, "selectOnStart");
            this.selectOnStart.Name = "selectOnStart";
            this.toolTipOptions.SetToolTip(this.selectOnStart, resources.GetString("selectOnStart.ToolTip"));
            this.selectOnStart.UseVisualStyleBackColor = true;
            // 
            // onBuild
            // 
            resources.ApplyResources(this.onBuild, "onBuild");
            this.onBuild.Name = "onBuild";
            this.toolTipOptions.SetToolTip(this.onBuild, resources.GetString("onBuild.ToolTip"));
            this.onBuild.UseVisualStyleBackColor = true;
            // 
            // eacVersions
            // 
            resources.ApplyResources(this.eacVersions, "eacVersions");
            this.eacVersions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eacVersions.FormattingEnabled = true;
            this.eacVersions.Items.AddRange(new object[] {
            resources.GetString("eacVersions.Items"),
            resources.GetString("eacVersions.Items1")});
            this.eacVersions.Name = "eacVersions";
            this.toolTipOptions.SetToolTip(this.eacVersions, resources.GetString("eacVersions.ToolTip"));
            // 
            // versionText
            // 
            resources.ApplyResources(this.versionText, "versionText");
            this.versionText.Name = "versionText";
            this.toolTipOptions.SetToolTip(this.versionText, resources.GetString("versionText.ToolTip"));
            // 
            // versionIcon
            // 
            resources.ApplyResources(this.versionIcon, "versionIcon");
            this.versionIcon.Name = "versionIcon";
            this.versionIcon.TabStop = false;
            this.toolTipOptions.SetToolTip(this.versionIcon, resources.GetString("versionIcon.ToolTip"));
            // 
            // infoOpt2
            // 
            resources.ApplyResources(this.infoOpt2, "infoOpt2");
            this.infoOpt2.Name = "infoOpt2";
            this.infoOpt2.TabStop = false;
            this.toolTipOptions.SetToolTip(this.infoOpt2, resources.GetString("infoOpt2.ToolTip"));
            this.infoOpt2.Click += new System.EventHandler(this.infoOpt2_Click);
            // 
            // infoOpt1
            // 
            resources.ApplyResources(this.infoOpt1, "infoOpt1");
            this.infoOpt1.Name = "infoOpt1";
            this.infoOpt1.TabStop = false;
            this.toolTipOptions.SetToolTip(this.infoOpt1, resources.GetString("infoOpt1.ToolTip"));
            this.infoOpt1.Click += new System.EventHandler(this.infoOpt1_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.toolTipOptions.SetToolTip(this.pictureBox1, resources.GetString("pictureBox1.ToolTip"));
            // 
            // Options
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.versionIcon);
            this.Controls.Add(this.infoOpt2);
            this.Controls.Add(this.infoOpt1);
            this.Controls.Add(this.versionText);
            this.Controls.Add(this.eacVersions);
            this.Controls.Add(this.onBuild);
            this.Controls.Add(this.selectOnStart);
            this.Controls.Add(this.optionsText);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Options";
            this.toolTipOptions.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Options_FormClosed);
            this.Load += new System.EventHandler(this.Options_Load);
            ((System.ComponentModel.ISupportInitialize)(this.versionIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoOpt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoOpt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.PictureBox versionIcon;
        private System.Windows.Forms.ToolTip toolTipOptions;
        private System.ComponentModel.IContainer components;
    }
}