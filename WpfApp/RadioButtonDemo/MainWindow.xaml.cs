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

namespace RadioButtonDemo
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

        private void rbH_Checked(object sender, RoutedEventArgs e)
        {
            rbLblP.Background = Brushes.Aquamarine;
        }

        private void rbH_Unchecked(object sender, RoutedEventArgs e)
        {
            rbLblP.Background = Brushes.White;
        }
    }
}
