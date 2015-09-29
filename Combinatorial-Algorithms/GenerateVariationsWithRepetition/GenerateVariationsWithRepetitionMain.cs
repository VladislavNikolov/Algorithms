namespace GenerateVariationsWithRepetition
{
    using System;

    public class GenerateVariationsWithRepetitionMain
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] variation = new int[k];

            GenerateVariations(variation, n);
        }

        private static void GenerateVariations(int[] variation, int sizeOfSet, int index = 0)
        {
            if (index >= variation.Length)
            {
                Print(variation);
            }
            else
            {
                for (int i = 1; i <= sizeOfSet; i++)
                {
                    variation[index] = i;
                    GenerateVariations(variation, sizeOfSet, index + 1);
                }
            }
        }

        private static void Print(int[] variation)
        {
            Console.WriteLine("({0})", string.Join(", ", variation));
        }
    }
}
