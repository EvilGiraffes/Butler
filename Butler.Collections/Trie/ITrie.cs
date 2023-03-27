using Butler.Collections.Trie.Node;

namespace Butler.Collections.Trie;
/// <summary>
/// Represents a trie data structure.
/// </summary>
/// <typeparam name="TValue"><inheritdoc cref="ITrieNode{TValue, TKey}" path="/typeparam[@name='TValue']"/></typeparam>
/// <typeparam name="TKey"><inheritdoc cref="ITrieNode{TValue, TKey}" path="/typeparam[@name='TKey']"/></typeparam>
/// <seealso cref="ITrieNode{TValue, TKey}"/>
public interface ITrie<TValue, TKey> : ICollection<string>, IReadOnlyCollection<string>
{
    /// <summary>
    /// Whether there is a value which starts with the given <paramref name="prefix"/>.
    /// </summary>
    /// <param name="prefix">The prefix to search for.</param>
    /// <returns><see langword="true"/> if there is something starting the <paramref name="prefix"/>, <see langword="false"/> if not.</returns>
    bool StartsWith(string prefix);
    /// <summary>
    /// Traverses the <see cref="ITrie{TValue, TKey}"/> collection.
    /// </summary>
    /// <typeparam name="TResult"><inheritdoc cref="TrieTraversalStrategy{TResult, TValue, TKey}" path="/typeparam[@name='TResult']" /></typeparam>
    /// <param name="strategy">The strategy to perform the traversal on.</param>
    /// <returns>The value of the <paramref name="strategy"/>.</returns>
    TResult Traverse<TResult>(TrieTraversalStrategy<TValue, TKey, TResult> strategy);
}
