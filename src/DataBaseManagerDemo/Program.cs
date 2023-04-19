using PasteBinDataBaseManager;

DataBase dataBase = new DataBase(new Entry[]{}, "https://pastebin.com/raw/35gC0LFZ");

var per1 = dataBase.GetEntryByIdentifier("Person1");
var per2 = dataBase.GetEntryByIdentifier("Person2");

Console.WriteLine(per1.GetEntryInOneLine());
Console.WriteLine(per2.GetEntryInOneLine());
Console.WriteLine(dataBase.Entries[2].GetEntryInOneLine()); //Person3 doesnt contain an identifier, thus we get it manually

Console.ReadKey();