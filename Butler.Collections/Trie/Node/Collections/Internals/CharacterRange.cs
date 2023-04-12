namespace Butler.Collections.Trie.Node.Collections.Internals;
/// <summary>
/// Represents a range of <see cref="char"/>.
/// </summary>
readonly struct CharacterRange
{
    /// <summary>
    /// The lower most character.
    /// </summary>
    internal char LowerBound { get; init; }
    /// <summary>
    /// The uppermost character.
    /// </summary>
    internal char UpperBound { get; init; }
    /// <summary>
    /// Verifies if the <paramref name="value"/> is in the range of this <see cref="CharacterRange"/>.
    /// </summary>
    /// <param name="value">The value to check if is in range.</param>
    /// <returns><see langword="true"/> if it is in range, <see langword="false"/> if not.</returns>
    internal bool InRange(char value)
        => value >= LowerBound
        && value <= UpperBound;
}
