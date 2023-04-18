namespace PasteBinDataBaseManager;

public class EntryCreator
{
    public static Entry CreateEntry(string line)
    {
        string[] splittedBySpace = line.Split(']').Last().Split(' ');
        
        List<string> types = new List<string>() { };
        List<string> values = new List<string>() { };
        string identifier;
        
        if (!line.Contains('['))
        {
            identifier = "NOT DEFINED";
        }
        else
        {
            identifier = line.Split('[').Last().Split(']').First();
        }
        
        foreach (var str in splittedBySpace)
        {
            if (str.Contains(':'))
            {
                types.Add(str.Replace(":", ""));
            }

            if (str.Contains(','))
            {
                values.Add(str.Replace(",", ""));
            }
        }

        return new Entry(identifier, types.ToArray(), values.ToArray());
    }
}