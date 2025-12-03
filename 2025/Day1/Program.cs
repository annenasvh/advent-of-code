using System;
using System.IO;

namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int DialLocation = 50;

            string FileName = "Input.txt";
            // string FileName = "Example.txt";

            // Read moves from inputfile
            string[] Moves = File.ReadAllLines(FileName);

            // Do all dial moves
            int DoorPassword = 0;
            for(int i=0; i < Moves.Length; i++)
            {
                bool TurnDirectionRight = Moves[i][0] == 'R';
                int TurnAmount = int.Parse(Moves[i].Substring(1));

                // Console.WriteLine($"Zeros counted: {DoorPassword}.\n ------------");
                // Console.WriteLine($"Move: {Moves[i]}.");
                // Console.WriteLine($"Dial Location: {DialLocation}.");
                (DialLocation, int ExtraZeros) = TurnDial(DialLocation, TurnDirectionRight, TurnAmount);


                // Track door password (number of times dial lands on 0 + number of times it passes 0)
                DoorPassword += ExtraZeros;
                if (DialLocation == 0) {
                    DoorPassword += 1;
                }
            }

            // Output final dial location
            Console.WriteLine($"Door password: {DoorPassword} (Dial Location: {DialLocation})");
        }

        static (int Location, int ZeroCount) TurnDial(int DialLocation, bool TurnRight, int TurnAmount)
        {
            int NewDialLocation;

            int ZeroCounter = 0;


            if (TurnRight)
            {
                NewDialLocation = DialLocation + TurnAmount;
                while (NewDialLocation > 99)
                {
                    // Prevent double counting if we land on zero exactly
                    if (NewDialLocation == 100)
                    {
                        ZeroCounter -= 1;
                    }
                    // Console.WriteLine($"\tLocation computed: {NewDialLocation}");
                    NewDialLocation -= 100;
                    ZeroCounter += 1;                  
                }
            
            }
            else
            {
                NewDialLocation = DialLocation - TurnAmount;
                while (NewDialLocation < 0 )
                {
                    // Console.WriteLine($"\tLocation computed: {NewDialLocation}");
                    NewDialLocation += 100;
                    ZeroCounter += 1;
                }

                // If we start at 0, we do not want to count that as passing zero (e.g. L5 from 0 moves to -5)
                if (DialLocation == 0)
                {
                    ZeroCounter -= 1;
                }

                // This should never happen
                if (ZeroCounter < 0)
                {
                    Console.WriteLine("Error: Negative zero counter.");
                }
            }

            return (NewDialLocation, ZeroCounter);
        }
    }
}
