namespace Butler.Collections.Trie.Errors;
/// <summary>
/// Represents a class where the character is invalid.
/// </summary>
public abstract class InvalidCharacterException : TrieNodeException
{
    /// <summary>
    /// The character that was attempted to use.
    /// </summary>
    public char AttemptedCharacter { get; init; }
    /// <inheritdoc/>
    public InvalidCharacterException()
    {
    }
    /// <inheritdoc/>
    public InvalidCharacterException(string message) : base(message)
    {
    }
    /// <inheritdoc/>
    public InvalidCharacterException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
