namespace Butler.Collections.Trie.Errors;
/// <summary>
/// Represents an exception when the node can not be found.
/// </summary>
/// <typeparam name="TValue"><inheritdoc cref="InvalidKeyException{TValue, TKey}" path="/typeparam[@name='TValue']"/></typeparam>
/// <typeparam name="TKey"><inheritdoc cref="InvalidKeyException{TKey, TValue}" path="/typeparam[@name='TKey']"/></typeparam>
public class NodeNotFound<TValue, TKey> : InvalidKeyException<TValue, TKey>
{
    /// <inheritdoc/>
    public NodeNotFound()
    {
    }
    /// <inheritdoc/>
    public NodeNotFound(string message) : base(message)
    {
    }
    /// <inheritdoc/>
    public NodeNotFound(string message, Exception innerException) : base(message, innerException)
    {
    }
}
