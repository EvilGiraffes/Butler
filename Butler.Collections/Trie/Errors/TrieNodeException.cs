namespace Butler.Collections.Trie.Errors;
/// <summary>
/// Represents a <see cref="ITrieNode"/> exception.
/// </summary>
public abstract class TrieNodeException : Exception
{
    /// <summary>
    /// The context in which this exception occured.
    /// </summary>
    ITrieNode Context { get; init; } = default!;
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
