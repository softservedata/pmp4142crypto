using Crypt2.DAL;
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
using System.Windows.Shapes;

namespace Crypt2
{
    /// <summary>
    /// Логика взаимодействия для less6.xaml
    /// </summary>
    public partial class less6 : Window
    {
        Les6 logic6;
        public List<string> a;
        public less6()
        {
            InitializeComponent();
            logic6 = new Les6();
            a = new List<string>();
        }



        private void tb1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void key1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void key2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void num1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void num2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void it_Click(object sender, RoutedEventArgs e)
        {
            tb1.Text = "";
            foreach (var a in logic6.ReadText("a"))
                tb1.Text += a;
        }

        private void et_Click(object sender, RoutedEventArgs e)
        {
            List<string> a = new List<string>();
            a.Add(tb2.Text);
            logic6.WriteResult(a);
        }

        private void ik_Click(object sender, RoutedEventArgs e)
        {
            num1.Text = "";
            num1.Text = logic6.ReadN(@"inputkey.txt");
            num2.Text = "";
            num2.Text = logic6.ReadN1(@"inputkey1.txt");
        }

        private void ek_Click(object sender, RoutedEventArgs e)
        {
            List<string> a = new List<string>();
            List<string> b = new List<string>();
            a.Add(num1.Text);
            logic6.WriteKey(a);
            num1.Text = "";
            b.Add(num2.Text);
            logic6.WriteKey1(b);
            num2.Text = "";
        }

        private void en_Click(object sender, RoutedEventArgs e)
        {
            tb2.Text = "";
            if ((num1.Text.Length > 0) && (num2.Text.Length > 0))
            {
                long p = Convert.ToInt64(num1.Text);
                long q = Convert.ToInt64(num2.Text);

                if (logic6.IsTheNumberSimple(p) && logic6.IsTheNumberSimple(q))
                {
                    string s = "";

                    s = tb1.Text;
                    s = s.ToUpper();

                    long n = p * q;
                    long m = (p - 1) * (q - 1);
                    long d = logic6.Calculate_d(m);
                    long e_ = logic6.Calculate_e(d, m);

                    List<string> result = logic6.RSA_Endoce(s, e_, n);

                    List<string> a = new List<string>();
                    foreach (string item in result)
                    {
                        tb2.Text += item + " ";

                    }
                    this.a = result;


                    key1.Text = d.ToString();
                    key2.Text = n.ToString();


                }
                else
                    MessageBox.Show("p або q - не прості числа!");
            }
            else
                MessageBox.Show("Введіть p і q!");

        }




        private void de_Click(object sender, RoutedEventArgs e)
        {
            
            if ((key1.Text.Length > 0) && (key2.Text.Length > 0))
            {
                long d = Convert.ToInt64(key1.Text);
                long n = Convert.ToInt64(key2.Text);

                List<string> input = new List<string>();

                string b = "";
                foreach (char item in tb2.Text)
                {
                    if (item == ' ')
                    {
                        input.Add(b);
                        b = "";
                    }
                    else
                    {
                        b += Convert.ToString(item);
                    }
                    
                }



                string result = logic6.RSA_Dedoce(input, d, n);

                tb1.Text = result;
            }
            else
                MessageBox.Show("Введіть секретний ключ!");
        }

        private void ck_Click(object sender, RoutedEventArgs e)
        {
            
            num1.Text = logic6.CreateKey();
           
        }

       

        private void ck2_Click(object sender, RoutedEventArgs e)
        {
            num2.Text = logic6.CreateKey();
        }
    }
}
