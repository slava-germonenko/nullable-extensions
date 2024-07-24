using SG.NullableExtensions.Tests.Models;
using SG.NullableExtensions.ValueTasks;

namespace SG.NullableExtensions.Tests.ValueTasks;

public class ValueOrAsyncTests
{
    [Fact]
    public async ValueTask ValueOrAsync_Should_ReturnFallbackValueOnNullClass()
    {
        Counter? nullCounter = null;
        var counter = await nullCounter.ValueOrAsync(() => ValueTask.FromResult(new Counter
        {
            Count = 42,
        }));

        Assert.Null(nullCounter);
        Assert.Equal(42, counter.Count);
    }

    [Fact]
    public async ValueTask ValueOrAsync_Should_ReturnFallbackValueOnNullStruct()
    {
        StructCounter? nullCounter = null;
        var counter = await nullCounter.ValueOrAsync(() => ValueTask.FromResult(new StructCounter
        {
            Count = 42,
        }));

        Assert.Null(nullCounter);
        Assert.Equal(42, counter.Count);
    }

    [Fact]
    public async ValueTask ValueOrAsync_ShouldNot_ReturnFallbackValueOnNonNullClass()
    {
        var nullCounter = new Counter { Count = 11 };
        var counter = await nullCounter.ValueOrAsync(() => ValueTask.FromResult(new Counter
        {
            Count = 42,
        }));

        Assert.Equal(11, counter.Count);
    }

    [Fact]
    public async ValueTask ValueOrAsync_ShouldNot_ReturnFallbackValueOnNonNullStruct()
    {
        StructCounter? nullCounter = new StructCounter { Count = 11 };
        var counter = await nullCounter.ValueOrAsync(() => ValueTask.FromResult(new StructCounter
        {
            Count = 42,
        }));

        Assert.Equal(11, counter.Count);
    }
}