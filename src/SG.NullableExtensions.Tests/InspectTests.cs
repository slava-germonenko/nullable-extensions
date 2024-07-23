using SG.NullableExtensions.Tests.Models;

namespace SG.NullableExtensions.Tests;

public class InspectTests
{
    [Fact]
    public void Inspect_Should_CallActionOnNonNull()
    {
        Counter counter = new() { Count = 0 };
        counter.Inspect(c => c.Count += 1);
        Assert.NotEqual(0, counter.Count);
    }

    [Fact]
    public void Inspect_Should_CallActionOnNonNull_Struct()
    {
        int outerCounter = 0;
        StructCounter? counter = new() { Count = 0 };

        // Use outerCounter because structs are passed by value
        // therefore are not update like that.
        counter.Inspect(_ => outerCounter += 1);
        Assert.NotEqual(0, outerCounter);
    }

    [Fact]
    public void Inspect_ShouldNot_CallActionOnNonNull()
    {
        var outerCounter = 0;
        Counter? counter = null;

        counter.Inspect(c =>
        {
            c = new();
            outerCounter += 1;
        });

        Assert.Equal(0, outerCounter);
        Assert.Null(counter);
    }

    [Fact]
    public void Inspect_ShouldNot_CallActionOnNonNull_Struct()
    {
        var outerCounter = 0;
        StructCounter? counter = null;

        counter.Inspect(c =>
        {
            c = new();
            outerCounter += 1;
        });

        Assert.Equal(0, outerCounter);
        Assert.Null(counter);
    }
}