namespace CombinationsWithoutRepetition
{
    using System;

    public class CombinationsWithoutRepetitionMain
    {
        private static int n;
        private static int k;
        private static long numberOfCombinations;

        public static void Main()
        {
            Console.WriteLine("Enter number of elements n:");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of elements per combination k (k <= n):");
            k = int.Parse(Console.ReadLine());
            int[] combination = new int[k];

            GenerateCombination(1, 0, combination);

            Console.WriteLine("Total number of combinations with repetitions: {0}", numberOfCombinations);
        }

        private static void GenerateCombination(int startIndex, int currentIndex, int[] combination)
        {
            if (currentIndex >= k)
            {
                PrintCombination(combination);
            }
            else
            {
                for (int i = startIndex; i <= n; i++)
                {
                    combination[currentIndex] = i;
                    GenerateCombination(i + 1, currentIndex + 1, combination);
                }
            }
        }

        private static void PrintCombination(int[] combination)
        {
            foreach (int i in combination)
            {
                Console.Write("{0} ", i);
            }

            numberOfCombinations++;
            Console.WriteLine();
        }
    }
}
