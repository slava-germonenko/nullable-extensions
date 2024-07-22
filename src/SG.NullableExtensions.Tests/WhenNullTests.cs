using SG.NullableExtensions.Tests.Models;

namespace SG.NullableExtensions.Tests;

public class WhenNullTests
{
    [Fact]
    public void WhenNull_ShouldNot_CallActionOnNonNull()
    {
        int outerCounter = 0;

        Counter counter = new() { Count = 0 };
        counter.WhenNull(() => outerCounter += 1);

        Assert.Equal(0, outerCounter);
    }

    [Fact]
    public void WhenNull_ShouldNot_CallActionOnNonNull_Struct()
    {
        int outerCounter = 0;
        StructCounter? counter = new() { Count = 0 };

        counter.WhenNull(() => outerCounter += 1);
        Assert.Equal(0, outerCounter);
    }

    [Fact]
    public void WhenNull_Should_CallActionOnNull()
    {
        int outerCounter = 0;

        Counter? counter = null;
        counter.WhenNull(() => outerCounter += 1);

        Assert.NotEqual(0, outerCounter);
    }

    [Fact]
    public void WhenNull_Should_CallActionOnNull_Struct()
    {
        int outerCounter = 0;

        StructCounter? counter = null;
        counter.WhenNull(() => outerCounter += 1);

        Assert.NotEqual(0, outerCounter);
    }
}