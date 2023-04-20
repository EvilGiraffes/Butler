using System.Text;

using Butler.Internals.Generators.Errors;

namespace Butler.Internals.Generators.CodeBuilding.IndentHandlers;
/// <summary>
/// Represents a <see cref="IIndentHandler"/> which uses spaces to indent.
/// </summary>
public sealed class SpaceIndentHandler : IIndentHandler
{
    internal const char Space = ' ';
    int depth;
    readonly int spaces;
    /// <summary>
    /// Constructs a new <see cref="SpaceIndentHandler"/> with <paramref name="spaces"/> amount of spaces per indent.
    /// </summary>
    /// <param name="spaces">The spaces to use for indent. Must be more than 0.</param>
    /// <exception cref="SpacesOutOfRange">Thrown if the spaces are 0 or less.</exception>
    public SpaceIndentHandler(int spaces)
    {
        if (spaces < 1)
            throw new SpacesOutOfRange()
            {
                Given = spaces,
                Minimum = 1,
                Maximum = int.MaxValue
            };
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
        if (depth < 1)
            return;
        int count = spaces * depth;
        builder.Append(Space, count);
    }
}
