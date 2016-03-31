// Alternatively, use GenerateVariationsWithoutRepetition with k == n to achieve the same result.

namespace Permutations
{
    using System;
    using System.Linq;

    public class PermutationsMain
    {
        private static int countOfPermutations;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] permutation = Enumerable.Range(1, n).ToArray();

            Permute(permutation);

            Console.WriteLine("Total permutation: {0}", countOfPermutations);
        }

        private static void Permute(int[] permutation, int startIndex = 0)
        {
            if (startIndex >= permutation.Length - 1)
            {
                //Console.WriteLine(string.Join(", ", permutation));
                countOfPermutations++;
            }
            else
            {
                for (int i = startIndex; i < permutation.Length; i++)
                {
                    Swap(ref permutation[startIndex], ref permutation[i]);
                    Permute(permutation, startIndex + 1);
                    Swap(ref permutation[startIndex], ref permutation[i]);
                }
            }
        }

        private static void Swap(ref int i, ref int j)
        {
            if (i == j)
            {
                return;
            }

            i ^= j;
            j ^= i;
            i ^= j;
        }
    }
}
