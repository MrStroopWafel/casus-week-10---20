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
        public int Prijs, BetalingsWaarde;
        public List<int> Waarde = new List<int>();
        //public picture;

        public Kaart(string _Kleur, int _Prijs, string _Tekst,string _Naam, int _BetalingsWaarde, List<int> _Waarde)
        {
            Kleur = _Kleur;
            Prijs = _Prijs;
            Tekst = _Tekst;
            Naam = _Naam;
            Waarde = _Waarde;
            BetalingsWaarde = _BetalingsWaarde;
        }
        public Kaart KaartUitdelen()
        {
            Kaart kaart = new Kaart(Kleur, Prijs, Tekst, Naam, BetalingsWaarde, Waarde);
            return kaart;
        }
    }
}
