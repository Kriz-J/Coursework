namespace DataStructuresAndAlgorithms;

public class HashMap
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

    private Entry?[] _entries;

    private readonly double _loadFactor;

    private int _maxSizeBeforeResizing;

    public int Count { get; private set; }

    public HashMap(int capacity = 23, double loadFactor = 0.75)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(capacity, 1);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(capacity, int.MaxValue);

        ArgumentOutOfRangeException.ThrowIfLessThan(loadFactor, 0.05);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(loadFactor, 1);

        _entries = new Entry[capacity];
        _loadFactor = loadFactor;
        _maxSizeBeforeResizing = UpdateMaxSize();
    }

    public void Put(int key, string value)
    {
        if (Count + 1 > _maxSizeBeforeResizing && !KeyAlreadyExists(key))
        {
            Resize();
        }
        
        InsertEntry(key, value);
    }
    
    public string Get(int key)
    {
        var index = Hash(key);

        for (int i = 0; i < Count; i++)
        {
            if (_entries[index] is null) break;
            if (_entries[index]!.Key == key)
            {
                return _entries[index]!.Value;
            }

            index = Hash(index + 1);
        }

        throw new KeyNotFoundException($"Specified key '{key}' not found.");
    }
    
    public void Remove(int key)
    {
        var index = Hash(key);

        for (int i = 0; i < Count; i++)
        {
            if (_entries[index] is null) break;
            if (_entries[index]!.Key == key)
            {
                _entries[index] = null;
                Count--;

                RehashCluster(index);
                
                return;
            }

            index = Hash(index + 1);
        }

        throw new KeyNotFoundException($"Specified key '{key}' not found.");
    }
    
    public int Size() => Count;

    private int Hash(int key) => key % _entries.Length;

    private int UpdateMaxSize() => (int)(_entries.Length * _loadFactor);

    private void InsertEntry(int key, string value)
    {
        var index = Hash(key);

        for (int i = 0; i < Count + 1; i++)
        {
            if (_entries[index] is null)
            {
                AddNewEntry(index, key, value);
                return;
            }

            if (_entries[index]!.Key == key)
            {
                UpdateEntry(index, value);
                return;
            }

            index = Hash(index + 1);
        }

        throw new InvalidOperationException($"Could not insert key-value-pair '{key}:{value}'.");
    }

    private void AddNewEntry(int index, int key, string value)
    {
        _entries[index] = new Entry(key, value);
        Count++;
    }

    private void UpdateEntry(int index, string value)
    {
        _entries[index]!.Value = value;
    }

    private void Resize()
    {
        if ((long)Count * 2 > int.MaxValue)
        {
            throw new InvalidOperationException("Hash table maximum size exceeded.");
        }

        var newArray = new Entry[Count * 2];
        var entriesCopy = _entries;
        
        _entries = newArray;
        Count = 0;
        
        foreach (var entry in entriesCopy)
        {
            if (entry is not null)
            {
                InsertEntry(entry.Key, entry.Value);
            }
        }

        _maxSizeBeforeResizing = UpdateMaxSize();
    }

    private void RehashCluster(int index)
    {
        for (int j = Hash(index + 1); _entries[j] is not null; j = Hash(j + 1))
        {
            RehashEntry(j);
        }
    }

    private void RehashEntry(int index)
    {
        var rehashKey = _entries[index]!.Key;
        var rehashValue = _entries[index]!.Value;
        _entries[index] = null;
        Count--;

        InsertEntry(rehashKey, rehashValue);
    }

    private bool KeyAlreadyExists(int key)
    {
        var index = Hash(key);

        return ProbeForKey(key, index);
    }

    private bool ProbeForKey(int key, int index)
    {
        for (int i = 0; i < Count; i++)
        {
            if (_entries[index] is null) return false;
            if (_entries[index]!.Key == key) return true;

            index = Hash(index + 1);
        }

        return false;
    }
}