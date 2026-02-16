using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Configurator
{
    partial class Config
    {
        //VARIABLES
        public string selectedPath = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.labelStart = new System.Windows.Forms.Label();
            this.gameFolder = new System.Windows.Forms.Label();
            this.browserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonChangeFolder = new System.Windows.Forms.Button();
            this.folderSelected = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.buildButton = new System.Windows.Forms.Button();
            this.buildLogs = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.executeButton = new System.Windows.Forms.Button();
            this.versionNumber = new System.Windows.Forms.Label();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bugReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suggestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.visitWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconAdd = new System.Windows.Forms.PictureBox();
            this.buildIcon = new System.Windows.Forms.PictureBox();
            this.dependenciesIcon = new System.Windows.Forms.PictureBox();
            this.warningPB = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buildIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dependenciesIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningPB)).BeginInit();
            this.SuspendLayout();
            // 
            // labelStart
            // 
            resources.ApplyResources(this.labelStart, "labelStart");
            this.labelStart.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labelStart.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelStart.Name = "labelStart";
            this.toolTip.SetToolTip(this.labelStart, resources.GetString("labelStart.ToolTip"));
            // 
            // gameFolder
            // 
            resources.ApplyResources(this.gameFolder, "gameFolder");
            this.gameFolder.Name = "gameFolder";
            this.toolTip.SetToolTip(this.gameFolder, resources.GetString("gameFolder.ToolTip"));
            // 
            // browserDialog
            // 
            resources.ApplyResources(this.browserDialog, "browserDialog");
            // 
            // buttonChangeFolder
            // 
            resources.ApplyResources(this.buttonChangeFolder, "buttonChangeFolder");
            this.buttonChangeFolder.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonChangeFolder.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonChangeFolder.Name = "buttonChangeFolder";
            this.toolTip.SetToolTip(this.buttonChangeFolder, resources.GetString("buttonChangeFolder.ToolTip"));
            this.buttonChangeFolder.UseMnemonic = false;
            this.buttonChangeFolder.UseVisualStyleBackColor = false;
            this.buttonChangeFolder.Click += new System.EventHandler(this.buttonChangeFolder_Click);
            // 
            // folderSelected
            // 
            resources.ApplyResources(this.folderSelected, "folderSelected");
            this.folderSelected.Name = "folderSelected";
            this.toolTip.SetToolTip(this.folderSelected, resources.GetString("folderSelected.ToolTip"));
            // 
            // infoLabel
            // 
            resources.ApplyResources(this.infoLabel, "infoLabel");
            this.infoLabel.ForeColor = System.Drawing.Color.Red;
            this.infoLabel.Name = "infoLabel";
            this.toolTip.SetToolTip(this.infoLabel, resources.GetString("infoLabel.ToolTip"));
            // 
            // buildButton
            // 
            resources.ApplyResources(this.buildButton, "buildButton");
            this.buildButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buildButton.CausesValidation = false;
            this.buildButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buildButton.Name = "buildButton";
            this.toolTip.SetToolTip(this.buildButton, resources.GetString("buildButton.ToolTip"));
            this.buildButton.UseMnemonic = false;
            this.buildButton.UseVisualStyleBackColor = false;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // buildLogs
            // 
            resources.ApplyResources(this.buildLogs, "buildLogs");
            this.buildLogs.Cursor = System.Windows.Forms.Cursors.Default;
            this.buildLogs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buildLogs.ForeColor = System.Drawing.Color.DarkCyan;
            this.buildLogs.Name = "buildLogs";
            this.toolTip.SetToolTip(this.buildLogs, resources.GetString("buildLogs.ToolTip"));
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.progressBar.Name = "progressBar";
            this.progressBar.Step = 0;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.toolTip.SetToolTip(this.progressBar, resources.GetString("progressBar.ToolTip"));
            this.progressBar.Value = 20;
            // 
            // executeButton
            // 
            resources.ApplyResources(this.executeButton, "executeButton");
            this.executeButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.executeButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.executeButton.Name = "executeButton";
            this.toolTip.SetToolTip(this.executeButton, resources.GetString("executeButton.ToolTip"));
            this.executeButton.UseMnemonic = false;
            this.executeButton.UseVisualStyleBackColor = false;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // versionNumber
            // 
            resources.ApplyResources(this.versionNumber, "versionNumber");
            this.versionNumber.Name = "versionNumber";
            this.toolTip.SetToolTip(this.versionNumber, resources.GetString("versionNumber.ToolTip"));
            // 
            // menuBar
            // 
            resources.ApplyResources(this.menuBar, "menuBar");
            this.menuBar.BackColor = System.Drawing.Color.Transparent;
            this.menuBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuBar.Name = "menuBar";
            this.toolTip.SetToolTip(this.menuBar, resources.GetString("menuBar.ToolTip"));
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdatesToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            resources.ApplyResources(this.checkForUpdatesToolStripMenuItem, "checkForUpdatesToolStripMenuItem");
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            resources.ApplyResources(this.windowToolStripMenuItem, "windowToolStripMenuItem");
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            // 
            // minimizeToolStripMenuItem
            // 
            resources.ApplyResources(this.minimizeToolStripMenuItem, "minimizeToolStripMenuItem");
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bugReportToolStripMenuItem,
            this.suggestionToolStripMenuItem,
            this.websiteToolStripMenuItem,
            this.aboutToolStripMenuItem2});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            // 
            // bugReportToolStripMenuItem
            // 
            resources.ApplyResources(this.bugReportToolStripMenuItem, "bugReportToolStripMenuItem");
            this.bugReportToolStripMenuItem.Name = "bugReportToolStripMenuItem";
            this.bugReportToolStripMenuItem.Click += new System.EventHandler(this.bugReportToolStripMenuItem_Click);
            // 
            // suggestionToolStripMenuItem
            // 
            resources.ApplyResources(this.suggestionToolStripMenuItem, "suggestionToolStripMenuItem");
            this.suggestionToolStripMenuItem.Name = "suggestionToolStripMenuItem";
            this.suggestionToolStripMenuItem.Click += new System.EventHandler(this.suggestionToolStripMenuItem_Click);
            // 
            // websiteToolStripMenuItem
            // 
            resources.ApplyResources(this.websiteToolStripMenuItem, "websiteToolStripMenuItem");
            this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
            this.websiteToolStripMenuItem.Click += new System.EventHandler(this.websiteToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem2
            // 
            resources.ApplyResources(this.aboutToolStripMenuItem2, "aboutToolStripMenuItem2");
            this.aboutToolStripMenuItem2.Name = "aboutToolStripMenuItem2";
            this.aboutToolStripMenuItem2.Click += new System.EventHandler(this.aboutToolStripMenuItem2_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            resources.ApplyResources(this.aboutToolStripMenuItem1, "aboutToolStripMenuItem1");
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            // 
            // visitWebsiteToolStripMenuItem
            // 
            resources.ApplyResources(this.visitWebsiteToolStripMenuItem, "visitWebsiteToolStripMenuItem");
            this.visitWebsiteToolStripMenuItem.Name = "visitWebsiteToolStripMenuItem";
            // 
            // iconAdd
            // 
            resources.ApplyResources(this.iconAdd, "iconAdd");
            this.iconAdd.Name = "iconAdd";
            this.iconAdd.TabStop = false;
            this.toolTip.SetToolTip(this.iconAdd, resources.GetString("iconAdd.ToolTip"));
            // 
            // buildIcon
            // 
            resources.ApplyResources(this.buildIcon, "buildIcon");
            this.buildIcon.BackColor = System.Drawing.Color.Black;
            this.buildIcon.Name = "buildIcon";
            this.buildIcon.TabStop = false;
            this.toolTip.SetToolTip(this.buildIcon, resources.GetString("buildIcon.ToolTip"));
            // 
            // dependenciesIcon
            // 
            resources.ApplyResources(this.dependenciesIcon, "dependenciesIcon");
            this.dependenciesIcon.Name = "dependenciesIcon";
            this.dependenciesIcon.TabStop = false;
            this.toolTip.SetToolTip(this.dependenciesIcon, resources.GetString("dependenciesIcon.ToolTip"));
            // 
            // warningPB
            // 
            resources.ApplyResources(this.warningPB, "warningPB");
            this.warningPB.Name = "warningPB";
            this.warningPB.TabStop = false;
            this.toolTip.SetToolTip(this.warningPB, resources.GetString("warningPB.ToolTip"));
            // 
            // Config
            // 
            resources.ApplyResources(this, "$this");
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Controls.Add(this.warningPB);
            this.Controls.Add(this.dependenciesIcon);
            this.Controls.Add(this.buildIcon);
            this.Controls.Add(this.iconAdd);
            this.Controls.Add(this.versionNumber);
            this.Controls.Add(this.executeButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buildLogs);
            this.Controls.Add(this.buildButton);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.folderSelected);
            this.Controls.Add(this.buttonChangeFolder);
            this.Controls.Add(this.gameFolder);
            this.Controls.Add(this.labelStart);
            this.Controls.Add(this.menuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuBar;
            this.Name = "Config";
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Config_FormClosing);
            this.Load += new System.EventHandler(this.Config_Load);
            this.Shown += new System.EventHandler(this.Config_Shown);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buildIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dependenciesIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        //Components
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Label gameFolder;
        private System.Windows.Forms.FolderBrowserDialog browserDialog;
        private System.Windows.Forms.Button buttonChangeFolder;
        private System.Windows.Forms.Label folderSelected;

        //Open dialog box for choose the actual folder
        public void OpenFolderBrowser()
        {
            //Adding depscription to dialog
            browserDialog.Description = "Select the Game Folder of your game to continue.";

            //Get if dialog is closed and get the Folder Selected
            if(browserDialog.ShowDialog() == DialogResult.OK)
            {
                selectedPath = browserDialog.SelectedPath;

                //Update the text of gameFolder and add auto-ellipsis
                folderSelected.AutoEllipsis = true;
                folderSelected.AutoSize = false;
                folderSelected.Width = 350;
                folderSelected.Text = selectedPath;

                buildButton.Enabled = true;
                buildButton.BackColor = Color.Black;
                buildIcon.Visible = true;
            }
            else
            {
                buildButton.Enabled = false;
                buildIcon.Visible = false;
                buildButton.BackColor = Color.Gray;
            }
        }


        //Variables
        internal bool buildInProgress = false;

        //Start the build
        private async void StartBuilding() {
            buildIcon.Visible = false;
            buildInProgress = true;
            Console.WriteLine(buildInProgress);
            await Program.BuildApplication(this, selectedPath);
        }

        private void ExecuteProgram() {Program.Execute(selectedPath);}

        internal Label infoLabel;
        internal Label buildLogs;
        internal ProgressBar progressBar;
        internal Button executeButton;
        internal Button buildButton;
        private Label versionNumber;
        private MenuStrip menuBar;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem1;
        private ToolStripMenuItem visitWebsiteToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem bugReportToolStripMenuItem;

        private void Start()
        {
            //NOTE: Called within the InitializeComponents method
            versionNumber.Text = "Dependencies Installer v. " + Application.ProductVersion;

            //NOTE: Read options on start
            using (var f = new Options())
            {
                f.ReadValues();
                if(f.selectOnStart.Checked)
                    OpenFolderBrowser();
            }
        }

        private PictureBox iconAdd;
        internal PictureBox buildIcon;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem windowToolStripMenuItem;
        private ToolStripMenuItem minimizeToolStripMenuItem;
        private ToolStripMenuItem suggestionToolStripMenuItem;
        private PictureBox dependenciesIcon;
        private PictureBox warningPB;
        private ToolTip toolTip;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem websiteToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem2;
    }
}