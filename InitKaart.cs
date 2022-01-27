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
        string filePath = @"C:\Users\Roelp\source\repos\casus-week-10---20";
        public List<Kaart> KaartenLijst = new List<Kaart>();

        List<string> Lines = new List<string>();
        public InitKaart()
        {
            Lines = File.ReadAllLines(filePath).ToList();
            foreach (var Line in Lines)
            {
                string[] entries = Line.Split(',');
                List<int> TempList = new List<int>();
                if (entries.Length < 6)
                {
                    TempList.Add(Int32.Parse(entries[4]));
                }
                else 
                {
                    TempList.Add(Int32.Parse(entries[4]));
                    TempList.Add(Int32.Parse(entries[5]));
                }
                Kaart newKaart = new Kaart(entries[0], Int32.Parse(entries[1]), entries[2], entries[3], TempList );

                KaartenLijst.Add(newKaart);
            }
        }
    }
}