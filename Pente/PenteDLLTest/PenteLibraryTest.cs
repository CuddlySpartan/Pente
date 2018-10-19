using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PenteDLL.Controllers;

namespace PenteDLLTest
{
    [TestClass]
    public class PenteLibraryTest
    {
        PenteLibrary pente = new PenteLibrary();
        /*
         * TESSERA / TRIA TESTS
        */
        #region black_tessera_tests
        [TestMethod]
        public void BlackTesseraTestVerticlePass()
        {//this way -> |
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[3, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[4, 0] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTessera = pente.Tessera(0, 4);
            Assert.IsTrue(isTessera);
        }
        [TestMethod]
        public void BlackTesseraTestVerticleFail()
        {//this way -> |
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[3, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[6, 0] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTessera = pente.Tessera(6, 0);
            Assert.IsFalse(isTessera);
        }
        [TestMethod]
        public void BlackTesseraTestHorizontalPass()
        {//this way -> -
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[6, 6] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[6, 7] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[6, 8] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[6, 9] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTessera = pente.Tessera(9, 6);
            Assert.IsTrue(isTessera);
            //WHY NOT WORK
        }
        [TestMethod]
        public void BlackTesseraTestHorizontalFail()
        {//this way -> -
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 2] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 3] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 6] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTessera = pente.Tessera(0, 6);
            Assert.IsFalse(isTessera);
        }
        [TestMethod]
        public void BlackTesseraTestDiagonalPositivePass()
        {// this way -> /
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[4, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[3, 2] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 3] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 4] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTessera = pente.Tessera(1, 4);
            Assert.IsTrue(isTessera);
        }
        [TestMethod]
        public void BlackTesseraTestDiagonalPositiveFail()
        {// this way -> /
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[4, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[3, 2] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 3] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[10, 4] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTessera = pente.Tessera(10, 4);
            Assert.IsFalse(isTessera);
        }
        [TestMethod]
        public void BlackTesseraTestDiagonalNegativePass()
        {// this way -> \
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[1, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[3, 3] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[4, 4] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTessera = pente.Tessera(4, 4);
            Assert.IsTrue(isTessera);
        }
        [TestMethod]
        public void BlackTesseraTestDiagonalNegativeFail()
        {// this way -> \
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[1, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[3, 3] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[4, 9] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTessera = pente.Tessera(3, 8);
            Assert.IsFalse(isTessera);
        }
        #endregion
        #region black_tria_tests
        [TestMethod]
        public void BlackTriaTestVerticlePass()
        {//this way -> |
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[3, 0] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria(3, 0);
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void BlackTriaTestVerticleFail()
        {//this way -> |
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[3, 4] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria(3, 4);
            Assert.IsFalse(isTria);
        }
        [TestMethod]
        public void BlackTriaTestHorizontalPass()
        {//this way -> -
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 2] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 3] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria(0, 3);
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void BlackTriaTestHorizontalFail()
        {//this way -> -
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 5] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 2] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 3] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria(0, 3);
            Assert.IsFalse(isTria);
        }
        [TestMethod]
        public void BlackTriaTestDiagonalPositivePass()
        {// this way -> /
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[4, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[3, 2] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 3] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria(4, 1);
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void BlackTriaTestDiagonalPositiveFail()
        {// this way -> /
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[4, 7] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[3, 2] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 3] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria(2, 3);
            Assert.IsFalse(isTria);
        }
        [TestMethod]
        public void BlackTriaTestDiagonalNegativePass()
        {//this way -> \
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[1, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[3, 3] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria(3, 3);
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void BlackTriaTestDiagonalNegativeFail()
        {//this way -> \
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[7, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[3, 3] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isTria = pente.Tria(3, 3);
            Assert.IsFalse(isTria);
        }
        #endregion
        #region white_tessera_tests
        [TestMethod]
        public void WhiteTesseraTestVerticlePass()
        {//this way -> |
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[3, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[4, 0] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTessera = pente.Tessera(0, 4);
            Assert.IsTrue(isTessera);
        }
        [TestMethod]
        public void WhiteTesseraTestVerticleFail()
        {//this way -> |
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[3, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[6, 0] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTessera = pente.Tessera(0, 6);
            Assert.IsFalse(isTessera);
        }
        [TestMethod]
        public void WhiteTesseraTestHorizontalPass()
        {//this way -> -
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 3] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 4] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTessera = pente.Tessera(4, 0);
            Assert.IsTrue(isTessera);
        }
        [TestMethod]
        public void WhiteTesseraTestHorizontalFail()
        {//this way -> -
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 3] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 6] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTessera = pente.Tessera(6, 0);
            Assert.IsFalse(isTessera);
        }
        [TestMethod]
        public void WhiteTesseraTestDiagonalPositivePass()
        {// this way -> /
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[4, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[3, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 3] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[1, 4] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTessera = pente.Tessera(4, 1);
            Assert.IsTrue(isTessera);
        }
        [TestMethod]
        public void WhiteTesseraTestDiagonalPositiveFail()
        {// this way -> /
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[4, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[3, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 3] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[10, 4] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTessera = pente.Tessera(10, 4);
            Assert.IsFalse(isTessera);
        }
        [TestMethod]
        public void WhiteTesseraTestDiagonalNegativePass()
        {// this way -> \
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[1, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[3, 3] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[4, 4] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTessera = pente.Tessera(4, 4);
            Assert.IsTrue(isTessera);
        }
        [TestMethod]
        public void WhiteTesseraTestDiagonalNegativeFail()
        {// this way -> \
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[1, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[3, 3] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[4, 9] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTessera = pente.Tessera(4, 9);
            Assert.IsFalse(isTessera);
        }
        #endregion
        #region white_tria_tests
        [TestMethod]
        public void WhiteTriaTestVerticlePass()
        {//this way -> |
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[3, 0] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTria = pente.Tria(3, 0);
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void WhiteTriaTestVerticleFail()
        {//this way -> |
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[3, 4] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTria = pente.Tria(3, 4);
            Assert.IsFalse(isTria);
        }
        [TestMethod]
        public void WhiteTriaTestHorizontalPass()
        {//this way -> -
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 3] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTria = pente.Tria(0, 3);
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void WhiteTriaTestHorizontalFail()
        {//this way -> -
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 5] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 3] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTria = pente.Tria(0, 3);
            Assert.IsFalse(isTria);
        }
        [TestMethod]
        public void WhiteTriaTestDiagonalPositivePass()
        {// this way -> /
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[4, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[3, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 3] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTria = pente.Tria(2, 3);
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void WhiteTriaTestDiagonalPositiveFail()
        {// this way -> /
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[4, 7] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[3, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 3] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTria = pente.Tria(2, 3);
            Assert.IsFalse(isTria);
        }
        [TestMethod]
        public void WhiteTriaTestDiagonalNegativePass()
        {//this way -> \
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[1, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[3, 3] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTria = pente.Tria(3, 3);
            Assert.IsTrue(isTria);
        }
        [TestMethod]
        public void WhiteTriaTestDiagonalNegativeFail()
        {//this way -> \
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[7, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[3, 3] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isTria = pente.Tria(3, 3);
            Assert.IsFalse(isTria);
        }
        #endregion

        /*
         * CAPTURE TESTS
        */
        #region white_capture_tests
        [TestMethod]
        public void WhiteCaptureVerticlePass()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void WhiteCaptureVerticleFail()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void WhiteCaptureHorizontalPass()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void WhiteCaptureHorizontalFail()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void WhiteCapturePositiveDiagonalPass()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void WhiteCaptureNegativeDigonalFail()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void WhiteCaptureNegativeDiagonalPass()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void WhiteCaptureNegativeDiagonalFail()
        {
            Assert.Inconclusive();
        }
        #endregion
        #region black_capture_tests

        #endregion

        /*
         * WIN CONDITION TESTS
        */
        #region white_pente_tests
        [TestMethod]
        public void WhiteWinPenteVerticlePass()
        {
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[3, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[4, 0] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isWin = pente.FiveInARow(4,0);
            Assert.IsTrue(isWin);
        }
        [TestMethod]
        public void WhiteWinPenteVerticleFail()
        {
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[8, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[3, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[4, 0] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isWin = pente.FiveInARow(0, 4);
            Assert.IsFalse(isWin);
        }
        [TestMethod]
        public void WhiteWinPenteHorizontalPass()
        {
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 3] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 4] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isWin = pente.FiveInARow(0, 4);
            Assert.IsTrue(isWin);
        }
        [TestMethod]
        public void WhiteWinPenteHorizontalFail()
        {
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[8, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[3, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[4, 0] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isWin = pente.FiveInARow(0, 4);
            Assert.IsFalse(isWin);
        }
        [TestMethod]
        public void WhiteWinPentePositiveDiagonalPass()
        {
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[4, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[3, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[1, 3] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 4] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isWin = pente.FiveInARow(0, 4);
            Assert.IsTrue(isWin);
        }
        [TestMethod]
        public void WhiteWinPentePositiveDiagonalFail()
        {
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[4, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[3, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[1, 3] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[0, 5] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isWin = pente.FiveInARow(5, 0);
            Assert.IsFalse(isWin);
        }
        [TestMethod]
        public void WhiteWinPenteNegativeDiagonalPass()
        {
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[1, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[3, 3] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[4, 4] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isWin = pente.FiveInARow(4, 4);
            Assert.IsTrue(isWin);
        }
        [TestMethod]
        public void WhiteWinPenteNegativeDiagonalFail()
        {
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[1, 1] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[3, 3] = PenteLibrary.PlayerPiece.PLAYER2;
            pente.Board[4, 6] = PenteLibrary.PlayerPiece.PLAYER2;

            bool isWin = pente.FiveInARow(6, 4);
            Assert.IsFalse(isWin);
        }
        #endregion
        #region white_capture_tests
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
        #endregion
        #region black_pente_tests
        [TestMethod]
        public void BlackWinPenteVerticlePass()
        {
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[3, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[4, 0] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isWin = pente.FiveInARow(4, 0);
            Assert.IsTrue(isWin);
        }
        [TestMethod]
        public void BlackWinPenteVerticleFail()
        {
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[8, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[3, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[4, 0] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isWin = pente.FiveInARow(0, 4);
            Assert.IsFalse(isWin);
        }
        [TestMethod]
        public void BlackWinPenteHorizontalPass()
        {
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 2] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 3] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 4] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isWin = pente.FiveInARow(0, 4);
            Assert.IsTrue(isWin);
        }
        [TestMethod]
        public void BlackWinPenteHorizontalFail()
        {
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[8, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[3, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[4, 0] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isWin = pente.FiveInARow(0, 4);
            Assert.IsFalse(isWin);
        }
        [TestMethod]
        public void BlackWinPentePositiveDiagonalPass()
        {
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[4, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[3, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 3] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 4] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isWin = pente.FiveInARow(0, 4);
            Assert.IsTrue(isWin);
        }
        [TestMethod]
        public void BlackWinPentePositiveDiagonalFail()
        {
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[4, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[3, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 3] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[0, 5] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isWin = pente.FiveInARow(5, 0);
            Assert.IsFalse(isWin);
        }
        [TestMethod]
        public void BlackWinPenteNegativeDiagonalPass()
        {
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[3, 3] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[4, 4] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isWin = pente.FiveInARow(4, 4);
            Assert.IsTrue(isWin);
        }
        [TestMethod]
        public void BlackWinPenteNegativeDiagonalFail()
        {
            pente.Board = new PenteLibrary.PlayerPiece[19, 19];
            pente.Board[0, 0] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[1, 1] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[2, 2] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[3, 3] = PenteLibrary.PlayerPiece.PLAYER1;
            pente.Board[4, 6] = PenteLibrary.PlayerPiece.PLAYER1;

            bool isWin = pente.FiveInARow(6, 4);
            Assert.IsFalse(isWin);
        }
        #endregion
        #region black_capture_tests
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
        #endregion
    }
}