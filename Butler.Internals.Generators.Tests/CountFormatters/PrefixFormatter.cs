namespace Butler.Internals.Generators.Tests.CountFormatters
{
    class PrefixFormatter : ICountFormatter
    {
        readonly ICountFormatter wrapped;
        readonly string prefix;
        public PrefixFormatter(ICountFormatter wrapped, string prefix)
        {
            this.wrapped = wrapped;
            this.prefix = prefix;
        }
        public string GetFormatted(int count)
            => prefix + wrapped.GetFormatted(count);
    }
}
