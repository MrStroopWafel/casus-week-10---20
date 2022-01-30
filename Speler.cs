using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machi_Koro
{
    internal class Speler
    {
        public int Geld, SpelerNummer, Positie;
        public List<Kaart> Bezienswaardigheden = new List<Kaart>();
        public List<Kaart> Gebouwen = new List<Kaart>();

        public Speler(int _SpelerNummer)
        {
            Geld = 23;
            SpelerNummer = _SpelerNummer;
            Positie = _SpelerNummer;
        }
    }
}