using System.Collections;
using System.Diagnostics;

using Butler.Collections.Trie.Errors;
using Butler.Collections.Trie.Node.Collections.Internals;

namespace Butler.Collections.Trie.Node.Collections;
// TESTME: Needs testing.
/// <summary>
/// Represents a <see cref="ITrieNodeCollection{TValue, TKey}"/> which only works with standard english alphabet.
/// </summary>
/// <typeparam name="TValue"><inheritdoc cref="ITrieNodeCollection{TValue, TKey}" path="/typeparam[@name='TValue']"/></typeparam>
public sealed class EnglishTrieNodeCollection<TValue> : ITrieNodeCollection<TValue, char>
{
    /// <inheritdoc/>
    public int Count { get; } = AlphabetLength;
    /// <summary>
    /// The upperbound of this collection.
    /// </summary>
    public char UpperBound
        => range.UpperBound;
    /// <summary>
    /// The lowerbound of this collection.
    /// </summary>
    public char LowerBound
        => range.LowerBound;
    readonly ITrieNode<TValue, char>?[] nodes;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    readonly Func<char, char> transform;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    readonly CharacterRange range;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    const int AlphabetLength = 26;
    EnglishTrieNodeCollection(ITrieNode<TValue, char>?[] nodes, Func<char, char> transform, CharacterRange range)
    {
        this.nodes = nodes;
        this.transform = transform;
        this.range = range;
    }
    /// <inheritdoc/>
    public ITrieNode<TValue, char> this[char key]
    {
        get => nodes[EnsureTransformAndGetIndex(key)]
            ?? throw new NodeNotFound();
        set => nodes[EnsureTransformAndGetIndex(key)] = value;
    }
    /// <inheritdoc/>
    public bool Contains(char key)
        => nodes[EnsureTransformAndGetIndex(key)] is not null;
    /// <inheritdoc/>
    public bool IsSupported(char key)
        => range.InRange(transform(key));
    /// <summary>
    /// Transforms the key based on this collections implementation.
    /// </summary>
    /// <param name="key">The key to transform.</param>
    /// <returns>The transformed <see cref="char"/>.</returns>
    public char Transform(char key)
        => transform(key);
    /// <inheritdoc/>
    public IEnumerator<ITrieNode<TValue, char>> GetEnumerator()
    {
        foreach (ITrieNode<TValue, char>? node in nodes)
            if (node is not null)
                yield return node;
    }
    /// <summary>
    /// Creates a new <see cref="EnglishTrieNodeCollection{TValue}"/> collections with uppercase values.
    /// </summary>
    /// <returns>A new <see cref="EnglishTrieNodeCollection{TValue}"/>.</returns>
    public static EnglishTrieNodeCollection<TValue> UpperCase()
    {
        CharacterRange range = new()
        {
            LowerBound = 'A',
            UpperBound = 'Z'
        };
        return Create(range, char.ToUpper);
    }
    /// <summary>
    /// Creates a new <see cref="EnglishTrieNodeCollection{TValue}"/> collection with lowercase values.
    /// </summary>
    /// <returns><inheritdoc cref="UpperCase" path="/returns"/></returns>
    public static EnglishTrieNodeCollection<TValue> LowerCase()
    {
        CharacterRange range = new()
        {
            LowerBound = 'a',
            UpperBound = 'z'
        };
        return Create(range, char.ToLower);
    }
    int GetIndex(char key)
        => key - LowerBound;
    char EnsureTransform(char key)
    {
        char transformed = transform(key);
        if (!range.InRange(transformed))
            throw new KeyOutOfRange<char>
            {
                AttemptedKey = key,
                Range = 0..(AlphabetLength - 1),
                Calculated = GetIndex(transformed)
            };
        return transformed;
    }
    int EnsureTransformAndGetIndex(char key)
        => GetIndex(EnsureTransform(key));
    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
    static void InitializeArrayToNull(ITrieNode<TValue, char>?[] array)
    {
        for (int i = 0; i < array.Length; i++)
            array[i] = null;
    }
    static EnglishTrieNodeCollection<TValue> Create(CharacterRange range, Func<char, char> transform)
    {
        ITrieNode<TValue, char>?[] nodes = new ITrieNode<TValue, char>?[AlphabetLength];
        InitializeArrayToNull(nodes);
        return new(nodes, transform, range);
    }
}
