using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Machi_Koro
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StartPagina startPagina = new StartPagina();
            Application.Run(startPagina);
            if (startPagina.StartGame)
            {
                InitScherm initscherm = new InitScherm();
                Application.Run(initscherm);
                if (initscherm.StartGame)
                {
                    //Application.Run(new TafelScherm()); //(StartPagina.settings, InitScherm);
                }
            }
        }
    }
}
