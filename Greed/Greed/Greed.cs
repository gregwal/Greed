using System;
using System.Collections.Generic;
using System.Linq;

namespace Greed
{
    public class Dice
    {
        private readonly static int sidesOnDice = 6;

        public int[] RollDice(int numberOfDice)
        {
            Random random = new Random();
            int[] dice = new int[numberOfDice];
            for (int i = 0; i < numberOfDice; i++)
            {
                dice[i] = random.Next(1, sidesOnDice + 1);
            }
            return dice;
        }

        public int GetScore(int[] diceRolls)
        {
            Dictionary<int, int> diceRollsCount = GetDiceRollsCount(diceRolls);
            return CalculateDiceScore(diceRollsCount);
        }

        private static int CalculateDiceScore(Dictionary<int, int> diceRollsCount)
        {
            Dictionary<int, int> tripleScore = new Dictionary<int, int> { { 1, 1000 }, { 2, 200 }, { 3, 300 }, { 4, 400 }, { 5, 500 }, { 6, 600 } };
            Dictionary<int, int> ofKindMultiple = new Dictionary<int, int> { { 6, 8 }, { 5, 4 }, { 4, 2 }, { 3, 1 } };

            // Straight: one of each face [1,2,3,4,5,6]
            if (diceRollsCount.All(d => d.Value == 1))
                return 1200;

            // Three pairs: exactly three different values each appearing twice
            if (diceRollsCount.Count(d => d.Value == 2) == 3)
                return 800;

            int score = 0;

            for (int diceSide = 1; diceSide <= sidesOnDice; diceSide++)
            {
                int count = diceRollsCount[diceSide];

                if (count >= 3)
                {
                    // Score triple or higher (4/5/6-of-a-kind multiply the triple score)
                    score += tripleScore[diceSide] * ofKindMultiple[count];
                }
                else
                {
                    // Score singles — only 1s and 5s count
                    if (diceSide == 1)
                        score += count * 100;
                    else if (diceSide == 5)
                        score += count * 50;
                }
            }

            return score;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diceRolls"></param>
        /// <returns></returns>
        private static Dictionary<int, int> GetDiceRollsCount(int[] diceRolls)
        {
            Dictionary<int, int> diceRollsCount = new Dictionary<int, int>();

             // iterate through each possible number on the die
            for (int diceSide = 1; diceSide < sidesOnDice + 1; diceSide++)
            {
                diceRollsCount.Add(diceSide, 0);
                // iterate through each dice roll
                foreach (var diceRoll in diceRolls)
                {
                    if (diceRoll == diceSide)
                    {
                        diceRollsCount[diceSide]++;
                    }
                }
            }

            return diceRollsCount;
        }
    }
}
