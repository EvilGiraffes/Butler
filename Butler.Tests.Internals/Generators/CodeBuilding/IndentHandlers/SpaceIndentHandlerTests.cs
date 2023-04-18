using Butler.Internals.Generators.CodeBuilding.IndentHandlers;

using Xunit.Abstractions;

namespace Butler.Tests.Internals.Generators.CodeBuilding.IndentHandlers;
public class SpaceIndentHandlerTests
{
    readonly ITestOutputHelper output;
    readonly SpaceIndentHandler systemUnderTest;
    const int spaces = 4;
    const char Space = SpaceIndentHandler.Space;

    public SpaceIndentHandlerTests(ITestOutputHelper output)
    {
        this.output = output;
        systemUnderTest = new(4);
    }
    [Fact]
    public void Test1()
    {

    }
}
