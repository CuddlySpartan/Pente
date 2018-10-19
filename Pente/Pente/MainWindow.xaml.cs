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

namespace Pente
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

        List<string> dimensions = new List<string>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 9; i < 40; i = i + 2)
            {
                dimensions.Add($"{i} x {i}");
            }
            cmbxGridSize.ItemsSource = dimensions;
            cmbxGridSize.SelectedIndex = cmbxGridSize.Items.IndexOf("19 x 19");
        }

        private void btnSinglePlayer_Click(object sender, RoutedEventArgs e)
        {
            int selection;
            int.TryParse(cmbxGridSize.SelectedItem.ToString().Substring(0, 2), out selection);
            GameWindow gameWindow = new GameWindow(selection, true);
            gameWindow.Show();

            this.Close();
        }

        private void btnMultiPlayer_Click(object sender, RoutedEventArgs e)
        {
            int selection;
            int.TryParse(cmbxGridSize.SelectedItem.ToString().Substring(0, 2), out selection);
            GameWindow gameWindow = new GameWindow(selection, false);
            gameWindow.Show();

            this.Close();
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            Instructions instructions = new Instructions();
            instructions.Show();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
