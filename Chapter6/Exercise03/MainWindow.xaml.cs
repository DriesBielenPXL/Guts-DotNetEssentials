using System;
using System.Windows;

namespace Exercise03
{
    public partial class MainWindow : Window
    {

        private Random _random = new Random();
        private int _sum;
        private int _average;
        private int clicks;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            int number = _random.Next(200,400);
            randomTextBox.Text = $"{number}";
            clicks += 1;
            _sum += number;
            _average = _sum / clicks;

            if (clicks < 2)
            {
                sumTextBox.Text = $"{number}";
                averageTextBox.Text = $"{number}";
            } else if (clicks > 1)
            {
                sumTextBox.Text = $"{_sum}";
                averageTextBox.Text = $"{_average}";
            }

            if (clicks > 2)
            {
                generateButton.IsEnabled = false;
            }

        }
    }
}
