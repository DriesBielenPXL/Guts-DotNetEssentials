using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

namespace PixelPass
{
    /// <summary>
    /// Interaction logic for CreateOrUpdateAccountInfoWindow.xaml
    /// </summary>
    public partial class CreateAccountInfoWindow : Window
    {
        private IAccountInfoCollection _accountinfoCollection;
        public CreateAccountInfoWindow(IAccountInfoCollection accountInfoCollection)
        {
            _accountinfoCollection = accountInfoCollection;
            InitializeComponent();
            expirationSlider.ValueChanged += ExpirationSlider_ValueChanged;
        }

        private void ExpirationSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            DateTime today = DateTime.Today;

            today = today.AddDays(expirationSlider.Value);


            expirationDateTextBlock.Text = today.ToShortDateString();

        }

        private void passwordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            passwordStrengthTextBlock.Text = PasswordValidator.CalculateStrength(passwordTextBox.Text).ToString();
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            var accountInfo = new AccountInfo
            {
                Title = titleTextBox.Text,
                Username = usernameTextBox.Text,
                Password = passwordTextBox.Text,
                Notes = notesTextBox.Text,
                Expiration = Convert.ToDateTime(expirationDateTextBlock.Text)
            };
            _accountinfoCollection.AccountInfos.Add(accountInfo);
            this.Close();
        }
    }
}
