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

namespace CheckBoxDemo
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

        private void cbCheese_Checked(object sender, RoutedEventArgs e)
        {
            cbCheese.Background = Brushes.Red;
        }

        private void cbCheese_Unchecked(object sender, RoutedEventArgs e)
        {
            cbCheese.Background = Brushes.White;
        }

        private void cbParent_Checked_Changed(object sender, RoutedEventArgs e)
        {
            bool newVal = (cbParent.IsChecked == true);
            cbCheese.IsChecked = newVal;
            cbHam.IsChecked = newVal;
            cbTuna.IsChecked = newVal;
            cbPepp.IsChecked = newVal;
        }
        private void cbTopingsCheckedChanged(object sender, RoutedEventArgs e)
        {
            cbParent.IsChecked = null;
            if ((cbCheese.IsChecked == true) && (cbHam.IsChecked == true) 
                && (cbTuna.IsChecked == true) && (cbPepp.IsChecked == true)) { 
              cbParent.IsChecked = true;
            }
            if ((cbCheese.IsChecked == false) && (cbHam.IsChecked == false)
                && (cbTuna.IsChecked == false) && (cbPepp.IsChecked == false))
            {
                cbParent.IsChecked = false;
            }
        }

        
    }
}
