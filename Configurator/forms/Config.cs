using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using Configurator.forms;
using Newtonsoft.Json.Linq;

namespace Configurator
{
    public partial class Config : Form
    {
        public Config() {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }

        private void Config_Load(object sender, EventArgs e) {Console.WriteLine($"{DateTime.Now}: App loaded and ready.");}
        private void Config_Shown(object sender, EventArgs e) {Start();}
        private void buttonChangeFolder_Click(object sender, EventArgs e) {OpenFolderBrowser();}
        private void buildButton_Click(object sender, EventArgs e) {StartBuilding();}
        private void executeButton_Click(object sender, EventArgs e) {ExecuteProgram();}
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {using (var f = new Options()) {f.ShowDialog();}}

        //NOTE: CONTEXT MENU ACTIONS
        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e) {Application.Exit();}
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e) { using (var f = new AboutDialog()) {f.ShowDialog();}}
        private void visitWebsiteToolStripMenuItem_Click(object sender, EventArgs e) {Process.Start("https://play-epik-incorporation.netlify.app/developers#dependenciesInstaller");}
        private void sendAFeedbackToolStripMenuItem_Click(object sender, EventArgs e) {Process.Start("https://github.com/Andrea-Filice/DependenciesInstaller/issues/new?labels=question");}
        private void bugReportToolStripMenuItem_Click(object sender, EventArgs e) {Process.Start("https://github.com/Andrea-Filice/DependenciesInstaller/issues/new?labels=bug");}
        private void suggestionToolStripMenuItem_Click(object sender, EventArgs e) { Process.Start("https://github.com/Andrea-Filice/DependenciesInstaller/issues/new?labels=enhancement"); }
        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e) { this.WindowState = FormWindowState.Minimized; }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://cdn-playepik.netlify.app/dependencies/dependencies.json");
                JObject data = JObject.Parse(json);

                string currentVersion = Application.ProductVersion;
                string latestVersion = data["versionDependenciesInstaller"]?.ToString();

                //CREATE VERION OBJECTS
                Version latest = new Version(latestVersion);
                Version current = new Version(currentVersion);

                int result = current.CompareTo(latest);

                if (result < 0)
                {
                    var message = MessageBox.Show("A new update is available! (v. " + latestVersion + "), Do you want to update it?", "Updater", MessageBoxButtons.YesNo);
                    if(message == DialogResult.Yes)
                        Process.Start("https://github.com/Andrea-Filice/DependenciesInstaller/releases/latest");
                }
                else
                    MessageBox.Show("You have the latest version available.", "Updater", MessageBoxButtons.OK);
            }
        }
        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The application will restart to apply changes.", "Reload", MessageBoxButtons.OK);
            this.Refresh();
        }
    }
}
