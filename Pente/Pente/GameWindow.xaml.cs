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
        bool player1FirstTurn = true;
        bool player1SecondTurn = false;
        int[] lastLocation;
        int tournamentSpaces = 2;
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
                grid.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/Wood.jpg")));
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
            if (!player1SecondTurn)
            {
                Ellipse ellipse = (Ellipse)sender;
                if (ellipse.Opacity == 0)
                {
                    if (pL.isPlayer1Turn)
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
                    if(player1FirstTurn)
                    lastLocation = pieceLocation;
                     List<int> captureLocation = pL.Capture(pieceLocation[0], pieceLocation[1]);
                    if (captureLocation.Count > 0)
                    {
                        for (int pieceCount = 0; pieceCount < captureLocation.Count; pieceCount = pieceCount + 2)
                        {
                            Ellipse ellipse1 = (Ellipse)GameGrid.Children[(captureLocation[pieceCount + 1] + captureLocation[pieceCount] * GameGrid.Rows)];
                            ellipse1.Opacity = 0;
                            ellipse1.Fill = EmptySpace;
                        }
                    }
                    HookUpBoards();
                    if (pL.FiveInARow(pieceLocation[0], pieceLocation[1]))
                    {
                        if (pL.isPlayer1Turn)
                        {
                            MessageBox.Show("Player 1 wins");
                        }
                        else
                        {
                            MessageBox.Show("Player 2 wins");
                        }
                    }
                    if(player1FirstTurn && !pL.isPlayer1Turn)
                    {
                        player1FirstTurn = false;
                        player1SecondTurn = true;
                    }
                }
            }
            else
            {
                Ellipse ellipse = (Ellipse)sender;
                int[] newPieceLocation = FindPiece(ellipse);

                if (newPieceLocation[0] > lastLocation[0]+tournamentSpaces || 
                    (newPieceLocation[0] < lastLocation[0] - tournamentSpaces) || 
                    (newPieceLocation[1] > lastLocation[1] + tournamentSpaces) || 
                    (newPieceLocation[1] < lastLocation[1] - tournamentSpaces))
                {
                    player1SecondTurn = false;
                    if (ellipse.Opacity == 0)
                    {
                        if (pL.isPlayer1Turn)
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
                        List<int> captureLocation = pL.Capture(newPieceLocation[0], newPieceLocation[1]);
                        if (captureLocation.Count > 0)
                        {
                            for (int pieceCount = 0; pieceCount < captureLocation.Count; pieceCount = pieceCount + 2)
                            {
                                Ellipse ellipse1 = (Ellipse)GameGrid.Children[(captureLocation[pieceCount + 1] + captureLocation[pieceCount] * GameGrid.Rows)];
                                ellipse1.Opacity = 0;
                                ellipse1.Fill = EmptySpace;
                            }
                        }
                        HookUpBoards();
                        if (pL.FiveInARow(newPieceLocation[0], newPieceLocation[1]))
                        {
                            if (pL.isPlayer1Turn)
                            {
                                MessageBox.Show("Player 1 wins");
                            }
                            else
                            {
                                MessageBox.Show("Player 2 wins");
                            }
                        }

                    }
                }
            }
            if(pL.player1Captures >= 5)
            {
                MessageBox.Show("Trash p1");
            }
            else if (pL.player2Captures >= 5)
            {
                MessageBox.Show("Your the best p2");
            }
            ChangeEllipseColor();
        }

        private void ChangeEllipseColor()
        {
            if(pL.isPlayer1Turn)
            {
                turnIndicator.Fill = player2;
            }
            else
            {
                turnIndicator.Fill = player1;
            }
        }

        #region NameChanging
        private void Player1Name_LostFocus(object sender, RoutedEventArgs e)
        {
            //Checks if textbox is empty
            if (tbxPlayer1Name.Text.Length != 0)
            {
                lblPlayer1Name.Content = tbxPlayer1Name.Text;
            }
            else
            {
                tbxPlayer1Name.Text = "Player 1";
            }
            //Sets player 1 text box invisible and unusable after losing focus
            tbxPlayer1Name.IsEnabled = false;
            tbxPlayer1Name.Visibility = Visibility.Hidden;
            tbxPlayer1Name.Focusable = false;
            lblPlayer1Name.Visibility = Visibility.Visible;
        }

        private void Player1Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //Checks if textbox is empty
                if (tbxPlayer1Name.Text.Length != 0)
                {
                    lblPlayer1Name.Content = tbxPlayer1Name.Text;
                }
                else
                {
                    tbxPlayer1Name.Text = "Player 1";
                }
                //Sets player 1 text box invisible and unusable after clicking enter
                tbxPlayer1Name.IsEnabled = false;
                tbxPlayer1Name.Visibility = Visibility.Hidden;
                tbxPlayer1Name.Focusable = true;
                lblPlayer1Name.Visibility = Visibility.Visible;
            }
        }

        private void Player2Name_LostFocus(object sender, RoutedEventArgs e)
        {
            //Checks if textbox is empty
            if (tbxPlayer2Name.Text.Length != 0)
            {
                lblPlayer2Name.Content = tbxPlayer2Name.Text;
            }
            else
            {
                tbxPlayer2Name.Text = "Player 2";
            }
            //Sets player 2 text box invisible and unusable after losing focus
            tbxPlayer2Name.IsEnabled = false;
            tbxPlayer2Name.Visibility = Visibility.Hidden;
            tbxPlayer2Name.Focusable = false;
            lblPlayer2Name.Visibility = Visibility.Visible;
        }

        private void Player2Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //Checks if textbox is empty
                if (tbxPlayer2Name.Text.Length != 0)
                {
                    lblPlayer2Name.Content = tbxPlayer2Name.Text;
                }
                else
                {
                    tbxPlayer2Name.Text = "Player 2";
                }
                //Sets player 2 text box invisible and unusable after clicking enter
                tbxPlayer2Name.IsEnabled = false;
                tbxPlayer2Name.Visibility = Visibility.Hidden;
                tbxPlayer2Name.Focusable = false;
                lblPlayer2Name.Visibility = Visibility.Visible;
            }
        }

        private void Player2NameEdit_Click(object sender, MouseButtonEventArgs e)
        {
            //When pencil is clicked textbox becomes available 
            tbxPlayer2Name.IsEnabled = true;
            tbxPlayer2Name.Visibility = Visibility.Visible;
            tbxPlayer2Name.Focusable = true;
            tbxPlayer2Name.Focus();
            tbxPlayer2Name.Text = "";
            lblPlayer2Name.Visibility = Visibility.Hidden;

        }

        private void Player1NameEdit_Click(object sender, MouseButtonEventArgs e)
        {
            //When pencil is clicked textbox becomes available 
            tbxPlayer1Name.IsEnabled = true;
            tbxPlayer1Name.Visibility = Visibility.Visible;
            tbxPlayer1Name.Focusable = true;
            tbxPlayer1Name.Focus();
            tbxPlayer1Name.Text = "";
            lblPlayer1Name.Visibility = Visibility.Hidden;
        }
        #endregion
    }
}
