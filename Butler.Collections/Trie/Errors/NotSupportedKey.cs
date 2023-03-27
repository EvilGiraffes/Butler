using Butler.Collections.Trie.Node;

namespace Butler.Collections.Trie.Errors;
/// <summary>
/// Thrown when the character is not supported.
/// </summary>
/// <typeparam name="TValue"><inheritdoc cref="InvalidKeyException{TValue, TKey}" path="/typeparam[@name='TValue']"/></typeparam>
/// <typeparam name="TKey"><inheritdoc cref="InvalidKeyException{TValue, TKey}" path="/typeparam[@name='TKey']"/></typeparam>
public class NotSupportedKey<TValue, TKey> : InvalidKeyException<TValue, TKey>
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
