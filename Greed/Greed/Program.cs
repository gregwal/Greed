using System;

namespace Greed
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of dice to roll: ");
            int numberOfDice = Convert.ToInt32(Console.ReadLine());

            Dice dice = new Dice();
            int[] diceRolled = dice.RollDice(numberOfDice);
            Console.WriteLine($"Dice rolled: [{string.Join(", ", diceRolled)}]");
            var score = dice.GetScore(diceRolled);
            
            Console.WriteLine($"The score is: {score}");
        }
    }
}
