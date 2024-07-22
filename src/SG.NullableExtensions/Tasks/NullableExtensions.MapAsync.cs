namespace SG.NullableExtensions.Tasks;

public static partial class NullableExtensions
{
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
    public static Task<TResult?> MapAsync<TSource, TResult>(
        this TSource? source,
        Func<TSource, Task<TResult?>> map
    ) where TResult : class
        => source is null ? Task.FromResult<TResult?>(null) : map(source);

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
    public static async Task<TResult?> MapAsync<TSource, TResult>(
        this Task<TSource?> getSourceTask,
        Func<TSource, Task<TResult?>> map
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
    public static async Task<TResult?> MapAsync<TSource, TResult>(
        this Task<TSource?> getSourceTask,
        Func<TSource, TResult?> map
    ) where TResult : class
    {
        var source = await getSourceTask;
        return source is null ? null : map(source);
    }
}