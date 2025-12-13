using System;
using System.Windows.Forms;

namespace Configurator.forms
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
            OnLoad();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void buttonOK_Click(object sender, EventArgs e) {this.Close();}
    }
}
