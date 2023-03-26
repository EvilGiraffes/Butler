namespace Butler.Collections.Trie;

/// <summary>
/// A traversal strategy which is used to traverse a <see cref="ITrie"/> by taking the root <see cref="ITrieNode"/>.
/// </summary>
/// <typeparam name="TResult">The return type once it has traversed the trie.</typeparam>
/// <param name="root">The root <see cref="ITrieNode"/> of the <see cref="ITrie"/>.</param>
/// <returns><typeparamref name="TResult"/> from the strategy definition.</returns>
public delegate TResult TrieTraversalStrategy<TResult>(ITrieNode root);