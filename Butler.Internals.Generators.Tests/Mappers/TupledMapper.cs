using System.Collections.Generic;

namespace Butler.Internals.Generators.Tests.Mappers
{
    sealed class TupledMapper : IStringMapper<int>
    {
        public int Start { get; } = 2;
        public int End
            => Start + map.Count - 1;
        static readonly Dictionary<int, string> map = new Dictionary<int, string>
        {
            { 2, "Double" },
            { 3, "Tripple" },
            { 4, "Quadruple" },
            { 5, "Quintuple" }
        };
        public string this[int key]
            => map[key];

    }
}
