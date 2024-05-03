using System.Windows;

namespace Exercise01
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void listBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int index = listBox.SelectedIndex;
            if (index != -1)
            {
                listBox.Items.RemoveAt(index);
            }
            
        }
    }
}
