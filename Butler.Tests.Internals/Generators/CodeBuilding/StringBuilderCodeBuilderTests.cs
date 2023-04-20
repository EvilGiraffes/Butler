using System.Text;

using Butler.Internals.Generators.CodeBuilding;
using Butler.Internals.Generators.CodeBuilding.IndentHandlers;

namespace Butler.Tests.Internals.Generators.CodeBuilding;
public class StringBuilderCodeBuilderTests
{
    readonly Mock<IIndentHandler> indentHandler;
    readonly StringBuilder wrapped;
    readonly StringBuildedCodeBuilder systemUnderTest;
    public StringBuilderCodeBuilderTests()
    {
        indentHandler = new();
        wrapped = new();
        systemUnderTest = new(indentHandler.Object, wrapped);
    }
    [Fact]
    public void Count_String_LengthOfString()
    {
        string given = "this is the way";
        int expected = given.Length;
        wrapped.Append(given);
        systemUnderTest.Count.Should().Be(expected);
    }
}
