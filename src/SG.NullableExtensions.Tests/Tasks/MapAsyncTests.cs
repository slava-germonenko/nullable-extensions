using SG.NullableExtensions.Tests.Models;
using SG.NullableExtensions.Tasks;

namespace SG.NullableExtensions.Tests.Tasks;

public class MapAsyncTests
{
    [Fact]
    public async Task WhenSourceIsNonNullCass_MapAsync_Should_MapToNewValue()
    {
        var counter = new Counter { Count = 5 };
        var marker = await counter.MapAsync(
            c => Task.FromResult<Marker?>(new Marker { Touched = c.Count > 0 })
        );

        Assert.NotNull(marker);
        Assert.True(marker.Touched);
    }

    [Fact]
    public async Task WhenSourceIsNonNullStruct_MapAsync_Should_MapToNewValue()
    {
        StructCounter? counter = new StructCounter { Count = 5 };
        var marker = await counter.MapAsync(
            c => Task.FromResult<StructMarker?>(new StructMarker { Touched = c.Count > 0 })
        );

        Assert.NotNull(marker);
        Assert.True(marker.Value.Touched);
    }

    [Fact]
    public async Task WhenSourceIsNullCass_MapAsync_ShouldNot_MapToNewValue()
    {
        Counter? counter = null;
        var marker = await counter.MapAsync(
            c => Task.FromResult<Marker?>(new Marker { Touched = c.Count > 0 })
        );

        Assert.Null(marker);
    }

    [Fact]
    public async Task WhenSourceIsNullStruct_MapAsync_ShouldNot_MapToNewValue()
    {
        StructCounter? counter = null;
        var marker = await counter.MapAsync(
            c => Task.FromResult<StructMarker?>(new StructMarker { Touched = c.Count > 0 })
        );

        Assert.Null(marker);
    }






    [Fact]
    public async Task WhenTaskOutputIsNonNullCass_MapAsync_Should_MapToNewValue()
    {
        var counterTask = Task.FromResult<Counter?>(new Counter { Count = 5 });
        var marker = await counterTask.MapAsync(
            c => Task.FromResult<Marker?>(new Marker { Touched = c.Count > 0 })
        );

        Assert.NotNull(marker);
        Assert.True(marker.Touched);
    }

    [Fact]
    public async Task WhenTaskOutputIsNonNullStruct_MapAsync_Should_MapToNewValue()
    {
        var counterTask = Task.FromResult<StructCounter?>(new StructCounter { Count = 5 });
        var marker = await counterTask.MapAsync(
            c => Task.FromResult<StructMarker?>(new StructMarker { Touched = c.Count > 0 })
        );

        Assert.NotNull(marker);
        Assert.True(marker.Value.Touched);
    }

    [Fact]
    public async Task WhenTaskOutputIsNullCass_MapAsync_ShouldNot_MapToNewValue()
    {
        var counterTask = Task.FromResult<Counter?>(null);
        var marker = await counterTask.MapAsync(
            c => Task.FromResult<Marker?>(new Marker { Touched = c.Count > 0 })
        );

        Assert.Null(marker);
    }

    [Fact]
    public async Task WhenTaskOutputIsNullStruct_MapAsync_ShouldNot_MapToNewValue()
    {
        var counterTask = Task.FromResult<StructCounter?>(null);
        var marker = await counterTask.MapAsync(
            c => Task.FromResult<StructMarker?>(new StructMarker { Touched = c.Count > 0 })
        );

        Assert.Null(marker);
    }
}