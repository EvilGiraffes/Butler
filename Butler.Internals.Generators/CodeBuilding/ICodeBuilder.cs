using System;
using System.Collections.Generic;

namespace Butler.Internals.Generators.CodeBuilding;
/// <summary>
/// Represents a code builder for generators.
/// </summary>
public interface ICodeBuilder
{
    /// <summary>
    /// Gets the current count of objects in the builder.
    /// </summary>
    int Count { get; }
    /// <summary>
    /// Gets or sets the <see cref="char"/> based on the give <paramref name="index"/>.
    /// </summary>
    /// <param name="index">The index in which to replace the value.</param>
    /// <returns>The <see cref="char"/> at the given <paramref name="index"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the index doesnt correspond to the current builder.</exception>
    char this[int index] { get; set; }
    /// <summary>
    /// Appends <paramref name="text"/> to the builder.
    /// </summary>
    /// <param name="text">The text to append to the builder.</param>
    /// <returns>The current instance of <see cref="ICodeBuilder"/>.</returns>
    ICodeBuilder Append(string text);
    /// <summary>
    /// Appends <paramref name="value"/> to the builder.
    /// </summary>
    /// <typeparam name="T">The type which should be appended.</typeparam>
    /// <param name="value">The <typeparamref name="T"/> to append to the builder.</param>
    /// <returns><inheritdoc cref="Append(string)" path="/returns"/></returns>
    ICodeBuilder Append<T>(T value);
    /// <summary>
    /// Appends the <paramref name="value"/> by the specified amount.
    /// </summary>
    /// <param name="value">The value to append x amount.</param>
    /// <param name="count">The amount of times to append it.</param>
    /// <returns><inheritdoc cref="Append(string)" path="/returns"/></returns>
    ICodeBuilder Append(char value, int count);
    /// <summary>
    /// Formats using the format <paramref name="format"/> with the object <paramref name="value"/> and appends to the builder.
    /// </summary>
    /// <param name="format">The format which should be used.</param>
    /// <param name="value">The value to format into the <paramref name="format"/></param>
    /// <returns><inheritdoc cref="Append(string)" path="/returns"/></returns>
    ICodeBuilder AppendFormat(string format, object value);
    /// <summary>
    /// Formats using the format <paramref name="format"/> with the objects <paramref name="values"/> and appends to the builder.
    /// </summary>
    /// <param name="format"><inheritdoc cref="AppendFormat(string, object)" path="/param[@name='format']"/></param>
    /// <param name="values">The values to format into the <paramref name="format"/></param>
    /// <returns><inheritdoc cref="Append(string)" path="/returns"/></returns>
    ICodeBuilder AppendFormat(string format, params object[] values);
    /// <summary>
    /// <para><inheritdoc cref="AppendFormat(string, object)" path="/summary"/></para>
    /// <para>Uses the <paramref name="provider"/> to format.</para>
    /// </summary>
    /// <param name="provider">The format provider to format according to.</param>
    /// <param name="format"><inheritdoc cref="AppendFormat(string, object)" path="/param[@name='format']"/></param>
    /// <param name="value"><inheritdoc cref="AppendFormat(string, object)" path="/param[@name='value']"/></param>
    /// <returns><inheritdoc cref="Append(string)" path="/returns"/></returns>
    ICodeBuilder AppendFormat(IFormatProvider? provider, string format, object value);
    /// <summary>
    /// <para><inheritdoc cref="AppendFormat(string, object[])" path="/summary"/></para>
    /// <para>Uses the <paramref name="provider"/> to format.</para>
    /// </summary>
    /// <param name="provider"><inheritdoc cref="AppendFormat(IFormatProvider?, string, object)" path="/param[@name='provider']"/></param>
    /// <param name="format"><inheritdoc cref="AppendFormat(string, object[])" path="/param[@name='format']"/></param>
    /// <param name="values"><inheritdoc cref="AppendFormat(string, object[])" path="/param[@name='values']"/></param>
    /// <returns><inheritdoc cref="Append(string)" path="/returns"/></returns>
    ICodeBuilder AppendFormat(IFormatProvider? provider, string format, params object[] values);
    /// <summary>
    /// Joins the list to the builder using <paramref name="seperator"/>
    /// </summary>
    /// <typeparam name="T">The type used in the <see cref="IEnumerable{T}"/>.</typeparam>
    /// <param name="seperator">The seperator to use between each value in the given <see cref="IEnumerable{T}"/>.</param>
    /// <param name="values">The values to append using a seperator.</param>
    /// <returns><inheritdoc cref="Append(string)" path="/returns"/></returns>
    ICodeBuilder AppendJoin<T>(char seperator, IEnumerable<T> values);
    /// <inheritdoc cref="AppendJoin{T}(char, IEnumerable{T})"/>
    ICodeBuilder AppendJoin<T>(string seperator, IEnumerable<T> values);
    /// <summary>
    /// Appends a new line character.
    /// </summary>
    /// <returns><inheritdoc cref="Append(string)" path="/returns"/></returns>
    ICodeBuilder AppendLine();
    /// <summary>
    /// Appends the <paramref name="text"/> and adds a new line character afterwards.
    /// </summary>
    /// <param name="text"><inheritdoc cref="Append(string)" path="/param[@name='text']"/></param>
    /// <returns><inheritdoc cref="Append(string)" path="/returns"/></returns>
    ICodeBuilder AppendLine(string text);
    /// <summary>
    /// Appends the <paramref name="value"/> object and adds a new line character afterwards.
    /// </summary>
    /// <typeparam name="T"><inheritdoc cref="Append{T}(T)" path="/typeparam"/></typeparam>
    /// <param name="value">The <typeparamref name="T"/> to be appended.</param>
    /// <returns><inheritdoc cref="Append(string)" path="/returns"/></returns>
    ICodeBuilder AppendLine<T>(T value);
    /// <summary>
    /// Inserts <paramref name="value"/> at the given <paramref name="index"/>.
    /// </summary>
    /// <typeparam name="T">The type which should be inserted.</typeparam>
    /// <param name="index">The index of the builder where it should be inserted.</param>
    /// <param name="value">The value to insert at the given <paramref name="index"/>.</param>
    /// <returns><inheritdoc cref="Append(string)" path="/returns"/></returns>
    ICodeBuilder Insert<T>(int index, T value);
    /// <summary>
    /// Removes a section of the length of <paramref name="length"/> starting at <paramref name="startIndex"/>.
    /// </summary>
    /// <param name="startIndex">The index to start the removal.</param>
    /// <param name="length">The length to remove.</param>
    /// <returns></returns>
    ICodeBuilder Remove(int startIndex, int length);
    /// <summary>
    /// Indents the builder once.
    /// </summary>
    /// <returns><inheritdoc cref="Append(string)" path="/returns"/></returns>
    ICodeBuilder Indent();
    /// <summary>
    /// Deindents the builder once.
    /// </summary>
    /// <returns><inheritdoc cref="Append(string)" path="/returns"/></returns>
    ICodeBuilder DeIndent();
    /// <summary>
    /// Clears the entire builder of content.
    /// </summary>
    void Clear();
}
