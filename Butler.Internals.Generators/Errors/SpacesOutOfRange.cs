using System;

namespace Butler.Internals.Generators.Errors;
/// <summary>
/// Represents an <see cref="Exception"/> thrown whenever the spaces are not within valid range.
/// </summary>
public class SpacesOutOfRange : Exception
{
    /// <summary>
    /// The given spaces.
    /// </summary>
    public int Given { get; set; }
    /// <summary>
    /// The minimum amount of spaces.
    /// </summary>
    public int Minimum { get; set; }
    /// <summary>
    /// The maximum amount of spaces.
    /// </summary>
    public int Maximum { get; set; }
    /// <inheritdoc/>
    public SpacesOutOfRange()
    {
    }
    /// <inheritdoc/>
    public SpacesOutOfRange(string message) : base(message)
    {
    }
    /// <inheritdoc/>
    public SpacesOutOfRange(string message, Exception innerException) : base(message, innerException)
    {
    }
}
