using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exercise06
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

        private void drawButton_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush brush = new SolidColorBrush(Colors.Black);
            DrawStreet(10, 10 , 50, brush, paperCanvas);
            DrawStreet(70, 10, 50, brush, paperCanvas);
            DrawStreet(130, 10, 50, brush, paperCanvas);
            DrawStreet(190, 10, 50, brush, paperCanvas);

        }

        private void DrawStreet(int topX, int topY, int size, SolidColorBrush brush, Canvas canvas)
        {
            DrawTriangle(topX, topY, size, canvas);
            DrawRectangle(canvas, brush, topX, topY, size);
        }

        private void DrawTriangle(int topX, int topY, int size, Canvas canvas)
        {
            Line line1 = new Line();
            line1.Stroke = new SolidColorBrush(Colors.Black);
            line1.StrokeThickness = 2;
            line1.X1 = topX;
            line1.Y1 = topY;
            line1.X2 = topX;
            line1.Y2 = topY + size;

            Line line2 = new Line();
            line2.Stroke = new SolidColorBrush(Colors.Black);
            line2.StrokeThickness = 2;
            line2.X1 = topX;
            line2.Y1 = topY;
            line2.X2 = topX + size;
            line2.Y2 = topY + size;

            Line line3 = new Line();
            line3.Stroke = new SolidColorBrush(Colors.Black);
            line3.StrokeThickness = 2;
            line3.X1 = topX + size;
            line3.Y1 = topY;
            line3.X2 = topX + size;
            line3.Y2 = topY;

            // Add the lines to the canvas or any other required operations
            canvas.Children.Add(line1);
            canvas.Children.Add(line2);
            canvas.Children.Add(line3);
        }

        private void DrawRectangle(Canvas canvas,
                                   SolidColorBrush brush,
                                   double topX,
                                   double topY,
                                   double size)
        {
            Rectangle rectangle = new Rectangle
            {
                Width = size,
                Height = size,
                Margin = new Thickness(topX, topY + size, 0, 0),
                Stroke = brush
            };
            canvas.Children.Add(rectangle);
        }
    }
}
