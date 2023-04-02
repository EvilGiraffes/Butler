
using Xunit.Abstractions;

namespace Butler.Internals.Tests;
/// <summary>
/// Represents extentions for <see cref="ITestOutputHelper"/> where the values is boolean.
/// </summary>
public static class WriteBooleanHelper
{
    /// <summary>
    /// Writes the result with the expected being <see langword="true"/>.
    /// </summary>
    /// <typeparam name="TSeperator"><inheritdoc cref="WriteResultHelper.WriteResult{T, TSeperator}(ITestOutputHelper, T, T, TSeperator)" path="/typeparam"/></typeparam>
    /// <param name="output"><inheritdoc cref="WriteResultHelper.WriteResult{T, TSeperator}(ITestOutputHelper, T, T, TSeperator)" path="/param[@name='output']"/></param>
    /// <param name="actual"><inheritdoc cref="WriteResultHelper.WriteResult{T, TSeperator}(ITestOutputHelper, T, T, TSeperator)" path="/param[@name='actual']"/></param>
    /// <param name="seperator"><inheritdoc cref="WriteResultHelper.WriteResult{T, TSeperator}(ITestOutputHelper, T, T, TSeperator)" path="/param[@name='seperator']"/></param>
    public static void WriteExpectedTrue<TSeperator>(this ITestOutputHelper output, bool actual, TSeperator seperator)
        => WriteResultHelper.WriteResult(output, true, actual, seperator);
    /// <inheritdoc cref="WriteExpectedTrue{TSeperator}(ITestOutputHelper, bool, TSeperator)"/>
    public static void WriteExpectedTrue(this ITestOutputHelper output, bool actual, string seperator)
        => WriteExpectedTrue<string>(output, actual, seperator);
    public static void WriteExpectedTrue(this ITestOutputHelper output, bool actual)
        => WriteExpectedTrue(output, actual, WriteResultHelper.DefaultSeperator);
}
