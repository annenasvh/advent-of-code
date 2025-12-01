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

                DialLocation = TurnDial(DialLocation, TurnDirectionRight, TurnAmount);

                // Console.WriteLine($"Processing Move: {Moves[i]}.");
                // Console.WriteLine($"Dial Location: {DialLocation}.");

                // Track door password (number of times dial lands on 0)
                if (DialLocation == 0) {
                    DoorPassword += 1;
                }
            }

            // Output final dial location
            Console.WriteLine($"Door password: {DoorPassword} (Dial Location: {DialLocation})");
        }

        static int TurnDial(int DialLocation, bool TurnRight, int TurnAmount)
        {
            int NewDialLocation;
            if (TurnRight)
            {
                NewDialLocation = DialLocation + TurnAmount;
                while (NewDialLocation > 99)
                {
                    NewDialLocation -= 100;
                }
            }
            else
            {
                NewDialLocation = DialLocation - TurnAmount;
                while (NewDialLocation < 0 )
                {
                    NewDialLocation += 100;
                }
            }

            return NewDialLocation;
        }
    }
}
