using FluentAssertions;

namespace MalawiMeta.Test;

public class SampleTest
{
    [Fact]
    public void Test_That_It_Works()
    {
        true.Should().BeTrue();
    }
}