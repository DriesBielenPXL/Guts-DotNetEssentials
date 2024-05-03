using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;

namespace Exercise07
{
    public partial class MainWindow : Window
    {
        private IList<string> _listOfMonths;
        public MainWindow()
        {
            InitializeComponent();
            _listOfMonths = new List<string>() { "January", "february", "maart", "april", "mei", "juni", "juli", "augustus", "september", "october", "november", "december"};
        }

        private void lookupButton_Click(object sender, RoutedEventArgs e)
        {
            var number = int.Parse(monthNumberTextBox.Text);
            monthNameTextBox.Text = _listOfMonths[number - 1];
        }
    }
}
