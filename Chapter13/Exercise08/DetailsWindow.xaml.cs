using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Exercise08
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        private Person _person;

        public DetailsWindow(Person person)
        {
            InitializeComponent();
            _person = person;
            LoadPersonDetails();
        }

        private void LoadPersonDetails()
        {
            firstnameTextBox.Text = _person.Firstname ?? string.Empty;
            nameTextBox.Text = _person.Name ?? string.Empty;
            addressTextBox.Text = _person.Address ?? string.Empty;
            phoneTextBox.Text = _person.Phone ?? string.Empty;
            if (_person.BirthDate != default)
            {
                birthDateTextBox.Text = _person.BirthDate.ToShortDateString();
            }

            if (_person.Gender == Gender.Male)
            {
                maleRadioButton.IsChecked = true;
            }
            else if (_person.Gender == Gender.Female)
            {
                femaleRadioButton.IsChecked = true;
            }
        }


        private void okButton_Click_1(object sender, RoutedEventArgs e)
        {
            _person.Firstname = firstnameTextBox.Text;
            _person.Name = nameTextBox.Text;
            _person.Address = addressTextBox.Text;
            _person.Phone = phoneTextBox.Text;

            if (DateTime.TryParse(birthDateTextBox.Text, out DateTime parsedDate))
            {
                _person.BirthDate = parsedDate;
            }

            if (maleRadioButton.IsChecked == true)
            {
                _person.Gender = Gender.Male;
            }
            else if (femaleRadioButton.IsChecked == true)
            {
                _person.Gender = Gender.Female;
            }

            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
