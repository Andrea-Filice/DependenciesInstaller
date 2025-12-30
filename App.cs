using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Installer
{
    internal class App
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        static void Main(string[] args)
        {
            Console.WriteLine($"{getCurrentDate()}: -- DEPENDENCIES INSTALLER {Assembly.GetExecutingAssembly().GetName().Version} --");

            string programPath = AppDomain.CurrentDomain.BaseDirectory;

            //CHECK FOR THE .BAT FILE VERSION
            string batPath = Path.Combine(programPath, "Game", "Install_EasyAntiCheat.bat");

            if (!File.Exists(batPath))
                batPath = Path.Combine(programPath, "Game", "Install_EasyAntiCheat_old.bat");

            string exePath = Path.Combine(programPath, "Game", "start_protected_game.exe");

            string appDataRoot = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), appFolder = Path.Combine(appDataRoot, "PlayEpikInstaller");
            Directory.CreateDirectory(appFolder);

            string savedDataPath = Path.Combine(appFolder, "installerLog.txt");

            try
            {
                Console.WriteLine($"{getCurrentDate()}: Starting the .bat installer with admin privileges...");
                //STARTING .BAT INSTALLER
                if (!File.Exists(savedDataPath))
                {
                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = batPath;
                    psi.Verb = "runas";
                    psi.UseShellExecute = true;

                    using (Process p = Process.Start(psi)) {p.WaitForExit();}
                    File.WriteAllText(savedDataPath, $"Installation complete: {getCurrentDate()}, DO NOT DELETE THIS FILE.");
                }

                //STARTING THE GAME
                Console.WriteLine($"{getCurrentDate()}: Starting the .exe program...");
                Process.Start(exePath);

                Console.WriteLine($"{getCurrentDate()}: Everything completed successfully!");
                Environment.Exit(0);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox(IntPtr.Zero, $"Fatal error: an unknown error occurred during the execution of the game, error code: {ex.Message}", "Fatal Error", 0x00000010);
                Environment.Exit(0);
            }
        }

        static string getCurrentDate() {return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");}
    }
}
