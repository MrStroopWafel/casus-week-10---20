using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machi_Koro
{
    internal class Kaart
    {
        public string Kleur, Tekst, Naam;
        public int Prijs, BetalingsWaarde, Hoeveelheid;
        public List<int> Waarde = new List<int>();
        public string filePath = @"../../MK_kaarten/images/";
        public string fileType = @".jpg";
        //public picture;

        public Kaart(string _Kleur, int _Prijs, string _Tekst, string _Naam, int _BetalingsWaarde, int _Hoeveelheid, List<int> _Waarde)
        {
            Kleur = _Kleur;
            Prijs = _Prijs;
            Tekst = _Tekst;
            Naam = _Naam;
            BetalingsWaarde = _BetalingsWaarde;
            Hoeveelheid = _Hoeveelheid;
            Waarde = _Waarde;

        }
        public Kaart KaartUitdelen()
        {
            Kaart kaart = new Kaart(Kleur, Prijs, Tekst, Naam, BetalingsWaarde, Hoeveelheid, Waarde);
            return kaart;
        }
    }
}
