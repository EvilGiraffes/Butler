namespace Butler.Internals.Generators.Tests.CountFormatters
{
    sealed class EnumeratedFormatter : ICountFormatter
    {
        readonly ICountFormatter wrapped;
        readonly int startIndex;
        readonly string seperator;
        public EnumeratedFormatter(ICountFormatter wrapped, int startIndex = 0, string seperator = ", ")
        {
            this.wrapped = wrapped;
            this.startIndex = startIndex;
            this.seperator = seperator;
        }
        public string GetFormatted(int count)
        {
            int length = count - startIndex + 1;
            string[] formatResult = new string[length];
            for (int i = 0; i < length; i++)
                formatResult[i] = wrapped.GetFormatted(i + startIndex);
            return string.Join(seperator, formatResult);
        }
    }
}
