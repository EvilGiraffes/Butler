namespace Butler.Collections.Trie.Errors;
/// <summary>
/// Thrown when the character is not supported.
/// </summary>
public class NotSupportedCharacter : InvalidCharacterException
{
    /// <summary>
    /// The characters that is valid for this <see cref="ITrieNode"/>.
    /// </summary>
    public IEnumerable<char> ValidCharacters { get; init; } = Enumerable.Empty<char>();
    /// <inheritdoc/>
    public NotSupportedCharacter()
    {
    }
    /// <inheritdoc/>
    public NotSupportedCharacter(string message) : base(message)
    {
    }
    /// <inheritdoc/>
    public NotSupportedCharacter(string message, Exception innerException) : base(message, innerException)
    {
    }
}
