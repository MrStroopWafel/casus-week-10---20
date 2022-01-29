using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Random;

namespace Machi_Koro
{
    public partial class TafelScherm : Form
    {
        private List<PictureBox> PicureBoxsOnder = new List<PictureBox>();
        private List<PictureBox> PicureBoxsLinks = new List<PictureBox>();
        private List<PictureBox> PicureBoxsBoven = new List<PictureBox>();
        private List<PictureBox> PicureBoxsRechts = new List<PictureBox>();
        private List<Speler> spelerLijst = new List<Speler>();
        private bool heeftGedobbeld;
        private bool wachttijd;
        private int maxWachttijd;
        private Speler spelendeSpeler;




        public TafelScherm(Settings _Settings, InitScherm _InitScherm)
        {
            InitializeComponent();
            //aanmaken van picure box lijsten en het roteren van de pb
            LijstMakenPicureBoxes();
            RotateCardsHorizontaal(PicureBoxsLinks, PicureBoxsRechts);
            //opzetten van de wachttijd
            if (_Settings.wachttijd)
            {
                wachttijd = true;
                maxWachttijd = _Settings.wachttijd_lengte;
            } else
            {
                wachttijd = false;
            }
            //aanmaken van de speler en tafel
            MaakSpelersAan(_InitScherm.AantalSpelers);
            MaakTafel(spelerLijst.Count);






            

        }

        private void MaakTafel(int _SpelerAantal)
        {
            switch (_SpelerAantal)
            {
                case 2:
                    TweeSpelerScherm();
                    break;
                case 3:
                    DrieSpelerScherm();
                    break;
                default:
                    break;
            }
        }

        private void TweeSpelerScherm()
        {
            foreach (PictureBox pb in PicureBoxsLinks)
            {
                pb.Hide();
            }
            foreach (PictureBox pb in PicureBoxsRechts)
            {
                pb.Hide();
            }
            lb_LinksSpeler.Hide();
            lb_LinksGeld.Hide();
            lb_RechtsSpeler.Hide();
            lb_RechtsGeld.Hide();
        }
        private void DrieSpelerScherm()
        {
            foreach (PictureBox pb in PicureBoxsBoven)
            {
                pb.Hide();
            }
            lb_BovenSpeler.Hide();
            lb_BovenGeld.Hide();
        }

        /// <summary>
        /// methode om spelers aan te maken tijdens creatie van de klasse
        /// </summary>
        /// <param name="_AantalSpelers">De hoeveelheid spelers zoals in initscherm is aangegeven</param>
        private void MaakSpelersAan(int _AantalSpelers)
        {
            for (int i = 0; i < _AantalSpelers; i++)
            {
                spelerLijst.Add(new Speler());
            }
        }
        /*
        private void BezienswaardigheidKopen(object sender, EventArgs e)
        {
            if (spelendeSpeler.Geld == Kaart.Prijs)
            {

            }
        }
        
        public checkGeld()
        {

            foreach (card in player.cardlist)
            {
                //SPELER CHECK HIERBOVEN
                switch (card.kleur)
                {
                    case "Groen":
                        CheckGroen(card, player);
                        break;
                    case "Blauw":
                        CheckBlauw(card, player);
                        break;
                    case "Paars"
                        CheckPaars(card, player);
                        break;
                    default:
                        break;


                }
            }
            foreach (player in notPlayerplayerlist)
            {
                foreach (card in player.cardlist)
                {
                    //SPELER CHECK HIERBOVEN
                    switch (card.kleur)
                    {
                        case "Rood":
                            CheckGroen(card, player);
                            break;
                        case "Blauw":
                            CheckBlauw(card, player);
                            break;
                        default:
                            break;


                    }
                }
            }

        }
        private void CheckGroen(Kaart _Card, Speler _Speler)
        {
            foreach (waarde in _Card.Waarde)
            {
                if (waarde == rndNummer)
                {

                    _Speler.Geld.Add(_Card.BetalingsWaarde);
                    break;
                }
            }
        }
        private void CheckBlauw(Kaart _Card, Speler _Speler) 
        {
            foreach (waarde in _Card.Waarde)
            {
                if (waarde == rndNummer)
                {

                    _Speler.Geld.Add(_Card.BetalingsWaarde);
                    break;
                }
            }
        }
        private void CheckRood(Kaart _Card, Speler _Speler) 
        {
            foreach (waarde in _Card.Waarde) 
            {
                if (waarde == rndNummer) 
                {
                    if (_Speler.Geld > 1) 
                    {
                        _Speler.Geld.Remove(_Card.BetalingsWaarde); <---speler aan de beurt. spelerAanDeBeurt.Geld.Remove???
                        _Speler.Geld.Add(_Card.Betalingswaarde); <---speler die rode kaart heeft
            
        private void CheckPaars()
         */
        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void bt_dobbel_Click(object sender, EventArgs e)
        {
            heeftGedobbeld = true;
            Random rnd = new Random();
            int rndNummer = rnd.Next(1, 7);
            bt_volgendespeler.Enabled = true;
            btn_Kopen.Enabled = true;
            lb_DobbelNummer.Text = rndNummer.ToString();
        }


        private void bt_volgendespeler_Click(object sender, EventArgs e)
        {

        }

        private void btn_Kopen_Click(object sender, EventArgs e)
        {
            //KoopScherm koopscherm = new KoopScherm();
            //Application.Run(koopscherm);
        }
        /// <summary>
        /// Functie om de linker en rechter picture box te draaien
        /// </summary>
        /// <param name="_Picturebox1">kaarten van de linker speler</param>
        /// <param name="_Picturebox2">kaarten van de rechter speler</param>
        private void RotateCardsHorizontaal(List<PictureBox> _Picturebox1, List<PictureBox> _Picturebox2)
        {
            //link
            foreach (PictureBox pb in _Picturebox1)
            {
                pb.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pb.Refresh();
            }
            //rechts
            foreach (PictureBox pb in _Picturebox2)
            {
                pb.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                pb.Refresh();
            }
        }
        /// <summary>
        /// Functie om de boven en onder picture box te draaien
        /// </summary>
        /// <param name="_Picturebox1">kaarten van de onder speler</param>
        /// <param name="_Picturebox2">kaarten van de boven speler</param>
        private void RotateCardsVerticaal(List<PictureBox> _Picturebox1, List<PictureBox> _Picturebox2)
        {
            //onder
            foreach (PictureBox pb in _Picturebox1)
            {
                pb.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pb.Refresh();
            }
            //boven
            foreach (PictureBox pb in _Picturebox2)
            {
                pb.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                pb.Refresh();
            }
        }

        /// <summary>
        /// Method om de lijsten te vullen met alle horizontale en alle verticale picture boxes
        /// </summary>
        private void LijstMakenPicureBoxes()
        {
            //onder speler
            PicureBoxsOnder.Add(pb_OnderSpeler1);
            PicureBoxsOnder.Add(pb_OnderSpeler2);
            PicureBoxsOnder.Add(pb_OnderSpeler3);
            PicureBoxsOnder.Add(pb_OnderSpeler4);
            PicureBoxsOnder.Add(pb_OnderSpeler5);
            PicureBoxsOnder.Add(pb_treinstation1);
            PicureBoxsOnder.Add(pb_winkelcentrum1);
            PicureBoxsOnder.Add(pb_pretpark1);
            PicureBoxsOnder.Add(pb_radiostation1);

            //links speler
            PicureBoxsLinks.Add(pb_LinksSpeler1);
            PicureBoxsLinks.Add(pb_LinksSpeler2);
            PicureBoxsLinks.Add(pb_LinksSpeler3);
            PicureBoxsLinks.Add(pb_LinksSpeler4);
            PicureBoxsLinks.Add(pb_LinksSpeler5);
            PicureBoxsLinks.Add(pb_treinstation2);
            PicureBoxsLinks.Add(pb_winkelcentrum2);
            PicureBoxsLinks.Add(pb_pretpark2);
            PicureBoxsLinks.Add(pb_radiostation2);

            //boven speler
            PicureBoxsBoven.Add(pb_BovenSpeler1);
            PicureBoxsBoven.Add(pb_BovenSpeler2);
            PicureBoxsBoven.Add(pb_BovenSpeler3);
            PicureBoxsBoven.Add(pb_BovenSpeler4);
            PicureBoxsBoven.Add(pb_BovenSpeler5);
            PicureBoxsBoven.Add(pb_treinstation3);
            PicureBoxsBoven.Add(pb_winkelcentrum3);
            PicureBoxsBoven.Add(pb_pretpark3);
            PicureBoxsBoven.Add(pb_radiostation3);

            //rechts speler
            PicureBoxsRechts.Add(pb_RechtsSpeler1);
            PicureBoxsRechts.Add(pb_RechtsSpeler2);
            PicureBoxsRechts.Add(pb_RechtsSpeler3);
            PicureBoxsRechts.Add(pb_RechtsSpeler4);
            PicureBoxsRechts.Add(pb_RechtsSpeler5);
            PicureBoxsRechts.Add(pb_treinstation4);
            PicureBoxsRechts.Add(pb_winkelcentrum4);
            PicureBoxsRechts.Add(pb_pretpark4);
            PicureBoxsRechts.Add(pb_radiostation4);
        }
    }
}
