using Butler.Collections.Trie.Errors;

namespace Butler.Collections.Trie.Node.Collections;
/// <summary>
/// Represents a collection for <see cref="ITrieNode{TValue, TKey}"/>.
/// </summary>
/// <typeparam name="TValue"><inheritdoc cref="ITrieNode{TValue, TKey}" path="/typeparam[@name='TValue']"/></typeparam>
/// <typeparam name="TKey"><inheritdoc cref="ITrieNode{TValue, TKey}" path="/typeparam[@name='TKey']"/></typeparam>
public interface ITrieNodeCollection<TValue, TKey> : IReadOnlyCollection<ITrieNode<TValue, TKey>>
{
    /// <summary>
    /// Gets or sets the <see cref="ITrieNode{TValue, TKey}"/> based on the <paramref name="key"/>.
    /// </summary>
    /// <param name="key">The <typeparamref name="TKey"/> to find the correct <see cref="ITrieNode{TValue, TKey}"/> based on.</param>
    /// <returns>The stored <see cref="ITrieNode{TValue, TKey}"/>.</returns>
    /// <exception cref="KeyException{TKey}">Thrown when the key is invalid.</exception>
    /// <exception cref="NodeNotFound">Thrown when the node cant be found given <paramref name="key"/>.</exception>
    ITrieNode<TValue, TKey> this[TKey key] { get; set; }
    /// <summary>
    /// Checks if the <paramref name="key"/> exists in this collection.
    /// </summary>
    /// <param name="key"><inheritdoc cref="this[TKey]" path="/param[@name='key']"/></param>
    /// <returns><see langword="true"/> if the <paramref name="key"/> is contained, <see langword="false"/> if not.</returns>
    bool Contains(TKey key);
    /// <inheritdoc cref="ITrieNode{TValue, TKey}.IsSupported(TKey)"/>
    bool IsSupported(TKey key);
}
