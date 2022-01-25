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
    public partial class InitScherm : Form
    {
        int AantalSpelers, AantalAi;
        public InitScherm()
        {
            InitializeComponent();
        }

        private void btn_Begin_Click(object sender, EventArgs e)
        {
            AantalSpelers = DropdownToInt(cmb_SpelerAantal.Text);
            AantalAi = DropdownToInt(cmb_AiAantal.Text);
            this.Close();
        }
        /// <summary>
        /// Converts the dropdown text to an int by removing the text
        /// </summary>
        /// <param name="_Text">The text value of the dropdown menu</param>
        /// <returns></returns>
        private int DropdownToInt(string _Text)
        {
            string[] words = _Text.Split(' ');
            return Int32.Parse(words[0]);
        }
    }
}
