using System;
using System.Windows;

namespace Exercise13
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            var price = Convert.ToInt32(priceLabel.Text);
            var btw = 0.0;

            if (rateCheckBox.IsChecked == true)
            {
                btw = price * 0.06;
            } else
            {
                btw = price * 0.21;
            }

            btwLabel.Text = $"{btw}";
            totalTextBox.Text = $"{price + btw}";
        }
    }
}
