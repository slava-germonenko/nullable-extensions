namespace SG.NullableExtensions.Tests.Models;

public class Counter
{
    public int Count { get; set; }

    public Task IncrementAsync()
    {
        Count++;
        return Task.CompletedTask;
    }
}