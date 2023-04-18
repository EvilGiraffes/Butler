namespace Butler.Internals.Generators.Tests.CountFormatters;

sealed class ProvidedFormatter : ICountFormatter
{
    readonly string format;
    public ProvidedFormatter(string format)
    {
        this.format = format;
    }
    public string GetFormatted(int count)
        => string.Format(format, count);
}
