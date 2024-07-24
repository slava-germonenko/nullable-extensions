namespace SG.NullableExtensions.ValueTasks;

public static partial class NullableExtensions
{
    /// <summary>
    /// Maps a value if it is not null. Otherwise, returns null.
    /// </summary>
    /// <param name="source">The source value to be mapped.</param>
    /// <param name="mapAsync">The async map function.</param>
    /// <typeparam name="TSource">The type of the source value.</typeparam>
    /// <typeparam name="TResult">The type of the output.</typeparam>
    /// <returns>
    /// Returns the result of the <c>mapAsync</c> function if the source value is not null.
    /// Otherwise, returns <c>null</c>.
    /// </returns>
    public static ValueTask<TResult?> MapAsync<TSource, TResult>(
        this TSource? source,
        Func<TSource, ValueTask<TResult?>> mapAsync
    ) where TSource : class where TResult : class
        => source is null ? ValueTask.FromResult<TResult?>(null) : mapAsync(source);

    /// <summary>
    /// Maps a value if it is not null. Otherwise, returns null.
    /// </summary>
    /// <param name="source">The source value to be mapped.</param>
    /// <param name="mapAsync">The async map function.</param>
    /// <typeparam name="TSource">The type of the source value.</typeparam>
    /// <typeparam name="TResult">The type of the output.</typeparam>
    /// <returns>
    /// Returns the result of the <c>mapAsync</c> function if the source value is not null.
    /// Otherwise, returns <c>null</c>.
    /// </returns>
    public static ValueTask<TResult?> MapAsync<TSource, TResult>(
        this TSource? source,
        Func<TSource, ValueTask<TResult?>> mapAsync
    ) where TSource : struct where TResult : struct
        => source.HasValue ? mapAsync(source.Value) : ValueTask.FromResult<TResult?>(null);

    /// <summary>
    /// Maps the output of a task if the output is not null.
    /// Otherwise, returns null.
    /// </summary>
    /// <param name="sourceTask">The source value to be mapped.</param>
    /// <param name="mapAsync">The async map function.</param>
    /// <typeparam name="TSource">The type of the source value.</typeparam>
    /// <typeparam name="TResult">The type of the output.</typeparam>
    /// <returns>
    /// Returns the result of the <c>mapAsync</c> function if the source value is not null.
    /// Otherwise, returns <c>null</c>.
    /// </returns>
    public static async ValueTask<TResult?> MapAsync<TSource, TResult>(
        this ValueTask<TSource?> sourceTask,
        Func<TSource, ValueTask<TResult?>> mapAsync
    ) where TSource : class where TResult : class
    {
        var source = await sourceTask;
        return source is null ? null : await mapAsync(source);
    }

    /// <summary>
    /// Maps the output of a task if the output is not null.
    /// Otherwise, returns null.
    /// </summary>
    /// <param name="sourceTask">The source value to be mapped.</param>
    /// <param name="mapAsync">The async map function.</param>
    /// <typeparam name="TSource">The type of the source value.</typeparam>
    /// <typeparam name="TResult">The type of the output.</typeparam>
    /// <returns>
    /// Returns the result of the <c>mapAsync</c> function if the source value is not null.
    /// Otherwise, returns <c>null</c>.
    /// </returns>
    public static async ValueTask<TResult?> MapAsync<TSource, TResult>(
        this ValueTask<TSource?> sourceTask,
        Func<TSource, ValueTask<TResult?>> mapAsync
    ) where TSource : struct where TResult : struct
    {
        var source = await sourceTask;
        return source.HasValue ? await mapAsync(source.Value) : null;
    }
}