using PenteDLL.Controllers;
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
using System.Windows.Shapes;

namespace Pente
{
    /// <summary>
    /// Interaction logic for GameOverWindow.xaml
    /// </summary>
    public partial class GameOverWindow : Window
    {
        public string WinString { get; set; }

        public bool WithAI { get; set; }

        public int Size { get; set; }

        // Initializes the components and sets the name of the winners
        public GameOverWindow(string winString, bool withAI, int size)
        {
            InitializeComponent();

            WinString = winString;
            WithAI = withAI;
            Size = size;
        }

        //Once the window has loaded, change the textbox to name who wins
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtWin.Text = WinString;
        }


        private void btnPlayAgain_Click_1(object sender, RoutedEventArgs e)
        {
            //Opens the Main Menu window
            GameWindow window = new GameWindow(Size, WithAI);
            //Shows the new window
            window.Show();
            //Closes the Window
            this.Close();
        }

        private void btnMainMenu_Click_1(object sender, RoutedEventArgs e)
        {
            //Opens the Main Menu window
            var window = new MainWindow();
            //Shows the new window
            window.Show();
            //Closes the Window
            this.Close();
        }
    }
}
