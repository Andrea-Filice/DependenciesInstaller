using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace Configurator
{
    public partial class Config : Form
    {
        public Config() {
            InitializeComponent();
            Start();
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }

        private void Config_Load(object sender, EventArgs e) {Console.WriteLine($"{DateTime.Now}: Loading config files");}
        private void buttonChangeFolder_Click(object sender, EventArgs e) {OpenFolderBrowser();}
        private void buildButton_Click(object sender, EventArgs e) {StartBuilding();}
        private void executeButton_Click(object sender, EventArgs e) {ExecuteProgram();}


        //NOTE: MENU ACTIONS
        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e){Application.Exit();}

        private void visitWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo website = new ProcessStartInfo("https://play-epik-incorporation.netlify.app/developers#dependenciesInstaller");
            Process.Start(website);
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e){MessageBox.Show("Dependencies Installer (v. " + Application.ProductVersion + ").", "About Dependencies Installer", MessageBoxButtons.OK);}

        private void sendAFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo website = new ProcessStartInfo("https://github.com/Andrea-Filice/DependenciesInstaller/issues/new?labels=question");
            Process.Start(website);
        }

        private void bugReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo website = new ProcessStartInfo("https://github.com/Andrea-Filice/DependenciesInstaller/issues/new?labels=bug");
            Process.Start(website);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://playepikservercontents.netlify.app/dependencies/dependencies.json");
                JObject data = JObject.Parse(json);

                string currentVersion = Application.ProductVersion;
                string latestVersion = data["versionDependenciesInstaller"]?.ToString();

                //CREATE VERION OBJECTS
                Version latest = new Version(latestVersion);
                Version current = new Version(currentVersion);

                int result = current.CompareTo(latest);

                if (result < 0)
                {
                    var message = MessageBox.Show("A new update is available! (v. " + latestVersion + "), do you want to update it?", "Updater", MessageBoxButtons.YesNo);
                    if(message == DialogResult.Yes)
                    {
                        ProcessStartInfo website = new ProcessStartInfo("https://github.com/Andrea-Filice/DependenciesInstaller/releases/latest");
                        Process.Start(website);
                    }
                }
                else
                    MessageBox.Show("You have the latest version available.", "Updater", MessageBoxButtons.OK);
            }
        }
    }
}
