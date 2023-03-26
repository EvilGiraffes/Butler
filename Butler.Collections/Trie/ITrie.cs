namespace Butler.Collections.Trie;
/// <summary>
/// Represents a trie data structure.
/// </summary>
public interface ITrie : ICollection<string>, IReadOnlyCollection<string>
{
    /// <summary>
    /// Whether there is a value which starts with the given <paramref name="prefix"/>.
    /// </summary>
    /// <param name="prefix">The prefix to search for.</param>
    /// <returns><see langword="true"/> if there is something starting the <paramref name="prefix"/>, <see langword="false"/> if not.</returns>
    bool StartsWith(string prefix);
    /// <summary>
    /// Traverses the <see cref="ITrie"/> collection.
    /// </summary>
    /// <typeparam name="TResult">The value to be returned after the traversal has been completed.</typeparam>
    /// <param name="traversalStrategy">The strategy to perform the traversal on.</param>
    /// <returns>The value of the <paramref name="traversalStrategy"/>.</returns>
    TResult Traverse<TResult>(TrieTraversalStrategy<TResult> traversalStrategy);
}
