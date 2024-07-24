using SG.NullableExtensions.Tests.Models;
using SG.NullableExtensions.Tasks;

namespace SG.NullableExtensions.Tests.Tasks;

public class ValueOrAsyncTests
{
    [Fact]
    public async Task ValueOrAsync_Should_ReturnFallbackValueOnNullClass()
    {
        Counter? nullCounter = null;
        var counter = await nullCounter.ValueOrAsync(() => Task.FromResult(new Counter
        {
            Count = 42,
        }));

        Assert.Null(nullCounter);
        Assert.Equal(42, counter.Count);
    }

    [Fact]
    public async Task ValueOrAsync_Should_ReturnFallbackValueOnNullStruct()
    {
        StructCounter? nullCounter = null;
        var counter = await nullCounter.ValueOrAsync(() => Task.FromResult(new StructCounter
        {
            Count = 42,
        }));

        Assert.Null(nullCounter);
        Assert.Equal(42, counter.Count);
    }

    [Fact]
    public async Task ValueOrAsync_ShouldNot_ReturnFallbackValueOnNonNullClass()
    {
        var nullCounter = new Counter { Count = 11 };
        var counter = await nullCounter.ValueOrAsync(() => Task.FromResult(new Counter
        {
            Count = 42,
        }));

        Assert.Equal(11, counter.Count);
    }

    [Fact]
    public async Task ValueOrAsync_ShouldNot_ReturnFallbackValueOnNonNullStruct()
    {
        StructCounter? nullCounter = new StructCounter { Count = 11 };
        var counter = await nullCounter.ValueOrAsync(() => Task.FromResult(new StructCounter
        {
            Count = 42,
        }));

        Assert.Equal(11, counter.Count);
    }

    [Fact]
    public async Task ValueOrAsync_Should_ReturnFallbackValueWhenTaskOutputIsNullClass()
    {
        var counterTask = Task.FromResult<Counter?>(null);
        var counter = await counterTask.ValueOrAsync(new Counter { Count = 42 });

        Assert.Equal(42, counter.Count);
    }

    [Fact]
    public async Task ValueOrAsync_Should_ReturnFallbackValueWhenTaskOutputIsNullStruct()
    {
        var counterTask = Task.FromResult<StructCounter?>(null);
        var counter = await counterTask.ValueOrAsync(new StructCounter { Count = 42 });

        Assert.Equal(42, counter.Count);
    }

    [Fact]
    public async Task ValueOrAsync_ShouldNot_ReturnFallbackValueWhenTaskOutputIsNonNullClass()
    {
        var counterTask = Task.FromResult<Counter?>(new Counter{ Count = 11 });
        var counter = await counterTask.ValueOrAsync(new Counter { Count = 42 });

        Assert.Equal(11, counter.Count);
    }

    [Fact]
    public async Task ValueOrAsync_ShouldNot_ReturnFallbackValueWhenTaskOutputIsNonNullStruct()
    {
        var counterTask = Task.FromResult<StructCounter?>(new StructCounter{ Count = 11 });
        var counter = await counterTask.ValueOrAsync(new StructCounter { Count = 42 });

        Assert.Equal(11, counter.Count);
    }
}