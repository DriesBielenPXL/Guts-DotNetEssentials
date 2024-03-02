using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Exercise06
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private Rectangle minutesRectangle = new Rectangle();
        private Rectangle secondsRectangle = new Rectangle();
        private int _minutes = 0;
        private int _seconds = 0;
        private Brush brush = new SolidColorBrush(Colors.Black);

        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tick;
            minutesRectangle.Stroke = brush;
            secondsRectangle.Stroke = brush;
            minutesRectangle.Height = 10;
            secondsRectangle.Height = 10;
            secondsRectangle.Margin = new Thickness(0, 50, 0, 0);
            minutesRectangle.Fill = brush;
            secondsRectangle.Fill = brush;
            timer.Start();
            paperCanvas.Children.Add(minutesRectangle);
            paperCanvas.Children.Add(secondsRectangle);

        }

        private void tick(object sender, EventArgs e)
        {
            if (_seconds == 59)
            {
                _seconds = 0;
                _minutes += 1;
            }
            else
            {
                _seconds++;
            }
            if (_minutes > 59)
            {
                _minutes = 0;
            }
            minutesRectangle.Width = _minutes * 10;
            secondsRectangle.Width = _seconds * 10;
        }

    }
}