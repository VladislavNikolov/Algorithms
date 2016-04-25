namespace GeneratePermutationsIteratively
{
    using System;

    public class GeneratePermutationsIterativelyMain
    {
        public static void Main()
        {
            Console.Write("Input N:");
            int n = int.Parse(Console.ReadLine());
            

            int key = n - 1;
            int[] currentPermutation = new int[n];

            for (int i = 0; i < n; i++)
            {
                currentPermutation[i] = i + 1;
            }

            Print(currentPermutation);
            while (true)
            {
                key = FindKey(currentPermutation);
                if (key >= 0)
                {
                    SwapKey(currentPermutation, key);
                    Array.Sort(currentPermutation, key + 1, n - key - 1);
                    Print(currentPermutation);
                }
                else
                {
                    break;
                }
            }
        }
        
        private static void Print(int[] currentPerm)
        {
            for (int i = 0; i < currentPerm.Length; i++)
            {
                Console.Write(currentPerm[i] + " ");
            }

            Console.WriteLine();
        }

        private static void SwapKey(int[] arr, int key)
        {
            int tempNum;
            for (int i = arr.Length - 1; i >= key; i--)
            {
                if (arr[i] > arr[key])
                {
                    tempNum = arr[key];
                    arr[key] = arr[i];
                    arr[i] = tempNum;
                    return;
                }
            }
        }

        private static int FindKey(int[] currentPerm)
        {
            for (int i = currentPerm.Length - 2; i >= 0; i--)
            {
                if (currentPerm[i] < currentPerm[i + 1])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
