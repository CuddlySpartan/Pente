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
        Brush player1 = Brushes.White;
        Brush player2 = Brushes.Black;
        Brush EmptySpace = Brushes.Red;
        Brush gridLines = Brushes.Black;
        public GameWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 19 * 19; i++)
            {
                Grid grid = new Grid();
                grid.Background = Brushes.LightYellow;
                Rectangle horizontal = new Rectangle();
                horizontal.Height = 2;
                horizontal.Fill = gridLines;
                Rectangle vertical = new Rectangle();
                vertical.Width = 2;
                vertical.Fill = gridLines;
                grid.Children.Add(horizontal);
                grid.Children.Add(vertical);
                Background.Children.Add(grid);
            }
            GameGrid.Rows = 19;
            GameGrid.Columns = 19;
        }

        public GameWindow(int size)
        {
            InitializeComponent();
            for (int i = 0; i < size * size; i++)
            {
                Rectangle rect = new Rectangle();
                rect.Stroke = Brushes.Black;
                Background.Children.Add(rect);
            }
            GameGrid.Rows = size;
            GameGrid.Columns = size;
        }
        PenteLibrary pL = new PenteLibrary();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            pL.StartGame();


            for (int i = 0; i < GameGrid.Rows; i++)
            {
                for (int j = 0; j < GameGrid.Rows; j++)
                {
                    Ellipse ellipse = new Ellipse();
                    ellipse.Fill = EmptySpace;
                    ellipse.Opacity = 0.0;
                    ellipse.MouseLeftButtonDown += MouseLeftClick_Down;
                    GameGrid.Children.Add(ellipse);
                }
            }
        }

        public void HookUpBoards()
        {
            Ellipse[,] boardUpdater = new Ellipse[GameGrid.Columns, GameGrid.Rows];
            for (int i = 0; i < GameGrid.Rows; i++)
            {
                for (int j = 0; j < GameGrid.Columns; j++)
                {
                    boardUpdater[i, j] = (Ellipse)GameGrid.Children[(i * GameGrid.Rows) + j];
                }
            }

            for (int i = 0; i < boardUpdater.GetLength(0); i++)
            {
                for (int j = 0; j < boardUpdater.GetLength(1); j++)
                {
                    if (boardUpdater[i, j].Fill.Equals(player2))
                    {
                        pL.Board[i, j] = PenteLibrary.PlayerPiece.PLAYER2;
                    }
                    else if (boardUpdater[i, j].Fill.Equals(player1))
                    {
                        pL.Board[i, j] = PenteLibrary.PlayerPiece.PLAYER1;
                    }
                    else
                    {
                        pL.Board[i, j] = PenteLibrary.PlayerPiece.EMPTY;
                    }
                }
            }
        }

        private int[] FindPiece(object piece)
        {
            int[] locations = new int[2];

            for (int i = 0; i < GameGrid.Rows; i++)
            {
                for (int j = 0; j < GameGrid.Columns; j++)
                {
                    if (piece.Equals(GameGrid.Children[i + j * GameGrid.Rows]))
                    {
                        locations[0] = i;
                        locations[1] = j;
                    }
                }
            }


            return locations;
        }

        private void MouseLeftClick_Down(object sender, RoutedEventArgs e)
        {
            Ellipse ellipse = (Ellipse)sender;
            if (ellipse.Opacity == 0)
            {
                if (pL.isPlayer2Turn)
                {
                    ellipse.Fill = player2;
                    ellipse.Opacity = 100;
                    pL.TurnOver();
                }
                else
                {
                    ellipse.Fill = player1;
                    ellipse.Opacity = 100;
                    pL.TurnOver();
                }
                HookUpBoards();
                int[] pieceLocation = FindPiece(ellipse);
                int[] captureLocation = pL.Capture(pieceLocation[0], pieceLocation[1]);
                if(captureLocation[0] < GameGrid.Rows + 1)
                {
                    Ellipse ellipse1 = (Ellipse)GameGrid.Children[(captureLocation[0] + captureLocation[1] * GameGrid.Rows)];
                    ellipse1.Opacity = 0;
                    ellipse1.Fill = EmptySpace;
                }
                HookUpBoards();
                if (pL.FiveInARow(pieceLocation[0], pieceLocation[1]))
                {
                    if(pL.isPlayer2Turn)
                    {
                        MessageBox.Show("Player 1 wins");
                    }
                    else
                    {
                        MessageBox.Show("Player 2 wins");
                    }
                }
            }
            else
            {

            }
        }
    }
}
