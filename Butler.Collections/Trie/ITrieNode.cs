using Butler.Collections.Trie.Errors;

namespace Butler.Collections.Trie;
/// <summary>
/// Represents a node used in a <see cref="ITrie"/>.
/// </summary>
/// <seealso cref="ITrie"/>
public interface ITrieNode
{
    /// <summary>
    /// The value stored in this node.
    /// </summary>
    char Value { get; set; }
    /// <summary>
    /// Whether this node is an end of a word.
    /// </summary>
    bool IsEndOfWord { get; set; }
    /// <summary>
    /// Gets the next node given the character.
    /// </summary>
    /// <param name="character">The character node to get</param>
    /// <returns><see cref="ITrieNode"/> child with the <paramref name="character"/> as the value.</returns>
    /// <inheritdoc cref="Value" path="/exception"/>
    /// <exception cref="NodeNotFound">Thrown if the node is not found.</exception>
    ITrieNode this[char character] { get; }
    /// <summary>
    /// Checks if the current node has a definition of this character.
    /// </summary>
    /// <param name="character">The character to check.</param>
    /// <returns><see langword="true"/> if it is found in the current node, <see langword="false"/> if it is not.</returns>
    /// <inheritdoc cref="Value" path="/exception"/>
    bool Contains(char character);
    /// <summary>
    /// Determins if the <paramref name="character"/> is supported by this node.
    /// </summary>
    /// <param name="character">The character to check.</param>
    /// <returns><see langword="true"/> if it is supported, <see langword="false"/> if it is not supported.</returns>
    bool IsSupported(char character);
    /// <summary>
    /// Adds a new child to the current node.
    /// </summary>
    /// <param name="character">The new child to add.</param>
    /// <inheritdoc cref="Value" path="/exception"/>
    void Add(char character);
    /// <summary>
    /// Removes the given child.
    /// </summary>
    /// <param name="character">The child to remove.</param>
    /// <returns><see langword="true"/> if it was able to remove the value, <see langword="false"/> if it could not remove the value.</returns>
    /// <inheritdoc cref="Value" path="/exception"/>
    bool Remove(char character);
}
