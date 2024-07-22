namespace SG.NullableExtensions.Tasks;

public static partial class NullableExtensions
{
        /// <summary>
    /// Checks if the source value is null. If it's not, then it'll simply return the value.
    /// Otherwise, it'll return the output of the async factory <c>defaultValueFactory</c>.
    /// </summary>
    /// <param name="source">The source possibly null value.</param>
    /// <param name="defaultValueFactory">The async factory that will be used to get an alternative value.</param>
    /// <typeparam name="T">The type of the source value.</typeparam>
    /// <returns>
    ///     Returns the value itself if it's defined.
    ///     Otherwise, returns the output of the async factory <c>defaultValueFactory</c>.
    /// </returns>
    public static Task<T> ValueOrAsync<T>(this T? source, Func<Task<T>> defaultValueFactory)
        => source is null ? defaultValueFactory() : Task.FromResult(source);

    /// <summary>
    /// Checks if the output of the given task. If it's not, then it'll simply return the value.
    /// Otherwise, it'll return the output of the async factory <c>defaultValueFactory</c>.
    /// </summary>
    /// <param name="getSourceTask">The source possibly null value.</param>
    /// <param name="defaultValueFactory">The async factory that will be used to get an alternative value.</param>
    /// <typeparam name="T">The type of the source value.</typeparam>
    /// <returns>
    ///     Returns the value itself if it's defined.
    ///     Otherwise, returns the output of the async factory <c>defaultValueFactory</c>.
    /// </returns>
    public static async Task<T> ValueOrAsync<T>(
        this Task<T?> getSourceTask,
        Func<Task<T>> defaultValueFactory)
    {
        var source = await getSourceTask;
        return source ?? await defaultValueFactory();
    }

    /// <summary>
    /// Checks if the output of the given task. If it's not, then it'll simply return the value.
    /// Otherwise, it'll return the output of the factory <c>defaultValueFactory</c>.
    /// </summary>
    /// <param name="getSourceTask">The source possibly null value.</param>
    /// <param name="defaultValueFactory">The factory that will be used to get an alternative value.</param>
    /// <typeparam name="T">The type of the source value.</typeparam>
    /// <returns>
    ///     Returns the value itself if it's defined.
    ///     Otherwise, returns the output of the factory <c>defaultValueFactory</c>.
    /// </returns>
    public static async Task<T> ValueOrAsync<T>(
        this Task<T?> getSourceTask,
        Func<T> defaultValueFactory)
    {
        var source = await getSourceTask;
        return source ?? defaultValueFactory();
    }
}