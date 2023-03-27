using Butler.Collections.Trie.Node;

namespace Butler.Collections.Trie.Errors;
/// <summary>
/// Represents a <see cref="ITrieNode{TKey, TValue}"/> exception.
/// </summary>
/// <typeparam name="TValue"><inheritdoc cref="ITrieNode{TValue, TKey}" path="/typeparam[@name='TValue']"/></typeparam>
/// <typeparam name="TKey"><inheritdoc cref="ITrieNode{TValue, TKey}" path="/typeparam[@name='TKey']"/></typeparam>
public abstract class TrieNodeException<TValue, TKey> : Exception
{
    /// <summary>
    /// The context in which this exception occured.
    /// </summary>
    public ITrieNode<TValue, TKey> Context { get; init; } = default!;
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
