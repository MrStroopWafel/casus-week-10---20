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
            Application.Run(new StartPagina());
            InitScherm initscherm = new InitScherm();
            Application.Run(initscherm);
            //Application.Run(new BordScherm(StartPagina.settings, InitScherm);
        }
    }
}
