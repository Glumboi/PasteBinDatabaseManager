using System.Runtime.CompilerServices;

namespace PasteBinDataBaseManager;

public class DataBase
{
    private Entry[] _entries = new Entry[]{};

    public Entry[] Entries => _entries;

    public DataBase(Entry[] entries, string url)
    {
        _entries = url != null && !File.Exists(url) ? GetEntriesFromPaste(WebReader.ReadFromUrl(url).Result): 
            GetEntriesFromPaste(File.ReadAllLines(url));
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

        throw new DataBaseException("Could not find the specified Identifier!\nIs the specified Identifier valid?");
    }
    
    private Entry[] GetEntriesFromPaste(string[] lines)
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