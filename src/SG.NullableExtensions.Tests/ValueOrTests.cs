using SG.NullableExtensions.Tests.Models;

namespace SG.NullableExtensions.Tests;

public class ValueOrTests
{
    [Fact]
    public void ValueOr_Should_ReturnFallbackValue()
    {
        Counter? counter = null;
        Counter fallback = new Counter { Count = 42 };

        var value = counter.ValueOr(fallback);
        Assert.Equal(fallback, value);
    }

    [Fact]
    public void ValueOr_Should_ReturnFallbackValue_Struct()
    {
        StructCounter? counter = null;
        StructCounter fallback = new StructCounter { Count = 42 };

        var value = counter.ValueOr(fallback);
        Assert.Equal(fallback.Count, value.Count);
    }

    [Fact]
    public void ValueOr_Should_ReturnOutputOfFallbackFactory()
    {
        Counter? counter = null;
        Counter fallback = new Counter { Count = 42 };

        var value = counter.ValueOr(() => fallback);
        Assert.Equal(fallback, value);
    }

    [Fact]
    public void ValueOr_Should_ReturnOutputOfFallbackFactory_Struct()
    {
        StructCounter? counter = null;
        StructCounter fallback = new StructCounter { Count = 42 };

        var value = counter.ValueOr(() => fallback);
        Assert.Equal(fallback.Count, value.Count);
    }
}