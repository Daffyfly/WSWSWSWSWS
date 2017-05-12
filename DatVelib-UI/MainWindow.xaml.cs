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

namespace DatVelib_UI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StartBox.Text = "Adresse de départ";
            FinishBox.Text = "Adresse arrivée";
        }

        private void StartBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("StartBox Focused");
            StartBox.Text = "";
        }

        private void StartBox_LostFocus(object sender, RoutedEventArgs e)
        {
            StartBox.Text = "Adresse de départ";

        }

        private void FinishBox_LostFocus(object sender, RoutedEventArgs e)
        {
            FinishBox.Text = "Adresse de d'arrivée";
        }

        private void FinishBox_GotFocus(object sender, RoutedEventArgs e)
        {
            FinishBox.Text = "";
        }
    }
}
