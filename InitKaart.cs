using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Machi_Koro
{
    class InitKaart
    {
        string filePath = @"../../kaarten.txt";
        public List<Kaart> KaartenLijst = new List<Kaart>();
        public List<Kaart> BezienswaardighedenLijst = new List<Kaart>();

        List<string> Lines = new List<string>();

        //public Kaart newKaart;

        public InitKaart()
        {
            int i = 0;
            Lines = File.ReadAllLines(filePath).ToList();
            foreach (var Line in Lines)
            {
                string[] entries = Line.Split(',');
                List<int> TempList = new List<int>();

                if (entries.Length < 8)
                {
                    TempList.Add(Int32.Parse(entries[6]));
                }
                else
                {
                    TempList.Add(Int32.Parse(entries[6]));
                    TempList.Add(Int32.Parse(entries[7]));
                }

                if (entries[0] == "grijs")
                {
                    TempList.Clear();
                    TempList.Add(99);
                }

                Kaart newKaart = new Kaart(entries[0], Int32.Parse(entries[1]), entries[2], entries[3], Int32.Parse(entries[4]), Int32.Parse(entries[5]), TempList);
                KaartenLijst.Add(newKaart);
                if (Int32.Parse(entries[4]) < 89)
                {
                    KaartenLijst.Add(newKaart);
                }
                else
                {
                    BezienswaardighedenLijst.Add(newKaart);
                }
            }
        }
    }
}