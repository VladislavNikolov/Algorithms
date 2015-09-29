namespace GenerateVariationsWithoutRepetition
{
    using System;

    public class GenerateVariationsWithoutRepetitionMain
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] variation = new int[k];
            bool[] used = new bool[n + 1];

            GenerateVariations(variation, n, used);
        }

        private static void GenerateVariations(int[] variation, int sizeOfSet, bool[] used, int index = 0)
        {
            if (index >= variation.Length)
            {
                Print(variation);
            }
            else
            {
                for (int i = 1; i <= sizeOfSet; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        variation[index] = i;
                        GenerateVariations(variation, sizeOfSet, used, index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        private static void Print(int[] variation)
        {
            Console.WriteLine("({0})", string.Join(", ", variation));
        }
    }
}
