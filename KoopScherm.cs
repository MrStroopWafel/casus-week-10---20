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
    internal partial class KoopScherm : Form
    {
        Speler Speler;
        List<Kaart> KaartLijst = new List<Kaart>();
        List<PictureBox> PictureBoxs = new List<PictureBox>();
        List<Kaart> DisplayKaarten = new List<Kaart>();
        public bool gekocht;

        public KoopScherm(Speler _Speler, List<Kaart> _KaartLijst)
        {
            InitializeComponent();
            PictureBoxLijst();
            Speler = _Speler;
            KaartLijst = _KaartLijst;
            KoopLijst();
        }
        private void KoopLijst()
        {
            int i = 0;
            foreach (Kaart Kaart in KaartLijst)
            {
                if (Speler.Geld >= Kaart.Prijs)
                {
                    string bestand = Kaart.Naam;
                    string filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                    PictureBoxs[i].Image = Image.FromFile(filePath);
                    PictureBoxs[i].Visible = true;
                    ++i;
                    DisplayKaarten.Add(Kaart);
                }
            }
        }
        private void PictureBoxLijst()
        {
            PictureBoxs.Add(pictureBox_1);
            PictureBoxs.Add(pictureBox_2);
            PictureBoxs.Add(pictureBox_3);
            PictureBoxs.Add(pictureBox_4);
            PictureBoxs.Add(pictureBox_5);
            PictureBoxs.Add(pictureBox_6);
            PictureBoxs.Add(pictureBox_7);
            PictureBoxs.Add(pictureBox_8);
            PictureBoxs.Add(pictureBox_9);
            PictureBoxs.Add(pictureBox_10);
            PictureBoxs.Add(pictureBox_11);
            PictureBoxs.Add(pictureBox_12);
            PictureBoxs.Add(pictureBox_13);
            PictureBoxs.Add(pictureBox_14);
            PictureBoxs.Add(pictureBox_15);
        }

        private void btn_terug_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void KoopKaart_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            gekocht = true;
            string[] pb_Id = pb.Name.Split('_');
            int i = Int32.Parse(pb_Id[1]);
            i -= 1;
            Speler.Gebouwen.Add(DisplayKaarten[i]);
            Speler.Geld -= DisplayKaarten[i].Prijs;
            this.Close();
        }
    }
}
