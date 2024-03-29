using System;

using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace BeetleGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer = new DispatcherTimer();
        private Beetle _beetle;
        private DateTime _startTime;

        public MainWindow()
        {
            InitializeComponent();
            _timer.Tick += _timer_Tick;

            _timer.Interval = TimeSpan.FromMilliseconds(200);

            GenerateLocation(out int x, out int y);
            _beetle = new Beetle(paperCanvas, x, y, (int)sizeSlider.Value);
            sizeSlider.ValueChanged += SizeSlider_ValueChanged;
            speedSlider.ValueChanged += SpeedSlider_ValueChanged;
        }
        private void _timer_Tick(object sender, EventArgs e)
        {
            _beetle.ChangePosition();
        }

        private void GenerateLocation(out int x, out int y)
        {
            Random random = new Random();
            x = random.Next(Convert.ToInt32(paperCanvas.Width));
            y = random.Next(Convert.ToInt32(paperCanvas.Height));
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            if (startButton.Content.ToString() == "Start")
            {
                _timer.Start();
                _beetle.IsVisible = true;
                startButton.Content = "Stop";
                _startTime = DateTime.Now;
                speedSlider.IsEnabled = false;
                sizeSlider.IsEnabled = false;
                messageLabel.Content = "";
            }
            else
            {
                startButton.Content = "Start";
                _timer.Stop();
                messageLabel.Content = $"total distance in meters: {_beetle.ComputeDistance(_startTime, DateTime.Now)}";
                speedSlider.IsEnabled = true;
                sizeSlider.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (sender == upButton)
            {
                _beetle.Up = true;
            }
            else if (sender == downButton)
            {
                _beetle.Up = false;
            }
            else if (sender == rightButton)
            {
                _beetle.Right = true;
            }
            else
            {
                _beetle.Right = false;
            }
        }

        private void SizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_beetle != null)
            {
                _beetle.Size = (int)sizeSlider.Value;
                sizeLabel.Content = sizeSlider.Value;
                _timer.Interval = CalculateInterval();
            }
        }

        private void SpeedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_beetle != null)
            {
                _beetle.Speed = speedSlider.Value;
                speedLabel.Content = speedSlider.Value;
                _timer.Interval = CalculateInterval();
            }
        }

        private TimeSpan CalculateInterval()
        {
            double interval = 100 / speedSlider.Value * sizeSlider.Value / 10;
            return TimeSpan.FromMilliseconds(interval);
        }

    }
};

