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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ButtonDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double myFontSize = myLabel.FontSize; 
            myLabel.FontSize = myFontSize +1;
        }

        private void myBUtton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            double myFontSize = myLabel.FontSize;
            myLabel.FontSize = myFontSize - 1;
        }

        private void myBUtton_MouseEnter(object sender, MouseEventArgs e)
        {
            myLabel.Foreground = Brushes.Green;
        }

        private void myBUtton_MouseLeave(object sender, MouseEventArgs e)
        {
            myLabel.Foreground = Brushes.Black;
        }
    }
}
