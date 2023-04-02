using Butler.Collections.Trie.Errors;
using Butler.Collections.Trie.Node.Policies.Internals;

namespace Butler.Collections.Trie.Node.Policies;
// TESTME: Needs testing.
/// <summary>
/// Represents a policy for ASCII characters.
/// </summary>
/// <typeparam name="TValue">The value the node will contain.</typeparam>
public sealed class AsciiPolicy<TValue> : ITrieNodePolicy<char>
{
    readonly CharacterRange range;
    readonly Func<char, char> transform;
    AsciiPolicy(CharacterRange range, Func<char, char> transform)
    {
        this.range = range;
        this.transform = transform;
    }
    /// <inheritdoc/>
    public int IndexFrom(char key)
    {
        if (!IsSupported(key))
            throw new NotSupportedKey<TValue, char>
            {
                AttemptedKey = key
            };
        return transform(key) - range.LowerBound;
    }
    /// <inheritdoc/>
    public bool IsSupported(char key)
        => range.InRange(transform(key));
    /// <summary>
    /// Creates an uppercase <see cref="AsciiPolicy{TValue}"/>.
    /// </summary>
    /// <returns>A new <see cref="AsciiPolicy{TValue}"/>.</returns>
    public static AsciiPolicy<TValue> UpperCase()
    {
        CharacterRange range = new()
        {
            LowerBound = 'A',
            UpperBound = 'Z'
        };
        return new(range, char.ToUpper);
    }
    /// <summary>
    /// Creates a lowercase <see cref="AsciiPolicy{TValue}"/>.
    /// </summary>
    /// <returns><inheritdoc cref="UpperCase" path="/returns"/></returns>
    public static AsciiPolicy<TValue> LowerCase()
    {
        CharacterRange range = new()
        {
            LowerBound = 'a',
            UpperBound = 'z'
        };
        return new(range, char.ToLower);
    }
}
