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
                if (!IsValidID(i))
                {
                    InvalidSum += i;
                }   
            }

            return InvalidSum;
        }

        static bool IsValidID(long ID)
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
    }
}