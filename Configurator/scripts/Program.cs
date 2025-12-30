using Configurator.Exceptions;
using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Configurator
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Config());
        }

        public static async Task BuildApplication(Config form, string path)
        {
            //Windows Taskbar values
            TaskbarProgressBarState _state;

            //Variables
            string baseFolderPath, gamePath;
            DateTime timeStarted = DateTime.Now, timeEnded;
            Options options = new Options();

            //Setting-up the UI
            _state = TaskbarProgressBarState.Normal;
            UpdateTaskbar(form.progressBar.Value, _state);
            form.buildLogs.Visible = true;
            form.progressBar.Visible = true;
            form.buildButton.Visible = false;

            //Control if path == null
            if (path == null || path.Trim() == "")
            {
                MessageBox.Show("Error during the build of Installer.exe. Error 404: Folder Not Found or Empty.", "Build Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                form.buildLogs.Text = $"{GetCurrentDate()}: ERROR 404: Folder not found.";
                form.buildLogs.ForeColor = Color.Red;
                _state = TaskbarProgressBarState.Error;
                UpdateTaskbar(form.progressBar.Value, _state);
            }
            else
            {
                //Starting up the build
                form.buildLogs.ForeColor = Color.DarkCyan;
                form.buildLogs.Text = $"{GetCurrentDate()}: Starting building Installer.exe...";
                form.progressBar.Value = 20;
                _state = TaskbarProgressBarState.Normal;
                UpdateTaskbar(form.progressBar.Value, _state);

                await Task.Delay(2500);

                //Get base directory path
                baseFolderPath = Path.GetDirectoryName(path);
                form.buildLogs.Text = $"{GetCurrentDate()}: Finding base Path...";
                Console.WriteLine(GetCurrentDate() + ": Base Folder: " + baseFolderPath);
                form.progressBar.Value = 40;
                _state = TaskbarProgressBarState.Normal;
                UpdateTaskbar(form.progressBar.Value, _state);

                await Task.Delay(1000);

                //Create "Game" folder into that
                gamePath = Path.Combine(path, "Game");
                Console.WriteLine(GetCurrentDate() + ": Game path: " + gamePath);
                if (!Directory.Exists(gamePath))
                    Directory.CreateDirectory(gamePath);
                else
                {
                    MessageBox.Show($"A folder with the name of \"Game\" already exists. The program will copy files into that folder.", "Build Paused", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _state = TaskbarProgressBarState.Paused;
                    UpdateTaskbar(form.progressBar.Value, _state);
                }
                form.buildLogs.Text = $"{GetCurrentDate()}: Creating Game folder...";
                form.progressBar.Value = 50;
                _state = TaskbarProgressBarState.Normal;
                UpdateTaskbar(form.progressBar.Value, _state);

                await Task.Delay(1000);

                //Copy game_files into the new "Game" folder
                int availableFiles = Directory.GetFiles(path).Length, currentCopied = 0;
                string[] files = Directory.GetFiles(path);
                List<string> filesToMove = new List<string>();

                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    if (fileName != "Game")
                        filesToMove.Add(file);
                }

                foreach(string fileToMove in filesToMove)
                {
                    string fileName = Path.GetFileName(fileToMove);
                    string dstFile = Path.Combine(gamePath, fileName);

                    //UI Update
                    currentCopied++;
                    form.buildLogs.Text = $"{GetCurrentDate()}: Copying files ({currentCopied}/{availableFiles})...";

                    //Avoid conflicts
                    if(File.Exists(dstFile))
                        File.Delete(dstFile);

                    //Error handling
                    try {File.Move(fileToMove, dstFile);}
                    catch (IOException ex)
                    {
                        await ResetUI(form);
                        throw new BuildFailedException(form.buildLogs, ex);
                    }
                    catch(UnauthorizedAccessException ex)
                    {
                        await ResetUI(form);
                        throw new BuildFailedException(form.buildLogs, ex);
                    }
                }
                form.progressBar.Value = 60;
                _state = TaskbarProgressBarState.Normal;
                UpdateTaskbar(form.progressBar.Value, _state);

                await Task.Delay(2000);

                //Move sub_folders also
                int currentlyMoved = 0;
                string[] folders = Directory.GetDirectories(path);

                foreach (string folderPath in folders)
                {
                    string folderName = Path.GetFileName(folderPath);
                    if (folderName != "Game")
                    {
                        string dstFolder = Path.Combine(gamePath, folderName);

                        try
                        {
                            if (Directory.Exists(dstFolder))
                                Directory.Delete(dstFolder, true);

                            Directory.Move(folderPath, dstFolder);
                            currentlyMoved++;

                            form.buildLogs.Text = $"{GetCurrentDate()}: Moving folders ({folders.Length-1}/{currentlyMoved})...";
                        }
                        catch (Exception ex) when(
                            ex is IOException ||
                            ex is UnauthorizedAccessException ||
                            ex is DirectoryNotFoundException ||
                            ex is PathTooLongException ||
                            ex is ArgumentException
                        )
                        {
                            await ResetUI(form);
                            throw new BuildFailedException(form.buildLogs, ex);
                        }
                    }
                }
                form.progressBar.Value = 70;
                _state = TaskbarProgressBarState.Normal;
                UpdateTaskbar(form.progressBar.Value, _state);

                await Task.Delay(2000);

                //Get Installer.exe and installing it.
                string applicationDirectory = Directory.GetCurrentDirectory();
                string exePersistentDirectory = Path.Combine(applicationDirectory, "Installer.exe");
                string destinationPath = Path.Combine(path, "Installer.exe");

                form.buildLogs.Text = $"{GetCurrentDate()}: Installing \"Installer.exe\"...";

                try
                {
                    if (File.Exists(destinationPath))
                    {
                        await ResetUI(form);
                        throw new BuildFailedException(form.buildLogs, null);
                    }
                    else
                        File.Copy(exePersistentDirectory, destinationPath);
                }
                catch (Exception ex) when (
                    ex is IOException ||
                    ex is UnauthorizedAccessException ||
                    ex is PathTooLongException
                )
                {
                    await ResetUI(form);
                    throw new BuildFailedException(form.buildLogs, ex);
                }
                form.progressBar.Value = 80;
                _state = TaskbarProgressBarState.Normal;
                UpdateTaskbar(form.progressBar.Value, _state);

                await Task.Delay(1000);

                //Install Install_EasyAntiCheat.bat into Game folder
                string batPersistentDirectory = "";
                string currentVersion = "";

                currentVersion = options.ReadKey("versionSelected");
                if (currentVersion == "0")
                    batPersistentDirectory = Path.Combine(applicationDirectory, "Install_EasyAntiCheat.bat");
                else if (currentVersion == "1")
                    batPersistentDirectory = Path.Combine(applicationDirectory, "Install_EasyAntiCheat_old.bat");

                form.buildLogs.Text = $"{GetCurrentDate()}: Installing \"Install_EasyAntiCheat.bat\"...";

                try
                {
                    if (File.Exists(Path.Combine(gamePath, "Install_EasyAntiCheat.bat")) || File.Exists(Path.Combine(gamePath, "Install_EasyAntiCheat_old.bat")))
                    {
                        MessageBox.Show($"An error occurred during the build and now is canceled. Error: Installer.exe already exists.", "Build Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        form.buildLogs.ForeColor = Color.Red;
                        form.buildLogs.AutoEllipsis = true;
                        form.buildLogs.Text = $"{GetCurrentDate()}: BUILD FAILED! Error: Installer.exe already exists.";
                        _state = TaskbarProgressBarState.Error;
                        UpdateTaskbar(form.progressBar.Value, _state);
                        await ResetUI(form);
                        form.buildInProgress = false;
                    }
                    else
                    {
                        if (currentVersion == "0")
                            File.Copy(batPersistentDirectory, Path.Combine(gamePath, "Install_EasyAntiCheat.bat"));
                        else if (currentVersion == "1")
                            File.Copy(batPersistentDirectory, Path.Combine(gamePath, "Install_EasyAntiCheat_old.bat"));
                    }
                }
                catch (Exception ex) when(
                    ex is IOException ||
                    ex is UnauthorizedAccessException ||
                    ex is ArgumentException ||
                    ex is NotSupportedException
                )
                {
                    await ResetUI(form);
                    throw new BuildFailedException(form.buildLogs, ex);
                }
                form.progressBar.Value = 90;
                _state = TaskbarProgressBarState.Normal;
                UpdateTaskbar(form.progressBar.Value, _state);

                await Task.Delay(1000);

                //Build completed.
                timeEnded = DateTime.Now;

                string timeElapsedMinutes = (timeEnded - timeStarted).Minutes.ToString();
                string timeElapsedSeconds;

                //Format output for Seconds
                timeElapsedSeconds = ((timeEnded - timeStarted).Seconds < 10) ? $"0{(timeEnded - timeStarted).Seconds}" : (timeEnded - timeStarted).Seconds.ToString();

                //Setting-up the UI
                form.progressBar.Value = 100;
                _state = TaskbarProgressBarState.Normal;
                UpdateTaskbar(form.progressBar.Value, _state);
                form.buildLogs.ForeColor = Color.Green;
                form.executeButton.Visible = form.buildInProgress;
                form.buildLogs.Text = $"{GetCurrentDate()}: BUILD SUCCEEDED! (Time elapsed: {timeElapsedMinutes}:{timeElapsedSeconds})";

                //Updating variables
                form.buildInProgress = false;

                //Check if the option for executing after build is enabled.
                if (options.onBuild.Checked)
                {
                    form.executeButton.Visible = false;
                    Execute(path);
                }

                //Reset UI
                await ResetUI(form);
            }
        }

        public static void UpdateTaskbar(int value, TaskbarProgressBarState _state)
        {
            var taskbar = TaskbarManager.Instance;

            taskbar.SetProgressState(_state);

            if(_state == TaskbarProgressBarState.NoProgress)
                taskbar.SetProgressValue(0, 100);
            else
                taskbar.SetProgressValue(value, 100);
        }

        public static void Execute(string path)
        {
            //Get executable path from base path.
            string executablePath = Path.Combine(path, "Installer.exe");

            try
            {
                //NOTE: Create the ProcessStartInfo element with UseShellExecute set to false, however this doesn't work.
                var psi = new ProcessStartInfo
                {
                    FileName = executablePath,
                    UseShellExecute = false
                };

                Process.Start(psi); 
            }
            catch (Win32Exception ex)
            {
                //NOTE: Catch the Win32Exception for non-base privilegies of Configurator App.
                throw new ExecuteFailedException(ex);
            }
        }

        public static async Task ResetUI(Config form)
        {
            //Updating variables
            form.buildInProgress = false;
            await Task.Delay(3000);
            form.buildLogs.Visible = false;
            form.progressBar.Visible = false;
            form.executeButton.Visible = false;
            form.buildButton.Visible = true;
            form.buildButton.Enabled = true;
            form.buildButton.BackColor = Color.Black;
            form.buildIcon.Visible = true;
            UpdateTaskbar(form.progressBar.Value, TaskbarProgressBarState.NoProgress);
        }

        public static string GetCurrentDate()
        {
            return $"{(DateTime.Now.Hour < 10 ? "0" : "")}{DateTime.Now.Hour}:{(DateTime.Now.Minute < 10 ? "0" : "")}{DateTime.Now.Minute}:{(DateTime.Now.Second < 10 ? "0" : "")}{DateTime.Now.Second}";
        }
    }
}
