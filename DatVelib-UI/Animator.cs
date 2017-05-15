using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace DatVelib_UI
{
    class Animator
    {

        public static void FadeTextBlock(TextBlock block, DependencyProperty opacityProperty)
        {
            block.Visibility = System.Windows.Visibility.Visible;

            var a = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                FillBehavior = FillBehavior.Stop,
                BeginTime = TimeSpan.FromSeconds(0.1),
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };
            var storyboard = new Storyboard();

            storyboard.Children.Add(a);
            Storyboard.SetTarget(a, block);
            Storyboard.SetTargetProperty(a, new PropertyPath(opacityProperty));
            storyboard.Completed += delegate { block.Visibility = System.Windows.Visibility.Hidden; };
            storyboard.Begin();
        }

        public static void FadeTextBox(TextBox box, DependencyProperty opacityProperty)
        {
            box.Visibility = System.Windows.Visibility.Visible;

            var a = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                FillBehavior = FillBehavior.Stop,
                BeginTime = TimeSpan.FromSeconds(0.1),
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };
            var storyboard = new Storyboard();

            storyboard.Children.Add(a);
            Storyboard.SetTarget(a, box);
            Storyboard.SetTargetProperty(a, new PropertyPath(opacityProperty));
            storyboard.Completed += delegate { box.Visibility = System.Windows.Visibility.Hidden; };
            storyboard.Begin();
        }

        public static void FadePanel(StackPanel box, DependencyProperty opacityProperty)
        {
            box.Visibility = System.Windows.Visibility.Visible;

            var a = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                FillBehavior = FillBehavior.Stop,
                BeginTime = TimeSpan.FromSeconds(0.1),
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };
            var storyboard = new Storyboard();

            storyboard.Children.Add(a);
            Storyboard.SetTarget(a, box);
            Storyboard.SetTargetProperty(a, new PropertyPath(opacityProperty));
            storyboard.Completed += delegate { box.Visibility = System.Windows.Visibility.Hidden; };
            storyboard.Begin();
        }

        public static void ReverseFade(StackPanel s, DependencyProperty opacityProperty)
        {
            s.Visibility = System.Windows.Visibility.Hidden;

            var a = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                FillBehavior = FillBehavior.Stop,
                BeginTime = TimeSpan.FromSeconds(0.5),
                Duration = new Duration(TimeSpan.FromSeconds(2))
            };
            var storyboard = new Storyboard();

            storyboard.Children.Add(a);
            Storyboard.SetTarget(a, s);
            Storyboard.SetTargetProperty(a, new PropertyPath(opacityProperty));storyboard.Begin();
            storyboard.Completed += delegate { s.Visibility = System.Windows.Visibility.Visible; };
            
        }

    }//class Animator
}//ns
