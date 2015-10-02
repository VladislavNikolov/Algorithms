namespace GenerateSubsetsOfStringArray
{
    using System;
    using System.Collections.Generic;

    public class GenerateSubsetsOfStringArrayMain
    {
        public static void Main()
        {
            string[] fullSet = { "test", "rock", "fun" };
            int k = 2;
            List<string[]> allsets = new List<string[]>();
            allsets = GenerateAllSubsetCombinations(fullSet, k);

            foreach (string[] set in allsets)
            {
                Console.WriteLine(string.Join(" ", set));
            }
        }

        private static List<string[]> GenerateAllSubsetCombinations(string[] fullSet, int subsetSize)
        {
            if (fullSet == null)
            {
                throw new ArgumentException("Value cannot be null.", "fullSet");
            }

            if (subsetSize < 1)
            {
                throw new ArgumentException("Subset size must be 1 or greater.", "subsetSize");
            }

            if ((int)fullSet.LongLength < subsetSize)
            {
                throw new ArgumentException("Subset size cannot be greater than the total number of entries in the full set.", "subsetSize");
            }

            // All possible subsets will be stored here
            List<string[]> allSubsets = new List<string[]>();

            // Initialize current pick; will always be the leftmost consecutive x where x is subset size
            int[] currentPick = new int[subsetSize];
            for (int i = 0; i < subsetSize; i++)
            {
                currentPick[i] = i;
            }

            while (true)
            {
                // Add this subset's values to list of all subsets based on current pick
                string[] subset = new string[subsetSize];
                for (int i = 0; i < subsetSize; i++)
                {
                    subset[i] = fullSet[currentPick[i]];
                }

                allSubsets.Add(subset);

                if (currentPick[0] + subsetSize >= (int)fullSet.LongLength)
                {
                    // Last pick must have been the final 3; end of subset generation
                    break;
                }

                // Update current pick for next subset
                int shiftAfter = (int)currentPick.LongLength - 1;
                bool loop;
                do
                {
                    loop = false;

                    // Move current picker right
                    currentPick[shiftAfter]++;

                    // If we've gotten to the end of the full set, move left one picker
                    if (currentPick[shiftAfter] > (int)fullSet.LongLength - (subsetSize - shiftAfter))
                    {
                        if (shiftAfter > 0)
                        {
                            shiftAfter--;
                            loop = true;
                        }
                    }
                    else
                    {
                        // Update pickers to be consecutive
                        for (int i = shiftAfter + 1; i < (int)currentPick.LongLength; i++)
                        {
                            currentPick[i] = currentPick[i - 1] + 1;
                        }
                    }
                } while (loop);
            }

            return allSubsets;
        }
    }
}
