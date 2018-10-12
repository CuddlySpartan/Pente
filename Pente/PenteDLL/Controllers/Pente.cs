using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pente.Controllers
{
    class Pente
    {
        
        enum Color
        {
            EMPTY,
            BLACK,
            WHITE
        }

        struct PenteBoard
        {
            public Color[,] Board { get; set; }
        }

        public void StartGame()
        {
            PenteBoard pente = new PenteBoard();
            pente.Board = new Color[19, 19];

        }


        public void Tessera()
        {

        }

        public void Tria()
        {

        }
    }
}
