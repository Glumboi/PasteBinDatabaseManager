namespace PasteBinDataBaseManager;

public class EntryCreator
{
    public static Entry CreateEntry(string line)
    {
        string[] splittedBySpace = line.Split(']').Last().Split(": ");
        List<string> types = new List<string>();
        List<string> values = new List<string>();
        string identifier = !line.Contains('[')? "NOT DEFINED" : line.Split('[').Last().Split(']').First();
        
        for (int i = 0; i < splittedBySpace.Length; i++)
        {
            string str = splittedBySpace[i] += ":";

            if (str.Contains(':') && !str.Contains("https"))
            {
                types.Add(str.Replace(":", "").Remove(str.Contains(' ') ? str.IndexOf(' ') : 1, 1));
            }

            if (str.Contains(','))
            {
                var replaced = str.Replace(",", "");
                values.Add(replaced.Remove(replaced.Length - 1, 1));
            }
        }

        return new Entry(identifier, types.ToArray(), values.ToArray());
    }
}