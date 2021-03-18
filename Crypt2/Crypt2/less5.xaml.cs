using Crypt2.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Crypt2
{
    /// <summary>
    /// Логика взаимодействия для less5.xaml
    /// </summary>
    public partial class less5 : Window
    {
        Les6 Logic4;
        private byte[] cipherText;
        public less5()
        {
            InitializeComponent();
            Logic4 = new Les6();

        }

        private void sf_Click(object sender, RoutedEventArgs e)
        {
            List<string> a = new List<string>();
            a.Add(tb3.Text);
            Logic4.WriteResult(a);
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            tb.Text = "";
            tb.Text = Logic4.ReadN(@"inputkey.txt");
        }

        private void sk_Click(object sender, RoutedEventArgs e)
        {

            List<string> a = new List<string>();
            a.Add(tb.Text);
            Logic4.WriteKey(a);
            tb.Text = "";
        }

        private void en_Click(object sender, RoutedEventArgs e)
        {
            var cipher = new VigenereCipher("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            string key, inputText;
            try
            {
                key = tb.Text.ToUpper();
                inputText = tb2.Text.ToUpper();
            }
            catch
            {
                return;
            }
            tb3.Text = cipher.Encrypt(inputText, key);
        }

        private void op_Click(object sender, RoutedEventArgs e)
        {

            foreach (var a in Logic4.ReadText("a"))
                tb2.Text += a;
        }

        private void de_Click(object sender, RoutedEventArgs e)
        {
            var cipher = new VigenereCipher("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            string kay, inputText;
            try
            {
                kay = tb.Text.ToUpper();
                inputText = tb2.Text.ToUpper();
            }
            catch
            {
                return;
            }
            tb3.Text = cipher.Decrypt(inputText, kay);
        }

        private void tb2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
