namespace TreeDatastructures.Specialized;

public class TrieNode
{
    public TrieNode[] Children { get; set; }
        = new TrieNode[26];

    /// <summary>
    /// Indicates whether the current node is the last char from a word,
    /// i.e., you can get this word by traversing from the root element
    /// to this node
    /// </summary>
    public bool IsEndOfWord { get; set; }
}
