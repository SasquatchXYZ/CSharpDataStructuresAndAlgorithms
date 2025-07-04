using System.Collections;

var phoneBook = new Hashtable
{
    {
        "Marcin", "101-202-303"
    },
    {
        "Martyna", "202-303-404"
    },
};

phoneBook["Aline"] = "303-404-505";

Console.WriteLine("Phone numbers:");
if (phoneBook.Count == 0)
    Console.WriteLine("Empty list.");

foreach (DictionaryEntry entry in phoneBook)
{
    Console.WriteLine($"{entry.Key}: {entry.Value}");
}

Console.Write("\nSearch by name: ");
var name = Console.ReadLine() ?? string.Empty;
if (phoneBook.ContainsKey(name))
{
    var number = (string) phoneBook[name]!;
    Console.WriteLine($"Phone number for {name}: {number}");
}
else
{
    Console.WriteLine($"No phone number for {name}.");
}
