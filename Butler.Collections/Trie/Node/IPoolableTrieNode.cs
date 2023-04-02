namespace Butler.Collections.Trie.Node;
/// <summary>
/// Represents an <see cref="ITrieNode{TValue, TKey}"/> that is poolable.
/// </summary>
/// <typeparam name="TValue"><inheritdoc cref="ITrieNode{TValue, TKey}" path="/typeparam[@name='TValue']"/></typeparam>
/// <typeparam name="TKey"><inheritdoc cref="ITrieNode{TValue, TKey}" path="/typeparam[@name='TKey']"/></typeparam>
public interface IPoolableTrieNode<TValue, TKey> : ITrieNode<TValue, TKey>
{
    /// <summary>
    /// Activates the current node with the new values.
    /// </summary>
    /// <param name="value">The new value in the node.</param>
    /// <param name="isEndOfWord">The new state of the node.</param>
    void Activate(TValue value, bool isEndOfWord);
    /// <summary>
    /// Deactivates the node for pooling.
    /// </summary>
    void Deactivate();
}
