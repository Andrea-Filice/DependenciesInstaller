using System;
using System.Windows.Forms;

namespace Configurator
{
    public class BuildFailedException : Exception
    {
        public BuildFailedException(Label buildLogs, Exception ex)
        {
            MessageBox.Show($"An error occurred during the build and now is canceled. \nError message: {ex}", "Build Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            buildLogs.ForeColor = System.Drawing.Color.Red;
            buildLogs.AutoEllipsis = true;
            buildLogs.Text = $"{Program.GetCurrentDate()}: BUILD FAILED with this error message: {ex}";
        }
    }
}
