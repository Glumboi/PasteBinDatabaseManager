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
