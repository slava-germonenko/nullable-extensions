namespace SG.NullableExtensions.Tests.Models;

public class Counter
{
    public int Count { get; set; }

    public ValueTask IncrementAsync()
    {
        Count++;
        return ValueTask.CompletedTask;
    }

    public ValueTask<bool> CompareAsync(int count) => ValueTask.FromResult(count == Count);
}