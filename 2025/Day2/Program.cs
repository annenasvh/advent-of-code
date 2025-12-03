using System;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {   
            string fileName = "Input.txt";
            // string FileName = "Example.txt";

            string[] input = File.ReadAllLines(fileName);
            string[] ranges = input[0].Split(',');

            // loop through ranges and sum up invalid IDs
            long invalidSum = 0;
            for (int i = 0; i < ranges.Length; i++)
            {
                string[] bounds = ranges[i].Split('-');
                invalidSum += ProcessRange(Int64.Parse(bounds[0]), Int64.Parse(bounds[1]));
            }

            Console.WriteLine($"Sum of Invalid IDs: {invalidSum}"); 
        }

        static long ProcessRange(long lower, long upper)
        {
            long invalidSum = 0;
            for (long i = lower; i <= upper; i++)
            {
                // if (!IsValidID1(i))
                if (!IsValidID2(i))
                {
                    invalidSum += i;
                }   
            }

            return invalidSum;
        }

        // Part 1
        static bool IsValidID1(long id)
        {
            string stringID = id.ToString();

            if (stringID.Length % 2 != 0)
            {
                return true;
            }

            long firstHalf = Int64.Parse(stringID.Substring(0, stringID.Length / 2));
            long secondHalf = Int64.Parse(stringID.Substring(stringID.Length / 2));

            if (firstHalf == secondHalf)
            {
                return false;
            }

            return true;
        }

        // Part 2
        static bool IsValidID2(long iD)
        {
            string stringID = iD.ToString();

            // Note: the first half of an odd number is the shorter half
            // e.g. 12345 becomes 12, so we only check the repetition of 1 and 12 in the rest of the string. 
            // We do not need to check 123 as the number is odd and thus cannot be made of a number repeated twice
            string firstHalf = stringID.Substring(0,stringID.Length / 2);

            for (int len = 1; len <= firstHalf.Length; len++)
            {
                string repetitionCandidate = firstHalf.Substring(0, len);

                // repeating IDs are NOT valid
                if (IsRepetition(repetitionCandidate, stringID))
                {
                    return false;
                }
            }

            // non-repeating IDs are valid
            return true;
        }

        // checks if ID is made up of Repeating repeated any number of times.
        // E.g. For Repeating = 12: ID = 121212 -> true, ID = 121213 -> false
        static bool IsRepetition(string repeating, string iD)
        {
            
            long repeatingLen = repeating.Length;

            // if ID length is not a multiple of Repeating length, it cannot be a repetition
            if (iD.Length % repeatingLen != 0)
            {
                return false;
            }
            
            // check whether each substring of the right length equals Repeating
            for (long i = 0; i <= iD.Length - repeatingLen; i += repeatingLen)
            {
                if (iD.Substring((int)i, (int)(repeatingLen)) != repeating)
                {   
                    return false;
                }
            }
            return true;
        }
    }
}