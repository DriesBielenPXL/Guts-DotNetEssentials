using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BeetleGame
{
    public class Beetle
    {
        private int _x;
        private int _y;
        private int _size;
        private Ellipse _ellipse;
        private bool _isVisible = false;
        private Canvas _canvas;

        public Beetle(Canvas canvas, int x, int y, int size)
        {
            _x = x;
            _y = y;
            _canvas = canvas;
            _size = size;
            CreateEllipse();
            _isVisible = false;
            Up = true;
            Right = true;
        }

        public double Speed { get; set; }
        public int Size { get { return _size; } set { _size = value; } }
        public bool Up { get; set; }
        public bool Right { get; set; }
        public int X { get { return _x; } set { _x = value; UpdateEllipse(); } }
        public int Y { get { return _y; } set { _y = value; UpdateEllipse(); } }
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                if (IsVisible)
                {
                    _ellipse.Visibility = Visibility.Visible;
                }
                else
                {
                    _ellipse.Visibility = Visibility.Hidden;
                }
            }
        }

        public double ComputeDistance(DateTime time1, DateTime time2)
        {
            TimeSpan time = time2 - time1;
            int seconds = Convert.ToInt32(time.TotalSeconds);
            return (double)(seconds * Speed) / 100;
        }

        private void CreateEllipse()
        {
            _ellipse = new Ellipse
            {
                Width = _size,
                Height = _size,
                Margin = new Thickness(_x - (_size / 2), _y - (_size / 2), 0, 0),
                Stroke = new SolidColorBrush(Colors.Red),
                Fill = new SolidColorBrush(Colors.Red)
            };
            _canvas.Children.Add(_ellipse);
        }

        private void UpdateEllipse()
        {
            _ellipse.Width = Size;
            _ellipse.Height = Size;
            _ellipse.Margin = new Thickness(_x - (_size / 2), _y - (_size / 2), 0, 0);
        }

        public void ChangePosition()
        {
            if (Speed == 0)
            {
                return;
            }

            if (Up)
            {
                Y -= 1;
            }
            else
            {
                Y += 1;
            }

            if (Right)
            {
                X += 1;
            }
            else
            {
                X -= 1;
            }
            ChangeDirection();
        }

        private void ChangeDirection()
        {
            if (X <= Size / 2)
            {
                Right = true;
            }
            else if (X >= _canvas.Width - (_size / 2))
            {
                Right = false;
            }

            if (Y <= Size / 2)
            {
                Up = false;
            }
            else if (Y >= _canvas.Height - (_size / 2))
            {
                Up = true;
            }
        }
    }
}
