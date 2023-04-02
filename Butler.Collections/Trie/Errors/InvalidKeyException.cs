namespace Butler.Collections.Trie.Errors;
/// <summary>
/// Represents a class where the character is invalid.
/// </summary>
/// <typeparam name="TValue"><inheritdoc cref="TrieNodeException{TKey, TValue}" path="/typeparam[@name='TValue']"/></typeparam>
/// <typeparam name="TKey"><inheritdoc cref="TrieNodeException{TKey, TValue}" path="/typeparam[@name='TKey']"/></typeparam>
public abstract class InvalidKeyException<TValue, TKey> : TrieNodeException<TValue, TKey>
{
    /// <summary>
    /// The character that was attempted to use.
    /// </summary>
    public TKey AttemptedKey { get; init; } = default!;
    /// <inheritdoc/>
    public InvalidKeyException()
    {
    }
    /// <inheritdoc/>
    public InvalidKeyException(string message) : base(message)
    {
    }
    /// <inheritdoc/>
    public InvalidKeyException(string message, Exception innerException) : base(message, innerException)
    {
    }
}