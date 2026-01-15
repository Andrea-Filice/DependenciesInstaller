using System;
using System.Windows.Forms;
using System.Configuration;
using Configurator.Exceptions;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Configurator
{
    public partial class Options : Form
    {
        private const string AppFolderName = "Dependencies Installer";
        private const string AppDataFileName = "user.config";

        public Options()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void Options_FormClosed(object sender, FormClosedEventArgs e)
        {
            //WRITE SAVED VALUES
            WriteValues("versionSelected", eacVersions.SelectedIndex.ToString());
            WriteValues("selectFolderOnStart", selectOnStart.Checked.ToString());
            WriteValues("executeOnBuild", onBuild.Checked.ToString());
        }

        //NOTE: LOAD SAVED VALUES WHEN FORM IS LOADED
        private void Options_Load(object sender, EventArgs e) { ReadValues(); }

        //NOTE: SAVE AND LOAD METHODS
        public void WriteValues(string key, string value)
        {
            try
            {
                var settings = LoadAppDataSettings();
                settings[key] = value;
                SaveAppDataSettings(settings);
            }
            catch (ConfigurationErrorsException ex)
            {
                throw new ErrorGeneratedException(new ConfigurationErrorsException("Unable to save configuration.", ex));
            }
            catch (IOException ex)
            {
                throw new ErrorGeneratedException(new ConfigurationErrorsException("I/O error saving configuration.", ex));
            }
        }

        public void ReadValues()
        {
            try
            {
                var fb = LoadAppDataSettings();

                int valueDropDown = 0;
                if (fb.TryGetValue("versionSelected", out var vs) && !string.IsNullOrWhiteSpace(vs))
                    int.TryParse(vs, out valueDropDown);

                bool selectFolder = false;
                if (fb.TryGetValue("selectFolderOnStart", out var sf) && !string.IsNullOrWhiteSpace(sf))
                    bool.TryParse(sf, out selectFolder);

                bool executeOnBuild = false;
                if (fb.TryGetValue("executeOnBuild", out var eb) && !string.IsNullOrWhiteSpace(eb))
                    bool.TryParse(eb, out executeOnBuild);

                selectOnStart.Checked = selectFolder;
                onBuild.Checked = executeOnBuild;

                var maxIndex = Math.Max(0, eacVersions.Items.Count - 1);
                eacVersions.SelectedIndex = Math.Min(maxIndex, Math.Max(0, valueDropDown));
            }
            catch(Exception ex) when(
            ex is ConfigurationErrorsException ||
            ex is IOException ||
            ex is UnauthorizedAccessException)
            {
                throw new ErrorGeneratedException(ex);
            }
        }

        public string ReadKey(string key)
        {
            try
            {
                var fb = LoadAppDataSettings();
                if (fb.TryGetValue(key, out var v))
                    return v;
                return null;
            }
            catch(Exception ex) when
            (   ex is ConfigurationErrorsException ||
                ex is UnauthorizedAccessException ||
                ex is IOException)
            {
                throw new ErrorGeneratedException(ex);
            }
        }

        private string GetAppDataFilePath()
        {
            var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), AppFolderName);
            Directory.CreateDirectory(folder);
            return Path.Combine(folder, AppDataFileName);
        }

        private Dictionary<string, string> LoadAppDataSettings()
        {
            var filePath = GetAppDataFilePath();
            var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            if (!File.Exists(filePath))
                return dict;

            foreach (var line in File.ReadAllLines(filePath, Encoding.UTF8))
            {
                if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))
                    continue;
                var idx = line.IndexOf('=');

                if (idx <= 0) continue;

                var k = line.Substring(0, idx).Trim();
                var v = line.Substring(idx + 1).Trim();
                dict[k] = v;
            }
            return dict;
        }

        private void SaveAppDataSettings(Dictionary<string, string> settings)
        {
            var filePath = GetAppDataFilePath();
            var sb = new StringBuilder();
            foreach (var kv in settings)
            {
                sb.AppendLine($"{kv.Key}={kv.Value}");
            }
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        private void infoOpt1_Click(object sender, EventArgs e) {MessageBox.Show($"The “Select Folder on Start” option launches the folder selection mode as soon as the application is opened.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);}
        private void infoOpt2_Click(object sender, EventArgs e) {MessageBox.Show($"The “Execute on Build” option, when enabled, immediately launches a preview of your game when the build is complete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);}
    }
}
