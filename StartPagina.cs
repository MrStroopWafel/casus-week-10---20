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
        public Settings settings;
        public bool StartGame;
        public StartPagina()
        {
            InitializeComponent();
            settings = new Settings(this);
            StartGame = false;
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            settings.ShowDialog();
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            StartGame = true;
            this.Close();
        }
    }
}
