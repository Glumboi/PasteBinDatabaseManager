using PasteBinDataBaseManager;

DataBase dataBase = new DataBase(new Entry[]{}, "https://pastebin.com/raw/35gC0LFZ");

foreach (var entry in dataBase.Entries)
{
    Console.WriteLine(entry.GetEntryInOneLine());
}
Console.ReadKey();