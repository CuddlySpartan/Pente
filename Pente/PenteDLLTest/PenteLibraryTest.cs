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
        public void BlackTesseraTestVerticlePass()
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
        public void BlackTesseraTestVerticleFail()
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
        public void BlackTesseraTestHorizontalPass()
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
        public void BlackTesseraTestHorizontalFail()
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
        public void BlackTesseraTestDiagonalPositivePass()
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
        public void BlackTesseraTestDiagonalPositiveFail()
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
        public void BlackTesseraTestDiagonalNegativePass()
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
        public void BlackTesseraTestDiagonalNegativeFail()
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
        public void BlackTriaTestVerticlePass()
        {//this way -> |
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 0] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria();
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void BlackTriaTestVerticleFail()
        {//this way -> |
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 3] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria();
            Assert.IsFalse(isTria);
        }
        [TestMethod]
        public void BlackTriaTestHorizontalPass()
        {//this way -> -
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 2] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria();
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void BlackTriaTestHorizontalFail()
        {//this way -> -
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 4] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 2] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria();
            Assert.IsFalse(isTria);
        }
        [TestMethod]
        public void BlackTriaTestDiagonalPositivePass()
        {// this way -> /
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[3, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 2] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria();
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void BlackTriaTestDiagonalPositiveFail()
        {// this way -> /
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[3, 6] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 2] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria();
            Assert.IsFalse(isTria);
        }
        [TestMethod]
        public void BlackTriaTestDiagonalNegativePass()
        {//this way -> \
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria();
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void BlackTriaTestDiagonalNegativeFail()
        {//this way -> \
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[6, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria();
            Assert.IsFalse(isTria);
        }

        /*
         * WHITE START HERE 
        */

        [TestMethod]
        public void WhiteTesseraTestVerticlePass()
        {//this way -> |
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[3, 0] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTessera = pente.Tessera();
            Assert.IsTrue(isTessera);
        }
        [TestMethod]
        public void WhiteTesseraTestVerticleFail()
        {//this way -> |
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[5, 0] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTessera = pente.Tessera();
            Assert.IsFalse(isTessera);
        }
        [TestMethod]
        public void WhiteTesseraTestHorizontalPass()
        {//this way -> -
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 3] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTessera = pente.Tessera();
            Assert.IsTrue(isTessera);
        }
        [TestMethod]
        public void WhiteTesseraTestHorizontalFail()
        {//this way -> -
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 5] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTessera = pente.Tessera();
            Assert.IsFalse(isTessera);
        }
        [TestMethod]
        public void WhiteTesseraTestDiagonalPositivePass()
        {// this way -> /
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[3, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[1, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 3] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTessera = pente.Tessera();
            Assert.IsTrue(isTessera);
        }
        [TestMethod]
        public void WhiteTesseraTestDiagonalPositiveFail()
        {// this way -> /
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[3, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[1, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[9, 3] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTessera = pente.Tessera();
            Assert.IsFalse(isTessera);
        }
        [TestMethod]
        public void WhiteTesseraTestDiagonalNegativePass()
        {// this way -> \
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[1, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[3, 3] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTessera = pente.Tessera();
            Assert.IsTrue(isTessera);
        }
        [TestMethod]
        public void WhiteTesseraTestDiagonalNegativeFail()
        {// this way -> \
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[1, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[3, 8] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTessera = pente.Tessera();
            Assert.IsFalse(isTessera);
        }

        [TestMethod]
        public void WhiteTriaTestVerticlePass()
        {//this way -> |
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 0] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTria = pente.Tria();
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void WhiteTriaTestVerticleFail()
        {//this way -> |
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 3] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTria = pente.Tria();
            Assert.IsFalse(isTria);
        }
        [TestMethod]
        public void WhiteTriaTestHorizontalPass()
        {//this way -> -
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 2] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTria = pente.Tria();
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void WhiteTriaTestHorizontalFail()
        {//this way -> -
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 4] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 2] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTria = pente.Tria();
            Assert.IsFalse(isTria);
        }
        [TestMethod]
        public void WhiteTriaTestDiagonalPositivePass()
        {// this way -> /
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[3, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[1, 2] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTria = pente.Tria();
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void WhiteTriaTestDiagonalPositiveFail()
        {// this way -> /
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[3, 6] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[1, 2] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTria = pente.Tria();
            Assert.IsFalse(isTria);
        }
        [TestMethod]
        public void WhiteTriaTestDiagonalNegativePass()
        {//this way -> \
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[1, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTria = pente.Tria();
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void WhiteTriaTestDiagonalNegativeFail()
        {//this way -> \
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[6, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[1, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTria = pente.Tria();
            Assert.IsFalse(isTria);
        }

        /*
         * WIN CONS START HERE
        */

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