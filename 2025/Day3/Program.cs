using System;
using System.IO;

namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "Input.txt";
            // string fileName = "Example.txt";

            string[] banks = File.ReadAllLines(fileName);

            int totalJoltage = 0;
            for (int i = 0; i < banks.Length; i++)
            {   
                // convert string[] to int[]
                int[] bank = new int[banks[i].Length];
                for (int j = 0; j < bank.Length; j++)
                {
                    // banks[i][j] is char so casting to int gives ASCII value, solved by doing "-'0'"
                    bank[j] = banks[i][j] -'0';
                }
                totalJoltage += FindLargestJoltage(bank);
            }

            Console.WriteLine($"Maxiumum joltage possible: {totalJoltage}");

        }

        static int FindLargestJoltage(int[] bank)
        {   
            // find the largest battery, excluding the last one, as we always pick two batteries
            (int firstDigit, int firstDigitIndex) = FindLargestDigit(bank[0..(bank.Length-1)]);
            (int secondDigit, _) = FindLargestDigit(bank[(firstDigitIndex+1)..bank.Length]);

            return Int32.Parse(firstDigit.ToString() + secondDigit.ToString());
        }

        // Given an int[] returns the value and index of the largest digit (e.g. [1,5,2,3] => (5,1)) 
        static (int, int) FindLargestDigit(int[] arr)
        {   int largest = -1;
            int largestIndex = -1;

            for (int i = 0; i < arr.Length; i++)
            {   
                // we want to find the first instance of the largest number
                if (arr[i] > largest)
                {
                    largest = arr[i];
                    largestIndex = i;
                }
            }
            return (largest, largestIndex);
        }
    }
}