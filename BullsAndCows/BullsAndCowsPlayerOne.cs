﻿using System;

namespace BullsAndCows
{
    class BullsAndCowsPlayerOne
    {
        private int numberOfDigits;
        private int[] secretNumberArray;
        private string guessNumber;
        private int Cows;
        private int Bulls;

        private Random random;

        public BullsAndCowsPlayerOne() : this(4)
        {
        }

        public BullsAndCowsPlayerOne(int digits)
        {            
            numberOfDigits = digits;
            secretNumberArray = new int[numberOfDigits];
            guessNumber = null;
            Cows = 0;
            Bulls = 0;
            random = new Random();
        }

        public void Run()
        {
            GenerateSecretNumber();
            ShowSecretNumber();

            while (true)
            {
                GetGuessNumber();

                Cows = 0;                
                Bulls = 0;
                CountBullsAndCows();
                if (Bulls == numberOfDigits)
                {
                    Console.WriteLine("********You Win!********");
                    break;
                }
            }            
        }

        private void CountBullsAndCows()
        {
            for (int i = 0; i < secretNumberArray.Length; i++)
            {
                string digit = secretNumberArray[i].ToString();
                int index = guessNumber.IndexOf(digit);
                if (index == i)
                    Bulls++;
                else if (index >= 0)
                    Cows++;
            }
            Console.WriteLine("Bulls {0}. Cows: {1}.", Bulls, Cows);
        }

        private void GetGuessNumber()
        {
            bool isValidNumber = false;
            Console.WriteLine("Please enter your guess number:");
            while (!isValidNumber)
            {
                guessNumber = Console.ReadLine();
                if (guessNumber.Length == numberOfDigits && IsUniqueDigits(guessNumber))
                    isValidNumber = true;
                else
                    Console.WriteLine("Invalid number! Please re-enter your guess number:");
            }
        }

        private bool IsUniqueDigits(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (number[i] == number[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void ShowSecretNumber()
        {
            foreach (int i in secretNumberArray)
                Console.Write("{0 }", i);
            Console.WriteLine();
        }

        private void GenerateSecretNumber()
        {
            for (int i = 0; i < secretNumberArray.Length; i++)
            {
                bool isUnique = false;
                int newNumber = 0;
                while (!isUnique)
                {
                    newNumber = random.Next(10);
                    isUnique = true;
                    for (int j = 0; j < i; j++)
                    {
                        if (newNumber == secretNumberArray[j])
                        {
                            isUnique = false;
                            break;
                        }
                    }
                }
                secretNumberArray[i] = newNumber;
            }

        }
    }
}
