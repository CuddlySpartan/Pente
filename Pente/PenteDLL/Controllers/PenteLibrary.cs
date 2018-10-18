using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenteDLL.Controllers
{
    public class PenteLibrary
    {
        //Whose turn it is
        //This determines what color the piece is
        public bool isPlayer1Turn = false;

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

        public void StartGame()
        {
            //Initializes the board
            Board = new PlayerPiece[19, 19];
        }

        public void Tessera()
        {
            //Detects Tessera
        }

        public void Tria()
        {
            //Detects Tria
        }



        public void TurnOver()
        {
            //Toggles which turn it is
            isPlayer1Turn = !isPlayer1Turn;
        }

        public bool FiveInARow(int i, int j)
        {
            //Adds together how many pieces are in a row
            //If it's 5 or more the player wins
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

        public List<int> Capture(int column, int row)
        {
            //When a piece is placed that satisfies the
            //conditions for capturing, the pieces captured
            //are removed from the board.
            List<int> spacesCaptured = new List<int>();
            if (CaptureUp(row, column))
            {
                spacesCaptured.Add(row-1);
                spacesCaptured.Add(column);
                spacesCaptured.Add(row-2);
                spacesCaptured.Add(column);
            }
            if (CaptureDown(row, column))
            {
                spacesCaptured.Add(row+1);
                spacesCaptured.Add(column);
                spacesCaptured.Add(row+2);
                spacesCaptured.Add(column);
            }
            if (CaptureLeft(row, column))
            {
                spacesCaptured.Add(row);
                spacesCaptured.Add(column-1);
                spacesCaptured.Add(row);
                spacesCaptured.Add(column-2);
            }
            if (CaptureRight(row, column))
            {
                spacesCaptured.Add(row);
                spacesCaptured.Add(column + 1);
                spacesCaptured.Add(row);
                spacesCaptured.Add(column+2);
            }
            if (CaptureUpLeft(row, column))
            {
                spacesCaptured.Add(row-1);
                spacesCaptured.Add(column - 1);
                spacesCaptured.Add(row-2);
                spacesCaptured.Add(column - 2);

            }
            if (CaptureDownLeft(row, column))
            {
                spacesCaptured.Add(row+1);
                spacesCaptured.Add(column - 1);
                spacesCaptured.Add(row+2);
                spacesCaptured.Add(column - 2);

            }
            if (CaptureUpRight(row, column))
            {
                spacesCaptured.Add(row-1);
                spacesCaptured.Add(column + 1);
                spacesCaptured.Add(row-2);
                spacesCaptured.Add(column + 2);

            }
            if (CaptureDownRight(row, column))
            {
                spacesCaptured.Add(row+1);
                spacesCaptured.Add(column + 1);
                spacesCaptured.Add(row+2);
                spacesCaptured.Add(column + 2);
            }
            for(int i =0; i < spacesCaptured.Count; i=i+4)
            {
                if(isPlayer1Turn)
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
                if(Board[row - 1, column] != PlayerPiece.EMPTY && Board[row - 2, column] != PlayerPiece.EMPTY)
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
                if (Board[row, column-1] != PlayerPiece.EMPTY && Board[row, column-2] != PlayerPiece.EMPTY)
                    return true;
            }
            return false;
        }

        public bool CaptureRight(int row, int column)
        {
            if ((column + 3) < Board.GetLength(0) && Board[row, column + 1] != Board[row, column]
                && Board[row, column + 2] != Board[row, column] && Board[row, column + 3] == Board[row, column])
            {
                if (Board[row, column+1] != PlayerPiece.EMPTY && Board[row, column+1] != PlayerPiece.EMPTY)
                    return true;
            }
            return false;
        }

        public bool CaptureUpLeft(int row, int column)
        {
            if ((row - 3) >= 0 && (column - 3) >= 0 && Board[row - 1, column - 1] != Board[row, column]
                && Board[row - 2, column - 2] != Board[row, column] && Board[row - 3, column - 3] == Board[row, column])
            {
                if (Board[row - 1, column-1] != PlayerPiece.EMPTY && Board[row - 2, column-2] != PlayerPiece.EMPTY)
                    return true;
            }
            return false;
        }

        public bool CaptureDownLeft(int row, int column)
        {
            if ((row + 3) < Board.GetLength(0) && (column - 3) >= 0 && Board[row + 1, column - 1] != Board[row, column]
                && Board[row + 2, column - 2] != Board[row, column] && Board[row + 3, column - 3] == Board[row, column])
            {
                if (Board[row + 1, column-1] != PlayerPiece.EMPTY && Board[row + 2, column-2] != PlayerPiece.EMPTY)
                    return true;
            }
            return false;
        }

        public bool CaptureUpRight(int row, int column)
        {
            if ((row - 3) >= 0 && (column + 3) < Board.GetLength(0) && Board[row - 1, column + 1] != Board[row, column]
                && Board[row - 2, column + 2] != Board[row, column] && Board[row - 3, column + 3] == Board[row, column])
            {
                if (Board[row - 1, column+1] != PlayerPiece.EMPTY && Board[row - 2, column+2] != PlayerPiece.EMPTY)
                    return true;
            }
            return false;
        }

        public bool CaptureDownRight(int row, int column)
        {
            if ((row + 3) < Board.GetLength(0) && (column + 3) < Board.GetLength(0) && Board[row + 1, column + 1] != Board[row, column]
                && Board[row + 2, column + 2] != Board[row, column] && Board[row + 3, column + 3] == Board[row, column])
            {
                if (Board[row + 2, column+2] != PlayerPiece.EMPTY && Board[row + 1, column+1] != PlayerPiece.EMPTY)
                    return true;
            }
            return false;
        }
        #endregion
    }
}
