using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exercise15
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

        public void ConvertSecondsToHoursMinutesSeconds(int totalSeconds, out int hours, out int minutes, out int seconds)
        {
            if (totalSeconds == 0)
            {
                hours = 0;
                minutes = 0;
                seconds = 0;
            } else
            {
                hours = totalSeconds / 3600; // 1 hour = 3600 seconds
                minutes = (totalSeconds % 3600) / 60; // 1 minute = 60 seconds
                seconds = totalSeconds % 60;
            }

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int totalSeconds = Convert.ToInt32(secondsTextBox.Text);
            int hours, minutes, seconds;


            ConvertSecondsToHoursMinutesSeconds(totalSeconds, out hours, out minutes, out seconds);
            MessageBox.Show($"{totalSeconds} seconds is {hours} hours, {minutes} minutes and {seconds} seconds");
        }
    }
}
