using NHunspell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Affine_Code
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Logic logic;
        public MainWindow()
        {
            InitializeComponent();
            logic = new Logic();
        }

        private void ENCODE_Click(object sender, RoutedEventArgs e)
        {
            txtOutputEncode.Text =  logic.Encipher(txtInputEncode.Text,Convert.ToInt32(txtAlphaEncode.Text),Convert.ToInt32(txtBetaEncode.Text));
        }

        private void DECODE_Click(object sender, RoutedEventArgs e)
        {
            txtOutputDecode.Text =  logic.Decipher(txtInputDecode.Text, Convert.ToInt32(txtAlphaDecode.Text), Convert.ToInt32(txtBetaDecode.Text));
        }

        private void EncodeText_Click(object sender, RoutedEventArgs e)
        {
            logic.ReadEncodeWrite(5, 8);
        }
        private  void DecodeText_Click(object sender, RoutedEventArgs e)
        {
            txtOutKeyTry.Text = logic.Decode().ToString();
        }
    }
}
