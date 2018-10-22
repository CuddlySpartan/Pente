using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PenteDLL.Controllers
{
    public class PenteLibrary
    {
        //Whose turn it is
        //This determines what color the piece is
        public bool isPlayer2Turn = false;

        //The board
        public PlayerPiece[,] Board { get; set; }

        //Counter for how many captures each player has
        //If this is 5 or more, that player wins
        public int player1Captures = 0;
        public int player2Captures = 0;


        public enum PlayerPiece
        {
            //Enum for determining which player owns which piece
            EMPTY,
            PLAYER1,
            PLAYER2
        }

        public void StartGame(int size)
        {
            //Initializes the board
            Board = new PlayerPiece[size, size];

        }

        //Detects Tessera
        public bool Tessera(int column, int row)
        {
            if (CheckTesseraUp(row, column, 0) + CheckTesseraDown(row, column, 1) == 6)
            {
                return true;
            }

            if (CheckTesseraLeft(row, column, 0) + CheckTesseraRight(row, column, 1) == 6)
            {
                return true;
            }

            if (CheckTesseraUpLeft(row, column, 0) + CheckTesseraDownRight(row, column, 1) == 6)
            {
                return true;
            }

            if (CheckTesseraDownLeft(row, column, 0) + CheckTesseraUpRight(row, column, 1) == 6)
            {
                return true;
            }

            return false;
        }

        #region Tessera Checking
        //Tessera detecting logic
        public int CheckTesseraUp(int row, int column, int a)
        {
            if ((row - 1) >= 0 && (Board[row, column] == Board[row - 1, column] || Board[row - 1, column] == PlayerPiece.EMPTY))
            {
                if (Board[row - 1, column] == PlayerPiece.EMPTY)
                {
                    return a + 1;
                }
                else
                {
                    a = CheckTesseraUp(row - 1, column, a + 1);
                }
            }
            return a;
        }

        public int CheckTesseraDown(int row, int column, int a)
        {
            if ((row + 1) < Board.GetLength(0) && (Board[row, column] == Board[row + 1, column] || Board[row + 1, column] == PlayerPiece.EMPTY))
            {
                if (Board[row + 1, column] == PlayerPiece.EMPTY)
                {
                    return a + 1;
                }
                else
                {
                    a = CheckTesseraDown(row + 1, column, a + 1);
                }
            }
            return a;
        }

        public int CheckTesseraLeft(int row, int column, int a)
        {
            if ((column - 1) >= 0 && (Board[row, column] == Board[row, column - 1] || Board[row, column - 1] == PlayerPiece.EMPTY))
            {
                if (Board[row, column - 1] == PlayerPiece.EMPTY)
                {
                    return a + 1;
                }
                else
                {
                    a = CheckTesseraLeft(row, column - 1, a + 1);
                }
            }
            return a;
        }

        public int CheckTesseraRight(int row, int column, int a)
        {
            if ((column + 1) < Board.GetLength(0) && (Board[row, column] == Board[row, column + 1] || Board[row, column + 1] == PlayerPiece.EMPTY))
            {
                if (Board[row, column + 1] == PlayerPiece.EMPTY)
                {
                    return a + 1;
                }
                else
                {
                    a = CheckTesseraRight(row, column + 1, a + 1);
                }
            }
            return a;
        }

        public int CheckTesseraUpLeft(int row, int column, int a)
        {
            if ((row - 1) >= 0 && (column - 1) >= 0 && (Board[row, column] == Board[row - 1, column - 1] || Board[row - 1, column - 1] == PlayerPiece.EMPTY))
            {
                if (Board[row - 1, column - 1] == PlayerPiece.EMPTY)
                {
                    return a + 1;
                }
                else
                {
                    a = CheckTesseraUpLeft(row - 1, column - 1, a + 1);
                }
            }
            return a;
        }

        public int CheckTesseraDownLeft(int row, int column, int a)
        {
            if ((row + 1) < Board.GetLength(0) && (column - 1) >= 0 && (Board[row, column] == Board[row + 1, column - 1] || Board[row + 1, column - 1] == PlayerPiece.EMPTY))
            {
                if (Board[row + 1, column - 1] == PlayerPiece.EMPTY)
                {
                    return a + 1;
                }
                else
                {
                    a = CheckTesseraDownLeft(row + 1, column - 1, a + 1);
                }
            }
            return a;
        }

        public int CheckTesseraUpRight(int row, int column, int a)
        {
            if ((row - 1) >= 0 && (column + 1) < Board.GetLength(0) && (Board[row, column] == Board[row - 1, column + 1] || Board[row - 1, column + 1] == PlayerPiece.EMPTY))
            {
                if (Board[row - 1, column + 1] == PlayerPiece.EMPTY)
                {
                    return a + 1;
                }
                else
                {
                    a = CheckTesseraUpRight(row - 1, column + 1, a + 1);
                }
            }
            return a;
        }

        public int CheckTesseraDownRight(int row, int column, int a)
        {
            if ((row + 1) < Board.GetLength(0) && (column + 1) < Board.GetLength(0) && (Board[row, column] == Board[row + 1, column + 1] || Board[row + 1, column + 1] == PlayerPiece.EMPTY))
            {
                if (Board[row + 1, column + 1] == PlayerPiece.EMPTY)
                {
                    return a + 1;
                }
                else
                {
                    a = CheckTesseraDownRight(row + 1, column + 1, a + 1);
                }
            }
            return a;
        }
        #endregion

        #region Tria Checking

        public string Tria(int i, int j)
        {
            //Detects Tria

            //For the sake of convenience to the developers, 
            //the entire board is checked for any trias
            //A string is returned saying which player has the tria
            //if there is one
            PlayerPiece piece;
            piece = CheckTriaUp(j, i);
            if (piece == PlayerPiece.PLAYER1)
            {
                return "Player1";
            }
            else if (piece == PlayerPiece.PLAYER2)
            {
                return "Player2";
            }
            piece = CheckTriaDown(j, i);
            if (piece == PlayerPiece.PLAYER1)
            {
                return "Player1";
            }
            else if (piece == PlayerPiece.PLAYER2)
            {
                return "Player2";
            }
            piece = CheckTriaLeft(j, i);
            if (piece == PlayerPiece.PLAYER1)
            {
                return "Player1";
            }
            else if (piece == PlayerPiece.PLAYER2)
            {
                return "Player2";
            }
            piece = CheckTriaRight(j, i);
            if (piece == PlayerPiece.PLAYER1)
            {
                return "Player1";
            }
            else if (piece == PlayerPiece.PLAYER2)
            {
                return "Player2";
            }
            piece = CheckTriaUpLeft(j, i);
            if (piece == PlayerPiece.PLAYER1)
            {
                return "Player1";
            }
            else if (piece == PlayerPiece.PLAYER2)
            {
                return "Player2";
            }
            piece = CheckTriaUpRight(j, i);
            if (piece == PlayerPiece.PLAYER1)
            {
                return "Player1";
            }
            else if (piece == PlayerPiece.PLAYER2)
            {
                return "Player2";
            }
            piece = CheckTriaDownLeft(j, i);
            if (piece == PlayerPiece.PLAYER1)
            {
                return "Player1";
            }
            else if (piece == PlayerPiece.PLAYER2)
            {
                return "Player2";
            }
            piece = CheckTriaDownRight(j, i);
            if (piece == PlayerPiece.PLAYER1)
            {
                return "Player1";
            }
            else if (piece == PlayerPiece.PLAYER2)
            {
                return "Player2";
            }

            return "";
        }

        //Tria checking logic
        public PlayerPiece CheckTriaUp(int row, int column)
        {
            if ((row - 5) >= 0 && Board[row, column] == PlayerPiece.EMPTY && Board[row - 1, column] != PlayerPiece.EMPTY && Board[row - 2, column] == Board[row - 1, column]
                && Board[row - 3, column] == PlayerPiece.EMPTY && Board[row - 4, column] == Board[row - 1, column] && Board[row - 5, column] == PlayerPiece.EMPTY)
            {
                return Board[row - 1, column];
            }
            if ((row - 4) >= 0 && Board[row, column] == PlayerPiece.EMPTY && Board[row - 1, column] != PlayerPiece.EMPTY && Board[row - 2, column] == Board[row - 1, column]
                && Board[row - 3, column] == Board[row - 1, column] && Board[row - 4, column] == PlayerPiece.EMPTY)
            {
                return Board[row - 1, column];
            }
            return PlayerPiece.EMPTY;
        }

        public PlayerPiece CheckTriaDown(int row, int column)
        {
            if ((row + 5) < Board.GetLength(0) && Board[row, column] == PlayerPiece.EMPTY && Board[row + 1, column] != PlayerPiece.EMPTY && Board[row + 2, column] == Board[row + 1, column]
                && Board[row + 3, column] == PlayerPiece.EMPTY && Board[row + 4, column] == Board[row + 1, column] && Board[row + 5, column] == PlayerPiece.EMPTY)
            {
                return Board[row + 1, column];
            }
            if ((row + 4) < Board.GetLength(0) && Board[row, column] == PlayerPiece.EMPTY && Board[row + 1, column] != PlayerPiece.EMPTY && Board[row + 2, column] == Board[row + 1, column]
                && Board[row + 3, column] == Board[row + 1, column] && Board[row + 4, column] == PlayerPiece.EMPTY)
            {
                return Board[row + 1, column];
            }
            return PlayerPiece.EMPTY;
        }

        public PlayerPiece CheckTriaLeft(int row, int column)
        {
            if ((column - 5) >= 0 && Board[row, column] == PlayerPiece.EMPTY && Board[row, column - 1] != PlayerPiece.EMPTY && Board[row, column - 2] == Board[row, column - 1]
                && Board[row, column - 3] == PlayerPiece.EMPTY && Board[row, column - 4] == Board[row, column - 1] && Board[row, column - 5] == PlayerPiece.EMPTY)
            {
                return Board[row, column - 1];
            }
            if ((column - 4) >= 0 && Board[row, column] == PlayerPiece.EMPTY && Board[row, column - 1] != PlayerPiece.EMPTY && Board[row, column - 2] == Board[row, column - 1]
                && Board[row, column - 3] == Board[row, column - 1] && Board[row, column - 4] == PlayerPiece.EMPTY)
            {
                return Board[row, column - 1];
            }
            return PlayerPiece.EMPTY;
        }

        public PlayerPiece CheckTriaRight(int row, int column)
        {
            if ((column + 5) < Board.GetLength(0) && Board[row, column] == PlayerPiece.EMPTY && Board[row, column + 1] != PlayerPiece.EMPTY && Board[row, column + 2] == Board[row, column + 1]
                && Board[row, column + 3] == PlayerPiece.EMPTY && Board[row, column + 4] == Board[row, column + 1] && Board[row, column + 5] == PlayerPiece.EMPTY)
            {
                return Board[row, column + 1];
            }
            if ((column + 4) < Board.GetLength(0) && Board[row, column] == PlayerPiece.EMPTY && Board[row, column + 1] != PlayerPiece.EMPTY && Board[row, column + 2] == Board[row, column + 1]
                && Board[row, column + 3] == Board[row, column + 1] && Board[row, column + 4] == PlayerPiece.EMPTY)
            {
                return Board[row, column + 1];
            }
            return PlayerPiece.EMPTY;
        }

        public PlayerPiece CheckTriaUpLeft(int row, int column)
        {
            if ((column - 5) >= 0 && (row - 5) >= 0 && Board[row, column] == PlayerPiece.EMPTY && Board[row - 1, column - 1] != PlayerPiece.EMPTY && Board[row - 2, column - 2] == Board[row - 1, column - 1]
                && Board[row - 3, column - 3] == PlayerPiece.EMPTY && Board[row - 4, column - 4] == Board[row - 1, column - 1] && Board[row - 5, column - 5] == PlayerPiece.EMPTY)
            {
                return Board[row - 1, column - 1];
            }
            if ((column - 4) >= 0 && (row - 4) >= 0 && Board[row, column] == PlayerPiece.EMPTY && Board[row - 1, column - 1] != PlayerPiece.EMPTY && Board[row - 2, column - 2] == Board[row - 1, column - 1]
                && Board[row - 3, column - 3] == Board[row - 1, column - 1] && Board[row - 4, column - 4] == PlayerPiece.EMPTY)
            {
                return Board[row - 1, column - 1];
            }
            return PlayerPiece.EMPTY;
        }

        public PlayerPiece CheckTriaDownLeft(int row, int column)
        {
            if ((column - 5) >= 0 && (row + 5) < Board.GetLength(0) && Board[row, column] == PlayerPiece.EMPTY && Board[row + 1, column - 1] != PlayerPiece.EMPTY && Board[row + 2, column - 2] == Board[row + 1, column - 1]
                && Board[row + 3, column - 3] == PlayerPiece.EMPTY && Board[row + 4, column - 4] == Board[row + 1, column - 1] && Board[row + 5, column - 5] == PlayerPiece.EMPTY)
            {
                return Board[row + 1, column - 1];
            }
            if ((column - 4) >= 0 && (row + 4) < Board.GetLength(0) && Board[row, column] == PlayerPiece.EMPTY && Board[row + 1, column - 1] != PlayerPiece.EMPTY && Board[row + 2, column - 2] == Board[row + 1, column - 1]
                && Board[row + 3, column - 3] == Board[row + 1, column - 1] && Board[row + 4, column - 4] == PlayerPiece.EMPTY)
            {
                return Board[row + 1, column - 1];
            }
            return PlayerPiece.EMPTY;
        }

        public PlayerPiece CheckTriaUpRight(int row, int column)
        {
            if ((column + 5) < Board.GetLength(0) && (row - 5) >= 0 && Board[row, column] == PlayerPiece.EMPTY && Board[row - 1, column + 1] != PlayerPiece.EMPTY && Board[row - 2, column + 2] == Board[row - 1, column + 1]
                && Board[row - 3, column + 3] == PlayerPiece.EMPTY && Board[row - 4, column + 4] == Board[row - 1, column + 1] && Board[row - 5, column + 5] == PlayerPiece.EMPTY)
            {
                return Board[row - 1, column + 1];
            }
            if ((column + 4) < Board.GetLength(0) && (row - 4) >= 0 && Board[row, column] == PlayerPiece.EMPTY && Board[row - 1, column + 1] != PlayerPiece.EMPTY && Board[row - 2, column + 2] == Board[row - 1, column + 1]
                && Board[row - 3, column + 3] == Board[row - 1, column + 1] && Board[row - 4, column + 4] == PlayerPiece.EMPTY)
            {
                return Board[row - 1, column + 1];
            }
            return PlayerPiece.EMPTY;
        }

        public PlayerPiece CheckTriaDownRight(int row, int column)
        {
            if ((column + 5) < Board.GetLength(0) && (row + 5) < Board.GetLength(0) && Board[row, column] == PlayerPiece.EMPTY && Board[row + 1, column + 1] != PlayerPiece.EMPTY && Board[row + 2, column + 2] == Board[row + 1, column + 1]
                && Board[row + 3, column + 3] == PlayerPiece.EMPTY && Board[row + 4, column + 4] == Board[row + 1, column + 1] && Board[row + 5, column + 5] == PlayerPiece.EMPTY)
            {
                return Board[row + 1, column + 1];
            }
            if ((column + 4) < Board.GetLength(0) && (row + 4) < Board.GetLength(0) && Board[row, column] == PlayerPiece.EMPTY && Board[row + 1, column + 1] != PlayerPiece.EMPTY && Board[row + 2, column + 2] == Board[row + 1, column + 1]
                && Board[row + 3, column + 3] == Board[row + 1, column + 1] && Board[row + 4, column + 4] == PlayerPiece.EMPTY)
            {
                return Board[row + 1, column + 1];
            }
            return PlayerPiece.EMPTY;
        }

        #endregion

        public void TurnOver()
        {
            //Toggles which turn it is
            isPlayer2Turn = !isPlayer2Turn;
        }

        public int[] AITurn()
        {
            //AI selects a random space based on spaces available
            Random r = new Random();

            int row;
            int column;
            while (true)
            {
                row = r.Next(Board.GetLength(0));
                column = r.Next(Board.GetLength(0));
                if (Board[row, column] == PlayerPiece.EMPTY)
                {
                    return new int[] { column, row };
                }
            }
        }

        /*Adds together how many pieces are in a row
        If it's 5 or more the player wins*/
        public bool FiveInARow(int i, int j)
        {
            if (CheckUp(j, i, 0) + CheckDown(j, i, 1) >= 5)
            {
                return true;
            }

            if (CheckLeft(j, i, 0) + CheckRight(j, i, 1) >= 5)
            {
                return true;
            }

            if (CheckUpLeft(j, i, 0) + CheckDownRight(j, i, 1) >= 5)
            {
                return true;
            }

            if (CheckDownLeft(j, i, 0) + CheckUpRight(j, i, 1) >= 5)
            {
                return true;
            }

            return false;
        }

        #region checking
        //Checks for 5 in a row wins in every direction
        public int CheckUp(int row, int column, int a)
        {
            if ((row - 1) >= 0 && (Board[row, column] == Board[row - 1, column]))
            {
                a = CheckUp(row - 1, column, a + 1);
            }
            return a;
        }

        public int CheckDown(int row, int column, int a)
        {
            if ((row + 1) < Board.GetLength(0) && (Board[row, column] == Board[row + 1, column]))
            {
                a = CheckDown(row + 1, column, a + 1);
            }
            return a;
        }

        public int CheckLeft(int row, int column, int a)
        {
            if ((column - 1) >= 0 && (Board[row, column] == Board[row, column - 1]))
            {
                a = CheckLeft(row, column - 1, a + 1);
            }
            return a;

        }

        public int CheckUpLeft(int row, int column, int a)
        {
            if ((column - 1) >= 0 && (row - 1) >= 0 && (Board[row, column] == Board[row - 1, column - 1]))
            {
                a = CheckUpLeft(row - 1, column - 1, a + 1);
            }
            return a;

        }

        public int CheckDownLeft(int row, int column, int a)
        {
            if ((column - 1) >= 0 && (row + 1) < Board.GetLength(0) && (Board[row, column] == Board[row + 1, column - 1]))
            {
                a = CheckDownLeft(row + 1, column - 1, a + 1);
            }
            return a;

        }

        public int CheckRight(int row, int column, int a)
        {
            if ((column + 1) < Board.GetLength(0) && (Board[row, column] == Board[row, column + 1]))
            {
                a = CheckRight(row, column + 1, a + 1);
            }
            return a;
        }

        public int CheckUpRight(int row, int column, int a)
        {
            if ((column + 1) < Board.GetLength(0) && (row - 1) >= 0 && (Board[row, column] == Board[row - 1, column + 1]))
            {
                a = CheckUpRight(row - 1, column + 1, a + 1);
            }
            return a;
        }

        public int CheckDownRight(int row, int column, int a)
        {
            if ((column + 1) < Board.GetLength(0) && (row + 1) < Board.GetLength(0) && (Board[row, column] == Board[row + 1, column + 1]))
            {
                a = CheckDownRight(row + 1, column + 1, a + 1);
            }
            return a;
        }
        #endregion

        /*When a piece is placed that satisfies the
        conditions for capturing, the pieces captured
        are removed from the board.*/
        public List<int> Capture(int column, int row)
        {
            List<int> spacesCaptured = new List<int>();
            if (CaptureUp(row, column))
            {
                spacesCaptured.Add(row - 1);
                spacesCaptured.Add(column);
                spacesCaptured.Add(row - 2);
                spacesCaptured.Add(column);
            }
            if (CaptureDown(row, column))
            {
                spacesCaptured.Add(row + 1);
                spacesCaptured.Add(column);
                spacesCaptured.Add(row + 2);
                spacesCaptured.Add(column);
            }
            if (CaptureLeft(row, column))
            {
                spacesCaptured.Add(row);
                spacesCaptured.Add(column - 1);
                spacesCaptured.Add(row);
                spacesCaptured.Add(column - 2);
            }
            if (CaptureRight(row, column))
            {
                spacesCaptured.Add(row);
                spacesCaptured.Add(column + 1);
                spacesCaptured.Add(row);
                spacesCaptured.Add(column + 2);
            }
            if (CaptureUpLeft(row, column))
            {
                spacesCaptured.Add(row - 1);
                spacesCaptured.Add(column - 1);
                spacesCaptured.Add(row - 2);
                spacesCaptured.Add(column - 2);

            }
            if (CaptureDownLeft(row, column))
            {
                spacesCaptured.Add(row + 1);
                spacesCaptured.Add(column - 1);
                spacesCaptured.Add(row + 2);
                spacesCaptured.Add(column - 2);

            }
            if (CaptureUpRight(row, column))
            {
                spacesCaptured.Add(row - 1);
                spacesCaptured.Add(column + 1);
                spacesCaptured.Add(row - 2);
                spacesCaptured.Add(column + 2);

            }
            if (CaptureDownRight(row, column))
            {
                spacesCaptured.Add(row + 1);
                spacesCaptured.Add(column + 1);
                spacesCaptured.Add(row + 2);
                spacesCaptured.Add(column + 2);
            }
            for (int i = 0; i < spacesCaptured.Count; i = i + 4)
            {
                if (isPlayer2Turn)
                {
                    player1Captures++;
                }
                else
                {
                    player2Captures++;
                }
            }
            return spacesCaptured;
        }

        #region capturing
        //Capturing Logic
        public bool CaptureUp(int row, int column)
        {
            if ((row - 3) >= 0 && Board[row - 1, column] != Board[row, column]
                && Board[row - 2, column] != Board[row, column] && Board[row - 3, column] == Board[row, column])
            {
                if (Board[row - 1, column] != PlayerPiece.EMPTY && Board[row - 2, column] != PlayerPiece.EMPTY)
                    return true;
            }
            return false;
        }

        public bool CaptureDown(int row, int column)
        {
            if ((row + 3) < Board.GetLength(0) && Board[row + 1, column] != Board[row, column]
                && Board[row + 2, column] != Board[row, column] && Board[row + 3, column] == Board[row, column])
            {
                if (Board[row + 1, column] != PlayerPiece.EMPTY && Board[row + 2, column] != PlayerPiece.EMPTY)
                    return true;
            }
            return false;
        }

        public bool CaptureLeft(int row, int column)
        {
            if ((column - 3) >= 0 && Board[row, column - 1] != Board[row, column]
                && Board[row, column - 2] != Board[row, column] && Board[row, column - 3] == Board[row, column])
            {
                if (Board[row, column - 1] != PlayerPiece.EMPTY && Board[row, column - 2] != PlayerPiece.EMPTY)
                    return true;
            }
            return false;
        }

        public bool CaptureRight(int row, int column)
        {
            if ((column + 3) < Board.GetLength(0) && Board[row, column + 1] != Board[row, column]
                && Board[row, column + 2] != Board[row, column] && Board[row, column + 3] == Board[row, column])
            {
                if (Board[row, column + 1] != PlayerPiece.EMPTY && Board[row, column + 2] != PlayerPiece.EMPTY)
                    return true;
            }
            return false;
        }

        public bool CaptureUpLeft(int row, int column)
        {
            if ((row - 3) >= 0 && (column - 3) >= 0 && Board[row - 1, column - 1] != Board[row, column]
                && Board[row - 2, column - 2] != Board[row, column] && Board[row - 3, column - 3] == Board[row, column])
            {
                if (Board[row - 1, column - 1] != PlayerPiece.EMPTY && Board[row - 2, column - 2] != PlayerPiece.EMPTY)
                    return true;
            }
            return false;
        }

        public bool CaptureDownLeft(int row, int column)
        {
            if ((row + 3) < Board.GetLength(0) && (column - 3) >= 0 && Board[row + 1, column - 1] != Board[row, column]
                && Board[row + 2, column - 2] != Board[row, column] && Board[row + 3, column - 3] == Board[row, column])
            {
                if (Board[row + 1, column - 1] != PlayerPiece.EMPTY && Board[row + 2, column - 2] != PlayerPiece.EMPTY)
                    return true;
            }
            return false;
        }

        public bool CaptureUpRight(int row, int column)
        {
            if ((row - 3) >= 0 && (column + 3) < Board.GetLength(0) && Board[row - 1, column + 1] != Board[row, column]
                && Board[row - 2, column + 2] != Board[row, column] && Board[row - 3, column + 3] == Board[row, column])
            {
                if (Board[row - 1, column + 1] != PlayerPiece.EMPTY && Board[row - 2, column + 2] != PlayerPiece.EMPTY)
                    return true;
            }
            return false;
        }

        public bool CaptureDownRight(int row, int column)
        {
            if ((row + 3) < Board.GetLength(0) && (column + 3) < Board.GetLength(0) && Board[row + 1, column + 1] != Board[row, column]
                && Board[row + 2, column + 2] != Board[row, column] && Board[row + 3, column + 3] == Board[row, column])
            {
                if (Board[row + 2, column + 2] != PlayerPiece.EMPTY && Board[row + 1, column + 1] != PlayerPiece.EMPTY)
                    return true;
            }
            return false;
        }
        #endregion
    }
}
