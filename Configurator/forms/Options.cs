using System;
using System.Windows.Forms;
using System.Configuration;
using Configurator.Exceptions;
using System.IO;
using System.Text;

namespace Configurator
{
    public partial class Options : Form
    {
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
                Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                KeyValueConfigurationCollection settings = configFile.AppSettings.Settings;

                if (settings[key] == null)
                    settings.Add(key, value);
                else
                    settings[key].Value = value;

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (ConfigurationErrorsException ex)
            {
                //NOTE: THROW THE EXCEPTION WITH AN UI MESSAGE.
                throw new ErrorGeneratedException(ex);
            }
            catch (UnauthorizedAccessException)
            {
                try
                {
                    var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dependencies Installer");
                    Directory.CreateDirectory(folder);
                    var filePath = Path.Combine(folder, "user.config");

                    var lines = File.Exists(filePath) ? File.ReadAllLines(filePath, Encoding.UTF8) : new string[0];
                    var sb = new StringBuilder();
                    var found = false;
                    foreach (var line in lines)
                    {
                        if (line.StartsWith(key + "=", StringComparison.OrdinalIgnoreCase))
                        {
                            sb.AppendLine(key + "=" + value);
                            found = true;
                        }
                        else
                            sb.AppendLine(line);
                    }
                    if (!found)
                        sb.AppendLine(key + "=" + value);

                    File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    throw new ErrorGeneratedException(new ConfigurationErrorsException("Unable to save configuration to user profile.", ex));
                }
            }
        }

        public void ReadValues()
        {
            try
            {
                Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                KeyValueConfigurationCollection settings = configFile.AppSettings.Settings;

                string versionSelected = settings["versionSelected"]?.Value ?? ConfigurationManager.AppSettings["versionSelected"];
                int valueDropDown = 0;
                if (!string.IsNullOrWhiteSpace(versionSelected))
                    int.TryParse(versionSelected, out valueDropDown);

                string selectFolderRaw = settings["selectFolderOnStart"]?.Value ?? ConfigurationManager.AppSettings["selectFolderOnStart"];
                string executeOnBuildRaw = settings["executeOnBuild"]?.Value ?? ConfigurationManager.AppSettings["executeOnBuild"];

                bool.TryParse(selectFolderRaw ?? string.Empty, out bool selectFolder);
                bool.TryParse(executeOnBuildRaw ?? string.Empty, out bool executeOnBuild);

                selectOnStart.Checked = selectFolder;
                onBuild.Checked = executeOnBuild;

                var maxIndex = Math.Max(0, eacVersions.Items.Count - 1);
                eacVersions.SelectedIndex = Math.Min(maxIndex, Math.Max(0, valueDropDown));
            }
            catch (ConfigurationErrorsException ex)
            {
                //NOTE: THROW THE EXCEPTION WITH AN UI MESSAGE.
                throw new ErrorGeneratedException(ex); 
            }
        }

        public string ReadKey(string key)
        {
            try
            {
                Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                KeyValueConfigurationCollection settings = configFile.AppSettings.Settings;

                var val = settings[key]?.Value ?? ConfigurationManager.AppSettings[key];
                if (!string.IsNullOrEmpty(val))
                    return val;

                var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dependencies Installer");
                var filePath = Path.Combine(folder, "user.config");
                if (File.Exists(filePath))
                {
                    foreach (var line in File.ReadAllLines(filePath, Encoding.UTF8))
                    {
                        if (line.StartsWith(key + "=", StringComparison.OrdinalIgnoreCase))
                            return line.Substring(line.IndexOf('=') + 1);
                    }
                }

                return null;
            }
            catch (ConfigurationErrorsException ex)
            {
                throw new ErrorGeneratedException(ex);
            }
        }
    }
}
