using System.Collections;

using Butler.Collections.Trie.Errors;
using Butler.Collections.Trie.Node.Policies;

namespace Butler.Collections.Trie.Node;
// TESTME: Needs testing.
/// <summary>
/// Represents a <see cref="IPoolableTrieNode{TValue, TKey}"/> where the node is handled by a <see cref="ITrieNodePolicy{TKey}"/>.
/// </summary>
/// <typeparam name="TValue"><inheritdoc cref="IPoolableTrieNode{TValue, TKey}" path="/typeparam[@name='TValue']"/></typeparam>
/// <typeparam name="TKey"><inheritdoc cref="IPoolableTrieNode{TValue, TKey}" path="/typeparam[@name='TValue']"/></typeparam>
public sealed class PoliciedTrieNode<TValue, TKey> : IPoolableTrieNode<TValue, TKey>
{
    /// <inheritdoc/>
    public TValue Value { get; set; }
    /// <inheritdoc/>
    public bool IsEndOfWord { get; set; }
    /// <inheritdoc/>
    public int Count { get; private set; }
    readonly ITrieNodePolicy<TKey> policy;
    readonly IList<ITrieNode<TValue, TKey>?> children;
    /// <summary>
    /// Constructs a new instance of <see cref="PoliciedTrieNode{TValue, TKey}"/>.
    /// </summary>
    /// <param name="value">The value this object should start with.</param>
    /// <param name="isEndOfWord">The state this object will start as.</param>
    /// <param name="policy">The policy this node will have defined.</param>
    /// <param name="children">The children contained in this node.</param>
    public PoliciedTrieNode(TValue value, bool isEndOfWord, ITrieNodePolicy<TKey> policy, IList<ITrieNode<TValue, TKey>?> children)
    {
        Value = value;
        IsEndOfWord = isEndOfWord;
        Count = 0;
        this.policy = policy;
        this.children = children;
    }
    // TODO: Find a better way to check the index range. Use Count property??
    /// <inheritdoc/>
    public ITrieNode<TValue, TKey> this[TKey key]
    {
        get
        {
            EnsureSupported(key);
            int index = GetIndex(key);
            return children[index] ?? throw new NodeNotFound<TValue, TKey>()
            {
                AttemptedKey = key
            };
        }
        set
        {
            EnsureSupported(key);
            SetChild(GetIndex(key), value);
        }
    }
    /// <summary>
    /// Removes a child from the collection.
    /// </summary>
    /// <param name="key">The key to remove.</param>
    /// <exception cref="InvalidKeyException{TValue, TKey}">Thrown when the key could not be calculated to the correct index.</exception>
    public void RemoveChild(TKey key)
    {
        EnsureSupported(key);
        SetChild(GetIndex(key), null);
    }
    /// <inheritdoc/>
    public bool Contains(TKey key)
        => children[GetIndex(key)] is not null;
    /// <inheritdoc/>
    public bool IsSupported(TKey key)
        => policy.IsSupported(key);
    /// <inheritdoc/>
    public void Activate(TValue value, bool isEndOfWord)
    {
        Value = value;
        IsEndOfWord = isEndOfWord;
    }
    /// <inheritdoc/>
    public void Deactivate()
    {
        children.Clear();
        Count = 0;
    }
    /// <inheritdoc/>
    public IEnumerator<ITrieNode<TValue, TKey>> GetEnumerator()
    {
        foreach (ITrieNode<TValue, TKey>? node in children)
        {
            if (node is null)
                continue;
            yield return node;
        }
    }
    int GetIndex(TKey key)
    {
        int index = policy.IndexFrom(key);
        if (index < 0 || index >= children.Count)
            throw new KeyOutOfRange<TValue, TKey>
            {
                AttemptedKey = key
            };
        return index;
    }
    void SetChild(int index, ITrieNode<TValue, TKey>? node)
    {
        ITrieNode<TValue, TKey>? previous = children[index];
        if (previous is null && node is null)
            return;
        children[index] = node;
        if (previous is null)
        {
            Count++;
            return;
        }
        Count--;
    }
    void EnsureSupported(TKey key)
    {
        if (IsSupported(key))
            return;
        throw new NotSupportedKey<TValue, TKey>
        {
            AttemptedKey = key
        };
    }
    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}
