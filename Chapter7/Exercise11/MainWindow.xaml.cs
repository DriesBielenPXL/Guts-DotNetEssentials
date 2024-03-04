using System;
using System.Windows;

namespace Exercise11
{
    public partial class MainWindow : Window
    {
        Random rand1 = new Random(1);
        Random rand2 = new Random(2);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void firstButton_Click(object sender, RoutedEventArgs e)
        {
            firstLabel.Content = $"{rand1.Next()}";
        }

        private void secondButton_Click(object sender, RoutedEventArgs e)
        {
            secondLabel.Content = $"{rand2.Next()}";
        }
    }
}
