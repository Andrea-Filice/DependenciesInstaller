using System;
using System.Windows.Forms;

namespace Configurator.Exceptions
{
    public class ErrorGeneratedException : Exception
    {
        public ErrorGeneratedException(Exception ex)
        {
            MessageBox.Show($"An unknown error occurred while saving your data. Error: {ex}", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
