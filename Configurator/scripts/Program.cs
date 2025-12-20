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

        public static async Task BuildApplication(string path, Label buildLogs, ProgressBar progressBar, Button baseButton, Button executeButton, PictureBox buildIcon)
        {
            //Windows Taskbar values
            TaskbarProgressBarState _state = TaskbarProgressBarState.Normal;

            //Variables
            string baseFolderPath, gamePath;
            DateTime timeStarted = DateTime.Now, timeEnded;

            //Setting-up the UI
            _state = TaskbarProgressBarState.Normal;
            UpdateTaskbar(progressBar.Value, _state);
            buildLogs.Visible = true;
            progressBar.Visible = true;
            baseButton.Visible = false;

            //Control if path == null
            if (path == null || path.Trim() == "")
            {
                MessageBox.Show("Error during the build of Installer.exe. Error 404: Folder Not Found or Empty.", "Build Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buildLogs.Text = $"{GetCurrentDate()}: ERROR 404: Folder not found.";
                buildLogs.ForeColor = Color.Red;
                _state = TaskbarProgressBarState.Error;
                UpdateTaskbar(progressBar.Value, _state);
            }
            else
            {
                //Starting up the build
                buildLogs.ForeColor = Color.DarkCyan;
                buildLogs.Text = $"{GetCurrentDate()}: Starting building Installer.exe...";
                progressBar.Value = 20;
                _state = TaskbarProgressBarState.Normal;
                UpdateTaskbar(progressBar.Value, _state);

                await Task.Delay(2500);

                //Get base directory path
                baseFolderPath = Path.GetDirectoryName(path);
                buildLogs.Text = $"{GetCurrentDate()}: Finding base Path...";
                Console.WriteLine(GetCurrentDate() + ": Base Folder: " + baseFolderPath);
                progressBar.Value = 40;
                _state = TaskbarProgressBarState.Normal;
                UpdateTaskbar(progressBar.Value, _state);

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
                    UpdateTaskbar(progressBar.Value, _state);
                }
                buildLogs.Text = $"{GetCurrentDate()}: Creating Game folder...";
                progressBar.Value = 50;
                _state = TaskbarProgressBarState.Normal;
                UpdateTaskbar(progressBar.Value, _state);

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
                    buildLogs.Text = $"{GetCurrentDate()}: Copying files ({currentCopied}/{availableFiles})...";

                    //Avoid conflicts
                    if(File.Exists(dstFile))
                        File.Delete(dstFile);

                    //Error handling
                    try {File.Move(fileToMove, dstFile);}
                    catch (IOException ex)
                    {
                        await ResetUI(buildLogs, progressBar, executeButton, baseButton, buildIcon);
                        throw new BuildFailedException(buildLogs, ex);
                    }
                    catch(UnauthorizedAccessException ex)
                    {
                        await ResetUI(buildLogs, progressBar, executeButton, baseButton, buildIcon);
                        throw new BuildFailedException(buildLogs, ex);
                    }
                }
                progressBar.Value = 60;
                _state = TaskbarProgressBarState.Normal;
                UpdateTaskbar(progressBar.Value, _state);

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

                            buildLogs.Text = $"{GetCurrentDate()}: Moving folders ({folders.Length-1}/{currentlyMoved})...";
                        }
                        catch (Exception ex) when(
                            ex is IOException ||
                            ex is UnauthorizedAccessException ||
                            ex is DirectoryNotFoundException ||
                            ex is PathTooLongException ||
                            ex is ArgumentException
                        )
                        {
                            await ResetUI(buildLogs, progressBar, executeButton, baseButton, buildIcon);
                            throw new BuildFailedException(buildLogs, ex);
                        }
                    }
                }
                progressBar.Value = 70;
                _state = TaskbarProgressBarState.Normal;
                UpdateTaskbar(progressBar.Value, _state);

                await Task.Delay(2000);

                //Get Installer.exe and installing it.
                string applicationDirectory = Directory.GetCurrentDirectory();
                string exePersistentDirectory = Path.Combine(applicationDirectory, "Installer.exe");
                string destinationPath = Path.Combine(path, "Installer.exe");

                buildLogs.Text = $"{GetCurrentDate()}: Installing \"Installer.exe\"...";

                try
                {
                    if (File.Exists(destinationPath))
                    {
                        await ResetUI(buildLogs, progressBar, executeButton, baseButton, buildIcon);
                        throw new BuildFailedException(buildLogs, null);
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
                    await ResetUI(buildLogs, progressBar, executeButton, baseButton, buildIcon);
                    throw new BuildFailedException(buildLogs, ex);
                }
                progressBar.Value = 80;
                _state = TaskbarProgressBarState.Normal;
                UpdateTaskbar(progressBar.Value, _state);

                await Task.Delay(1000);

                //Install Install_EasyAntiCheat.bat into Game folder
                string batPersistentDirectory = "";
                string currentVersion = "";

                using (var f = new Options())
                {
                    currentVersion = f.ReadKey("versionSelected");
                    if(currentVersion == "0")
                        batPersistentDirectory = Path.Combine(applicationDirectory, "Install_EasyAntiCheat.bat");
                    else if(currentVersion == "1")
                        batPersistentDirectory = Path.Combine(applicationDirectory, "Install_EasyAntiCheat_old.bat");

                    buildLogs.Text = $"{GetCurrentDate()}: Installing \"Install_EasyAntiCheat.bat\"...";
                }

                try
                {
                    if (File.Exists(Path.Combine(gamePath, "Install_EasyAntiCheat.bat")) || File.Exists(Path.Combine(gamePath, "Install_EasyAntiCheat_old.bat")))
                    {
                        MessageBox.Show($"An error occurred during the build and now is canceled. Error: Installer.exe already exists.", "Build Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        buildLogs.ForeColor = Color.Red;
                        buildLogs.AutoEllipsis = true;
                        buildLogs.Text = $"{GetCurrentDate()}: BUILD FAILED! Error: Installer.exe already exists.";
                        _state = TaskbarProgressBarState.Error;
                        UpdateTaskbar(progressBar.Value, _state);
                        await ResetUI(buildLogs, progressBar, executeButton, baseButton, buildIcon);
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
                    await ResetUI(buildLogs, progressBar, executeButton, baseButton, buildIcon);
                    throw new BuildFailedException(buildLogs, ex);
                }
                progressBar.Value = 90;
                _state = TaskbarProgressBarState.Normal;
                UpdateTaskbar(progressBar.Value, _state);

                await Task.Delay(1000);

                //Build completed.
                timeEnded = DateTime.Now;

                string timeElapsedMinutes = (timeEnded - timeStarted).Minutes.ToString();
                string timeElapsedSeconds;

                //Format output for Seconds
                timeElapsedSeconds = ((timeEnded - timeStarted).Seconds < 10) ? $"0{(timeEnded - timeStarted).Seconds}" : (timeEnded - timeStarted).Seconds.ToString();

                //Setting-up the UI
                progressBar.Value = 100;
                _state = TaskbarProgressBarState.Normal;
                UpdateTaskbar(progressBar.Value, _state);
                buildLogs.ForeColor = Color.Green;
                executeButton.Visible = true;
                buildLogs.Text = $"{GetCurrentDate()}: BUILD SUCCEEDED! (Time elapsed: {timeElapsedMinutes}:{timeElapsedSeconds})";

                //Updating variables
                using(var f = new Config()) {f.buildInProgress = false;}

                //Check if the option for executing after build is enabled.
                using(var f = new Options())
                {
                    if (f.onBuild.Checked)
                    {
                        executeButton.Visible = false;
                        Execute(path);
                    }
                }

                //Reset UI
                await ResetUI(buildLogs, progressBar, executeButton, baseButton, buildIcon);
            }
        }

        public static void UpdateTaskbar(int value, TaskbarProgressBarState _state)
        {
            var taskbar = TaskbarManager.Instance;

            taskbar.SetProgressState(_state);
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

        public static async Task ResetUI(Label logs, ProgressBar bar, Button executeButton, Button buildButton, PictureBox buildIcon)
        {
            //Updating variables
            using (var f = new Config()) { f.buildInProgress = false; }
            await Task.Delay(3000);
            logs.Visible = false;
            bar.Visible = false;
            executeButton.Visible = false;
            buildButton.Visible = true;
            buildButton.Enabled = true;
            buildButton.BackColor = Color.Black;
            buildIcon.Visible = true;
            UpdateTaskbar(bar.Value, TaskbarProgressBarState.NoProgress);
        }
        public static string GetCurrentDate()
        {
            return $"{(DateTime.Now.Hour < 10 ? "0" : "")}{DateTime.Now.Hour}:{(DateTime.Now.Minute < 10 ? "0" : "")}{DateTime.Now.Minute}:{(DateTime.Now.Second < 10 ? "0" : "")}{DateTime.Now.Second}";
        }
    }
}
