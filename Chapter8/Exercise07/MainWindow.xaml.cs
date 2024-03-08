using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Emit;
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

namespace Exercise07
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

        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            int number = Convert.ToInt32(sizeTextBox.Text);

            StringBuilder builder = new StringBuilder();

            for (int i = 1; i <= number; i++)
            {
                builder.Append("\t" + i);
            }
            builder.AppendLine();

            for (int i = 1; i <= number; i++)
            {
                builder.Append("\n" + i + "\t");

                for (int j = 1; j <= number; j++)
                {
                    builder.Append(i * j + "\t");
                }
            }

            tableTextBox.Text = builder.ToString();
        }
    }
}
