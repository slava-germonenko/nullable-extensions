using SG.NullableExtensions.Tests.Models;
using SG.NullableExtensions.ValueTasks;

namespace SG.NullableExtensions.Tests.ValueTasks;

public class MapAsyncTests
{
    [Fact]
    public async ValueTask WhenSourceIsNonNullCass_MapAsync_Should_MapToNewValue()
    {
        var counter = new Counter { Count = 5 };
        var marker = await counter.MapAsync(
            c => ValueTask.FromResult<Marker?>(new Marker { Touched = c.Count > 0 })
        );

        Assert.NotNull(marker);
        Assert.True(marker.Touched);
    }

    [Fact]
    public async ValueTask WhenSourceIsNonNullStruct_MapAsync_Should_MapToNewValue()
    {
        StructCounter? counter = new StructCounter { Count = 5 };
        var marker = await counter.MapAsync(
            c => ValueTask.FromResult<StructMarker?>(new StructMarker { Touched = c.Count > 0 })
        );

        Assert.NotNull(marker);
        Assert.True(marker.Value.Touched);
    }

    [Fact]
    public async ValueTask WhenSourceIsNullCass_MapAsync_ShouldNot_MapToNewValue()
    {
        Counter? counter = null;
        var marker = await counter.MapAsync(
            c => ValueTask.FromResult<Marker?>(new Marker { Touched = c.Count > 0 })
        );

        Assert.Null(marker);
    }

    [Fact]
    public async ValueTask WhenSourceIsNullStruct_MapAsync_ShouldNot_MapToNewValue()
    {
        StructCounter? counter = null;
        var marker = await counter.MapAsync(
            c => ValueTask.FromResult<StructMarker?>(new StructMarker { Touched = c.Count > 0 })
        );

        Assert.Null(marker);
    }






    [Fact]
    public async ValueTask WhenTaskOutputIsNonNullCass_MapAsync_Should_MapToNewValue()
    {
        var counterTask = ValueTask.FromResult<Counter?>(new Counter { Count = 5 });
        var marker = await counterTask.MapAsync(
            c => ValueTask.FromResult<Marker?>(new Marker { Touched = c.Count > 0 })
        );

        Assert.NotNull(marker);
        Assert.True(marker.Touched);
    }

    [Fact]
    public async ValueTask WhenTaskOutputIsNonNullStruct_MapAsync_Should_MapToNewValue()
    {
        var counterTask = ValueTask.FromResult<StructCounter?>(new StructCounter { Count = 5 });
        var marker = await counterTask.MapAsync(
            c => ValueTask.FromResult<StructMarker?>(new StructMarker { Touched = c.Count > 0 })
        );

        Assert.NotNull(marker);
        Assert.True(marker.Value.Touched);
    }

    [Fact]
    public async ValueTask WhenTaskOutputIsNullCass_MapAsync_ShouldNot_MapToNewValue()
    {
        var counterTask = ValueTask.FromResult<Counter?>(null);
        var marker = await counterTask.MapAsync(
            c => ValueTask.FromResult<Marker?>(new Marker { Touched = c.Count > 0 })
        );

        Assert.Null(marker);
    }

    [Fact]
    public async ValueTask WhenTaskOutputIsNullStruct_MapAsync_ShouldNot_MapToNewValue()
    {
        var counterTask = ValueTask.FromResult<StructCounter?>(null);
        var marker = await counterTask.MapAsync(
            c => ValueTask.FromResult<StructMarker?>(new StructMarker { Touched = c.Count > 0 })
        );

        Assert.Null(marker);
    }
}