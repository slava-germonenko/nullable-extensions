namespace SG.NullableExtensions.ValueTasks;

public static partial class NullableExtensions
{
    /// <summary>
    /// Checks if the source value is null. If it's not, then it'll simply return the value.
    /// Otherwise, it'll return the output of the factory <c>defaultValueFactory</c>.
    /// </summary>
    /// <param name="source">The source possibly null value.</param>
    /// <param name="fallbackValueFactory">The factory that will be used to get the fallback value.</param>
    /// <typeparam name="T">The type of the source value.</typeparam>
    /// <returns>
    /// Returns the value itself if it's defined.
    /// Otherwise, returns the output of the factory <c>defaultValueFactory</c>.
    /// </returns>
    public static ValueTask<T> ValueOrAsync<T>(this T? source, Func<ValueTask<T>> fallbackValueFactory) where T : class
        => source is null ? fallbackValueFactory() : ValueTask.FromResult(source);

    /// <summary>
    /// Checks if the source value is null. If it's not, then it'll simply return the value.
    /// Otherwise, it'll return the output of the factory <c>defaultValueFactory</c>.
    /// </summary>
    /// <param name="source">The source possibly null value.</param>
    /// <param name="fallbackValueFactory">The factory that will be used to get the fallback value.</param>
    /// <typeparam name="T">The type of the source value.</typeparam>
    /// <returns>
    /// Returns the value itself if it's defined.
    /// Otherwise, returns the output of the factory <c>defaultValueFactory</c>.
    /// </returns>
    public static ValueTask<T> ValueOrAsync<T>(this T? source, Func<ValueTask<T>> fallbackValueFactory) where T : struct
        => source.HasValue ? ValueTask.FromResult(source.Value) : fallbackValueFactory();

    /// <summary>
    /// Checks if the output of a task is null. If it's not, then it'll simply return the value.
    /// Otherwise, it'll return specified fallback value.<c>defaultValue</c>.
    /// </summary>
    /// <param name="sourceTask">The task used to get a value to check.</param>
    /// <param name="fallbackValue">The fallback value to be used instead.</param>
    /// <typeparam name="T">The type of the source value.</typeparam>
    /// <returns>
    /// Returns the value itself if it's defined. Otherwise, returns the <c>defaultValue</c>.
    /// </returns>
    public static async ValueTask<T> ValueOrAsync<T>(this ValueTask<T?> sourceTask, T fallbackValue)
        => await sourceTask ?? fallbackValue;
}