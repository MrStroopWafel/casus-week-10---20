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
        InitKaart initKaart = new InitKaart();
        public StartPagina()
        {
            InitializeComponent();
            label1.Text = initKaart.KaartenLijst[0].KaartUitdelen + initKaart.KaartenLijst[0].Naam;
            label2.Text = initKaart.KaartenLijst[15].Kleur + initKaart.KaartenLijst[15].Naam; 
        }
    }
}
