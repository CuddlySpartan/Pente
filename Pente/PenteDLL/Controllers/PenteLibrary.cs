using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenteDLL.Controllers
{
    public class PenteLibrary
    {
        public enum PlayerPiece
        {
            EMPTY,
            PLAYER1,
            PLAYER2
        }

        public PlayerPiece[,] Board { get; set; }

        public void StartGame()
        {
            Board = new PlayerPiece[19, 19];
        }

        public void Tessera()
        {

        }

        public void Tria()
        {

        }

        public bool isPlayer2Turn = false;

        public void TurnOver()
        {
            isPlayer2Turn = !isPlayer2Turn;
        }

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
        //Checks for 5 in a row wins
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
            if ((column - 1) >= 0 && (row + 1) <= Board.GetLength(0) && (Board[row, column] == Board[row + 1, column - 1]))
            {
                a = CheckDownLeft(row + 1, column - 1, a + 1);
            }
            return a;

        }

        public int CheckRight(int row, int column, int a)
        {
            if ((column + 1) <= Board.GetLength(0) && (Board[row, column] == Board[row, column + 1]))
            {
                a = CheckRight(row, column + 1, a + 1);
            }
            return a;
        }

        public int CheckUpRight(int row, int column, int a)
        {
            if ((column + 1) <= Board.GetLength(0) && (row - 1) >= 0 && (Board[row, column] == Board[row - 1, column + 1]))
            {
                a = CheckUpRight(row - 1, column + 1, a + 1);
            }
            return a;
        }

        public int CheckDownRight(int row, int column, int a)
        {
            if ((column + 1) <= Board.GetLength(0) && (row + 1) <= Board.GetLength(0) && (Board[row, column] == Board[row + 1, column + 1]))
            {
                a = CheckDownRight(row + 1, column + 1, a + 1);
            }
            return a;
        }
        #endregion

        public int[] Capture(int i, int j)
        {
            bool capture = false;
            if (CaptureUp(j, i))
            {
                capture = true;
            }
            else if (CaptureDown(j, i))
            {


            }
            else if (CaptureLeft(j, i))
            {

            }
            else if (CaptureRight(j, i))
            {

            }
            else if (CaptureUpLeft(j, i))
            {

            }
            else if (CaptureDownLeft(j, i))
            {

            }
            else if (CaptureUpRight(j, i))
            {

            }
            else if (CaptureDownRight(j, i))
            {

            }

            if(capture)
            {
                int[] boardReturn = { i, j};
                return boardReturn;
            }
            else
            {
                int[] boardReturn = { Board.GetLength(0)+1, Board.GetLength(1)};
                return boardReturn;
            }
        }

        #region caputuring
        public bool CaptureUp(int row, int column)
        {
            if ((row - 3) >= 0 && Board[row - 1, column] != Board[row, column]
                && Board[row - 2, column] != Board[row, column] && Board[row - 3, column] == Board[row, column])
            {
                return true;
            }
            return false;
        }

        public bool CaptureDown(int row, int column)
        {
            if ((row + 3) <= Board.GetLength(0) && Board[row + 1, column] != Board[row, column]
                && Board[row + 2, column] != Board[row, column] && Board[row + 3, column] == Board[row, column])
            {
                return true;
            }
            return false;
        }

        public bool CaptureLeft(int row, int column)
        {
            if ((column - 3) >= 0 && Board[row, column - 1] != Board[row, column]
                && Board[row, column - 2] != Board[row, column] && Board[row, column - 3] == Board[row, column])
            {
                return true;
            }
            return false;
        }

        public bool CaptureRight(int row, int column)
        {
            if ((column + 3) <= Board.GetLength(0) && Board[row, column + 1] != Board[row, column]
                && Board[row, column + 2] != Board[row, column] && Board[row, column + 3] == Board[row, column])
            {
                return true;
            }
            return false;
        }

        public bool CaptureUpLeft(int row, int column)
        {
            if ((row - 3) >= 0 && (column - 3) >= 0 && Board[row - 1, column - 1] != Board[row, column]
                && Board[row - 2, column - 2] != Board[row, column] && Board[row - 3, column - 3] == Board[row, column])
            {
                return true;
            }
            return false;
        }

        public bool CaptureDownLeft(int row, int column)
        {
            if ((row + 3) <= Board.GetLength(0) && (column - 3) >= 0 && Board[row + 1, column - 1] != Board[row, column]
                && Board[row + 2, column - 2] != Board[row, column] && Board[row + 3, column - 3] == Board[row, column])
            {
                return true;
            }
            return false;
        }

        public bool CaptureUpRight(int row, int column)
        {
            if ((row - 3) >= 0 && (column + 3) <= Board.GetLength(0) && Board[row - 1, column + 1] != Board[row, column]
                && Board[row - 2, column + 2] != Board[row, column] && Board[row - 3, column + 3] == Board[row, column])
            {
                return true;
            }
            return false;
        }

        public bool CaptureDownRight(int row, int column)
        {
            if ((row + 3) <= Board.GetLength(0) && (column + 3) <= Board.GetLength(0) && Board[row + 1, column + 1] != Board[row, column]
                && Board[row + 2, column + 2] != Board[row, column] && Board[row + 3, column + 3] == Board[row, column])
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
