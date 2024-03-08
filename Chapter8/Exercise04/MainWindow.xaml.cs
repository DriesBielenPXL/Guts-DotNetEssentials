using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Exercise04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _size = 10;

        public MainWindow()
        {
            InitializeComponent();

            DrawRectangle();
        }

        private void DrawRectangle()
        {
            for (int row = 1; row<=6; row++)
            {
                for (int colum = 1; colum<=row; colum++)
                {
                    Rectangle rectangle = new Rectangle
                    {
                        Width = _size,
                        Height = _size,
                        Margin = new Thickness(colum * 10,row* 10, 0, 0),
                        Stroke = new SolidColorBrush(Colors.Black)
                    };

                    paperCanvas.Children.Add(rectangle);
                }
            }
        }
    }
}
