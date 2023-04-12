using System.Collections;

namespace Butler.Internals.Tests.DataHelper;
public abstract class Data : IEnumerable<object[]>
{
    protected abstract IDataBuilder Builder { get; }
    public IEnumerator<object[]> GetEnumerator()
        => Builder.GetData().GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}
