using Default = System.Collections.Generic;

namespace DataStructuresAndAlgorithms;

public class HashTable
{
    public class Entry
    {
        public int Key { get; }
        public string Value { get; set; }

        public Entry(int key, string value)
        {
            Key = key;
            Value = value;
        }
    }

    private readonly Default.LinkedList<Entry>?[] _buckets;
    public int Count { get; private set; }

    public HashTable(int capacity = 13)
    {
        _buckets = new Default.LinkedList<Entry>[capacity];
    }

    public void Put(int key, string value)
    {
        var bucket = _buckets[Hash(key)] ?? new Default.LinkedList<Entry>();

        foreach (var entry in bucket)
        {
            if (entry.Key == key)
            {
                entry.Value = value;
                return;
            }
        }

        bucket.AddLast(new Entry(key, value));
        Count++;
    }

    public string Get(int key)
    {
        var bucket = _buckets[Hash(key)];
        if (bucket is not null)
        {
            foreach (var entry in bucket)
            {
                if (entry.Key == key)
                {
                    return entry.Value;
                }
            }
        }

        throw new KeyNotFoundException(KeyNotFoundMessage(key));
    }

    public void Remove(int key)
    {
        var bucket = _buckets[Hash(key)];
        if (bucket is not null)
        {
            foreach (var entry in bucket)
            {
                if (entry.Key == key)
                {
                    bucket.Remove(entry);
                }
            }
        }

        throw new KeyNotFoundException(KeyNotFoundMessage(key));
    }

    private int Hash(int key) => Math.Abs(key) % _buckets.Length;

    private static string KeyNotFoundMessage(int key) => $"The specified key '{key}' does not exist in the table.";
}