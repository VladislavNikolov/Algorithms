namespace GenerateCombinationsWithRepetition
{
    using System;

    public class GenerateCombinationsWithRepetition
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] combination = new int[k];

            GenerateCombination(combination, n);
        }

        private static void GenerateCombination(int[] combination, int sizeOfSet, int index = 0, int start = 1)
        {
            if (index == combination.Length)
            {
                Print(combination);
            }
            else
            {
                for (int i = start; i <= sizeOfSet; i++)
                {
                    combination[index] = i;
                    GenerateCombination(combination, sizeOfSet, index + 1, i);
                }
            }
        }

        private static void Print(int[] combination)
        {
            Console.WriteLine("({0})", string.Join(", ", combination));
        }
    }
}
