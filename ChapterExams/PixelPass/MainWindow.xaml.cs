using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PixelPass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IAccountInfoCollection _accountInfoCollection;
        private AccountInfo _currentAccountInfo;
        private List<AccountInfo> _accountinfo = new List<AccountInfo>();
        private DispatcherTimer _copyTimer = new DispatcherTimer();
        private const int CopyDurationSeconds = 10;
        private int _remainingSeconds;


        public MainWindow()
        {
            InitializeComponent();
            _copyTimer.Interval = TimeSpan.FromSeconds(1);
            _copyTimer.Tick += _copyTimer_Tick;
        }

        private void _copyTimer_Tick(object sender, EventArgs e)
        {
            _remainingSeconds--;
            expirationProgressBar.Value = _remainingSeconds;

            if (_remainingSeconds == 0)
            {
                _copyTimer.Stop();
                Clipboard.Clear();
                copyButton.IsEnabled = true;

            }
        }

        private void openItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //dialog.Filter = "Text files | *.txt; *.doc";
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    _accountInfoCollection = AccountInfoCollectionReader.Read(dialog.FileName);
                    accountInfoListBox.ItemsSource = _accountInfoCollection.AccountInfos;
                    //accountInfoListBox.Items.Refresh(); enkel als je je lijst wijzigt niet als je ze toewijst
                    newAccountInfoButton.IsEnabled = true;
                    this.Title = $"Pixelpass - {_accountInfoCollection.Name}";
                } catch (ParseException ex)
                {
                    MessageBox.Show($"{dialog.FileName} seems corrupt.  \n \n Details: \n \n {ex.Message}", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
             }


        }

        private void accountInfoListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (accountInfoListBox.SelectedItem is AccountInfo selectedAccount)
            {
                if (selectedAccount.IsExpired)
                {
                    detailsCanvas.Background = new SolidColorBrush(Colors.LightCoral);
                    copyButton.IsEnabled = false;
                } else
                {
                    detailsCanvas.Background = new SolidColorBrush(Colors.White);
                    copyButton.IsEnabled = true;
                }

                _currentAccountInfo = selectedAccount;
                titleTextBlock.Text = selectedAccount.Title;
                usernameTextBlock.Text = selectedAccount.Username;
                notesTextBlock.Text = selectedAccount.Notes;
                expirationTextBlock.Text = selectedAccount.Expiration.ToString("dd/MM/yyyy");
            }
        }

        private void newAccountInfoButton_Click(object sender, RoutedEventArgs e)
        {
            CreateAccountInfoWindow infoWindow = new CreateAccountInfoWindow(_accountInfoCollection);

            infoWindow.ShowDialog();

            accountInfoListBox.Items.Refresh();
        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        { 
            Clipboard.SetText(_currentAccountInfo.Password);
            copyButton.IsEnabled = false;
            _remainingSeconds = CopyDurationSeconds;
            expirationProgressBar.Maximum = CopyDurationSeconds;
            expirationProgressBar.Value = CopyDurationSeconds;
            _copyTimer.Start();
        }
    }
}
