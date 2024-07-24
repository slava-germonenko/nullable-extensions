using SG.NullableExtensions.Tests.Models;
using SG.NullableExtensions.Tasks;

namespace SG.NullableExtensions.Tests.Tasks;

public class IsAsyncTests
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(1, 2)]
    public async Task IsAsync_Should_CallPredicateOnNonNullClass(int actualCount, int expectedCount)
    {
        var counter = new Counter { Count = actualCount };
        var comparisonResult = await counter.IsAsync(c => Task.FromResult(c.Count == expectedCount));
        Assert.Equal(actualCount == expectedCount, comparisonResult);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(1, 2)]
    public async Task IsAsync_Should_CallPredicateOnNonNullStruct(int actualCount, int expectedCount)
    {
        StructCounter? counter = new() { Count = actualCount };
        var comparisonResult = await counter.IsAsync(c => Task.FromResult(c.Count == expectedCount));
        Assert.Equal(actualCount == expectedCount, comparisonResult);
    }

    [Fact]
    public async Task IsAsync_ShouldNot_CallPredicateOnNullClass()
    {
        Counter? counter = null;
        var comparisonResult = await counter.IsAsync(_ => Task.FromResult(true));
        Assert.False(comparisonResult);
    }

    [Fact]
    public async Task IsAsync_ShouldNot_CallPredicateOnNullStruct()
    {
        StructCounter? counter = null;
        var comparisonResult = await counter.IsAsync(_ => Task.FromResult(true));
        Assert.False(comparisonResult);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(1, 2)]
    public async Task IsAsync_Should_CallPredicateOnNonNullClassTaskOutput(int actualCount, int expectedCount)
    {
        var counterTask = Task.FromResult<Counter?>(new Counter { Count = actualCount });
        var comparisonResult = await counterTask.IsAsync(c => Task.FromResult(c.Count == expectedCount));
        Assert.Equal(actualCount == expectedCount, comparisonResult);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(1, 2)]
    public async Task IsAsync_Should_CallPredicateOnNonNullStructTaskOutput(int actualCount, int expectedCount)
    {
        var counterTask = Task.FromResult<StructCounter?>(new StructCounter { Count = actualCount });
        var comparisonResult = await counterTask.IsAsync(c => Task.FromResult(c.Count == expectedCount));
        Assert.Equal(actualCount == expectedCount, comparisonResult);
    }

    [Fact]
    public async Task IsAsync_ShouldNot_CallPredicateOnNullClassTaskOutput()
    {
        Counter? counter = null;
        var comparisonResult = await counter.IsAsync(_ => Task.FromResult(true));
        Assert.False(comparisonResult);
    }

    [Fact]
    public async Task IsAsync_ShouldNot_CallPredicateOnNullStructTaskOutput()
    {
        StructCounter? counter = null;
        var comparisonResult = await counter.IsAsync(_ => Task.FromResult(true));
        Assert.False(comparisonResult);
    }
}