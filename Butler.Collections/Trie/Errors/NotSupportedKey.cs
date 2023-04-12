using Butler.Collections.Trie.Node;

namespace Butler.Collections.Trie.Errors;
/// <summary>
/// Thrown when the character is not supported.
/// </summary>
/// <typeparam name="TKey"><inheritdoc cref="KeyException{TKey}" path="/typeparam[@name='TKey']"/></typeparam>
public class NotSupportedKey<TKey> : KeyException<TKey>
{
    /// <summary>
    /// The characters that is valid for this <see cref="ITrieNode{TValue, TKey}"/>.
    /// </summary>
    public IEnumerable<TKey> ValidKeys { get; init; } = Enumerable.Empty<TKey>();
    /// <inheritdoc/>
    public NotSupportedKey()
    {
    }
    /// <inheritdoc/>
    public NotSupportedKey(string message) : base(message)
    {
    }
    /// <inheritdoc/>
    public NotSupportedKey(string message, Exception innerException) : base(message, innerException)
    {
    }
}
