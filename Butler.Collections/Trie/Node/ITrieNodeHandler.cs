using Butler.Collections.Trie.Errors;

namespace Butler.Collections.Trie.Node;
// TODO: Make this to handle and mutate the nodes, make the node itself only show values.
/// <summary>
/// Represents an object to handle an <see cref="ITrieNode{TValue, TKey}"/>.
/// </summary>
/// <typeparam name="TNode">The node that will be handled by this handler.</typeparam>
/// <typeparam name="TValue"><inheritdoc cref="ITrieNode{TValue, TKey}" path="/typeparam[@name='TValue']"/></typeparam>
/// <typeparam name="TKey"><inheritdoc cref="ITrieNode{TValue, TKey}" path="/typeparam[@name='TKey']"/></typeparam>
/// <seealso cref="ITrie{TValue, TKey}"/>
/// <seealso cref="ITrieNode{TValue, TKey}"/>
public interface ITrieNodeHandler<TNode, TValue, TKey>
    where TNode : ITrieNode<TValue, TKey>
{
    /// <summary>
    /// Creates a new node.
    /// </summary>
    /// <param name="startValue">The value it should start with.</param>
    /// <param name="isEndOfWord">Which state it should start in.</param>
    /// <returns>A new <see cref="ITrieNode{TValue, TKey}"/> of type <typeparamref name="TNode"/>.</returns>
    TNode Create(TValue startValue, bool isEndOfWord);
    /// <summary>
    /// Changes the current state of the <see cref="ITrieNode{TValue, TKey}"/>.
    /// </summary>
    /// <remarks>
    /// This may return the same object if it only mutates, however if its represented as a value type it may return a new object.
    /// </remarks>
    /// <param name="node">The node to set the state for.</param>
    /// <param name="isEndOfWord">The new state.</param>
    /// <returns>A <see cref="ITrieNode{TValue, TKey}"/> of type <typeparamref name="TNode"/> with the new state.</returns>
    TNode ChangeState(TNode node, bool isEndOfWord);
    /// <summary>
    /// Adds a new child with the given <paramref name="key"/> to <paramref name="node"/>.
    /// </summary>
    /// <param name="node">The node to add the child to.</param>
    /// <param name="key">The new child to add.</param>
    /// <exception cref="NotSupportedKey{TValue, TKey}">Thrown when the key is not supported in the current node.</exception>
    void AddChild(TNode node, TKey key);
    /// <summary>
    /// Pops the given child from <paramref name="node"/>.
    /// </summary>
    /// <param name="node">The node to pop the child from.</param>
    /// <param name="key">The child to pop.</param>
    /// <returns>The node it removed from the <paramref name="node"/>.</returns>
    /// <exception cref="NodeNotFound{TValue, TKey}">Thrown when the node in <paramref name="node"/> with the given <paramref name="key"/> could not be found.</exception>
    /// <exception cref="NotSupportedKey{TValue, TKey}">Thrown when the key is not supported in the current node.</exception>
    TNode PopChild(TNode node, TKey key);
    /// <summary>
    /// Determins if the <paramref name="key"/> is supported by <typeparamref name="TNode"/>.
    /// </summary>
    /// <param name="key">The character to check.</param>
    /// <returns><see langword="true"/> if it is supported, <see langword="false"/> if it is not supported.</returns>
    bool IsSupported(TKey key);
    /// <summary>
    /// Recalls the node when deleted.
    /// </summary>
    /// <remarks>
    /// This method is where you would add object pooling logic if so desired.
    /// </remarks>
    /// <param name="node">The node that has been removed.</param>
    void Recall(TNode node);
}
