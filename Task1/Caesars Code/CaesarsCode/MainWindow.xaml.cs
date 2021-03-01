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

namespace CaesarsCode
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
            txtOutputEncode.Text = logic.Encipher(txtInputEncode.Text,Int32.Parse(txtInputKey.Text));
        }

        private void DECODE_Click(object sender, RoutedEventArgs e)
        {
            txtOutputDecode.Text = logic.Decipher(txtInputDecode.Text, Int32.Parse(txtInputKeyDecode.Text));
        }

        private void ReadEncode_Click(object sender, RoutedEventArgs e)
        {
            var rand = new Random();
            logic.ReadEncodeWrite(rand.Next(26));
        }

        private void ReadDecode_Click(object sender, RoutedEventArgs e)
        {
            txtAlpabetChanges.Text = "";
            List<string> lst = new List<string>();
            lst = logic.ReadTextLst();
            Dictionary<Char, int> dic = new Dictionary<char, int>();
            dic = logic.GetLettersEntrence(lst);
            var sortedDict = from entry in dic orderby entry.Value descending select entry;

            string[] arr = new string[] { "e", "t", "i", "a", "o", "n", "s", "r", "h", "c", "l", "d", "p", "y", "u", "m", "f", "b", "g", "w", "v", "k", "x", "q", "z", "j" };

            int amount_of_letters = 0;
            foreach(var elem in sortedDict)
            {
                amount_of_letters += elem.Value;
            }

            for(int i = 0; i < 26; i++)
            {
                txtAlpabetChanges.Text += sortedDict.ElementAt(i).Key + "  --   " + sortedDict.ElementAt(i).Value + " -- " + String.Format("{0:0.00}", (sortedDict.ElementAt(i).Value * 100.0 / amount_of_letters)) + " %     ------   " + arr[i] + "\n";
            }

            txtPercent.Text = String.Format("{0:0.00}", logic.SpellChecker().ToString());

            txtOutKeyTry.Text = logic.Decode().ToString();
        }
    }
}
