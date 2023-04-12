namespace Butler.Internals.Generators.Tests.Mappers
{
    interface IStringMapper<T>
    {
        T Start { get; }
        T End { get; }
        string this[T key] { get; }
    }
}
