namespace Butler.Collections.Trie.Errors;
/// <summary>
/// Represents a class where the <typeparamref name="TKey"/> context is needed.
/// </summary>
/// <typeparam name="TKey">The key used.</typeparam>
public abstract class KeyException<TKey> : Exception
{
    /// <summary>
    /// The key that was attempted.
    /// </summary>
    public TKey AttemptedKey { get; init; } = default!;
    /// <inheritdoc/>
    public KeyException()
    {
    }
    /// <inheritdoc/>
    public KeyException(string message) : base(message)
    {
    }
    /// <inheritdoc/>
    public KeyException(string message, Exception innerException) : base(message, innerException)
    {
    }
}