using System;
using System.IO;

namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dialLocation = 50;

            string fileName = "Input.txt";
            // string fileName = "Example.txt";

            // Read moves from inputfile
            string[] moves = File.ReadAllLines(fileName);

            // Do all dial moves
            int doorPassword = 0;
            for(int i=0; i < moves.Length; i++)
            {
                bool turnDirectionRight = moves[i][0] == 'R';
                int turnAmount = int.Parse(moves[i].Substring(1));

                // Console.WriteLine($"Zeros counted: {DoorPassword}.\n ------------");
                // Console.WriteLine($"Move: {Moves[i]}.");
                // Console.WriteLine($"Dial Location: {dialLocation}.");
                (dialLocation, int extraZeros) = TurnDial(dialLocation, turnDirectionRight, turnAmount);


                // Track door password (number of times dial lands on 0 + number of times it passes 0)
                doorPassword += extraZeros;
                if (dialLocation == 0) {
                    doorPassword += 1;
                }
            }

            // Output final dial location
            Console.WriteLine($"Door password: {doorPassword} (Dial Location: {dialLocation})");
        }

        static (int location, int zeroCount) TurnDial(int dialLocation, bool turnRight, int turnAmount)
        {
            int newDialLocation;

            int zeroCounter = 0;


            if (turnRight)
            {
                newDialLocation = dialLocation + turnAmount;
                while (newDialLocation > 99)
                {
                    // Prevent double counting if we land on zero exactly
                    if (newDialLocation == 100)
                    {
                        zeroCounter -= 1;
                    }
                    // Console.WriteLine($"\tLocation computed: {NewDialLocation}");
                    newDialLocation -= 100;
                    zeroCounter += 1;                  
                }
            
            }
            else
            {
                newDialLocation = dialLocation - turnAmount;
                while (newDialLocation < 0 )
                {
                    // Console.WriteLine($"\tLocation computed: {NewDialLocation}");
                    newDialLocation += 100;
                    zeroCounter += 1;
                }

                // If we start at 0, we do not want to count that as passing zero (e.g. L5 from 0 moves to -5)
                if (dialLocation == 0)
                {
                    zeroCounter -= 1;
                }

                // This should never happen
                if (zeroCounter < 0)
                {
                    Console.WriteLine("Error: Negative zero counter.");
                }
            }

            return (newDialLocation, zeroCounter);
        }
    }
}
