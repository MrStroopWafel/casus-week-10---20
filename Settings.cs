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
    public partial class Settings : Form
    {
        bool wachttijd;
        int wachttijd_lengte;
        int AI_moeilijkheid;
        private StartPagina StartPagina;
        public Settings(StartPagina _StartPagina)
        {
            InitializeComponent();
            StartPagina = _StartPagina;
        }

        private void Cb_wachttijd_CheckStateChanged(object sender, EventArgs e)
        {
            if (Cb_wachttijd.Checked)
            {
                Tb_wachttijd.Visible = false;
                settingsLabel2.Visible = false;
            }
            else
            {
                Tb_wachttijd.Visible = true;
                settingsLabel2.Visible = true;
            }

        }

        private void settingsConfirm_Click(object sender, EventArgs e)
        {
            wachttijd_lengte = Int32.Parse(Tb_wachttijd.Text);
            if (Cb_wachttijd.Checked)
            {
                wachttijd = true;
            }
            else
            {
                wachttijd = false;
            }
            AI_moeilijkheid = Int32.Parse(Dd_moeilijkheid.Text);
            testlabel.Text = Dd_moeilijkheid.Text;
            StartPagina.Show();
            this.Close();
        }
    }
}
