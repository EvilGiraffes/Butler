using System.Text;

using Butler.Internals.Generators.CodeBuilding.IndentHandlers;
using Butler.Internals.Generators.Errors;

namespace Butler.Tests.Internals.Generators.CodeBuilding.IndentHandlers;
public class SpaceIndentHandlerTests
{
    readonly SpaceIndentHandler systemUnderTest;
    const int Spaces = 4;
    const char Space = SpaceIndentHandler.Space;
    const int MaxIterations = 100000;
    static int NumberGeneration
        => 5;
    public SpaceIndentHandlerTests()
    {
        systemUnderTest = new(Spaces);
    }
    [Fact]
    public void Ctor_SpaceAboveZero_NoException()
    {
        Action act = () => _ = new SpaceIndentHandler(1);
        act.Should().NotThrow<SpacesOutOfRange>();
    }
    [Fact]
    public void Ctor_SpaceBelowOne_Exception()
    {
        Action act = () => _ = new SpaceIndentHandler(0);
        act.Should().Throw<SpacesOutOfRange>();
    }
    [Fact]
    public void AppendIndent_NoIndent_UnIndentedString()
    {
        string expected = "Hello World!";
        StringBuilder builder = new();
        systemUnderTest.AppendIndent(builder);
        builder.Append(expected);
        string actual = builder.ToString();
        actual.Should().Be(expected);
    }
    [Theory]
    [MemberData(nameof(GenerateNumber))]
    public void AppendIndent_Indented_Indented(int indents)
    {
        string lastValue = "bababababbab";
        string expected = new string(Space, Spaces * indents) + lastValue;
        StringBuilder builder = new();
        for (int i = 0; i < indents; i++)
            systemUnderTest.Indent();
        systemUnderTest.AppendIndent(builder);
        builder.Append(lastValue);
        string actual = builder.ToString();
        actual.Should().Be(expected);
    }
    [Theory]
    [MemberData(nameof(GenerateNumber))]
    public void AppendIndent_DeIndentIndented_OneIndent(int indents)
    {
        string lastValue = "bibibibibababa";
        string expected = new string(Space, Spaces) + lastValue;
        StringBuilder builder = new();
        int count = indents + 1;
        for (int i = 0; i < count; i++)
            systemUnderTest.Indent();
        for (int i = 0; i < indents; i++)
            systemUnderTest.DeIndent();
        systemUnderTest.AppendIndent(builder);
        builder.Append(lastValue);
        string actual = builder.ToString();
        actual.Should().Be(expected);
    }
    [Fact]
    public void IndentingPropertyTest()
    {
        string expected = "paisley my beloved";
        Random randomizer = Random.Shared;
        StringBuilder builder = new();
        for (int i = 0; i < randomizer.Next(1, MaxIterations); i++)
        {
            systemUnderTest.Indent();
            systemUnderTest.DeIndent();
        }
        systemUnderTest.AppendIndent(builder);
        builder.Append(expected);
        string actual = builder.ToString();
        actual.Should().Be(expected);
    }
    public static IEnumerable<object[]> GenerateNumber()
    {
        for (int i = 1; i <= NumberGeneration; i++)
            yield return new object[] { i };
    }
}
