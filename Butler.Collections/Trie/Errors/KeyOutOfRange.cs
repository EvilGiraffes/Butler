namespace Butler.Collections.Trie.Errors;
/// <summary>
/// Represents an exception thrown when the key is out of range.
/// </summary>
public class KeyOutOfRange<TKey> : KeyException<TKey>
{
    /// <summary>
    /// The range it should be within.
    /// </summary>
    public Range Range { get; init; }
    /// <summary>
    /// The Index it calculated to.
    /// </summary>
    public Index Calculated { get; init; }
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
