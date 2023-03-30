using Butler.Collections.Trie.Node;

namespace Butler.Collections.Trie;
/// <summary>
/// Represents a strategy to traverse a trie with a <see cref="ITrieNode{TValue, TKey}"/>.
/// </summary>
/// <typeparam name="TValue"><inheritdoc cref="ITrieNode{TValue, TKey}" path="/typeparam[@name='TValue']"/></typeparam>
/// <typeparam name="TKey"><inheritdoc cref="ITrieNode{TValue, TKey}" path="/typeparam[@name='TKey']"/></typeparam>
/// <typeparam name="TResult">The result after the stratgy has completed.</typeparam>
/// <param name="root">The root of the <see cref="ITrie{TValue, TKey}"/>.</param>
/// <returns>The result as defined by the strategy of type <typeparamref name="TResult"/>.</returns>
public delegate TResult TrieTraversalStrategy<TValue, TKey, TResult>(ITrieNode<TValue, TKey> root);