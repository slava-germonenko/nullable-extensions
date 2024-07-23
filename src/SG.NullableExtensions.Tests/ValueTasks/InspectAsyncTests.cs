using SG.NullableExtensions.Tests.Models;
using SG.NullableExtensions.ValueTasks;

namespace SG.NullableExtensions.Tests.ValueTasks;

public class InspectAsyncTests
{
    [Fact]
    public async ValueTask InspectAsync_Should_InspectAsynchronouslyNonNullClass()
    {
        var counter = new Counter();
        await counter.InspectAsync(c => c.IncrementAsync());
        Assert.NotEqual(default, counter.Count);
    }

    [Fact]
    public async ValueTask InspectAsync_Should_InspectAsynchronouslyNonNullStruct()
    {
        StructCounter? counter = new StructCounter();
        await counter.InspectAsync(c => c.IncrementAsync());
        Assert.NotEqual(default, counter.Value.Count);
    }

    [Fact]
    public async ValueTask InspectAsync_ShouldNot_InspectAsynchronouslyNullClass()
    {
        var externalCounter = 0;
        Counter? counter = null;

        await counter.InspectAsync(async c =>
        {
            externalCounter++;
            await c.IncrementAsync();
        });

        Assert.Null(counter);
        Assert.Equal(default, externalCounter);
    }

    [Fact]
    public async ValueTask InspectAsync_ShouldNot_InspectAsynchronouslyNullStruct()
    {
        var externalCounter = 0;
        StructCounter? counter = null;

        await counter.InspectAsync(async c =>
        {
            externalCounter++;
            await c.IncrementAsync();
        });

        Assert.Null(counter);
        Assert.Equal(default, externalCounter);
    }

    [Fact]
    public async ValueTask InspectAsync_Should_InspectTaskAsynchronouslyOnNonNullClass()
    {
        var counter = new Counter();
        var counterTask = ValueTask.FromResult<Counter?>(counter);
        await counterTask.InspectAsync(c => c.IncrementAsync());
        Assert.NotEqual(default, counter);
    }

    [Fact]
    public async ValueTask InspectAsync_Should_InspectTaskAsynchronouslyOnNonNullStruct()
    {
        var counter = new StructCounter();
        var counterTask = ValueTask.FromResult<StructCounter?>(counter);
        await counterTask.InspectAsync(c => c.IncrementAsync());
        Assert.NotEqual(default, counter);
    }
}