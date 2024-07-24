using SG.NullableExtensions.Tests.Models;
using SG.NullableExtensions.Tasks;

namespace SG.NullableExtensions.Tests.Tasks;

public class WhenNullAsyncTests
{
    [Fact]
    public async Task WhenNullAsync_Should_CallAsyncActionOnNullClass()
    {
        var touched = false;
        var increment = () =>
        {
            touched = true;
            return Task.CompletedTask;
        };

        Counter? counter = null;

        await counter.WhenNullAsync(increment);
        Assert.True(touched);
    }

    [Fact]
    public async Task WhenNullAsync_Should_CallAsyncActionOnNullStruct()
    {
        var touched = false;
        var increment = () =>
        {
            touched = true;
            return Task.CompletedTask;
        };

        StructCounter? counter = null;

        await counter.WhenNullAsync(increment);
        Assert.True(touched);
    }

    [Fact]
    public async Task WhenNullAsync_ShouldNot_CallAsyncActionOnNonNullClass()
    {
        var touched = false;
        await new Counter().WhenNullAsync(() =>
        {
            touched = true;
            return Task.CompletedTask;
        });
        Assert.False(touched);
    }

    [Fact]
    public async Task WhenNullAsync_ShouldNot_CallAsyncActionOnNonNullStruct()
    {
        var touched = false;
        StructCounter? counter = new StructCounter();
        await counter.WhenNullAsync(() =>
        {
            touched = true;
            return Task.CompletedTask;
        });
        Assert.False(touched);
    }

    [Fact]
    public async Task WhenNullAsync_Should_CallActionOnNullClassOutputFromTask()
    {
        var touched = false;
        var counterTask = Task.FromResult<Counter?>(null);

        await counterTask.WhenNullAsync(() =>
        {
            touched = true;
            return Task.CompletedTask;
        });

        Assert.True(touched);
    }

    [Fact]
    public async Task WhenNullAsync_Should_CallActionOnNullStructOutputFromTask()
    {
        var touched = false;
        var counterTask = Task.FromResult<StructCounter?>(null);

        await counterTask.WhenNullAsync(() =>
        {
            touched = true;
            return Task.CompletedTask;
        });

        Assert.True(touched);
    }

    [Fact]
    public async Task WhenNullAsync_ShouldNot_CallAsyncActionOnNonNullClassOutputFromTask()
    {
        var touched = false;
        var counterTask = Task.FromResult<Counter?>(new Counter());

        await counterTask.WhenNullAsync(() =>
        {
            touched = true;
            return Task.CompletedTask;
        });

        Assert.False(touched);
    }

    [Fact]
    public async Task WhenNullAsync_ShouldNot_CallAsyncActionOnNonNullStructOutputFromTask()
    {
        var touched = false;
        var counterTask = Task.FromResult<StructCounter?>(new StructCounter());

        await counterTask.WhenNullAsync(() =>
        {
            touched = true;
            return Task.CompletedTask;
        });

        Assert.False(touched);
    }
}