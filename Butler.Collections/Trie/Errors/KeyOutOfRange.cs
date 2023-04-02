namespace Butler.Collections.Trie.Errors;
/// <summary>
/// Represents an exception thrown when the key is out of range.
/// </summary>
public class KeyOutOfRange<TValue, TKey> : InvalidKeyException<TValue, TKey>
{
    /// <inheritdoc/>
    public KeyOutOfRange()
    {
    }
    /// <inheritdoc/>
    public KeyOutOfRange(string message) : base(message)
    {
    }
    /// <inheritdoc/>
    public KeyOutOfRange(string message, Exception innerException) : base(message, innerException)
    {
    }
}
