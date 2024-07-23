using SG.NullableExtensions.Tasks;
using SG.NullableExtensions.Tests.Models;

namespace SG.NullableExtensions.Tests.Tasks;

public class InspectAsyncTests
{
    [Fact]
    public async Task Inspect_Should_CallActionOnNonNull()
    {
        Counter counter = new() { Count = 0 };
        await counter.InspectAsync(c => c.IncrementAsync());
        Assert.NotEqual(0, counter.Count);
    }

    [Fact]
    public async Task Inspect_Should_CallActionOnNonNull_Task()
    {
        var counter = await Task.FromResult<Counter?>(new Counter())
            .InspectAsync(c => c.IncrementAsync());

        Assert.NotNull(counter);
        Assert.NotEqual(0, counter.Count);
    }


    [Fact]
    public async Task Inspect_Should_CallActionOnNonNull_Struct()
    {
        int outerCounter = 0;
        StructCounter? counter = new() { Count = 0 };

        // Use outerCounter because structs are passed by value
        // therefore are not update like that.
        await counter.InspectAsync(async _ => outerCounter += 1);
        Assert.NotEqual(0, outerCounter);
    }

    [Fact]
    public async Task Inspect_Should_CallActionOnNonNull_Task_Struct()
    {
        int outerCounter = 0;
        StructCounter? counter = new() { Count = 0 };

        // Use outerCounter because structs are passed by value
        // therefore are not update like that.
        await counter.InspectAsync(c => c.);
        Assert.NotEqual(0, outerCounter);
    }

    [Fact]
    public async Task Inspect_ShouldNot_CallActionOnNonNull()
    {
        var outerCounter = 0;
        Counter? counter = null;

        await counter.InspectAsync(async c =>
        {
            c = new();
            outerCounter += 1;
        });


        Assert.Equal(0, outerCounter);
        Assert.Null(counter);
    }

    [Fact]
    public async Task Inspect_ShouldNot_CallActionOnNonNull_Struct()
    {
        var outerCounter = 0;
        StructCounter? counter = null;

        await counter.InspectAsync(async c =>
        {
            c = new();
            outerCounter += 1;
        });

        Assert.Equal(0, outerCounter);
        Assert.Null(counter);
    }
}