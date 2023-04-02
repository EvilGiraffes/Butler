using Butler.Collections.Trie.Errors;

namespace Butler.Collections.Trie.Node.Policies;
// TODO: Implement.
/// <summary>
/// Represents a policy to handle the a generic <see cref="ITrieNode{TValue, TKey}"/>.
/// </summary>
public interface ITrieNodePolicy<TKey>
{
    /// <summary>
    /// Gets the index using the given <typeparamref name="TKey"/>.
    /// </summary>
    /// <param name="key">The key to get the index from.</param>
    /// <returns>An index for the array.</returns>
    /// <exception cref="NotSupportedKey{TValue, TKey}">Thrown when the key is not supported by the current policy.</exception>
    int IndexFrom(TKey key);
    /// <summary>
    /// Determins if the <typeparamref name="TKey"/> is supported by the current node.
    /// </summary>
    /// <param name="key">The key to check if is supported.</param>
    /// <returns><see langword="true"/> if it is supported, <see langword="false"/> if it is not.</returns>
    bool IsSupported(TKey key);
}
