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
        private List<PictureBox> PicureBoxsOnderKaarten = new List<PictureBox>();
        private List<PictureBox> PicureBoxsLinksKaarten = new List<PictureBox>();
        private List<PictureBox> PicureBoxsBovenKaarten = new List<PictureBox>();
        private List<PictureBox> PicureBoxsRechtsKaarten = new List<PictureBox>();
        private List<PictureBox> PicureBoxsOnderBezienswaardigheden = new List<PictureBox>();
        private List<PictureBox> PicureBoxsLinksBezienswaardigheden = new List<PictureBox>();
        private List<PictureBox> PicureBoxsBovenBezienswaardigheden = new List<PictureBox>();
        private List<PictureBox> PicureBoxsRechtsBezienswaardigheden = new List<PictureBox>();
        private List<Speler> spelerLijst = new List<Speler>();
        private List<Kaart> kaartenLijst = new List<Kaart>();
        private List<Kaart> BezienswaardighedenLijst = new List<Kaart>();
        private bool heeftGedobbeld;
        private bool wachttijd;
        private int maxWachttijd, rndNummer, ronde;
        private Speler spelendeSpeler;


        public TafelScherm(Settings _Settings, InitScherm _InitScherm)
        {
            InitializeComponent();
            //aanmaken van picure box lijsten en het roteren van de pb
            LijstMakenPicureBoxes();
            ronde = 1;


            HideAllPictureboxes();
            MaakTafel(_InitScherm.AantalSpelers);

            //opzetten van de wachttijd
            if (_Settings.wachttijd)
            {
                wachttijd = true;
                maxWachttijd = _Settings.wachttijd_lengte;
            }
            else
            {
                wachttijd = false;
            }
            //aanmaken van de speler
            MaakSpelersAan(_InitScherm.AantalSpelers);
            InitKaart initKaart = new InitKaart();
            kaartenLijst = initKaart.KaartenLijst;
            BezienswaardighedenLijst = initKaart.BezienswaardighedenLijst;

            foreach (Speler speler in spelerLijst)
            {
                speler.Gebouwen.Add(HaalKaartOp("Graanveld"));
                speler.Gebouwen.Add(HaalKaartOp("Bakkerij"));
            }

            spelendeSpeler = spelerLijst[0];
            LaadAlleKaarten();
            RotateCardsHorizontaal(PicureBoxsLinksKaarten, PicureBoxsRechtsKaarten, PicureBoxsLinksBezienswaardigheden, PicureBoxsRechtsBezienswaardigheden, true);
        }

        private void LaadAlleKaarten()
        {
            switch (spelerLijst.Count)
            {
                case 2:
                    lb_OnderGeld.Text = spelerLijst[0].Geld.ToString();
                    lb_BovenGeld.Text = spelerLijst[1].Geld.ToString();
                    LaadKaartenOnder();
                    LaadKaartenBoven();
                    break;
                case 3:
                    lb_OnderGeld.Text = spelerLijst[0].Geld.ToString();
                    lb_LinksGeld.Text = spelerLijst[1].Geld.ToString();
                    lb_RechtsGeld.Text = spelerLijst[2].Geld.ToString();
                    LaadKaartenOnder();
                    LaadKaartenLinks();
                    LaadKaartenRechts();
                    break;
                default:
                    LaadAlleSpelerKaarten();
                    break;
            }
        }
        private void LaadAlleSpelerKaarten()
        {
            LaadKaartenOnder();
            LaadKaartenLinks();
            LaadKaartenBoven();
            LaadKaartenRechts();
        }
        private void LaadKaartenOnder()
        {
            string bestand;
            string filePath;
            for (int x = 0; x < spelendeSpeler.Gebouwen.Count; x++)
            {
                bestand = spelendeSpeler.Gebouwen[x].Naam;
                filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                PicureBoxsOnderKaarten[x].Image = Image.FromFile(filePath);
                PicureBoxsOnderKaarten[x].Show();
            }
            for (int x = 0; x < 4; x++)
            {
                bestand = BezienswaardighedenLijst[x].Naam;
                filePath = $"../../MK_kaarten/images/{bestand} (NG).jpg";
                PicureBoxsOnderBezienswaardigheden[x].Image = Image.FromFile(filePath);
                PicureBoxsOnderBezienswaardigheden[x].Show();
                foreach (Kaart Bezienswaardigheid in spelendeSpeler.Bezienswaardigheden)
                {
                    if (Bezienswaardigheid.Naam == BezienswaardighedenLijst[x].Naam)
                    {
                        bestand = Bezienswaardigheid.Naam;
                        filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                        PicureBoxsOnderBezienswaardigheden[x].Image = Image.FromFile(filePath);
                        PicureBoxsOnderBezienswaardigheden[x].Show();

                    }
                }
            }
        }
        private void LaadKaartenLinks()
        {
            for (int i = 0; i < spelerLijst.Count; i++)
            {
                for (int x = 0; x < spelerLijst[i].Gebouwen.Count; x++)
                {
                    string bestand = spelerLijst[i].Gebouwen[x].Naam;
                    string filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                    PicureBoxsLinksKaarten[x].Image = Image.FromFile(filePath);
                    PicureBoxsLinksKaarten[x].Show();
                }
            }
        }
        private void LaadKaartenBoven()
        {
            for (int i = 0; i < spelerLijst.Count; i++)
            {
                for (int x = 0; x < spelerLijst[i].Gebouwen.Count; x++)
                {
                    string bestand = spelerLijst[i].Gebouwen[x].Naam;
                    string filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                    PicureBoxsBovenKaarten[x].Image = Image.FromFile(filePath);
                    PicureBoxsBovenKaarten[x].Show();
                }
            }
        }
        private void LaadKaartenRechts()
        {
            for (int i = 0; i < spelerLijst.Count; i++)
            {
                for (int x = 0; x < spelerLijst[i].Gebouwen.Count; x++)
                {
                    string bestand = spelerLijst[i].Gebouwen[x].Naam;
                    string filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                    PicureBoxsRechtsKaarten[x].Image = Image.FromFile(filePath);
                    PicureBoxsRechtsKaarten[x].Show();
                }
            }
        }

        private Kaart HaalKaartOp(string _KaartNaam)
        {
            List<int> templist = new List<int>();
            foreach (Kaart kaart in kaartenLijst)
            {
                if (kaart.Naam == _KaartNaam)
                {
                    return kaart;
                }
            }
            return new Kaart("niks", 0, " ", "Failcard", 0, 0, templist);
        }
        private Kaart HaalBezienswaardigheidtOp(string _KaartNaam)
        {
            List<int> templist = new List<int>();
            foreach (Kaart kaart in BezienswaardighedenLijst)
            {
                if (kaart.Naam == _KaartNaam)
                {
                    return kaart;
                }
            }
            return new Kaart("niks", 0, " ", "Failcard", 0, 0, templist);
        }

        private void MaakTafel(int _SpelerAantal)
        {
            switch (_SpelerAantal)
            {
                case 2:
                    TweeSpelerScherm();
                    HideBezienswaardighedenZijkant();
                    break;
                case 3:
                    DrieSpelerScherm();
                    HideBezienswaardighedenBoven();
                    break;
                default:
                    break;
            }
        }
        private void HideBezienswaardighedenZijkant()
        {
            for (int i = 0; i < PicureBoxsLinksBezienswaardigheden.Count; i++)
            {
                PicureBoxsLinksBezienswaardigheden[i].Hide();
                PicureBoxsRechtsBezienswaardigheden[i].Hide();
            }
        }
        private void HideBezienswaardighedenBoven()
        {
            for (int i = 0; i < PicureBoxsLinksBezienswaardigheden.Count; i++)
            {
                PicureBoxsBovenBezienswaardigheden[i].Hide();
            }
        }
        private void HideAllPictureboxes()
        {
            for (int i = 0; i < PicureBoxsOnderKaarten.Count; i++)
            {
                PicureBoxsOnderKaarten[i].Hide();
                PicureBoxsLinksKaarten[i].Hide();
                PicureBoxsBovenKaarten[i].Hide();
                PicureBoxsRechtsKaarten[i].Hide();
            }
        }

        private void TweeSpelerScherm()
        {
            lb_BovenSpeler.Text = "Speler 2";

            lb_LinksSpeler.Hide();
            lb_LinksGeld.Hide();
            lb_RechtsSpeler.Hide();
            lb_RechtsGeld.Hide();
        }
        private void DrieSpelerScherm()
        {
            lb_RechtsSpeler.Text = "Speler 3";

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
                int spelerNummer = 1 + i;
                spelerLijst.Add(new Speler(spelerNummer));
            }
        }
        private void pb_Treinstation1_Click(object sender, EventArgs e)
        {
            if (spelendeSpeler.Geld >= BezienswaardighedenLijst[0].Prijs && heeftGedobbeld)
            {
                spelendeSpeler.Bezienswaardigheden.Add(HaalBezienswaardigheidtOp("Treinstation"));
                string bestand = BezienswaardighedenLijst[0].Naam;
                string filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                pb_treinstation1.Image = Image.FromFile(filePath);
                pb_treinstation1.Show();
                spelendeSpeler.Geld -= BezienswaardighedenLijst[0].Prijs;
                VolgendeRonden();
            }
        }
        private void pb_Winkelcentrum1_Click(object sender, EventArgs e)
        {
            if (spelendeSpeler.Geld >= BezienswaardighedenLijst[1].Prijs && heeftGedobbeld)
            {
                spelendeSpeler.Bezienswaardigheden.Add(HaalBezienswaardigheidtOp("Winkelcentrum"));
                string bestand = BezienswaardighedenLijst[1].Naam;
                string filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                pb_winkelcentrum1.Image = Image.FromFile(filePath);
                pb_winkelcentrum1.Show();
                spelendeSpeler.Geld -= BezienswaardighedenLijst[1].Prijs;
                VolgendeRonden();
            }
        }
        private void pb_Pretpark1_Click(object sender, EventArgs e)
        {
            if (spelendeSpeler.Geld >= BezienswaardighedenLijst[2].Prijs && heeftGedobbeld)
            {
                spelendeSpeler.Bezienswaardigheden.Add(HaalBezienswaardigheidtOp("Pretpark"));
                string bestand = BezienswaardighedenLijst[2].Naam;
                string filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                pb_pretpark1.Image = Image.FromFile(filePath);
                pb_pretpark1.Show();
                spelendeSpeler.Geld -= BezienswaardighedenLijst[2].Prijs;
                VolgendeRonden();
            }
        }
        private void pb_Radiostation1_Click(object sender, EventArgs e)
        {
            if (spelendeSpeler.Geld >= BezienswaardighedenLijst[3].Prijs && heeftGedobbeld)
            {
                spelendeSpeler.Bezienswaardigheden.Add(HaalBezienswaardigheidtOp("Radiostation"));
                string bestand = BezienswaardighedenLijst[3].Naam;
                string filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                pb_radiostation1.Image = Image.FromFile(filePath);
                pb_radiostation1.Show();
                spelendeSpeler.Geld -= BezienswaardighedenLijst[3].Prijs;
                VolgendeRonden();
            }
        }
        private void VolgendeRonden()
        {
            int volgendeNummer = spelendeSpeler.SpelerNummer - 1;
            if (volgendeNummer == 0)
            {
                switch (spelerLijst.Count)
                {
                    case 2:
                        volgendeNummer = 2;
                        break;
                    case 3:
                        volgendeNummer = 3;
                        break;
                    default:
                        volgendeNummer = 4;
                        break;
                }
            }
            foreach (Speler speler in spelerLijst)
            {
                speler.Positie = speler.Positie + 1;
                if (speler.Positie > spelerLijst.Count)
                {
                    speler.Positie = 1;
                }
            }

            foreach (Speler speler in spelerLijst)
            {
                if (speler.SpelerNummer == volgendeNummer)
                {
                    spelendeSpeler = speler;
                    heeftGedobbeld = false;
                    HideAllPictureboxes();
                    LaadKaartenOnder();
                    bt_dobbel.Visible = true;
                    btn_Kopen.Visible = false;
                    bt_volgendespeler.Visible = false;
                    lb_DobbelNummer.Visible = false;
                    ++ronde;

                    switch (spelerLijst.Count)
                    {
                        case 2:
                            WisselTweeSpelers();
                            break;
                        case 3:
                            WisselDrieSpelers();
                            break;
                        default:
                            WisselSpelers();
                            break;
                    }
                }
            }
        }
        private void WisselTweeSpelers()
        {
            string bestand;
            string filePath;
            foreach (Speler speler in spelerLijst)
            {

                if (speler != spelendeSpeler)
                {
                    for (int x = 0; x < speler.Gebouwen.Count; x++)
                    {
                        bestand = speler.Gebouwen[x].Naam;
                        filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                        PicureBoxsBovenKaarten[x].Image = Image.FromFile(filePath);
                        PicureBoxsBovenKaarten[x].Show();
                        lb_BovenGeld.Text = speler.Geld.ToString();
                        lb_BovenSpeler.Text = "Speler " + speler.SpelerNummer.ToString();
                    }
                    for (int x = 0; x < 4; x++)
                    {
                        if (x < speler.Bezienswaardigheden.Count && speler.Bezienswaardigheden[x].Naam == BezienswaardighedenLijst[x].Naam)
                        {
                            bestand = speler.Bezienswaardigheden[x].Naam;
                            filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                            PicureBoxsBovenBezienswaardigheden[x].Image = Image.FromFile(filePath);
                            PicureBoxsBovenBezienswaardigheden[x].Show();
                        }
                        else
                        {
                            bestand = BezienswaardighedenLijst[x].Naam;
                            filePath = $"../../MK_kaarten/images/{bestand} (NG).jpg";
                            PicureBoxsBovenBezienswaardigheden[x].Image = Image.FromFile(filePath);
                            PicureBoxsBovenBezienswaardigheden[x].Show();
                            foreach (Kaart Bezienswaardigheid in speler.Bezienswaardigheden)
                            {
                                if (Bezienswaardigheid.Naam == BezienswaardighedenLijst[x].Naam)
                                {
                                    bestand = Bezienswaardigheid.Naam;
                                    filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                                    PicureBoxsBovenBezienswaardigheden[x].Image = Image.FromFile(filePath);
                                    PicureBoxsBovenBezienswaardigheden[x].Show();

                                }
                            }
                        }
                    }
                    UpdateLabel();
                    break;
                }
            }
        }
        private void WisselDrieSpelers()
        {
            string bestand;
            string filePath;
            foreach (Speler speler in spelerLijst)
            {

                if (speler != spelendeSpeler)
                {
                    if (speler.Positie == 2)
                    {
                        for (int x = 0; x < speler.Gebouwen.Count; x++)
                        {
                            bestand = speler.Gebouwen[x].Naam;
                            filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                            PicureBoxsLinksKaarten[x].Image = Image.FromFile(filePath);
                            PicureBoxsLinksKaarten[x].Show();
                            lb_LinksGeld.Text = speler.Geld.ToString();
                            lb_LinksSpeler.Text = "Speler " + speler.SpelerNummer.ToString();
                        }
                        for (int x = 0; x < 4; x++)
                        {
                            bestand = BezienswaardighedenLijst[x].Naam;
                            filePath = $"../../MK_kaarten/images/{bestand} (NG).jpg";
                            PicureBoxsLinksBezienswaardigheden[x].Image = Image.FromFile(filePath);
                            PicureBoxsLinksBezienswaardigheden[x].Show();
                            foreach (Kaart Bezienswaardigheid in speler.Bezienswaardigheden)
                            {
                                if (Bezienswaardigheid.Naam == BezienswaardighedenLijst[x].Naam)
                                {
                                    bestand = Bezienswaardigheid.Naam;
                                    filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                                    PicureBoxsLinksBezienswaardigheden[x].Image = Image.FromFile(filePath);
                                    PicureBoxsLinksBezienswaardigheden[x].Show();

                                }
                            }
                        }
                    }
                    else if (speler.Positie == 3)
                    {
                        for (int x = 0; x < speler.Gebouwen.Count; x++)
                        {
                            bestand = speler.Gebouwen[x].Naam;
                            filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                            PicureBoxsRechtsKaarten[x].Image = Image.FromFile(filePath);
                            PicureBoxsRechtsKaarten[x].Show();
                            lb_RechtsGeld.Text = speler.Geld.ToString();
                            lb_RechtsSpeler.Text = "Speler " + speler.SpelerNummer.ToString();
                        }
                        for (int x = 0; x < 4; x++)
                        {
                            bestand = BezienswaardighedenLijst[x].Naam;
                            filePath = $"../../MK_kaarten/images/{bestand} (NG).jpg";
                            PicureBoxsRechtsBezienswaardigheden[x].Image = Image.FromFile(filePath);
                            PicureBoxsRechtsBezienswaardigheden[x].Show();
                            foreach (Kaart Bezienswaardigheid in speler.Bezienswaardigheden)
                            {
                                if (Bezienswaardigheid.Naam == BezienswaardighedenLijst[x].Naam)
                                {
                                    bestand = Bezienswaardigheid.Naam;
                                    filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                                    PicureBoxsRechtsBezienswaardigheden[x].Image = Image.FromFile(filePath);
                                    PicureBoxsRechtsBezienswaardigheden[x].Show();

                                }
                            }
                        }
                    }
                }
            }
            RotateCardsHorizontaal(PicureBoxsLinksKaarten, PicureBoxsRechtsKaarten, PicureBoxsLinksBezienswaardigheden, PicureBoxsRechtsBezienswaardigheden, true);
            UpdateLabel();
        }
        private void WisselSpelers()
        {
            string bestand;
            string filePath;
            foreach (Speler speler in spelerLijst)
            {

                if (speler != spelendeSpeler)
                {
                    if (speler.Positie == 2)
                    {
                        for (int x = 0; x < speler.Gebouwen.Count; x++)
                        {
                            bestand = speler.Gebouwen[x].Naam;
                            filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                            PicureBoxsLinksKaarten[x].Image = Image.FromFile(filePath);
                            PicureBoxsLinksKaarten[x].Show();
                            lb_LinksGeld.Text = speler.Geld.ToString();
                            lb_LinksSpeler.Text = "Speler " + speler.SpelerNummer.ToString();
                        }
                        for (int x = 0; x < 4; x++)
                        {
                            bestand = BezienswaardighedenLijst[x].Naam;
                            filePath = $"../../MK_kaarten/images/{bestand} (NG).jpg";
                            PicureBoxsLinksBezienswaardigheden[x].Image = Image.FromFile(filePath);
                            PicureBoxsLinksBezienswaardigheden[x].Show();
                            foreach (Kaart Bezienswaardigheid in speler.Bezienswaardigheden)
                            {
                                if (Bezienswaardigheid.Naam == BezienswaardighedenLijst[x].Naam)
                                {
                                    bestand = Bezienswaardigheid.Naam;
                                    filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                                    PicureBoxsLinksBezienswaardigheden[x].Image = Image.FromFile(filePath);
                                    PicureBoxsLinksBezienswaardigheden[x].Show();

                                }
                            }
                        }
                    }
                    else if (speler.Positie == 3)
                    {
                        for (int x = 0; x < speler.Gebouwen.Count; x++)
                        {
                            bestand = speler.Gebouwen[x].Naam;
                            filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                            PicureBoxsBovenKaarten[x].Image = Image.FromFile(filePath);
                            PicureBoxsBovenKaarten[x].Show();
                            lb_RechtsGeld.Text = speler.Geld.ToString();
                            lb_RechtsSpeler.Text = "Speler " + speler.SpelerNummer.ToString();
                        }
                        for (int x = 0; x < 4; x++)
                        {
                            bestand = BezienswaardighedenLijst[x].Naam;
                            filePath = $"../../MK_kaarten/images/{bestand} (NG).jpg";
                            PicureBoxsBovenBezienswaardigheden[x].Image = Image.FromFile(filePath);
                            PicureBoxsBovenBezienswaardigheden[x].Show();
                            foreach (Kaart Bezienswaardigheid in speler.Bezienswaardigheden)
                            {
                                if (Bezienswaardigheid.Naam == BezienswaardighedenLijst[x].Naam)
                                {
                                    bestand = Bezienswaardigheid.Naam;
                                    filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                                    PicureBoxsBovenBezienswaardigheden[x].Image = Image.FromFile(filePath);
                                    PicureBoxsBovenBezienswaardigheden[x].Show();

                                }
                            }
                        }
                    }
                    else if (speler.Positie == 4)
                    {
                        for (int x = 0; x < speler.Gebouwen.Count; x++)
                        {
                            bestand = speler.Gebouwen[x].Naam;
                            filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                            PicureBoxsRechtsKaarten[x].Image = Image.FromFile(filePath);
                            PicureBoxsRechtsKaarten[x].Show();
                            lb_RechtsGeld.Text = speler.Geld.ToString();
                            lb_RechtsSpeler.Text = "Speler " + speler.SpelerNummer.ToString();
                        }
                        for (int x = 0; x < 4; x++)
                        {
                            foreach (Kaart Bezienswaardigheid in speler.Bezienswaardigheden)
                            {
                                bestand = BezienswaardighedenLijst[x].Naam;
                                filePath = $"../../MK_kaarten/images/{bestand} (NG).jpg";
                                PicureBoxsRechtsBezienswaardigheden[x].Image = Image.FromFile(filePath);
                                PicureBoxsRechtsBezienswaardigheden[x].Show();
                                if (Bezienswaardigheid.Naam == BezienswaardighedenLijst[x].Naam)
                                {
                                    bestand = Bezienswaardigheid.Naam;
                                    filePath = $"../../MK_kaarten/images/{bestand}.jpg";
                                    PicureBoxsRechtsBezienswaardigheden[x].Image = Image.FromFile(filePath);
                                    PicureBoxsRechtsBezienswaardigheden[x].Show();

                                }
                            }
                        }
                    }
                }
            }
            RotateCardsHorizontaal(PicureBoxsLinksKaarten, PicureBoxsRechtsKaarten, PicureBoxsLinksBezienswaardigheden, PicureBoxsRechtsBezienswaardigheden, true);
            UpdateLabel();
        }
        public void checkGeld()
        {

            foreach (Kaart kaart in spelendeSpeler.Gebouwen)
            {
                //SPELER CHECK HIERBOVEN
                switch (kaart.Kleur)
                {
                    case "groen":
                        CheckGroen(kaart, spelendeSpeler);
                        break;
                    case "blauw":
                        CheckBlauw(kaart, spelendeSpeler);
                        break;
                    case "paars":
                        CheckPaars(kaart, spelendeSpeler);
                        break;
                    default:
                        break;
                }
            }
            foreach (Speler speler in spelerLijst)
            {
                if (speler != spelendeSpeler)
                {
                    foreach (Kaart kaart in speler.Gebouwen)
                    {

                        //SPELER CHECK HIERBOVEN
                        switch (kaart.Kleur)
                        {
                            case "rood":
                                CheckRood(kaart, speler);
                                break;
                            case "blauw":
                                CheckBlauw(kaart, speler);
                                break;
                            default:
                                break;

                        }
                    }
                }
            }
            heeftGedobbeld = true;
            bt_dobbel.Visible = false;
            btn_Kopen.Visible = true;
            bt_volgendespeler.Visible = true;
            lb_DobbelNummer.Visible = true;
            UpdateLabel();
        }

        private void CheckGroen(Kaart _Kaart, Speler _Speler)
        {
            foreach (int waarde in _Kaart.Waarde)
            {
                if (waarde == rndNummer)
                {
                    switch (_Kaart.Naam)
                    {
                        case "Groente- en fruitmarkt":
                            GroentenEnFruit(_Speler);
                            break;
                        case "Kaasfabriek":
                            Kaasfabriek(_Speler);
                            break;
                        case "Meubelfabriek":
                            Meubelfabriek(_Speler);
                            break;
                        default:
                            _Speler.Geld = _Speler.Geld + _Kaart.BetalingsWaarde;
                            break;
                    }
                }
            }
        }
        private void Kaasfabriek(Speler _speler)
        {
            foreach (Kaart kaart in kaartenLijst)
            {
                if (kaart.Naam == "Veehouderij")
                {
                    _speler.Geld = _speler.Geld + kaart.Hoeveelheid * 3;
                    break;
                }
            }
        }
        private void Meubelfabriek(Speler _speler)
        {
            foreach (Kaart kaart in kaartenLijst)
            {
                if (kaart.Naam == "Bos" || kaart.Naam == "Mijn")
                {
                    _speler.Geld = _speler.Geld + kaart.Hoeveelheid * 3;
                }
            }
        }
        private void GroentenEnFruit(Speler _speler)
        {
            foreach (Kaart kaart in kaartenLijst)
            {
                if (kaart.Naam == "Graanveld")
                {
                    _speler.Geld = _speler.Geld + kaart.Hoeveelheid * 2;
                    break;
                }
            }
        }

        private void CheckBlauw(Kaart _Kaart, Speler _Speler)
        {
            if (_Kaart.Waarde[0] >= rndNummer)
            {
                _Speler.Geld = _Speler.Geld + _Kaart.BetalingsWaarde;
            }
        }
        private void CheckPaars(Kaart _Kaart, Speler _Speler)
        {
            switch (_Kaart.Naam)
            {
                case "TV-station":
                    TvStation(_Speler);
                    break;
                case "Stadium":
                    Stadium(_Speler);
                    break;
            }
        }
        private void TvStation(Speler _Speler)
        {
            List<Speler> tempSpelerLijst = new List<Speler>();
            foreach (Speler speler in spelerLijst)
            {
                if (speler != _Speler)
                {
                    tempSpelerLijst.Add(speler);
                }
            }
            int tempNum = new Random().Next(tempSpelerLijst.Count);
            foreach (Speler speler in tempSpelerLijst)
            {
                if (speler.Geld < 5)
                {
                    spelendeSpeler.Geld = spelendeSpeler.Geld + speler.Geld;
                    speler.Geld = speler.Geld - speler.Geld;
                }
                else
                {
                    spelendeSpeler.Geld = spelendeSpeler.Geld + 5;
                    speler.Geld = speler.Geld - 5;
                }
            }
        }
        private void Stadium(Speler _Speler)
        {
            foreach (Speler speler in spelerLijst)
            {
                if (speler != _Speler)
                {
                    if (speler.Geld < 2)
                    {
                        spelendeSpeler.Geld = spelendeSpeler.Geld + speler.Geld;
                        speler.Geld = speler.Geld - speler.Geld;
                    }
                    else
                    {
                        spelendeSpeler.Geld = spelendeSpeler.Geld + 2;
                        speler.Geld = speler.Geld - 2;
                    }
                }
            }
        }
        private void CheckRood(Kaart _Kaart, Speler _Speler)
        {
            foreach (int waarde in _Kaart.Waarde)
            {
                if (waarde == rndNummer)
                {
                    if (spelendeSpeler.Geld > _Kaart.BetalingsWaarde)
                    {
                        spelendeSpeler.Geld = spelendeSpeler.Geld - _Kaart.BetalingsWaarde;  //<---speler aan de beurt. 
                        _Speler.Geld = _Speler.Geld + _Kaart.BetalingsWaarde; //<---speler die rode kaart heeft
                    }
                    else
                    {
                        _Speler.Geld = _Speler.Geld + spelendeSpeler.Geld; //<---speler die rode kaart heeft
                        spelendeSpeler.Geld = spelendeSpeler.Geld - spelendeSpeler.Geld;  //<---speler aan de beurt. 
                    }
                }
            }
        }
        private void UpdateLabel()
        {
            switch (spelerLijst.Count)
            {
                case 2:
                    UpdateLabelTweeSpelers();
                    break;
                case 3:
                    UpdateLabelDrieSpelers();
                    break;
                default:
                    UpdateLabelVierSpelers();
                    break;
            }
        }
        private void UpdateLabelVierSpelers()
        {
            foreach (Speler speler in spelerLijst)
            {
                switch (speler.Positie)
                {
                    case 1:
                        lb_OnderGeld.Text = speler.Geld.ToString();
                        lb_OnderSpeler.Text = "Speler " + speler.SpelerNummer.ToString();
                        break;
                    case 2:
                        lb_LinksGeld.Text = speler.Geld.ToString();
                        lb_LinksSpeler.Text = "Speler " + speler.SpelerNummer.ToString();
                        break;
                    case 3:
                        lb_BovenGeld.Text = speler.Geld.ToString();
                        lb_BovenSpeler.Text = "Speler " + speler.SpelerNummer.ToString();
                        break;
                    case 4:
                        lb_RechtsGeld.Text = speler.Geld.ToString();
                        lb_RechtsSpeler.Text = "Speler " + speler.SpelerNummer.ToString();
                        break;
                }
            }
        }
        private void UpdateLabelDrieSpelers()
        {
            foreach (Speler speler in spelerLijst)
            {
                switch (speler.Positie)
                {
                    case 1:
                        lb_OnderGeld.Text = speler.Geld.ToString();
                        lb_OnderSpeler.Text = "Speler " + speler.SpelerNummer.ToString();
                        break;
                    case 2:
                        lb_LinksGeld.Text = speler.Geld.ToString();
                        lb_LinksSpeler.Text = "Speler " + speler.SpelerNummer.ToString();
                        break;
                    case 3:
                        lb_RechtsGeld.Text = speler.Geld.ToString();
                        lb_RechtsSpeler.Text = "Speler " + speler.SpelerNummer.ToString();
                        break;
                }
            }
        }
        private void UpdateLabelTweeSpelers()
        {
            foreach (Speler speler in spelerLijst)
            {
                switch (speler.Positie)
                {
                    case 1:
                        lb_OnderGeld.Text = speler.Geld.ToString();
                        lb_OnderSpeler.Text = "Speler " + speler.SpelerNummer.ToString();
                        break;
                    case 2:
                        lb_BovenGeld.Text = speler.Geld.ToString();
                        lb_BovenSpeler.Text = "Speler " + speler.SpelerNummer.ToString();
                        break;
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void bt_dobbel_Click(object sender, EventArgs e)
        {
            heeftGedobbeld = true;
            Random rnd = new Random();
            rndNummer = rnd.Next(1, 7);
            bt_volgendespeler.Enabled = true;
            btn_Kopen.Enabled = true;
            lb_DobbelNummer.Text = rndNummer.ToString();
            checkGeld();
        }

        private void bt_volgendespeler_Click(object sender, EventArgs e)
        {
            VolgendeRonden();
        }

        private void btn_Kopen_Click(object sender, EventArgs e)
        {
            KoopScherm koopscherm = new KoopScherm(spelendeSpeler, kaartenLijst);
            this.Hide();
            koopscherm.ShowDialog();
            this.Show();
            if (koopscherm.gekocht)
            {
                VolgendeRonden();
            }
        }
        /// <summary>
        /// Functie om de linker en rechter picture box te draaien
        /// </summary>
        /// <param name="_Picturebox1">kaarten van de linker speler</param>
        /// <param name="_Picturebox2">kaarten van de rechter speler</param>
        private void RotateCardsHorizontaal(List<PictureBox> _Picturebox1, List<PictureBox> _Picturebox2, List<PictureBox> _Picturebox3, List<PictureBox> _Picturebox4, bool rotateBezienswaardigheden)
        {
            for (int i = 0; i < _Picturebox1.Count; i++)
            {
                _Picturebox1[i].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                _Picturebox1[i].Refresh();
                _Picturebox2[i].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                _Picturebox2[i].Refresh();
            }
            if (rotateBezienswaardigheden)
            {
                for (int i = 0; i < _Picturebox3.Count; i++)
                {
                    _Picturebox3[i].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    _Picturebox3[i].Refresh();
                    _Picturebox4[i].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    _Picturebox4[i].Refresh();
                }
            }
        }
        /// <summary>
        /// Method om de lijsten te vullen met alle horizontale en alle verticale picture boxes
        /// </summary>
        private void LijstMakenPicureBoxes()
        {
            //onder speler
            PicureBoxsOnderKaarten.Add(pb_OnderSpeler3);
            PicureBoxsOnderKaarten.Add(pb_OnderSpeler2);
            PicureBoxsOnderKaarten.Add(pb_OnderSpeler4);
            PicureBoxsOnderKaarten.Add(pb_OnderSpeler1);
            PicureBoxsOnderKaarten.Add(pb_OnderSpeler5);
            PicureBoxsOnderBezienswaardigheden.Add(pb_treinstation1);
            PicureBoxsOnderBezienswaardigheden.Add(pb_winkelcentrum1);
            PicureBoxsOnderBezienswaardigheden.Add(pb_pretpark1);
            PicureBoxsOnderBezienswaardigheden.Add(pb_radiostation1);

            //links speler
            PicureBoxsLinksKaarten.Add(pb_LinksSpeler3);
            PicureBoxsLinksKaarten.Add(pb_LinksSpeler2);
            PicureBoxsLinksKaarten.Add(pb_LinksSpeler4);
            PicureBoxsLinksKaarten.Add(pb_LinksSpeler1);
            PicureBoxsLinksKaarten.Add(pb_LinksSpeler5);
            PicureBoxsLinksBezienswaardigheden.Add(pb_treinstation2);
            PicureBoxsLinksBezienswaardigheden.Add(pb_winkelcentrum2);
            PicureBoxsLinksBezienswaardigheden.Add(pb_pretpark2);
            PicureBoxsLinksBezienswaardigheden.Add(pb_radiostation2);

            //boven speler
            PicureBoxsBovenKaarten.Add(pb_BovenSpeler3);
            PicureBoxsBovenKaarten.Add(pb_BovenSpeler2);
            PicureBoxsBovenKaarten.Add(pb_BovenSpeler4);
            PicureBoxsBovenKaarten.Add(pb_BovenSpeler1);
            PicureBoxsBovenKaarten.Add(pb_BovenSpeler5);
            PicureBoxsBovenBezienswaardigheden.Add(pb_treinstation3);
            PicureBoxsBovenBezienswaardigheden.Add(pb_winkelcentrum3);
            PicureBoxsBovenBezienswaardigheden.Add(pb_pretpark3);
            PicureBoxsBovenBezienswaardigheden.Add(pb_radiostation3);

            //rechts speler
            PicureBoxsRechtsKaarten.Add(pb_RechtsSpeler3);
            PicureBoxsRechtsKaarten.Add(pb_RechtsSpeler2);
            PicureBoxsRechtsKaarten.Add(pb_RechtsSpeler4);
            PicureBoxsRechtsKaarten.Add(pb_RechtsSpeler1);
            PicureBoxsRechtsKaarten.Add(pb_RechtsSpeler5);
            PicureBoxsRechtsBezienswaardigheden.Add(pb_treinstation4);
            PicureBoxsRechtsBezienswaardigheden.Add(pb_winkelcentrum4);
            PicureBoxsRechtsBezienswaardigheden.Add(pb_pretpark4);
            PicureBoxsRechtsBezienswaardigheden.Add(pb_radiostation4);
        }
    }
}
