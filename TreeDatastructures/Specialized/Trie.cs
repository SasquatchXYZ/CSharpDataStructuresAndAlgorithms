namespace TreeDatastructures.Specialized;

public class Trie
{
    private readonly TrieNode _root = new();

    public bool DoesExist(string word)
    {
        var current = _root;
        foreach (var c in word)
        {
            var child = current.Children[c - 'a'];
            if (child is null) return false;
            current = child;
        }

        return current.IsEndOfWord;
    }

    public void Insert(string word)
    {
        var current = _root;
        foreach (var c in word)
        {
            var i = c - 'a';
            current.Children[i] = current.Children[i] ?? new TrieNode();
            current = current.Children[i];
        }

        current.IsEndOfWord = true;
    }

    public List<string> SearchByPrefix(string prefix)
    {
        var current = _root;
        foreach (var c in prefix)
        {
            var child = current.Children[c - 'a'];
            if (child is null) return new List<string>();
            current = child;
        }

        var results = new List<string>();
        GetAllWithPrefix(
            node: current,
            prefix,
            results);

        return results;
    }

    private static void GetAllWithPrefix(
        TrieNode? node,
        string prefix,
        List<string> results)
    {
        if (node is null) return;
        if (node.IsEndOfWord) results.Add(prefix);

        for (var c = 'a'; c <= 'z'; c++)
        {
            GetAllWithPrefix(
                node.Children[c - 'a'],
                prefix: prefix + c,
                results);
        }
    }
}
