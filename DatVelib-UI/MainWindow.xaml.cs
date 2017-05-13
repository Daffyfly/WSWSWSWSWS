using DatVelib_UI.Components;
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
using System.Windows.Media.Animation;
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
        static string StartBoxText = "Adresse de départ";
        static string FinishBoxText = "Adresse d'arrivée";

        public MainWindow()
        {
            InitializeComponent();
            StartBox.Text = StartBoxText;
            FinishBox.Text = FinishBoxText;
            InputPanel.HorizontalAlignment = HorizontalAlignment.Center;
            InputPanel.Margin = new Thickness(0, 50, 0, 0);
            GoBlock.TextAlignment = TextAlignment.Center;
            GoBlock.Padding = new Thickness(0, 20, 0, 20);


            ResultPanel.Visibility = Visibility.Collapsed;
            ResultPanel.Margin = new Thickness(0, 50, 0, 0);            
            ResultPanel.HorizontalAlignment = HorizontalAlignment.Center;
            ResultTitle.Padding = new Thickness(0, 15, 0, 15);
            ResultPanel.Width = SystemParameters.PrimaryScreenWidth/2;
            Scroller.Width = SystemParameters.PrimaryScreenWidth / 2;
            InstructionsPanel.Width = SystemParameters.PrimaryScreenWidth / 2;


            for (int i = 0; i < 500; i++)
            {
                InstructionBlock t = new InstructionBlock("Ceci est une instruction " + i);
                InstructionsPanel.Children.Add(t);
            }


        }

        private void StartBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if(StartBox.Text == StartBoxText)
                StartBox.Text = "";
        }

        private void StartBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if(StartBox.Text == "")
                StartBox.Text = StartBoxText;

        }

        private void FinishBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (FinishBox.Text == FinishBoxText)
                FinishBox.Text = "";
        }

        private void FinishBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if(FinishBox.Text == "")
                FinishBox.Text = FinishBoxText;
        }

       

        private void GoBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            GoBlock.Background = Ut.GetColor(255,255,255);
            GoBlock.Foreground = Ut.GetColor(33, 150, 243);
        }

        private void GoBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            GoBlock.Foreground = Ut.GetColor(255, 255, 255);
            GoBlock.Background = Ut.GetColor(33, 150, 243);
        }

        private void StartBox_MouseEnter(object sender, MouseEventArgs e)
        {
            StartBox.Foreground = Ut.GetColor(79, 195 , 247);
        }

        private void StartBox_MouseLeave(object sender, MouseEventArgs e)
        {
            StartBox.Foreground = Ut.GetColor(117, 117, 117);
        }

        private void FinishBox_MouseEnter(object sender, MouseEventArgs e)
        {
            FinishBox.Foreground = Ut.GetColor(79, 195, 247);

        }

        private void FinishBox_MouseLeave(object sender, MouseEventArgs e)
        {
            FinishBox.Foreground = Ut.GetColor(117, 117, 117);

        }

        private void GoBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (CanValidate())
            {
                Console.WriteLine("VALIDATE");
                Animator.FadeTextBlock(GoBlock, OpacityProperty);
                Animator.FadeTextBox(StartBox, OpacityProperty);
                Animator.FadeTextBox(FinishBox, OpacityProperty);
                //ResultPanel.Visibility = Visibility.Visible;
                TrajectoryBlock.Text = "De " + StartBox.Text + " à " + FinishBox.Text;
                TrajectoryBlock.TextWrapping = TextWrapping.Wrap;
                Animator.ReverseFade(ResultPanel, OpacityProperty);

            }
            else
                Console.WriteLine("NOT VALID!!!");

        }

      

        private bool CanValidate()
        {
            if (StartBox.Text != StartBoxText && StartBox.Text != "".Trim()
                && FinishBox.Text != FinishBoxText && FinishBox.Text != "".Trim())
                return true;
            return false;
        }
    }
}
