using System;
using System.Windows.Forms;

namespace Configurator.Exceptions
{
    public class ExecuteFailedException : Exception
    {
        public ExecuteFailedException(Exception ex)
        {
            MessageBox.Show($"An unknown error occurred during the \"Test\" phase.\nError: {ex}", "Unknown Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
