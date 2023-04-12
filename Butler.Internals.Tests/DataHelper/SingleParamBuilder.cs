using System.Collections;

namespace Butler.Internals.Tests.DataHelper;
public sealed class SingleParamBuilder : IDataBuilder, IEnumerable<object>
{
    readonly List<object> objects = new();
    public void Add(object obj)
        => objects.Add(obj);
    public IEnumerable<object[]> GetData()
        => objects.Select(obj => new object[] { obj });
    public IEnumerator<object> GetEnumerator()
        => objects.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}
