namespace SG.NullableExtensions.Tests.Models;

public struct StructCounter
{
    public int Count { get; set; }

    public Task IncrementAsync()
    {
        Count++;
        return Task.CompletedTask;
    }
}