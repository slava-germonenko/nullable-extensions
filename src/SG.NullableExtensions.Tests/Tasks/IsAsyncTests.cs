using SG.NullableExtensions.Tasks;
using SG.NullableExtensions.Tests.Models;

namespace SG.NullableExtensions.Tests.Tasks;

public class IsAsyncAsyncTests
{
    [Theory]
    [InlineData(42, 42, true)]
    [InlineData(42, 322, false)]
    public async Task IsAsync_Should_CallMethodOnNonNull(int expectedCount, int actualCount, bool output)
    {
        Counter counter = new() { Count = actualCount };
        Assert.Equal(output, await counter.IsAsync(async c => c.Count == expectedCount));
    }

    [Theory]
    [InlineData(42, 42, true)]
    [InlineData(42, 322, false)]
    public async Task IsAsync_Should_CallMethodOnNonNull_Struct(int expectedCount, int actualCount, bool output)
    {
        StructCounter? counter = new() { Count = actualCount };
        Assert.Equal(output, counter.IsAsync(async c => c.Count == expectedCount));
    }

    [Fact]
    public async Task IsAsync_Should_ReturnFalseOnNull()
    {
        Counter? counter = null;
        Assert.False(counter.IsAsync(async _ => true));
    }

    [Fact]
    public async Task IsAsync_Should_returnFalseNoNull_Struct()
    {
        StructCounter? counter = null;
        Assert.False(counter.IsAsync(_ => true));
    }
}