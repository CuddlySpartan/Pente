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




            return false;
        }

        //public bool FiveUp(int i, int j, int a)
        //{
        //    if (a == 4)
        //    {
        //        return true;
        //    }

        //    if ((i - 1) >= 0 && Board[i, j] == Board[i-1, j])
        //    {
        //        if (FiveUp(i - 1, j, a + 1))
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}

        //public bool FiveDown(int i, int j)
        //{

        //}

        //public bool FiveLeft(int i, int j)
        //{

        //}

        //public bool FiveRight(int i, int j)
        //{

        //}
    }
}
