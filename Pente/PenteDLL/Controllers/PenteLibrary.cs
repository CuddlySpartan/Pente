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

        public bool FiveInARow()
        {

            switch()
            case UpDown:

            case LeftRight:

            case UpRightDownRight:

            case UpLeftDownLeft:

            default:

            return false;
        }

        public int CheckUp(int i, int j, int a)
        {
            if (a == 4)
            {
                return true;
            }

            if ((i - 1) >= 0 && Board[i, j] == Board[i - 1, j])
            {
                if (CheckUp(i - 1, j, a + 1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public int CheckDown(int i, int j)
        {
            return null;

        }

        public int CheckLeft(int i, int j)
        {
            return null;

        }

        public int CheckRight(int i, int j)
        {
            return null;
        }
    }
}
