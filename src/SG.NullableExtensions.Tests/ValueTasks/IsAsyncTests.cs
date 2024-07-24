using SG.NullableExtensions.Tests.Models;
using SG.NullableExtensions.ValueTasks;

namespace SG.NullableExtensions.Tests.ValueTasks;

public class IsAsyncTests
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(1, 2)]
    public async ValueTask IsAsync_Should_CallPredicateOnNonNullClass(int actualCount, int expectedCount)
    {
        var counter = new Counter { Count = actualCount };
        var comparisonResult = await counter.IsAsync(c => c.CompareAsync(expectedCount));
        Assert.Equal(actualCount == expectedCount, comparisonResult);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(1, 2)]
    public async ValueTask IsAsync_Should_CallPredicateOnNonNullStruct(int actualCount, int expectedCount)
    {
        StructCounter? counter = new() { Count = actualCount };
        var comparisonResult = await counter.IsAsync(c => c.CompareAsync(expectedCount));
        Assert.Equal(actualCount == expectedCount, comparisonResult);
    }

    [Fact]
    public async ValueTask IsAsync_ShouldNot_CallPredicateOnNullClass()
    {
        Counter? counter = null;
        var comparisonResult = await counter.IsAsync(_ => ValueTask.FromResult(true));
        Assert.False(comparisonResult);
    }

    [Fact]
    public async ValueTask IsAsync_ShouldNot_CallPredicateOnNullStruct()
    {
        StructCounter? counter = null;
        var comparisonResult = await counter.IsAsync(_ => ValueTask.FromResult(true));
        Assert.False(comparisonResult);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(1, 2)]
    public async ValueTask IsAsync_Should_CallPredicateOnNonNullClassTaskOutput(int actualCount, int expectedCount)
    {
        var counterTask = ValueTask.FromResult<Counter?>(new Counter { Count = actualCount });
        var comparisonResult = await counterTask.IsAsync(c => c.CompareAsync(expectedCount));
        Assert.Equal(actualCount == expectedCount, comparisonResult);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(1, 2)]
    public async ValueTask IsAsync_Should_CallPredicateOnNonNullStructTaskOutput(int actualCount, int expectedCount)
    {
        var counterTask = ValueTask.FromResult<StructCounter?>(new StructCounter { Count = actualCount });
        var comparisonResult = await counterTask.IsAsync(c => c.CompareAsync(expectedCount));
        Assert.Equal(actualCount == expectedCount, comparisonResult);
    }

    [Fact]
    public async ValueTask IsAsync_ShouldNot_CallPredicateOnNullClassTaskOutput()
    {
        Counter? counter = null;
        var comparisonResult = await counter.IsAsync(_ => ValueTask.FromResult(true));
        Assert.False(comparisonResult);
    }

    [Fact]
    public async ValueTask IsAsync_ShouldNot_CallPredicateOnNullStructTaskOutput()
    {
        StructCounter? counter = null;
        var comparisonResult = await counter.IsAsync(_ => ValueTask.FromResult(true));
        Assert.False(comparisonResult);
    }
}