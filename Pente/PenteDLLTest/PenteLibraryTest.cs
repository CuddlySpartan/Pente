using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PenteDLL.Controllers;

namespace PenteDLLTest
{
    [TestClass]
    public class PenteLibraryTest
    {
        PenteLibrary pente = new PenteLibrary();
        [TestMethod]
        public void TesseraTestVerticle()
        {//this way -> |
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[3, 0] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTessera = pente.Tessera();
            Assert.IsTrue(isTessera);
        }
        [TestMethod]
        public void TesseraTestHorizontal()
        {//this way -> -
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 2] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 3] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTessera = pente.Tessera();
            Assert.IsTrue(isTessera);
        }
        [TestMethod]
        public void TesseraTestDiagonalPositive()
        {// this way -> /
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[3, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 2] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 3] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTessera = pente.Tessera();
            Assert.IsTrue(isTessera);
        }
        [TestMethod]
        public void TesseraTestDiagonalNegative()
        {// this way -> \
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[3, 3] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTessera = pente.Tessera();
            Assert.IsTrue(isTessera);
        }

        [TestMethod]
        public void TriaTestVerticle()
        {//this way -> |
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 0] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria();
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void TriaTestHorizontal()
        {//this way -> -
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 2] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria();
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void TriaTestDiagonalPositive()
        {// this way -> /
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[3, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 2] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria();
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void TriaTestDiagonalNegative()
        {//this way -> \
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria();
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void WhiteWinPente()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void WhiteWinCapture()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void BlackWinPente()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void BlackWinCapture()
        {
            Assert.Inconclusive();
        }
    }
}
