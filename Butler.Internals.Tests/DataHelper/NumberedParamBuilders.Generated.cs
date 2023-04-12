// This is a generated file.
// Do not edit as it will be overwritten.

using System.Collections;
namespace Butler.Internals.Tests.DataHelper;

// Generated Class.
public sealed class TwoParamBuilder : IDataBuilder, IEnumerable<object[]>
{
	readonly List<object[]> objects = new();
	public void Add(object obj1, object obj2, object obj3)
		=> objects.Add(new object[] { obj1, obj2, obj3 });
	public IEnumerable<object[]> GetData()
		=> objects;
	public IEnumerator<object[]> GetEnumerator()
		=> objects.GetEnumerator();
	IEnumerator IEnumerable.GetEnumerator()
		=> GetEnumerator();
}

// Generated Class.
public sealed class ThreeParamBuilder : IDataBuilder, IEnumerable<object[]>
{
	readonly List<object[]> objects = new();
	public void Add(object obj1, object obj2, object obj3, object obj4)
		=> objects.Add(new object[] { obj1, obj2, obj3, obj4 });
	public IEnumerable<object[]> GetData()
		=> objects;
	public IEnumerator<object[]> GetEnumerator()
		=> objects.GetEnumerator();
	IEnumerator IEnumerable.GetEnumerator()
		=> GetEnumerator();
}

// Generated Class.
public sealed class FourParamBuilder : IDataBuilder, IEnumerable<object[]>
{
	readonly List<object[]> objects = new();
	public void Add(object obj1, object obj2, object obj3, object obj4, object obj5)
		=> objects.Add(new object[] { obj1, obj2, obj3, obj4, obj5 });
	public IEnumerable<object[]> GetData()
		=> objects;
	public IEnumerator<object[]> GetEnumerator()
		=> objects.GetEnumerator();
	IEnumerator IEnumerable.GetEnumerator()
		=> GetEnumerator();
}

// Generated Class.
public sealed class FiveParamBuilder : IDataBuilder, IEnumerable<object[]>
{
	readonly List<object[]> objects = new();
	public void Add(object obj1, object obj2, object obj3, object obj4, object obj5, object obj6)
		=> objects.Add(new object[] { obj1, obj2, obj3, obj4, obj5, obj6 });
	public IEnumerable<object[]> GetData()
		=> objects;
	public IEnumerator<object[]> GetEnumerator()
		=> objects.GetEnumerator();
	IEnumerator IEnumerable.GetEnumerator()
		=> GetEnumerator();
}
