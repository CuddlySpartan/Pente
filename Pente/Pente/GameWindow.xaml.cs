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
using PenteDLL.Controllers;

namespace Pente
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PenteLibrary pL = new PenteLibrary();
            pL.StartGame();

            GameGrid.Rows = 19;
            GameGrid.Columns = 19;

            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    Rectangle rect = new Rectangle();
                    if (j % 2 == 0 && i % 2 == 0)
                    {
                        
                    }
                    rect.MouseLeftButtonDown += MouseLeftClick_Down;
                    GameGrid.Children.Add(rect);
                }
            }
        }

        private void MouseLeftClick_Down(object sender, RoutedEventArgs e)
        {
            Rectangle rectangle = (Rectangle)sender;
        }
    }
}
