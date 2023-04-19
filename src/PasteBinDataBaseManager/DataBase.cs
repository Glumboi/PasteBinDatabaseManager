using System.Runtime.CompilerServices;

namespace PasteBinDataBaseManager;

public class DataBase
{
    private Entry[] _entries = new Entry[]{};

    public Entry[] Entries => _entries;

    public DataBase(Entry[] entries, string url)
    {
        if (url != null)
        {
            _entries = GetEntriesFromPaste(WebReader.ReadFromUrl(url).Result);
        }
    }

    public string GetValueOfType(string identifier, string type)
    {
        var entry = GetEntryByIdentifier(identifier);
        return entry.GetValueOfType(type);
    }    
    
    public string GetTypeOfValue(string identifier, string value)
    {
        var entry = GetEntryByIdentifier(identifier);
        return entry.GetTypeOfValue(value);
    }
    
    public Entry GetEntryByIdentifier(string identifier)
    {
        foreach (var entry in _entries)
        {
            if (entry.GetIdentifier() == identifier) return entry;
        }

        throw new DataBaseException("Could not find the specified Identifier!\nIs the specified Identifier valid?");
    }
    
    public Entry[] GetEntriesFromPaste(string[] lines)
    {
        List<Entry> entries = new List<Entry>();
        
        foreach (var line in lines)
        {
            //Add to result 
            entries.Add(EntryCreator.CreateEntry(line));
        }
        
        //Return array with all entries
        return entries.ToArray();
    }
    
    public void PrintAllEntries()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry.GetEntryInOneLine());
        }
    }
}