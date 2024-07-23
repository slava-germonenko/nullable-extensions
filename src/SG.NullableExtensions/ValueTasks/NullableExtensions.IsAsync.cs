namespace SG.NullableExtensions.ValueTasks;

public static partial class NullableExtensions
{
    /// <summary>
    /// Calls an async predicate if the source value is not null.
    /// </summary>
    /// <param name="source">The source value.</param>
    /// <param name="asyncPredicate">The async predicate.</param>
    /// <typeparam name="T">The type of the source value.</typeparam>
    /// <returns>
    /// <c>true</c> if the source value is not null and matches the predicate.
    /// Otherwise, returns <c>false</c>
    /// </returns>
    public static async ValueTask<bool> IsAsync<T>(this T? source, Func<T, ValueTask<bool>> asyncPredicate)
        where T : class
        => source is not null && await asyncPredicate(source);

    /// <summary>
    /// Calls an async predicate if the given <see cref="Nullable{T}"/> has value.
    /// </summary>
    /// <param name="source">The source value.</param>
    /// <param name="asyncPredicate">The async predicate.</param>
    /// <typeparam name="T">The type of the source value.</typeparam>
    /// <returns>
    /// <c>true</c> if the source value is not null and matches the predicate.
    /// Otherwise, returns <c>false</c>
    /// </returns>
    public static async ValueTask<bool> IsAsync<T>(this T? source, Func<T, ValueTask<bool>> asyncPredicate)
        where T : struct
        => source.HasValue && await asyncPredicate(source.Value);
}