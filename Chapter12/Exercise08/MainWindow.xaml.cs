using System;
using System.Windows;

namespace Exercise08
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            areaTextBlock.Text = string.Empty;
            errorTextBlock.Text = string.Empty;

            int a = int.Parse(asideTextBox.Text);
            int b = int.Parse(bsideTextBox.Text);
            int c = int.Parse(csideTextBox.Text);

            if (IsValidTriangle(a, b, c))
            {
                double area = CalculateTriangleArea(a, b, c);
                areaTextBlock.Text = $"{area:F3}";
            }
            else
            {
                errorTextBlock.Text = "The sides do not form a valid triangle.";
            }
        }

        private bool IsValidTriangle(int a, int b, int c)
        {
            return (a + b > c) && (a + c > b) && (b + c > a);
        }

        private double CalculateTriangleArea(int a, int b, int c)
        {
            double s = (a + b + c) / 2.0;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        public int Max(int a, int b, int c)
        {
            return Math.Max(a, Math.Max(b, c));
        }

    }
}
