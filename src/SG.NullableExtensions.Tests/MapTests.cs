using SG.NullableExtensions.Tests.Models;

namespace SG.NullableExtensions.Tests;

public class MapTests
{
    [Fact]
    public void Map_Should_MapNotNull()
    {
        var counter = new Counter { Count = 0 };
        var mapOutput = counter.Map(c => new { MappedCount = c.Count });

        Assert.NotNull(mapOutput);
        Assert.Equal(counter.Count, mapOutput.MappedCount);
    }

    [Fact]
    public void Map_ShouldNot_MapNull()
    {
        Counter? counter = null;
        var mapOutput = counter.Map(c => new { MappedCount = c.Count });

        Assert.Null(mapOutput);
    }

    [Fact]
    public void Map_Should_MapNotNull_Struct()
    {
        StructCounter? counter = new StructCounter { Count = 0 };
        var count = counter.Map(c => c.Count);

        Assert.NotNull(count);
        Assert.Equal(counter?.Count, count);
    }

    [Fact]
    public void Map_ShouldNot_MapNull_Struct()
    {
        StructCounter? counter = null;
        var count = counter.Map(c => c.Count);

        Assert.Null(count);
    }
}