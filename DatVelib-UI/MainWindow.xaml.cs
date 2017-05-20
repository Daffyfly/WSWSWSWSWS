using DatVelib_UI.Components;
using System;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Controls;

using System.Windows.Input;


using Dat_VelibService;
using DatVelib_Service;

namespace DatVelib_UI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //default values
        static string StartBoxText = "Adresse de départ";
        static string FinishBoxText = "Adresse d'arrivée";

        public MainWindow()
        {
            InitializeComponent();
            StartBox.Text = StartBoxText;
            FinishBox.Text = FinishBoxText;

            //Dynamically setting this, more convenient
            InputPanel.HorizontalAlignment = HorizontalAlignment.Center;
            InputPanel.Margin = new Thickness(0, 50, 0, 0);
            GoBlock.TextAlignment = TextAlignment.Center;
            GoBlock.Padding = new Thickness(0, 20, 0, 20);

            //Setting & Hiding the results panel
            ResultPanel.Visibility = Visibility.Collapsed;
            ResultPanel.Margin = new Thickness(0, 50, 0, 0);
            ResultPanel.HorizontalAlignment = HorizontalAlignment.Center;
            ResultTitle.Padding = new Thickness(0, 15, 0, 15);
            ResultPanel.Width = SystemParameters.PrimaryScreenWidth / 2;
            Scroller.Width = SystemParameters.PrimaryScreenWidth / 2;
            InstructionsPanel.Width = SystemParameters.PrimaryScreenWidth / 2;

        }

        //Are all fields ok ?
        private bool CanValidate()
        {
            if (StartBox.Text != StartBoxText && StartBox.Text != "".Trim()
                && FinishBox.Text != FinishBoxText && FinishBox.Text != "".Trim())
                return true;
            return false;
        }

        #region FOCUS_EVENTS
        private void StartBox_GotFocus(object sender, RoutedEventArgs e)
        {
            //Emptying the textbox when the user focuses on it
            if (StartBox.Text == StartBoxText)
                StartBox.Text = "";
        }

        private void StartBox_LostFocus(object sender, RoutedEventArgs e)
        {
            //Reputting default text in textbox
            if (StartBox.Text.Trim() == "")
                StartBox.Text = StartBoxText;

        }

        private void FinishBox_GotFocus(object sender, RoutedEventArgs e)
        {
            //Emptying the textbox when the user focuses on it
            if (FinishBox.Text == FinishBoxText)
                FinishBox.Text = "";
        }

        private void FinishBox_LostFocus(object sender, RoutedEventArgs e)
        {
            //Reputting default text in textbox
            if (FinishBox.Text.Trim() == "")
                FinishBox.Text = FinishBoxText;
        }

        private void StartBox_MouseEnter(object sender, MouseEventArgs e)
        {
            StartBox.Foreground = Ut.GetColor(79, 195, 247);
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

        private void StartBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ErrorBlock.Visibility = Visibility.Collapsed;
        }

        private void FinishBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ErrorBlock.Visibility = Visibility.Collapsed;
        }

        #endregion

        #region GOBLOCK
        private void GoBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            GoBlock.Background = Ut.GetColor(255, 255, 255);
            GoBlock.Foreground = Ut.GetColor(33, 150, 243);
        }

        private void GoBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            GoBlock.Foreground = Ut.GetColor(255, 255, 255);
            GoBlock.Background = Ut.GetColor(33, 150, 243);
        }



        private void GoBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (CanValidate())
                {
                    List<string> result = Dat_VelibService.DatVelibService.GetClosestVelibs(StartBox.Text, FinishBox.Text);
                    if (result.Count == 2) //call the function that gives results
                    {
                        //Filling the blocks with data
                        StartAddressBlock.Text = "Départ : " + StartBox.Text;
                        StartVelibBlock.Text = "Station de vélib la plus proche : " + result[0].Replace("-", "");
                        FinishVelibBlock.Text = "Station de vélib arrivée : " + result[1].Replace("-", "");
                        FinishAddressBlock.Text = "Arrivée : " + FinishBox.Text;

                        StartAddressBlock.TextWrapping = TextWrapping.Wrap;
                        StartVelibBlock.TextWrapping = TextWrapping.Wrap;
                        FinishVelibBlock.TextWrapping = TextWrapping.Wrap;
                        FinishAddressBlock.TextWrapping = TextWrapping.Wrap;

                        //Getting the directions to follow

                        List<string> directions = TravelProcess.GetTravel(StartBox.Text, FinishBox.Text);
                        if (directions.Count > 0)
                        {
                            foreach (var item in directions)
                            {
                                InstructionBlock t = new InstructionBlock(item);
                                InstructionsPanel.Children.Add(t);
                            }

                            //hiding the addresses input
                            Animator.FadePanel(InputPanel, OpacityProperty);
                            //Showing the results
                            ResultPanel.Visibility = Visibility.Visible;
                            ErrorBlock.Visibility = Visibility.Collapsed;
                        }
                    }
                    else
                    {
                        ErrorBlock.Visibility = Visibility.Visible;
                    }
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Un erreur est survenue, en général c'est  parce que les adresses sont invalides ou le service de Velib n'est pas disponible.");
            }
        }

        #endregion



        #region RETURNBLOCK
        private void ReturnBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            ReturnBlock.Foreground = Ut.GetColor(252, 96, 66);
            ReturnBlock.Background = Ut.GetColor(255, 255, 255);
        }

        private void ReturnBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            ReturnBlock.Background = Ut.GetColor(252, 96, 66);
            ReturnBlock.Foreground = Ut.GetColor(255, 255, 255);
        }

        private void ReturnBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Animator.FadePanel(ResultPanel, OpacityProperty);
            InputPanel.Visibility = Visibility.Visible;
            StartBox.Text = StartBoxText;
            FinishBox.Text = FinishBoxText;
        }
        #endregion


    }
}
