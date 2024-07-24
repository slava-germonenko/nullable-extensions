using SG.NullableExtensions.Tests.Models;
using SG.NullableExtensions.ValueTasks;

namespace SG.NullableExtensions.Tests.ValueTasks;

public class WhenNullAsyncTests
{
    [Fact]
    public async ValueTask WhenNullAsync_Should_CallAsyncActionOnNullClass()
    {
        var externalCounter = 0;
        var increment = () =>
        {
            externalCounter++;
            return ValueTask.CompletedTask;
        };

        Counter? counter = null;

        await counter.WhenNullAsync(increment);
        Assert.NotEqual(default, externalCounter);
    }

    [Fact]
    public async ValueTask WhenNullAsync_Should_CallAsyncActionOnNullStruct()
    {
        var externalCounter = 0;
        var increment = () =>
        {
            externalCounter++;
            return ValueTask.CompletedTask;
        };

        StructCounter? counter = null;

        await counter.WhenNullAsync(increment);
        Assert.NotEqual(default, externalCounter);
    }

    [Fact]
    public async ValueTask WhenNullAsync_ShouldNot_CallAsyncActionOnNonNullClass()
    {
        var counter = new Counter();
        await counter.WhenNullAsync(() => counter.IncrementAsync());
        Assert.Equal(default, counter.Count);
    }

    [Fact]
    public async ValueTask WhenNullAsync_ShouldNot_CallAsyncActionOnNonNullStruct()
    {
        StructCounter? counter = new StructCounter();
        await counter.WhenNullAsync(() => counter.Value.IncrementAsync());
        Assert.Equal(default, counter.Value.Count);
    }
}