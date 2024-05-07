using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Exercise08
{
    public partial class MainWindow : Window
    {
        private List<Person> _persons = new List<Person>();
        Window _detailsWindow;
        public MainWindow()
        {
            InitializeComponent();
            Person dries = new Person("Bielen", "Dries", Gender.Male, "Thuis", "0468212699", DateTime.Parse("01/09/2004"));
            Person charlotte = new Person("Bielen", "charlotte", Gender.Female, "Thuis", "0468212699", DateTime.Parse("10/04/2004"));
            _persons.Add(dries);
            _persons.Add(charlotte);
            listBox.ItemsSource = _persons;
        }

        private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Person person = listBox.SelectedItem as Person;
            _detailsWindow = new DetailsWindow(person);
            _detailsWindow.ShowDialog();
        }
    }
}
