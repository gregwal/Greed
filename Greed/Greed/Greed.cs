using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greed
{
    public class Dice
    {
        private readonly static int sidesOnDice = 6;

        public int GetScore(int[] diceRolls)
        {
            Dictionary<int, int> diceRollsCount = GetDiceRollsCount(diceRolls);
            return CalculateDiceScore(diceRollsCount);
        }

        private static int CalculateDiceScore(Dictionary<int, int> diceRollsCount)
        {
            int singleOne = 100;
            int singleFive = 50;
            int straightScore = 1200;
            int threePairScore = 800;
            int underTriple = 2;
            int score = 0;
            Dictionary<int, int> tripleScore = new Dictionary<int, int> { { 1, 1000 }, { 2, 200 }, { 3, 300 }, { 4, 400 }, { 5, 500 }, { 6, 600 } };
            Dictionary<int, int> ofKindMultiple = new Dictionary<int, int> { { 6, 8 }, { 5, 4 }, { 4, 2 }, { 3, 1 } };

            // score a straight
            if (diceRollsCount.Count(dc => dc.Value == 1) == 6 )
            {
                score = straightScore;
            }

            // score three pairs
            if (diceRollsCount.Count(d => d.Value == 2) == 3)
            {
                score = threePairScore;
            }

            if (score == 0)
            {
                // Score multiples of three or higher
                if (diceRollsCount.Count(d => d.Value >= 3) >= 1)
                {
                    // for each side of dice
                    for (int diceSide = 1; diceSide <= sidesOnDice ; diceSide++)
                    {
                        for (int i = sidesOnDice; i >= 3; i--)
                        {
                            if (diceRollsCount[diceSide] == (i))
                            { 
                                score = tripleScore[diceSide] * ofKindMultiple[i];
                                break;
                            }
                        }
                    }
                }

                // score the singles
                if (diceRollsCount[1] <= underTriple)
                    score = score + (diceRollsCount[1] * singleOne);

                if (diceRollsCount[5] <= underTriple)
                    score = score + (diceRollsCount[5] * singleFive);
            }

            return score;
        }

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
                        diceRollsCount[diceSide] = diceRollsCount[diceSide]++;
                    }
                }
            }

            return diceRollsCount;
        }
    }
}
