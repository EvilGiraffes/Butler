﻿using Butler.Collections.Trie.Errors;

namespace Butler.Collections.Trie.Node;
/// <summary>
/// Represents a node used in a <see cref="ITrie{TValue, TKey}"/>.
/// </summary>
/// <typeparam name="TValue">Represents the value in this node.</typeparam>
/// <typeparam name="TKey">Represents the key the node uses.</typeparam>
/// <seealso cref="ITrie{TValue, TKey}"/>
/// <seealso cref="ITrieNodeHandler{TNode, TValue, TKey}"/>
public interface ITrieNode<TValue, TKey> : IReadOnlyCollection<ITrieNode<TValue, TKey>>
{
    /// <summary>
    /// The value stored in this node.
    /// </summary>
    TValue Value { get; }
    /// <summary>
    /// Whether this node is an end of a word.
    /// </summary>
    bool IsEndOfWord { get; }
    /// <summary>
    /// Gets the next node given the character.
    /// </summary>
    /// <param name="key">The character node to get</param>
    /// <returns><see cref="ITrieNode{TValue, TKey}"/> child with the <paramref name="key"/> as the value.</returns>
    /// <inheritdoc cref="Value" path="/exception"/>
    /// <exception cref="NodeNotFound{TValue, TKey}">Thrown if the node is not found.</exception>
    /// <exception cref="NotSupportedKey{TValue, TKey}">Thrown when the key is not supported in the current node.</exception>
    ITrieNode<TValue, TKey> this[TKey key] { get; }
    /// <summary>
    /// Checks if the current node has a definition of this character.
    /// </summary>
    /// <param name="key">The character to check.</param>
    /// <returns><see langword="true"/> if it is found in the current node, <see langword="false"/> if it is not.</returns>
    /// <exception cref="NotSupportedKey{TValue, TKey}">Thrown when the key is not supported in the current node.</exception>
    bool Contains(TKey key);
}
