namespace DataStructuresAndAlgorithms;

public class CharFinder
{
    public static char FindFirstNonRepeatingChar(string str)
    {
        var dict = new Dictionary<char, int>();

        foreach (var c in str)
        {
            if (!dict.ContainsKey(c))
            {
                dict.Add(c, 1);
            }
            else
            {
                dict[c]++;
            }
        }

        for (int i = 0; i < str.Length; i++)
        {
            if (dict[str[i]] == 1)
            {
                return str[i];
            }
        }

        return char.MinValue;
    }

    public static char FirstRepeatedCharacter(string str)
    {
        var set = new HashSet<char>();

        foreach (var c in str)
        {
            if (set.Contains(c))
            {
                return c;
            }

            set.Add(c);
        }

        return char.MinValue;
    }
}