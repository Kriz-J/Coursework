using System;

namespace DataStructuresAndAlgorithms;

public class HashTableExercises
{
    public static List<int> MostFrequent(int[] input)
    {
        if (input.Length == 0)
        {
            throw new ArgumentException("Input array cannot be null or empty.");
        }

        var frequencyDict = new Dictionary<int, int>();
        var maxFrequency = 0;
        var mostFrequentElements = new List<int>();

        foreach (var num in input)
        {
            if (!frequencyDict.ContainsKey(num))
            {
                frequencyDict.Add(num, 1);
            }
            else
            {
                frequencyDict[num]++;
            }

            if (frequencyDict[num] > maxFrequency)
            {
                maxFrequency = frequencyDict[num];
                mostFrequentElements.Clear();
                mostFrequentElements.Add(num);
            }
            else if (frequencyDict[num] == maxFrequency)
            {
                mostFrequentElements.Add(num);
            }
        }

        return mostFrequentElements;
    }

    public static int CountPairsWithDifference(int[] input, int difference)
    {
        var set = new HashSet<int>(input);
        var numberOfPairs = 0;

        foreach (var num in set)
        {
            if (set.Contains(num + difference))
            {
                numberOfPairs++;
            }
        }

        return numberOfPairs;
    }

    public static int[] TwoSum(int[] input, int target)
    {
        if (input.Length < 2)
        {
            throw new ArgumentException("Input array must contain at least two elements.");
        }

        var dict = new Dictionary<int, int>();

        for (int i = 0; i < input.Length; i++)
        {
            var complement = target - input[i];

            if (!dict.ContainsKey(complement))
            {
                dict.Add(input[i], i);
            }
            else
            {
                return new int[] {dict[complement], i};
            }
        }

        throw new InvalidOperationException("No solution found, input guarantees one solution.");
    }
}