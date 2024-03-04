using System;
using System.Windows;
using System.Windows.Controls;

namespace Exercise07
{
    public partial class MainWindow : Window
    {
        private string _lastOperator = "";
        private int _lastNumber = 0;
        private bool _action = false;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void numberButton_Click(object sender, RoutedEventArgs e)
        {
            if (outputTextBlock.Text == "0")
            {
                outputTextBlock.Text = outputTextBlock.Text.Substring(1);
            }
            if (_action)
            {
                outputTextBlock.Text = "";
            }
            outputTextBlock.Text += ((Button)sender).Content;
            _action = false;
        }

        private void operatorButton_Click(object sender, RoutedEventArgs e)
        {
            if (_lastOperator == "")
            {
                _lastNumber = Convert.ToInt32(outputTextBlock.Text);
                // to get last operator for switch
                _lastOperator = Convert.ToString(((Button)sender).Content);
            }
            else
            {
                switch (_lastOperator)
                {
                    case "+":
                        outputTextBlock.Text = $"{Convert.ToString(_lastNumber + Convert.ToInt32(outputTextBlock.Text))}";
                        _lastNumber = Convert.ToInt32(outputTextBlock.Text);
                        _lastOperator = Convert.ToString(((Button)sender).Content);
                        break;
                    case "-":
                        outputTextBlock.Text = $"{Convert.ToString(_lastNumber - Convert.ToInt32(outputTextBlock.Text))}";
                        _lastNumber = Convert.ToInt32(outputTextBlock.Text);
                        _lastOperator = Convert.ToString(((Button)sender).Content);
                        break;
                }
            }
            if (Convert.ToString(((Button)sender).Content) == "=")
            {
                _lastOperator = "";
                _lastNumber = 0;
                _action = false;
            }
            _action = true;
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            _lastOperator = "";
            _lastNumber = 0;
            outputTextBlock.Text = $"{_lastNumber}";
            _action = false;
        }
    }
}
