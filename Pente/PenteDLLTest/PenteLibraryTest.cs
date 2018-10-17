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
        public void TesseraTestVerticlePass()
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
        public void TesseraTestVerticleFail()
        {//this way -> |
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[5, 0] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTessera = pente.Tessera();
            Assert.IsFalse(isTessera);
        }
        [TestMethod]
        public void TesseraTestHorizontalPass()
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
        public void TesseraTestHorizontalFail()
        {//this way -> -
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 2] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 5] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTessera = pente.Tessera();
            Assert.IsFalse(isTessera);
        }
        [TestMethod]
        public void TesseraTestDiagonalPositivePass()
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
        public void TesseraTestDiagonalPositiveFail()
        {// this way -> /
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[3, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 2] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[9, 3] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTessera = pente.Tessera();
            Assert.IsFalse(isTessera);
        }
        [TestMethod]
        public void TesseraTestDiagonalNegativePass()
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
        public void TesseraTestDiagonalNegativeFail()
        {// this way -> \
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[3, 8] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTessera = pente.Tessera();
            Assert.IsFalse(isTessera);
        }

        [TestMethod]
        public void TriaTestVerticlePass()
        {//this way -> |
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 0] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria();
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void TriaTestVerticleFail()
        {//this way -> |
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 3] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria();
            Assert.IsFalse(isTria);
        }
        [TestMethod]
        public void TriaTestHorizontalPass()
        {//this way -> -
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 2] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria();
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void TriaTestHorizontalFail()
        {//this way -> -
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 4] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 2] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria();
            Assert.IsFalse(isTria);
        }
        [TestMethod]
        public void TriaTestDiagonalPositivePass()
        {// this way -> /
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[3, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 2] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria();
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void TriaTestDiagonalPositiveFail()
        {// this way -> /
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[3, 6] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 2] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria();
            Assert.IsFalse(isTria);
        }
        [TestMethod]
        public void TriaTestDiagonalNegativePass()
        {//this way -> \
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria();
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void TriaTestDiagonalNegativeFail()
        {//this way -> \
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[6, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria();
            Assert.IsFalse(isTria);
        }

        [TestMethod]
        public void WhiteWinPentePass()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void WhiteWinPenteFail()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void WhiteWinCapturePass()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void WhiteWinCaptureFail()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void BlackWinPentePass()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void BlackWinPenteFail()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void BlackWinCapturePass()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void BlackWinCaptureFail()
        {
            Assert.Inconclusive();
        }
    }
}
