namespace Butler.Collections.Matrix;
// TODO: Finish.
// TODO: Implement concrete.
/// <summary>
/// Represents a definition of a basic matrix.
/// </summary>
/// <typeparam name="T">The type stored in the matrix.</typeparam>
public interface IMatrix<T> : IList<T>, IReadOnlyList<T>
{
    /// <summary>
    /// Transforms every item in the <see cref="IMatrix{T}"/>.
    /// </summary>
    /// <param name="transform">The transformation to perform.</param>
    void Transform(Func<T, T> transform);
}
