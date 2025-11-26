using System;
using System.Windows.Forms;
using System.Configuration;
using Configurator.Exceptions;

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

        //NOTE: SAVE AND LOAD METHODS
        public void WriteValues(string key, string value)
        {
            try
            {
                Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                KeyValueConfigurationCollection settings = configFile.AppSettings.Settings;

                if (settings[key] == null)
                    settings.Add(key, value);
                else
                    settings[key].Value = value;

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException ex)
            {
                throw new ErrorGeneratedException(ex); //NOTE: THROW THE EXCEPTION WITH AN UI MESSAGE.
            }
        }

        public void ReadValues()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                int valueDropDown = 0;
                var versionSelected = appSettings["versionSelected"];
                if (!string.IsNullOrWhiteSpace(versionSelected))
                    int.TryParse(versionSelected, out valueDropDown);

                bool.TryParse(appSettings["selectFolderOnStart"] ?? string.Empty, out bool selectFolder);
                bool.TryParse(appSettings["executeOnBuild"] ?? string.Empty, out bool executeOnBuild);

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
            var appSettings = ConfigurationManager.AppSettings;

            if (appSettings[key] != null)
                return appSettings[key].ToString();
            else
                return null;
        }

        private void Options_FormClosed(object sender, FormClosedEventArgs e)
        {
            //WRITE SAVED VALUES
            WriteValues("versionSelected", eacVersions.SelectedIndex.ToString());
            WriteValues("selectFolderOnStart", selectOnStart.Checked.ToString());
            WriteValues("executeOnBuild", onBuild.Checked.ToString());
        }

        //NOTE: LOAD SAVED VALUES WHEN FORM IS LOADED
        private void Options_Load(object sender, EventArgs e){ReadValues();}
    }
}
