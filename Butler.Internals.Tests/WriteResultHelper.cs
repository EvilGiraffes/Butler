using Xunit.Abstractions;

namespace Butler.Internals.Tests;
/// <summary>
/// Extentions for <see cref="ITestOutputHelper"/> to write results easier.
/// </summary>
public static class WriteResultHelper
{
    /// <summary>
    /// The format used by the result.
    /// </summary>
    /// <value>Default value is <c>"Expected: {0}{1}Actual: {2}"</c></value>
    public static string ResultFormat { get; set; } = "Expected: {0}{1}Actual: {2}";
    /// <summary>
    /// The default seperator for formatting.
    /// </summary>
    /// <value>Newline defined by the enviroment.</value>
    public static readonly string DefaultSeperator = Environment.NewLine;
    /// <summary>
    /// Writes the expectation result of <paramref name="expected"/> and <paramref name="actual"/>.
    /// </summary>
    /// <typeparam name="T">The that has been tested.</typeparam>
    /// <typeparam name="TSeperator">The seperator to use.</typeparam>
    /// <param name="output">Current instance of <see cref="ITestOutputHelper"/> being extended.</param>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual">The actual value.</param>
    /// <param name="seperator">The seperator to seperate them with.</param>
    public static void WriteResult<T, TSeperator>(this ITestOutputHelper output, T expected, T actual, TSeperator seperator)
    {
        string validSeperator = seperator?.ToString() ?? DefaultSeperator;
        string formattedOutput = string.Format(ResultFormat, expected, validSeperator, actual);
        output.WriteLine(formattedOutput);
    }
    /// <inheritdoc cref="WriteResult{T, TSeperator}(ITestOutputHelper, T, T, TSeperator)"/>
    public static void WriteResult<T>(this ITestOutputHelper output, T expected, T actual, string seperator)
        => WriteResult<T, string>(output, expected, actual, seperator);
    /// <inheritdoc cref="WriteResult{T, TSeperator}(ITestOutputHelper, T, T, TSeperator)"/>
    public static void WriteResult<T>(this ITestOutputHelper output, T expected, T actual)
        => WriteResult<T, string>(output, expected, actual, DefaultSeperator);
}
