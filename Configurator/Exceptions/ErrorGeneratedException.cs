using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Configurator.Exceptions
{
    public class ErrorGeneratedException : Exception
    {
        public ErrorGeneratedException(Exception ex)
        {
            MessageBox.Show($"An unknown error occured. Error: {ex}", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
