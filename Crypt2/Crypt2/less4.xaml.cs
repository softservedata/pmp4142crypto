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
    /// Логика взаимодействия для less4.xaml
    /// </summary>
    public partial class less4 : Window
    {
        Les4 logic2;
        int n;
        public less4()
        {
            InitializeComponent();
            logic2 = new Les4();
            n = 0;
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


            tb3.Text = logic2.Encipher(tb2.Text , Convert.ToInt32(n) );
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tb3.Text = "";
            string n = tb1.Text;


            tb3.Text = logic2.Decipher(tb2.Text, Convert.ToInt32(n));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();


            list = logic2.ReadText(@"data1.txt");
            n = logic2.ReadN(@"data3.txt");
            foreach (string elem in list)
            {
                list2.Add(logic2.Decipher(elem,n));
            }
            logic2.WriteResult(list2);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();


            list = logic2.ReadText2(@"data2.txt");
            n = logic2.ReadN(@"data3.txt");
            foreach (string elem in list)
            {
                list2.Add(logic2.Encipher(elem, n));
            }
            logic2.WriteResult(list2);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            tb1.Text = Convert.ToString(logic2.ReadN(@"data3.txt"));
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
