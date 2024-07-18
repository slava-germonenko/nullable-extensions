namespace SG.NullableExtensions;

public static partial class NullableExtensions
{
    /// <summary>
    /// Checks if the underlying value is not null and matches the predicate.
    /// </summary>
    /// <param name="source">A nullable value</param>
    /// <param name="predicate">The predicate to be run against the underlying value</param>
    /// <typeparam name="T">The type of the possible underlying value</typeparam>
    /// <returns>
    ///     Returns true if the value is set and the predicate returns <c>true</c>.
    ///     Otherwise, return <c>false</c>.
    /// </returns>
    public static bool Is<T>(this T? source, Predicate<T> predicate)
        => source is not null && predicate(source);

    /// <summary>
    /// Checks if the underlying value is not null and matches the async predicate.
    /// </summary>
    /// <param name="source">A nullable value</param>
    /// <param name="asyncPredicate">The async predicate to be run against the underlying value</param>
    /// <typeparam name="T">The type of the possible underlying value</typeparam>
    /// <returns>
    ///     Returns true if the value is set and the predicate returns <c>true</c>.
    ///     Otherwise, return <c>false</c>.
    /// </returns>
    public static ValueTask<bool> IsAsync<T>(this T? source, Func<T, ValueTask<bool>> asyncPredicate)
        => source is null ? ValueTask.FromResult(false) : asyncPredicate(source);

    /// <summary>
    /// Checks if the underlying value is not null and matches the async predicate.
    /// </summary>
    /// <param name="getSourceTask">A task that returns a nullable value</param>
    /// <param name="asyncPredicate">The async predicate to be run against the underlying value</param>
    /// <typeparam name="T">The type of the possible underlying value</typeparam>
    /// <returns>
    ///     Returns true if the value is set and the predicate returns <c>true</c>.
    ///     Otherwise, return <c>false</c>.
    /// </returns>
    public static async ValueTask<bool> IsAsync<T>(
        this ValueTask<T?> getSourceTask,
        Func<T, ValueTask<bool>> asyncPredicate
    )
    {
        var source = await getSourceTask;
        return await source.IsAsync(asyncPredicate);
    }
}