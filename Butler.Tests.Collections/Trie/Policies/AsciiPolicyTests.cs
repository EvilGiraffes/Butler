using Butler.Collections.Trie.Node.Policies;
using Butler.Internals.Tests;

namespace Butler.Tests.Collections.Trie.Policies;
public class AsciiPolicyTests
{
    readonly ITestOutputHelper output;
    public AsciiPolicyTests(ITestOutputHelper output)
    {
        this.output = output;
    }
    [Fact]
    public void UppercaseIsSupported_LowerBound_True()
    {
        AsciiPolicy<char> policy = AsciiPolicy<char>.UpperCase();
        char lowerBound = 'A';
        bool actual = policy.IsSupported(lowerBound);
        output.WriteExpectedTrue(actual);
        actual.Should().BeTrue();
    }
}
