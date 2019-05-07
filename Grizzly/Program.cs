using System;
using System.Collections.Generic;

namespace Grizzly
{
    class Program
    {
        private static readonly List<Die> dice = new List<Die>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the dice rolling west!");

            bool shouldContinue;
            do
            {
                int option = SelectOption();

                switch (option)
                {
                    case 1:
                        AddDice();
                        break;
                    case 2:
                        RollDice();
                        break;
                }

                shouldContinue = CheckContinue();
            }
            while (shouldContinue);
        }

        private static int SelectOption()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1) Add Die");
            Console.WriteLine("2) Roll Die");
            Console.Write("> ");

            return GetNumberInput("Please pick 1 or 2.");
        }

        private static void AddDice()
        {
            Console.Write("How many sides should the die have? ");
            int sides = GetNumberInput();

            while (sides < 1)
            {
                Console.WriteLine("Please enter a number greater than zero.");
                sides = GetNumberInput();
            }

            dice.Add(new Die(sides));
            Console.WriteLine($"Added die with {sides} side{(sides > 1 ? "s" : "")}.");
        }

        private static void RollDice()
        {
            if (dice.Count == 0)
            {
                Console.WriteLine("There are no dice to roll!");
                return;
            }

            Console.WriteLine("Which die would you like to roll?");
            for (int i = 0; i < dice.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {dice[i].Sides}-sided");
            }

            int dieIndex = GetNumberInput() - 1;

            while (dieIndex < 0 || dieIndex >= dice.Count)
            {
                Console.WriteLine($"Please enter a number between 1 and {dice.Count}");
                dieIndex = GetNumberInput();
            }

            Die die = dice[dieIndex];
            Console.WriteLine($"Rolling {die.Sides}-sided die resulted in: {die.Roll()}");
        }

        private static bool CheckContinue()
        {
            Console.Write("Would you like to continue (y/N)? ");
            return Console.ReadLine().ToLower() == "y";
        }

        private static int GetNumberInput(string errMessage = "Please enter a valid number.")
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    return num;
                }
                else
                {
                    Console.WriteLine(errMessage);
                    Console.Write("> ");
                }
            }
        }
    }
}
