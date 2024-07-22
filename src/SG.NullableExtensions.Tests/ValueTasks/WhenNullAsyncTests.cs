using SG.NullableExtensions.Tests.Models;
using SG.NullableExtensions.ValueTasks;

namespace SG.NullableExtensions.Tests.ValueTasks;

public class WhenNullAsyncTests
{
    [Fact]
    public async ValueTask WhenNullAsync_Should_CallAsyncActionOnNullClass()
    {
        var touched = false;
        var increment = () =>
        {
            touched = true;
            return ValueTask.CompletedTask;
        };

        Counter? counter = null;

        await counter.WhenNullAsync(increment);
        Assert.True(touched);
    }

    [Fact]
    public async ValueTask WhenNullAsync_Should_CallAsyncActionOnNullStruct()
    {
        var touched = false;
        var increment = () =>
        {
            touched = true;
            return ValueTask.CompletedTask;
        };

        StructCounter? counter = null;

        await counter.WhenNullAsync(increment);
        Assert.True(touched);
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

    [Fact]
    public async ValueTask WhenNullAsync_Should_CallActionOnNullClassOutputFromTask()
    {
        var touched = false;
        var counterTask = ValueTask.FromResult<Counter?>(null);

        await counterTask.WhenNullAsync(() =>
        {
            touched = true;
            return ValueTask.CompletedTask;
        });

        Assert.True(touched);
    }

    [Fact]
    public async ValueTask WhenNullAsync_Should_CallActionOnNullStructOutputFromTask()
    {
        var touched = false;
        var counterTask = ValueTask.FromResult<StructCounter?>(null);

        await counterTask.WhenNullAsync(() =>
        {
            touched = true;
            return ValueTask.CompletedTask;
        });

        Assert.True(touched);
    }

    [Fact]
    public async ValueTask WhenNullAsync_ShouldNot_CallAsyncActionOnNonNullClassOutputFromTask()
    {
        var touched = false;
        var counterTask = ValueTask.FromResult<Counter?>(new Counter());

        await counterTask.WhenNullAsync(() =>
        {
            touched = true;
            return ValueTask.CompletedTask;
        });

        Assert.False(touched);
    }

    [Fact]
    public async ValueTask WhenNullAsync_ShouldNot_CallAsyncActionOnNonNullStructOutputFromTask()
    {
        var touched = false;
        var counterTask = ValueTask.FromResult<StructCounter?>(new StructCounter());

        await counterTask.WhenNullAsync(() =>
        {
            touched = true;
            return ValueTask.CompletedTask;
        });

        Assert.False(touched);
    }
}