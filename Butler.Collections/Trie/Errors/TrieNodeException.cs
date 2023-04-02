using Butler.Collections.Trie.Node;

namespace Butler.Collections.Trie.Errors;
/// <summary>
/// Represents a <see cref="ITrieNode{TKey, TValue}"/> exception.
/// </summary>
/// <typeparam name="TValue"><inheritdoc cref="ITrieNode{TValue, TKey}" path="/typeparam[@name='TValue']"/></typeparam>
/// <typeparam name="TKey"><inheritdoc cref="ITrieNode{TValue, TKey}" path="/typeparam[@name='TKey']"/></typeparam>
public abstract class TrieNodeException<TValue, TKey> : Exception
{
    /// <inheritdoc/>
    public TrieNodeException()
    {
    }
    /// <inheritdoc/>
    public TrieNodeException(string message) : base(message)
    {
    }
    /// <inheritdoc/>
    public TrieNodeException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
