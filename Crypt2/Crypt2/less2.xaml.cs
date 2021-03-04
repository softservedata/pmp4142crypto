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
    /// Логика взаимодействия для less2.xaml
    /// </summary>
    public partial class less2 : Window
    {
        Les2 logic2;
        public less2()
        {
            logic2 = new Les2();
            InitializeComponent();
        }

      

        private void tb4_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tb3.Text = "";
            string n = tb1.Text;
            string n1 = tb4.Text;

            tb3.Text = logic2.AffineEncrypt(tb2.Text, Convert.ToInt32(n),Convert.ToInt32(n1));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tb3.Text = "";
            string n = tb1.Text;
            string n1 = tb4.Text;

            tb3.Text = logic2.AffineDecrypt(tb2.Text, Convert.ToInt32(n), Convert.ToInt32(n1));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();


            list = logic2.ReadText(@"data1.txt");
            int n = logic2.ReadN(@"data3.txt");
            int n1 = logic2.ReadN1(@"data4.txt");
            foreach (string elem in list)
            {
                list2.Add(logic2.AffineDecrypt(elem, Convert.ToInt32(n), Convert.ToInt32(n1)));
            }
            logic2.WriteResult(list2);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();


            list = logic2.ReadText2(@"data2.txt");
            int n = logic2.ReadN(@"data3.txt");
            int n1 = logic2.ReadN1(@"data4.txt");
            foreach (string elem in list)
            {
                list2.Add(logic2.AffineEncrypt(elem, Convert.ToInt32(n), Convert.ToInt32(n1)));
            }
            logic2.WriteResult(list2);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            tb1.Text = "";
            tb4.Text = "";
            tb1.Text = Convert.ToString(logic2.ReadN(@"data3.txt"));
            tb4.Text = Convert.ToString(logic2.ReadN1(@"data4.txt"));
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();
            list.Add(tb3.Text);
            logic2.WriteResult(list);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();
            list = logic2.ReadText(@"data1.txt");
            tb2.Text = "";
            foreach (string s in list)
            {
                tb2.Text += s;
            }
        }
    }
}
