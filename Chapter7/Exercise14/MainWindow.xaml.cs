using System.Collections;
using System.Windows;

namespace Exercise14
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (maleRadioButton.IsChecked == true)
            {
                MessageBox.Show("MAN");
            }
            if (femaleRadioButton.IsChecked == true)
            {
                MessageBox.Show("VROUW");
            }
            if (firstRadioButton.IsChecked == true)
            {
                MessageBox.Show("tussen 18 en 30");
            }
            if (secondRadioButton.IsChecked == true)
            {
                MessageBox.Show("tussen 30 en 45");
            }
            if (thirdradioButton.IsChecked == true)
            {
                MessageBox.Show("tussen 45 en 60");
            }
            if (lastRdioButton.IsChecked == true)
            {
                MessageBox.Show("heel oud");
            }
        }
    }
}
