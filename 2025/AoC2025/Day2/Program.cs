using System;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {   
            string FileName = "Input.txt";
            // string FileName = "Example.txt";

            string[] Input = File.ReadAllLines(FileName);
            string[] Ranges = Input[0].Split(',');

            // loop through ranges and sum up invalid IDs
            long InvalidSum = 0;
            for (int i = 0; i < Ranges.Length; i++)
            {
                string[] Bounds = Ranges[i].Split('-');
                InvalidSum += ProcessRange(Int64.Parse(Bounds[0]), Int64.Parse(Bounds[1]));
            }

            Console.WriteLine($"Sum of Invalid IDs: {InvalidSum}"); 
        }

        static long ProcessRange(long Lower, long Upper)
        {
            long InvalidSum = 0;
            for (long i = Lower; i <= Upper; i++)
            {
                // if (!IsValidID1(i))
                if (!IsValidID2(i))
                {
                    InvalidSum += i;
                }   
            }

            return InvalidSum;
        }

        // Part 1
        static bool IsValidID1(long ID)
        {
            string StringID = ID.ToString();

            if (StringID.Length % 2 != 0)
            {
                return true;
            }

            long FirstHalf = Int64.Parse(StringID.Substring(0, StringID.Length / 2));
            long SecondHalf = Int64.Parse(StringID.Substring(StringID.Length / 2));

            if (FirstHalf == SecondHalf)
            {
                return false;
            }

            return true;
        }

        // Part 2
        static bool IsValidID2(long ID)
        {
            string StringID = ID.ToString();

            // Note: the first half of an odd number is the shorter half
            // e.g. 12345 becomes 12, so we only check the repetition of 1 and 12 in the rest of the string. 
            // We do not need to check 123 as the number is odd and thus cannot be made of a number repeated twice
            string FirstHalf = StringID.Substring(0,StringID.Length / 2);

            for (int len = 1; len <= FirstHalf.Length; len++)
            {
                string RepetitionCandidate = FirstHalf.Substring(0, len);

                // repeating IDs are NOT valid
                if (IsRepetition(RepetitionCandidate, StringID))
                {
                    return false;
                }
            }

            // non-repeating IDs are valid
            return true;
        }

        // checks if ID is made up of Repeating repeated any number of times.
        // E.g. For Repeating = 12: ID = 121212 -> true, ID = 121213 -> false
        static bool IsRepetition(string Repeating, string ID)
        {
            
            long RepeatingLen = Repeating.Length;

            // if ID length is not a multiple of Repeating length, it cannot be a repetition
            if (ID.Length % RepeatingLen != 0)
            {
                return false;
            }
            
            // check whether each substring of the right length equals Repeating
            for (long i = 0; i <= ID.Length - RepeatingLen; i += RepeatingLen)
            {
                if (ID.Substring((int)i, (int)(RepeatingLen)) != Repeating)
                {   
                    return false;
                }
            }
            return true;
        }
    }
}