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
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.visitWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bugReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suggestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.labelStart.AutoSize = true;
            this.labelStart.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labelStart.Font = new System.Drawing.Font("Clash Display Medium", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStart.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelStart.Location = new System.Drawing.Point(189, 47);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(454, 38);
            this.labelStart.TabIndex = 0;
            this.labelStart.Text = "Configure Easy-AntiCheat";
            // 
            // gameFolder
            // 
            this.gameFolder.AutoSize = true;
            this.gameFolder.Font = new System.Drawing.Font("Clash Display Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameFolder.Location = new System.Drawing.Point(76, 98);
            this.gameFolder.Name = "gameFolder";
            this.gameFolder.Size = new System.Drawing.Size(172, 26);
            this.gameFolder.TabIndex = 1;
            this.gameFolder.Text = "Game Folder: ";
            // 
            // buttonChangeFolder
            // 
            this.buttonChangeFolder.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonChangeFolder.Font = new System.Drawing.Font("Clash Display Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChangeFolder.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonChangeFolder.Location = new System.Drawing.Point(631, 98);
            this.buttonChangeFolder.Name = "buttonChangeFolder";
            this.buttonChangeFolder.Size = new System.Drawing.Size(146, 31);
            this.buttonChangeFolder.TabIndex = 2;
            this.buttonChangeFolder.Text = "Change";
            this.toolTip.SetToolTip(this.buttonChangeFolder, "Change build Folder");
            this.buttonChangeFolder.UseMnemonic = false;
            this.buttonChangeFolder.UseVisualStyleBackColor = false;
            this.buttonChangeFolder.Click += new System.EventHandler(this.buttonChangeFolder_Click);
            // 
            // folderSelected
            // 
            this.folderSelected.AutoSize = true;
            this.folderSelected.Font = new System.Drawing.Font("Clash Display Medium", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderSelected.Location = new System.Drawing.Point(254, 98);
            this.folderSelected.Name = "folderSelected";
            this.folderSelected.Size = new System.Drawing.Size(223, 26);
            this.folderSelected.TabIndex = 3;
            this.folderSelected.Text = "No folder selected";
            // 
            // infoLabel
            // 
            this.infoLabel.Font = new System.Drawing.Font("Clash Display Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel.ForeColor = System.Drawing.Color.Red;
            this.infoLabel.Location = new System.Drawing.Point(38, 371);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(726, 42);
            this.infoLabel.TabIndex = 4;
            this.infoLabel.Text = "Check the supported versions of Easy Anti-Cheat by going to “File” > “Options” an" +
    "d select one (RECOMMENDED: The latest version is already selected by default).";
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buildButton
            // 
            this.buildButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buildButton.CausesValidation = false;
            this.buildButton.Enabled = false;
            this.buildButton.Font = new System.Drawing.Font("Clash Display Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buildButton.Location = new System.Drawing.Point(207, 320);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(374, 48);
            this.buildButton.TabIndex = 5;
            this.buildButton.Text = "Build";
            this.toolTip.SetToolTip(this.buildButton, "Build");
            this.buildButton.UseMnemonic = false;
            this.buildButton.UseVisualStyleBackColor = false;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // buildLogs
            // 
            this.buildLogs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buildLogs.Cursor = System.Windows.Forms.Cursors.Default;
            this.buildLogs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buildLogs.Font = new System.Drawing.Font("Clash Display Medium", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildLogs.ForeColor = System.Drawing.Color.DarkCyan;
            this.buildLogs.Location = new System.Drawing.Point(-1, 284);
            this.buildLogs.Name = "buildLogs";
            this.buildLogs.Size = new System.Drawing.Size(802, 17);
            this.buildLogs.TabIndex = 6;
            this.buildLogs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buildLogs.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.progressBar.Location = new System.Drawing.Point(274, 302);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(238, 12);
            this.progressBar.Step = 0;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 7;
            this.toolTip.SetToolTip(this.progressBar, "Build Progress");
            this.progressBar.Value = 20;
            this.progressBar.Visible = false;
            // 
            // executeButton
            // 
            this.executeButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.executeButton.Font = new System.Drawing.Font("Clash Display Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.executeButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.executeButton.Location = new System.Drawing.Point(317, 246);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(149, 35);
            this.executeButton.TabIndex = 8;
            this.executeButton.Text = "Execute";
            this.toolTip.SetToolTip(this.executeButton, "Run the built program");
            this.executeButton.UseMnemonic = false;
            this.executeButton.UseVisualStyleBackColor = false;
            this.executeButton.Visible = false;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // versionNumber
            // 
            this.versionNumber.AutoSize = true;
            this.versionNumber.Font = new System.Drawing.Font("Clash Display Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionNumber.Location = new System.Drawing.Point(244, 422);
            this.versionNumber.Name = "versionNumber";
            this.versionNumber.Size = new System.Drawing.Size(0, 19);
            this.versionNumber.TabIndex = 9;
            this.versionNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuBar
            // 
            this.menuBar.BackColor = System.Drawing.Color.Transparent;
            this.menuBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.windowToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(800, 28);
            this.menuBar.TabIndex = 10;
            this.menuBar.Text = "menu";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(46, 24);
            this.toolStripMenuItem1.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.exitToolStripMenuItem.Text = "Check for Updates";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.checkForUpdatesToolStripMenuItem.Text = "Exit";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.minimizeToolStripMenuItem.Text = "Minimize";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1,
            this.visitWebsiteToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.aboutToolStripMenuItem.Text = "Info";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(175, 26);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // visitWebsiteToolStripMenuItem
            // 
            this.visitWebsiteToolStripMenuItem.Name = "visitWebsiteToolStripMenuItem";
            this.visitWebsiteToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.visitWebsiteToolStripMenuItem.Text = "Visit website";
            this.visitWebsiteToolStripMenuItem.Click += new System.EventHandler(this.visitWebsiteToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bugReportToolStripMenuItem,
            this.suggestionToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // bugReportToolStripMenuItem
            // 
            this.bugReportToolStripMenuItem.Name = "bugReportToolStripMenuItem";
            this.bugReportToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.bugReportToolStripMenuItem.Text = "Bug Report";
            this.bugReportToolStripMenuItem.Click += new System.EventHandler(this.bugReportToolStripMenuItem_Click);
            // 
            // suggestionToolStripMenuItem
            // 
            this.suggestionToolStripMenuItem.Name = "suggestionToolStripMenuItem";
            this.suggestionToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.suggestionToolStripMenuItem.Text = "Share a Suggestion";
            this.suggestionToolStripMenuItem.Click += new System.EventHandler(this.suggestionToolStripMenuItem_Click);
            // 
            // iconAdd
            // 
            this.iconAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconAdd.Image = ((System.Drawing.Image)(resources.GetObject("iconAdd.Image")));
            this.iconAdd.InitialImage = ((System.Drawing.Image)(resources.GetObject("iconAdd.InitialImage")));
            this.iconAdd.Location = new System.Drawing.Point(42, 97);
            this.iconAdd.Name = "iconAdd";
            this.iconAdd.Size = new System.Drawing.Size(28, 27);
            this.iconAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconAdd.TabIndex = 11;
            this.iconAdd.TabStop = false;
            // 
            // buildIcon
            // 
            this.buildIcon.BackColor = System.Drawing.Color.Black;
            this.buildIcon.Image = ((System.Drawing.Image)(resources.GetObject("buildIcon.Image")));
            this.buildIcon.InitialImage = ((System.Drawing.Image)(resources.GetObject("buildIcon.InitialImage")));
            this.buildIcon.Location = new System.Drawing.Point(331, 329);
            this.buildIcon.Name = "buildIcon";
            this.buildIcon.Size = new System.Drawing.Size(28, 30);
            this.buildIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buildIcon.TabIndex = 12;
            this.buildIcon.TabStop = false;
            this.buildIcon.Visible = false;
            // 
            // dependenciesIcon
            // 
            this.dependenciesIcon.Image = ((System.Drawing.Image)(resources.GetObject("dependenciesIcon.Image")));
            this.dependenciesIcon.Location = new System.Drawing.Point(136, 47);
            this.dependenciesIcon.Name = "dependenciesIcon";
            this.dependenciesIcon.Size = new System.Drawing.Size(47, 42);
            this.dependenciesIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dependenciesIcon.TabIndex = 13;
            this.dependenciesIcon.TabStop = false;
            // 
            // warningPB
            // 
            this.warningPB.Image = ((System.Drawing.Image)(resources.GetObject("warningPB.Image")));
            this.warningPB.Location = new System.Drawing.Point(16, 380);
            this.warningPB.Name = "warningPB";
            this.warningPB.Size = new System.Drawing.Size(28, 27);
            this.warningPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.warningPB.TabIndex = 14;
            this.warningPB.TabStop = false;
            // 
            // Config
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar;
            this.Name = "Config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurator";
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
            await Program.BuildApplication(selectedPath, buildLogs, progressBar, buildButton, executeButton, buildIcon);
        }

        private void ExecuteProgram() {Program.Execute(selectedPath);}

        private Label infoLabel;
        private Label buildLogs;
        private ProgressBar progressBar;
        private Button executeButton;
        internal Button buildButton;
        private Label versionNumber;
        private MenuStrip menuBar;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem1;
        private ToolStripMenuItem visitWebsiteToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem bugReportToolStripMenuItem;

        private void Start() //NOTE: Called within the InitializeComponents method
        {
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
        private PictureBox buildIcon;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem windowToolStripMenuItem;
        private ToolStripMenuItem minimizeToolStripMenuItem;
        private ToolStripMenuItem suggestionToolStripMenuItem;
        private PictureBox dependenciesIcon;
        private PictureBox warningPB;
        private ToolTip toolTip;
        private System.ComponentModel.IContainer components;
    }
}