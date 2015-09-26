namespace NestedLoopsToRecursion
{
    using System;

    public class NestedLoopsToRecursionMain
    {
        private static int numberOfLoops;
        private static long numberOfSequences;

        public static void Main()
        {
            Console.WriteLine("Enter number of loops:");
            numberOfLoops = int.Parse(Console.ReadLine());
            int[] sequence = new int[numberOfLoops];
            GenerateSequence(0, sequence);
            Console.WriteLine("Total number of sequences: {0}", numberOfSequences);
        }

        private static void GenerateSequence(int index, int[] sequence)
        {
            if (index >= numberOfLoops)
            {
                PrintSequence(sequence);
            }
            else
            {
                for (int i = 1; i <= numberOfLoops; i++)
                {
                    sequence[index] = i;
                    GenerateSequence(index + 1, sequence);
                }
            }
        }

        private static void PrintSequence(int[] sequence)
        {
            foreach (int i in sequence)
            {
                Console.Write("{0} ", i);
            }

            numberOfSequences++;
            Console.WriteLine();
        }
    }
}
