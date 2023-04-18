using System.Text;

namespace Butler.Internals.Generators.CodeBuilding.IndentHandlers;
/// <summary>
/// Represents a handler to handle indents for code.
/// </summary>
public interface IIndentHandler
{
    /// <summary>
    /// Will indent the current <see cref="IIndentHandler"/> by one.
    /// </summary>
    void Indent();
    /// <summary>
    /// Will deindent the current <see cref="IIndentHandler"/> by one.
    /// </summary>
    void DeIndent();
    /// <summary>
    /// Appends the current indent to the <paramref name="builder"/>.
    /// </summary>
    /// <param name="builder">The builder to append to.</param>
    void AppendIndent(StringBuilder builder);
}
