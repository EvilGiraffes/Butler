namespace Butler.Collections.Trie.Errors;
/// <summary>
/// Represents an exception when the node can not be found.
/// </summary>
public class NodeNotFound : InvalidCharacterException
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
