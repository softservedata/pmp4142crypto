﻿using System;
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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Les1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.ShowDialog();
        }

        private void Les2_Click(object sender, RoutedEventArgs e)
        {
            less2 les2 = new less2();
            les2.ShowDialog();
        }

        private void Les3_Click(object sender, RoutedEventArgs e)
        {
            less3 les3 = new less3();
            les3.ShowDialog();
        }
    }
}
