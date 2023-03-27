namespace Butler.Collections.Trie.Node;
/// <summary>
/// Represents an object to handle an <see cref="ITrieNode{TValue, TKey}"/>.
/// </summary>
/// <typeparam name="TValue"><inheritdoc cref="ITrieNode{TValue, TKey}" path="/typeparam[@name='TValue']"/></typeparam>
/// <typeparam name="TKey"><inheritdoc cref="ITrieNode{TValue, TKey}" path="/typeparam[@name='TKey']"/></typeparam>
/// <seealso cref="ITrie{TValue, TKey}"/>
/// <seealso cref="ITrieNode{TValue, TKey}"/>
public interface ITrieNodeHandler<TValue, TKey>
{
    /// <summary>
    /// Creates a new node.
    /// </summary>
    /// <param name="startValue">The value it should start with.</param>
    /// <param name="isEndOfWord">Which state it should start in.</param>
    /// <returns>A new <see cref="ITrieNode{TValue, TKey}"/>.</returns>
    ITrieNode<TValue, TKey> Create(TValue startValue, bool isEndOfWord);
    /// <summary>
    /// Changes the current state of the <see cref="ITrieNode{TValue, TKey}"/>.
    /// </summary>
    /// <param name="node">The node to set the state for.</param>
    /// <param name="isEndOfWord">The new state.</param>
    /// <returns>A <see cref="ITrieNode{TValue, TKey}"/> with the new state.</returns>
    ITrieNode<TValue, TKey> ChangeState(ITrieNode<TValue, TKey> node, bool isEndOfWord);
    /// <summary>
    /// Recalls the node when deleted.
    /// </summary>
    /// <remarks>
    /// This method is where you would add object pooling logic if so desired.
    /// </remarks>
    /// <param name="node">The node that has been removed.</param>
    void Recall(ITrieNode<TValue, TKey> node);
}
