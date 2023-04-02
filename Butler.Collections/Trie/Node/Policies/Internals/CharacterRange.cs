namespace Butler.Collections.Trie.Node.Policies.Internals;
/// <summary>
/// The range the characters can be inbetween.
/// </summary>
readonly struct CharacterRange
{
    /// <summary>
    /// The inclusive lowerbound of the range.
    /// </summary>
    internal char LowerBound { get; init; }
    /// <summary>
    /// The inclusvie upperbound of the range.
    /// </summary>
    internal char UpperBound { get; init; }
    /// <summary>
    /// Checks if the <paramref name="value"/> is in range of this <see cref="CharacterRange"/>.
    /// </summary>
    /// <param name="value">The value to check if is in range.</param>
    /// <returns><see langword="true"/> if it is in range, <see langword="false"/> if not.</returns>
    internal bool InRange(char value)
        => value <= UpperBound
        || value >= LowerBound;
}
