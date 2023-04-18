using System.Text;

namespace Butler.Internals.Generators.CodeBuilding.IndentHandlers;
// TESTME: Needs testing.
/// <summary>
/// Represents a <see cref="IIndentHandler"/> which uses spaces to indent.
/// </summary>
public sealed class SpaceIndentHandler : IIndentHandler
{
    readonly int spaces;
    int depth;
    internal const char Space = ' ';
    /// <summary>
    /// Constructs a new <see cref="SpaceIndentHandler"/> with <paramref name="spaces"/> amount of spaces per indent.
    /// </summary>
    /// <param name="spaces">The spaces to use for indent.</param>
    public SpaceIndentHandler(int spaces)
    {
        this.spaces = spaces;
    }
    /// <inheritdoc/>
    public void Indent()
        => depth++;
    /// <inheritdoc/>
    public void DeIndent()
    {
        if (depth < 1)
            return;
        depth--;
    }
    /// <inheritdoc/>
    public void AppendIndent(StringBuilder builder)
    {
        int count = spaces * depth;
        string indent = new(Space, count);
        builder.Append(indent);
    }
}
