namespace SG.NullableExtensions;

public static partial class NullableExtensions
{
    /// <summary>
    /// Maps a nullable value if defined using a map function.
    /// <code>
    /// var token = userService.GetUserOrNull(id)
    ///     .Map(user => tokenService.GenerateToken(user));
    /// </code>
    /// </summary>
    /// <param name="source">The source value to be mapped.</param>
    /// <param name="map">The map function.</param>
    /// <typeparam name="TSource">The type of the source value.</typeparam>
    /// <typeparam name="TResult">The type of the output.</typeparam>
    /// <returns>
    ///     Returns the result of the <c>map</c> function if the source value id defined.
    ///     Otherwise, returns <c>null</c>.
    /// </returns>
    public static TResult? Map<TSource, TResult>(this TSource? source, Func<TSource, TResult> map) where TResult : class
        => source is null ? null : map(source);

    /// <summary>
    /// Maps the result of a task if defined using a map function.
    /// <code>
    /// var something = userService.GetUserOrNull(id)
    ///     .MapAsync(user => tokenService.GenerateTokenAsync(user));
    /// </code>
    /// </summary>
    /// <param name="source">A source value to be mapped.</param>
    /// <param name="map">A map function.</param>
    /// <typeparam name="TSource">The type of the source value.</typeparam>
    /// <typeparam name="TResult">The type of the output.</typeparam>
    /// <returns>
    ///     Returns the result of the <c>map</c> function if the source value id defined.
    ///     Otherwise, returns <c>null</c>.
    /// </returns>
    public static ValueTask<TResult?> MapAsync<TSource, TResult>(
        this TSource? source,
        Func<TSource, ValueTask<TResult?>> map
    ) where TResult : class
        => source is null ? ValueTask.FromResult<TResult?>(null) : map(source);

    /// <summary>
    /// Maps the output of a task using an async map function.
    /// <code>
    /// var something = userService.GetUserOrNullAsync(id)
    ///     .MapAsync(user => tokenService.GenerateTokenAsync(user));
    /// </code>
    /// </summary>
    /// <param name="getSourceTask">The task that returns a nullable value.</param>
    /// <param name="map">The async map function.</param>
    /// <typeparam name="TSource">The type of the source value.</typeparam>
    /// <typeparam name="TResult">The type of the output.</typeparam>
    /// <returns>
    ///     Returns the result of the <c>map</c> function if the output of the task is not null.
    ///     Otherwise, returns <c>null</c>.
    /// </returns>
    public static async ValueTask<TResult?> MapAsync<TSource, TResult>(
        this ValueTask<TSource?> getSourceTask,
        Func<TSource, ValueTask<TResult?>> map
    ) where TResult : class
    {
        var source = await getSourceTask;
        return source is null ? null : await map(source);
    }

    /// <summary>
    /// Maps the output of a task using a map function.
    /// <code>
    /// var something = userService.GetUserOrNullAsync(id)
    ///     .MapAsync(user => tokenService.GenerateToken(user));
    /// </code>
    /// </summary>
    /// <param name="getSourceTask">The task that returns a nullable value.</param>
    /// <param name="map">The map function.</param>
    /// <typeparam name="TSource">The type of the source value.</typeparam>
    /// <typeparam name="TResult">The type of the output.</typeparam>
    /// <returns>
    ///     Returns the result of the <c>map</c> function if the output of the task is not null.
    ///     Otherwise, returns <c>null</c>.
    /// </returns>
    public static async ValueTask<TResult?> MapAsync<TSource, TResult>(
        this ValueTask<TSource?> getSourceTask,
        Func<TSource, TResult?> map
    ) where TResult : class
    {
        var source = await getSourceTask;
        return source is null ? null : map(source);
    }
}