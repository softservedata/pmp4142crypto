using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cipher
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void buttonCaesar_Click(object sender, EventArgs e)
        {
            Caesar caesar = new Caesar();
            caesar.ShowDialog();
        }

        private void buttonAthenian_Click(object sender, EventArgs e)
        {
            Athenian athenian = new Athenian();
            athenian.ShowDialog();
        }

        private void buttonCardano_Click(object sender, EventArgs e)
        {
            Cardano cardano = new Cardano();
            cardano.ShowDialog();
        }

        private void buttonChastokola_Click(object sender, EventArgs e)
        {
            Chastokola chastokola = new Chastokola();
            chastokola.ShowDialog();
        }

        private void buttonWiegener_Click(object sender, EventArgs e)
        {
            Wiegener wiegener = new Wiegener();
            wiegener.ShowDialog();
        }

        private void buttonRSA_Click(object sender, EventArgs e)
        {
            RSA rsa = new RSA();
            rsa.ShowDialog();
        }
    }
}
