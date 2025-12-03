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

            long totalJoltage = 0;
            for (int i = 0; i < banks.Length; i++)
            {   
                // convert string[] to int[]
                int[] bank = new int[banks[i].Length];
                for (int j = 0; j < bank.Length; j++)
                {
                    // banks[i][j] is char so casting to int gives ASCII value, solved by doing "-'0'"
                    bank[j] = banks[i][j] -'0';
                }
                // totalJoltage += FindLargestJoltage1(bank);
                totalJoltage += FindLargestJoltage2(bank);
            }
            Console.WriteLine($"Maxiumum joltage possible: {totalJoltage}");
            
        }

        // Part 1
        static long FindLargestJoltage1(int[] bank)
        {   
            // find the largest battery, excluding the last one, as we always pick two batteries
            (int firstDigit, int firstDigitIndex) = FindLargestDigit(bank[0..(bank.Length-1)]);
            (int secondDigit, _) = FindLargestDigit(bank[(firstDigitIndex+1)..bank.Length]);

            return Int64.Parse(firstDigit.ToString() + secondDigit.ToString());
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

        // Part 2
        static long FindLargestJoltage2(int[] bank)
        {   
            string acc = "";

            // first digit cannot be one of the last 11 digits
            int necessaryTailLength = 11;

            // necessary to correctly track the indices
            int largestIndex = 0;

            // Need to find 12 digits
            for(int i = 0; i < 12; i++)
            {
                (int largest, int relativeLargestIndex) = FindLargestDigit(bank[largestIndex..(bank.Length-necessaryTailLength)]);
                largestIndex += relativeLargestIndex + 1;

                acc += largest.ToString();
                necessaryTailLength -= 1;
            }

            return Int64.Parse(acc);
        }
    }
}