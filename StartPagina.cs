using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Machi_Koro
{
    public partial class StartPagina : Form
    {
        Settings settings;
        public StartPagina()
        {
            InitializeComponent();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            settings = new Settings();
            settings.ShowDialog();
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
