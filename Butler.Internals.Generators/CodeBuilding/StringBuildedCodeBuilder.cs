using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

using Butler.Internals.Generators.CodeBuilding.IndentHandlers;

namespace Butler.Internals.Generators.CodeBuilding;
// TESTME: Needs testing.
/// <summary>
/// Represents a <see cref="ICodeBuilder"/> using <see cref="StringBuilder"/> for the internal workings.
/// </summary>
public sealed class StringBuildedCodeBuilder : ICodeBuilder
{
    /// <inheritdoc/>
    public int Count
        => builder.Length;
    readonly IIndentHandler indentHandler;
    readonly StringBuilder builder;
    /// <summary>
    /// Constructs a new isntance of a <see cref="StringBuildedCodeBuilder"/>.
    /// </summary>
    /// <param name="indentHandler">The handler to how indents are processed.</param>
    public StringBuildedCodeBuilder(IIndentHandler indentHandler) : this(indentHandler, new())
    {
    }
    /// <summary>
    /// <inheritdoc cref="StringBuildedCodeBuilder(IIndentHandler)" path="/summary"/>
    /// </summary>
    /// <param name="indentHandler"><inheritdoc cref="StringBuildedCodeBuilder(IIndentHandler)" path="/param[@name='indentHandler']"/></param>
    /// <param name="builder">The <see cref="StringBuilder"/> used by this <see cref="ICodeBuilder"/>.</param>
    public StringBuildedCodeBuilder(IIndentHandler indentHandler, StringBuilder builder)
    {
        this.indentHandler = indentHandler;
        this.builder = builder;
    }
    /// <inheritdoc/>
    public char this[int index]
    {
        get => builder[index];
        set => builder[index] = value;
    }
    /// <inheritdoc/>
    public ICodeBuilder Append(string text)
    {
        if (string.IsNullOrEmpty(text))
            return this;
        indentHandler.AppendIndent(builder);
        builder.Append(text);
        return this;
    }
    /// <inheritdoc/>
    public ICodeBuilder Append<T>(T value)
    {
        if (value is null)
            return this;
        indentHandler.AppendIndent(builder);
        builder.Append(value);
        return this;
    }
    /// <inheritdoc/>
    public ICodeBuilder Append(char value, int count)
    {
        if (count < 1)
            return this;
        indentHandler.AppendIndent(builder);
        builder.Append(value, count);
        return this;
    }
    /// <inheritdoc/>
    public ICodeBuilder AppendFormat(string format, object value)
        => AppendFormat(null, format, value);
    /// <inheritdoc/>
    public ICodeBuilder AppendFormat(IFormatProvider? provider, string format, object value)
    {
        if (string.IsNullOrEmpty(format) ||
            value is null)
            return this;
        IFormatProvider ensuredProvider = EnsureFormatProvider(provider);
        indentHandler.AppendIndent(builder);
        builder.AppendFormat(ensuredProvider, format, value);
        return this;
    }
    /// <inheritdoc/>
    public ICodeBuilder AppendFormat(string format, params object[] values)
        => AppendFormat(null, format, values);
    /// <inheritdoc/>
    public ICodeBuilder AppendFormat(IFormatProvider? provider, string format, params object[] values)
    {
        if (string.IsNullOrEmpty(format) ||
            values.Length < 1)
            return this;
        IFormatProvider ensuredProvider = EnsureFormatProvider(provider);
        indentHandler.AppendIndent(builder);
        builder.AppendFormat(ensuredProvider, format, values);
        return this;
    }
    /// <inheritdoc/>
    public ICodeBuilder AppendJoin<T>(char seperator, IEnumerable<T> values)
        => AppendJoin(seperator.ToString(), values);
    /// <inheritdoc/>
    public ICodeBuilder AppendJoin<T>(string seperator, IEnumerable<T> values)
    {
        string toAppend = string.Join(seperator, values);
        indentHandler.AppendIndent(builder);
        builder.Append(toAppend);
        return this;
    }
    /// <inheritdoc/>
    public ICodeBuilder AppendLine()
    {
        builder.AppendLine();
        return this;
    }
    /// <inheritdoc/>
    public ICodeBuilder AppendLine(string text)
    {
        if (string.IsNullOrEmpty(text))
            return AppendLine();
        indentHandler.AppendIndent(builder);
        builder.AppendLine(text);
        return this;
    }
    /// <inheritdoc/>
    public ICodeBuilder AppendLine<T>(T value)
    {
        string? valueString = value?.ToString();
        if (string.IsNullOrEmpty(valueString))
            return AppendLine();
        indentHandler.AppendIndent(builder);
        builder.AppendLine(valueString);
        return this;
    }
    /// <inheritdoc/>
    public ICodeBuilder Insert<T>(int index, T value)
    {
        builder.Insert(index, value);
        return this;
    }
    /// <inheritdoc/>
    public ICodeBuilder Remove(int startIndex, int length)
    {
        builder.Remove(startIndex, length);
        return this;
    }
    /// <inheritdoc/>
    public ICodeBuilder DeIndent()
    {
        indentHandler.Indent();
        return this;
    }
    /// <inheritdoc/>
    public ICodeBuilder Indent()
    {
        indentHandler.DeIndent();
        return this;
    }
    /// <inheritdoc/>
    public void Clear()
        => builder.Clear();
    IFormatProvider EnsureFormatProvider(IFormatProvider? provider)
    {
        if (provider is not null)
            return provider;
        return CultureInfo.CurrentCulture;
    }
}
