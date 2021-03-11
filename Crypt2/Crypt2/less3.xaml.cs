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
    /// Логика взаимодействия для less3.xaml
    /// </summary>
    public partial class less3 : Window
    {
        Les3 logic2;
        public less3()
        {
            InitializeComponent();
            logic2 = new Les3();
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
            int[] n1 = new int[4];
            for (int i = 0; i < 4; i++)
            {
                n1[i] = 0;
            }
            int a = tb1.Text.Length;
            int j = 0;
            List<char> b = tb1.Text.ToList();
            foreach ( var elem in b)
            {
                n1[j] = Convert.ToInt32(Convert.ToString(elem));
                
                j++;
            }
            
            tb3.Text += logic2.Encipher(tb2.Text, n1);
            
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tb3.Text = "";
            string n = tb1.Text;
            int[] n1 = new int[4];
            for (int i = 0; i < 4; i++)
            {
                n1[i] = 0;
            }
            int a = tb1.Text.Length;
            int j = 0;
            List<char> b = tb1.Text.ToList();
            foreach (var elem in b)
            {
                n1[j] = Convert.ToInt32(Convert.ToString(elem));

                j++;
            }

            tb3.Text = logic2.Decipher(tb2.Text, n1);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();


            list = logic2.ReadText(@"data1.txt");
            int n = logic2.ReadN(@"data3.txt");
            string N = Convert.ToString(n);
            int[] n1 = new int[4];
            for (int i = 0; i < 4; i++)
            {
                n1[i] = 0;
            }
            int a = tb1.Text.Length;
            int j = 0;
            List<char> b = N.ToList();
            foreach (var elem in b)
            {
                n1[j] = Convert.ToInt32(Convert.ToString(elem));

                j++;
            }
            foreach (string elem in list)
            {
                list2.Add(logic2.Decipher(elem, n1));
            }
            logic2.WriteResult(list2);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();


            list = logic2.ReadText2(@"data2.txt");
            int n = logic2.ReadN(@"data3.txt");
            string N = Convert.ToString(n);
            int[] n1 = new int[4];
            for (int i = 0; i < 4; i++)
            {
                n1[i] = 0;
            }
            int a = tb1.Text.Length;
            int j = 0;
            List<char> b = N.ToList();
            foreach (var elem in b)
            {
                n1[j] = Convert.ToInt32(Convert.ToString(elem));

                j++;
            }
            string s="";
            foreach (string elem in list)
            {
                s += elem;
            }
            list2.Add(logic2.Encipher(s, n1));
            logic2.WriteResult(list2);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            tb1.Text = "";
           
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
