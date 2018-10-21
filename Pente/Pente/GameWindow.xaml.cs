﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        //Used for tournament rule
        bool player1FirstTurn = true;
        bool player1SecondTurn = false;
        int[] lastLocation;

        //Number of spaces the first player can't put their second piece on the second turn
        int tournamentSpaces = 2;
        //Colors we use for various things
        Brush player1 = Brushes.White;
        Brush player2 = Brushes.Black;
        Brush previousTimerColor = Brushes.Green;
        Brush EmptySpace = Brushes.Red;
        Brush gridLines = Brushes.Black;

        public bool WithAI { get; set; }

        #region Window Loading
        //Place holder for basic 19*19 board will be removed
        public GameWindow()
        {
            //Initializes the window for testing purposes
            InitializeComponent();
            //Creates a board with a background
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

        //Planning on using for board size
        public GameWindow(int size, bool withAI)
        {
            //Initializes the window
            InitializeComponent();
            for (int i = 0; i < size * size; i++)
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
            WithAI = withAI;

            GameGrid.Rows = size;
            GameGrid.Columns = size;
        }

        //PenteLibrary links the controller and the view together
        PenteLibrary pL = new PenteLibrary();

        //Timer for timing turns
        Timer timer = new Timer();

        /*Loads Background
         * Puts all elipses on the board*/
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Populates the board
            pL.StartGame(GameGrid.Rows);

            //View contains ellipses that are opaque on every spot
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
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Start();
            timer.Elapsed += new ElapsedEventHandler(UpdateTimer);
        }

        /*Hooks up both boards in the view and controller*/
        public void HookUpBoards()
        {
            //Updates the board in the DLL based on 
            //the board in the view                
            Ellipse[,] boardUpdater = new Ellipse[GameGrid.Columns, GameGrid.Rows];
            for (int i = 0; i < GameGrid.Rows; i++)
            {
                for (int j = 0; j < GameGrid.Columns; j++)
                {
                    boardUpdater[i, j] = (Ellipse)GameGrid.Children[(i * GameGrid.Rows) + j];
                }
            }
            //This determines player color on board locations in the controller
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

        /*Method used for finding the piece clicked
        The piece is then checked for wins, captures, 
        and tessera*/

        #endregion

        #region Turn Taking

        private void UpdateTimer(object source, ElapsedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
                {
                    int labelValue;
                    int.TryParse(lblTimer.Content.ToString(), out labelValue);
                    if (labelValue != 0)
                    {
                        lblTimer.Content = labelValue - 1;
                    }
                    else
                    {
                        ChangeEllipseColor();
                        pL.TurnOver();
                        if (WithAI)
                        {
                            TakeAITurn();
                            ChangeEllipseColor();
                        }
                        lblTimer.Content = "20";
                        previousTimerColor = lblTimer.Foreground;
                        lblTimer.Foreground = previousTimerColor;
                    }
                    if(!(bool)cbxMute.IsChecked)
                    {
                        if(labelValue <= 3)
                        {
                            lblTimer.Foreground = Brushes.Red;
                            Console.Beep();
                        }
                    }

                }));
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
        /*Forces player to place piece in center on first turn*/
        private void PlayersFirstTurn(Ellipse ellipse)
        {
            if (player1FirstTurn)
            {
                //The opacity of the piece is what we are checking 
                //to see if it has been placed already
                if (ellipse.Opacity == 0)
                {
                    //Locates clicked location
                    int[] pieceLocation = FindPiece(ellipse);
                    //Checks to see if on first turn player clicked in the center of the board. 
                    if (pieceLocation[0] == pL.Board.GetLength(0) / 2 && pieceLocation[1] == pL.Board.GetLength(1) / 2)
                    {
                        //Changes color of piece
                        ellipse.Fill = player1;
                        ellipse.Opacity = 100;
                        pL.TurnOver();
                        HookUpBoards();
                        lastLocation = pieceLocation;
                        player1FirstTurn = false;
                        player1SecondTurn = true;
                        ChangeEllipseColor();
                        lblTimer.Content = "20";
                        if (WithAI)
                        {
                            TakeAITurn();
                        }
                    }
                }
            }
        }

        /*Forces player to place piece 3 locations away from first piece*/
        private void PlayersSecondTurn(Ellipse ellipse)
        {
            //If this is the first player's second turn,
            //they have restricted movement. This handles
            //the restricted movement.
            int[] newPieceLocation = FindPiece(ellipse);

            if (newPieceLocation[0] > lastLocation[0] + tournamentSpaces ||
                (newPieceLocation[0] < lastLocation[0] - tournamentSpaces) ||
                (newPieceLocation[1] > lastLocation[1] + tournamentSpaces) ||
                (newPieceLocation[1] < lastLocation[1] - tournamentSpaces))
            {
                player1SecondTurn = false;
                //The opacity of the piece is what we are checking 
                //to see if it has been placed already
                if (ellipse.Opacity == 0)
                {
                    //Makes the piece the same color as the player who
                    //placed the piece
                    ellipse.Fill = player1;
                    ellipse.Opacity = 100;
                    pL.TurnOver();
                    HookUpBoards();
                    lblTimer.Content = "20";
                    if (WithAI)
                    {
                        TakeAITurn();
                    }
                }
            }

        }

        //Updates the window when a player clicks the board
        //Valid and invalid moves are handled
        private void MouseLeftClick_Down(object sender, RoutedEventArgs e)
        {

            //This check is for tournament rules
            if (player1FirstTurn)
            {
                PlayersFirstTurn((Ellipse)sender);
            }
            else if (!player1SecondTurn || pL.isPlayer1Turn)
            {
                Ellipse ellipse = (Ellipse)sender;
                //The opacity of the piece is what we are checking 
                //to see if it has been placed already
                if (ellipse.Opacity == 0)
                {
                    //Changes the piece placed to match the player's color
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
                        if (WithAI)
                        {
                            TakeAITurn();
                        }
                    }
                    lblTimer.Content = "20";
                    HookUpBoards();
                    int[] pieceLocation = FindPiece(ellipse);
                    //Checks for captures and handles them
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
                    if (pL.Tessera(pieceLocation[0], pieceLocation[1]))
                    {
                        if (pL.isPlayer1Turn)
                        {
                            lblTessera.Content = "Player 1 Tessera";
                            lblTessera.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            lblTessera.Content = "Player 2 Tessera";
                            lblTessera.Visibility = Visibility.Visible;
                        }
                    }
                    else
                    {
                        lblTessera.Visibility = Visibility.Hidden;
                    }
                    HookUpBoards();
                    //Checks for a five-in-a-row win
                    //Both scenarios will open the Game Over Window
                    if (pL.FiveInARow(pieceLocation[0], pieceLocation[1]))
                    {
                        if (!WithAI)
                        {
                            if (pL.isPlayer1Turn)
                            {
                                GameOverWindow gameOverWindow = new GameOverWindow($"{tbxPlayer1Name.Text} wins!", WithAI, GameGrid.Rows);
                                gameOverWindow.Show();
                                Close();
                            }
                            else
                            {
                                GameOverWindow gameOverWindow = new GameOverWindow($"{tbxPlayer2Name.Text} wins!", WithAI, GameGrid.Rows);
                                gameOverWindow.Show();
                                Close();
                            }
                        }
                        else
                        {
                            if (!pL.isPlayer1Turn)
                            {
                                GameOverWindow gameOverWindow = new GameOverWindow($"{tbxPlayer1Name.Text} wins!", WithAI, GameGrid.Rows);
                                gameOverWindow.Show();
                                Close();
                            }
                            else
                            {
                                GameOverWindow gameOverWindow = new GameOverWindow($"{tbxPlayer2Name.Text} wins!", WithAI, GameGrid.Rows);
                                gameOverWindow.Show();
                                Close();
                            }
                        }
                    }
                    //Handles tournament rule
                    if (player1FirstTurn && !pL.isPlayer1Turn)
                    {
                        player1FirstTurn = false;
                        player1SecondTurn = true;
                    }
                }
            }
            else
            {
                PlayersSecondTurn((Ellipse)sender);
            }
            //If either player has captured more
            //than 5 pieces, the game ends and that
            //player wins.
            //Both scenarios open the Game Over Window
            if (pL.player1Captures >= 5)
            {
                GameOverWindow gameOverWindow = new GameOverWindow($"{tbxPlayer1Name.Text} wins!", WithAI, GameGrid.Rows);
                gameOverWindow.Show();
                Close();
            }
            else if (pL.player2Captures >= 5)
            {
                GameOverWindow gameOverWindow = new GameOverWindow($"{tbxPlayer2Name.Text} wins!", WithAI, GameGrid.Rows);
                gameOverWindow.Show();
                Close();
            }
            //Toggles the turn indicator
            ChangeEllipseColor();
        }

        private void TakeAITurn()
        {
            int[] AIPiece = pL.AITurn();
            Ellipse aIEllipse = (Ellipse)GameGrid.Children[AIPiece[0] + AIPiece[1] * GameGrid.Rows];
            aIEllipse.Fill = player2;
            aIEllipse.Opacity = 100;
            pL.TurnOver();
        }

        private void ChangeEllipseColor()
        {
            //Changes the color of the turn indicator
            if (pL.isPlayer1Turn)
            {
                turnIndicator.Fill = player2;
            }
            else
            {
                turnIndicator.Fill = player1;
            }
        }
        #endregion

        #region NameChanging

        #region Player 1 Text
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
        #region Player 2 Text
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
        #endregion

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GameWindow newGame = new GameWindow(GameGrid.Rows, WithAI);
            newGame.Width = Width;
            newGame.Height = Height;
            newGame.Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Instructions instructions = new Instructions();
            instructions.Show();
        }
    }
}
