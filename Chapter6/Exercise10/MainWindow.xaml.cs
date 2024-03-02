using System;
using System.Windows;
using System.Windows.Threading;

namespace Exercise10
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
            timer.Tick += Timer_Tick;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progressBar.Value != 4)
            {
                progressBar.Value++;
            }
            else
            {
                progressBar.Value++;
                MessageBox.Show("To slow");
                timer.Stop();
                cancelButton.IsEnabled = false;
                okButton.IsEnabled = false;
            }
        }
    }
}
