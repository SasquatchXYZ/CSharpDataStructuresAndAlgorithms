using System.Text.RegularExpressions;
using TreeDatastructures.Specialized;

var trie = new Trie();
var countries = await File.ReadAllLinesAsync("Countries.txt");
foreach (var country in countries)
{
    var regex = new Regex("[^a-z]");
    var name = country.ToLower();
    name = regex.Replace(name, string.Empty);
    trie.Insert(name);
}

var text = string.Empty;
while (true)
{
    Console.Write("Enter next character: ");
    var key = Console.ReadKey();
    if (key.KeyChar is < 'a' or > 'z') return;
    text = (text + key.KeyChar).ToLower();
    var results = trie.SearchByPrefix(text);
    if (results.Count == 0) return;

    Console.WriteLine($"\nSuggestions for {text.ToUpper()}:");
    results.ForEach(r => Console.WriteLine(r.ToUpper()));
    Console.WriteLine();
}
