namespace GenerateSubsetsOfStringArray
{
    using System;

    internal class GenerateSubsetsOfStringArrayMain
    {
        private static void Main()
        {
            var set = new[] { "test", "rock", "fun", "jump" };
            int k = 3;

            string[] arr = new string[k];
            GenerateSubsets(set, arr, 0, 0);
        }

        private static void GenerateSubsets(string[] initial, string[] control, int index, int start)
        {
            if (index >= control.Length)
            {
                Console.WriteLine(string.Join(" ", control));
            }
            else
            {
                for (int i = start; i < initial.Length; i++)
                {
                    control[index] = initial[i];
                    GenerateSubsets(initial, control, index + 1, i + 1);
                }
            }
        }
    }
}
