using SG.NullableExtensions.Tests.Models;

namespace SG.NullableExtensions.Tests;

public class IsTests
{
    [Theory]
    [InlineData(42, 42, true)]
    [InlineData(42, 322, false)]
    public void Is_Should_CallMethodOnNonNull(int expectedCount, int actualCount, bool output)
    {
        Counter counter = new() { Count = actualCount };
        Assert.Equal(output, counter.Is(c => c.Count == expectedCount));
    }

    [Theory]
    [InlineData(42, 42, true)]
    [InlineData(42, 322, false)]
    public void Is_Should_CallMethodOnNonNull_Struct(int expectedCount, int actualCount, bool output)
    {
        StructCounter? counter = new() { Count = actualCount };
        Assert.Equal(output, counter.Is(c => c.Count == expectedCount));
    }

    [Fact]
    public void Is_Should_ReturnFalseOnNull()
    {
        Counter? counter = null;
        Assert.False(counter.Is(_ => true));
    }

    [Fact]
    public void Is_Should_returnFalseNoNull_Struct()
    {
        StructCounter? counter = null;
        Assert.False(counter.Is(_ => true));
    }
}