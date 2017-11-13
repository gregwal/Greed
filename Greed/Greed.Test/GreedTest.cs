using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Greed;


namespace Greed.Test
{
    [TestClass]
    public class GreedTest
    {
        Dice dice = new Dice();

        [TestMethod]
        public void GetScore_Dice1_ScoreIs100()
        {
            int[] diceRolled = new int[] { 1 };
            var score = dice.GetScore(diceRolled);
            Assert.AreEqual(100, score);
        }

        [TestMethod]
        public void GetScore_Dice5_ScoreIs50()
        {
            int[] diceRolled = new int[] { 5 };
            var score = dice.GetScore(diceRolled);
            Assert.AreEqual(50, score);
        }

        [TestMethod]
        public void GetScore_Dice111_ScoreIs1000()
        {
            int[] diceRolled = new int[] { 1, 1, 1 };
            var score = dice.GetScore(diceRolled);
            Assert.AreEqual(1000, score);
        }

        [TestMethod]
        public void GetScore_Dice11151_ScoreIs2050()
        {
            int[] diceRolled = new int[] { 1, 1, 1, 5, 1 };
            var score = dice.GetScore(diceRolled);
            Assert.AreEqual(2050, score);
        }

        [TestMethod]
        public void GetScore_Dice23462_ScoreIs0()
        {
            int[] diceRolled = new int[] { 2, 3, 4, 6, 2 };
            var score = dice.GetScore(diceRolled);
            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void GetScore_Dice34533_ScoreIs350()
        {
            int[] diceRolled = new int[] { 3, 4, 5, 3, 3 };
            var score = dice.GetScore(diceRolled);
            Assert.AreEqual(350, score);
        }

        [TestMethod]
        public void GetScore_Dice15124_ScoreIs250()
        {
            int[] diceRolled = new int[] { 1, 5, 1, 2, 4 };
            var score = dice.GetScore(diceRolled);
            Assert.AreEqual(250, score);
        }

        [TestMethod]
        public void GetScore_Dice55555_ScoreIs600()
        {
            int[] diceRolled = new int[] { 5, 5, 5, 5, 5 };
            var score = dice.GetScore(diceRolled);
            Assert.AreEqual(2000, score);
        }

        [TestMethod]
        public void GetScore_Dice2222_ScoreIs400()
        {
            int[] diceRolled = new int[] { 2, 2, 2, 2};
            var score = dice.GetScore(diceRolled);
            Assert.AreEqual(400, score);
        }

        [TestMethod]
        public void GetScore_Dice22222_ScoreIs800()
        {
            int[] diceRolled = new int[] { 2, 2, 2, 2, 2 };
            var score = dice.GetScore(diceRolled);
            Assert.AreEqual(800, score);
        }

        [TestMethod]
        public void GetScore_Dice222222_ScoreIs1600()
        {
            int[] diceRolled = new int[] { 2, 2, 2, 2, 2, 2 };
            var score = dice.GetScore(diceRolled);
            Assert.AreEqual(1600, score);
        }

        [TestMethod]
        public void GetScore_Dice223344_ScoreIs800()
        {
            int[] diceRolled = new int[] { 2, 2, 3, 3, 4, 4};
            var score = dice.GetScore(diceRolled);
            Assert.AreEqual(800, score);
        }

        [TestMethod]
        public void GetScore_Dice123456_ScoreIs1200()
        {
            int[] diceRolled = new int[] { 1, 2, 3, 4, 5, 6 };
            var score = dice.GetScore(diceRolled);
            Assert.AreEqual(1200, score);
        }
    }
}
