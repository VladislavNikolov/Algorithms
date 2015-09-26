﻿namespace TowerOfHanoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TowerOfHanoiMain
    {
        private static int stepsTaken;

        private static Stack<int> source;
        private static Stack<int> destination = new Stack<int>();
        private static Stack<int> spare = new Stack<int>();

        public static void Main()
        {
            Console.WriteLine("Enter number of disks:");
            int numberOfDisks = int.Parse(Console.ReadLine());
            source = new Stack<int>(Enumerable.Range(1, numberOfDisks).Reverse());
            PrintRods();
            MoveDisks(numberOfDisks, source, destination, spare);
        }

        private static void MoveDisks(int bottomDisk, Stack<int> sourceRod, Stack<int> destinationRod, Stack<int> spareRod)
        {
            if (bottomDisk == 1)
            {
                stepsTaken++;
                destinationRod.Push(sourceRod.Pop());
                Console.WriteLine("Step #{0}: Moved disk {1}", stepsTaken, bottomDisk);
                PrintRods();
            }
            else
            {
                MoveDisks(bottomDisk - 1, sourceRod, spareRod, destinationRod);
                stepsTaken++;
                destinationRod.Push(sourceRod.Pop());
                Console.WriteLine("Step #{0}: Moved disk {1}", stepsTaken, bottomDisk);
                PrintRods();
                MoveDisks(bottomDisk - 1, spareRod, destinationRod, sourceRod);
            }
        }

        private static void PrintRods()
        {
            Console.WriteLine("Source: {0}", string.Join(", ", source.Reverse()));
            Console.WriteLine("Destination: {0}", string.Join(", ", destination.Reverse()));
            Console.WriteLine("Spare: {0}", string.Join(", ", spare.Reverse()));
            Console.WriteLine();
        }
    }
}
