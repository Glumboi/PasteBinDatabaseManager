using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace PasteBinDatabaseManager;

public class Database
{
    private List<Entry> _entries = new List<Entry>();

    public List<Entry> Entries
    {
        set => _entries = value;
        get => _entries;
    }

    private string _databaseName = string.Empty;

    public string DatabaseName
    {
        set => _databaseName = value;
        get => _databaseName;
    }

    public Database(List<Entry> entries, string url, string databaseName = "")
    {
        DatabaseName = databaseName == "" ? $"Database_{StringHelpers.RandomString(6)}" : databaseName;

        if (entries.Count > 0)
            Entries = entries;

        if (!string.IsNullOrEmpty(url))
        {
            var test = GetEntriesFromPaste(!File.Exists(url) ? WebReader.ReadFromUrl(url).Result : File.ReadAllLines(url));
            foreach (var entry in test)
            {
                Entries.Add(entry);
            }
        }
        else
        {
            throw new DatabaseException("Cannot define an invalid file URL/Path.");
        }
    }

    public string GetValueOfType(string identifier, string type)
    {
        return GetEntryByIdentifier(identifier).GetValueOfType(type);
    }

    public string GetTypeOfValue(string identifier, string value)
    {
        return GetEntryByIdentifier(identifier).GetTypeOfValue(value);
    }

    public Entry GetEntryByIdentifier(string identifier)
    {
        foreach (var entry in _entries)
        {
            if (entry.GetIdentifier() == identifier) return entry;
        }

        throw new DatabaseException("Could not find the specified Identifier!\nIs the specified Identifier valid?");
    }

    private List<Entry> GetEntriesFromPaste(IEnumerable<string> lines)
    {
        List<Entry> rtrnEntries = new List<Entry>();

        foreach (var line in lines)
        {
            rtrnEntries.Add(EntryCreator.CreateEntry(line));
        }

        return rtrnEntries;
    }

    public void PrintAllEntries()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry.GetEntryInOneLine());
        }
    }

    public void DeInitialize()
    {
        _entries = new List<Entry> { };
        DatabaseName = string.Empty;
    }
}