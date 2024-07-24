using SG.NullableExtensions.Tests.Models;
using SG.NullableExtensions.Tasks;

namespace SG.NullableExtensions.Tests.Tasks;

public class InspectAsyncTests
{
    [Fact]
    public async Task InspectAsync_Should_InspectAsynchronouslyNonNullClass()
    {
        var counter = new Counter();
        await counter.InspectAsync(c =>
        {
            c.Count++;
            return Task.CompletedTask;
        });
        Assert.NotEqual(default, counter.Count);
    }

    [Fact]
    public async Task InspectAsync_Should_InspectAsynchronouslyNonNullStruct()
    {
        var touched = false;
        StructCounter? counter = new StructCounter();

        await counter.InspectAsync((StructCounter _) =>
        {
            touched = true;
            return Task.CompletedTask;
        });

        Assert.True(touched);
    }

    [Fact]
    public async Task InspectAsync_ShouldNot_InspectAsynchronouslyNullClass()
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
    public async Task InspectAsync_ShouldNot_InspectAsynchronouslyNullStruct()
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
    public async Task InspectAsync_Should_InspectTaskAsynchronouslyOnNonNullClass()
    {
        var counter = new Counter();
        var counterTask = Task.FromResult<Counter?>(counter);
        await counterTask.InspectAsync(c =>
        {
            c.Count++;
            return Task.CompletedTask;
        });
        Assert.NotEqual(default, counter);
    }

    [Fact]
    public async Task InspectAsync_Should_InspectTaskAsynchronouslyOnNonNullStruct()
    {
        var touched = false;
        var counterTask = Task.FromResult<StructCounter?>(new StructCounter());

        await counterTask.InspectAsync((StructCounter _) =>
        {
            touched = true;
            return Task.CompletedTask;
        });

        Assert.True(touched);
    }
}