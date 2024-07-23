namespace SG.NullableExtensions.Tasks;

public static partial class NullableExtensions
{
    /// <summary>
    /// Checks if the underlying value is not null and matches an async predicate.
    /// </summary>
    /// <param name="source">A nullable value</param>
    /// <param name="asyncPredicate">The async predicate to be run against the underlying value</param>
    /// <typeparam name="T">The type of the possible underlying value</typeparam>
    /// <returns>
    /// Returns true if the value is set and the predicate returns <c>true</c>.
    /// Otherwise, return <c>false</c>.
    /// </returns>
    public static Task<bool> IsAsync<T>(this T? source, Func<T, Task<bool>> asyncPredicate)
        => source is null ? Task.FromResult(false) : asyncPredicate(source);

    /// <summary>
    /// Checks if the underlying value is not null and matches an async predicate.
    /// </summary>
    /// <param name="getSourceTask">A task that returns a nullable value</param>
    /// <param name="asyncPredicate">The async predicate to be run against the underlying value</param>
    /// <typeparam name="T">The type of the possible underlying value</typeparam>
    /// <returns>
    ///     Returns true if the value is set and the predicate returns <c>true</c>.
    ///     Otherwise, return <c>false</c>.
    /// </returns>
    public static async Task<bool> IsAsync<T>(
        this Task<T?> getSourceTask,
        Func<T, Task<bool>> asyncPredicate
    )
    {
        var source = await getSourceTask;
        return await source.IsAsync(asyncPredicate);
    }
}