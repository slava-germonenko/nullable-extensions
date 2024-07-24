namespace SG.NullableExtensions.Tasks;

/// <summary>
/// A container for <c>Task</c> async overloads of the extension methods for nullable types.
/// </summary>
public static partial class NullableExtensions
{
    /// <summary>
    /// Calls an inspect function if the source value is not null.
    /// </summary>
    /// <param name="source">The source value to be checked for null.</param>
    /// <param name="inspectFunc">The inspect function to be called.</param>
    /// <typeparam name="T">The type of the source value.</typeparam>
    /// <returns>The unchanged source value.</returns>
    public static async Task<T?> InspectAsync<T>(this T? source, Func<T, Task> inspectFunc) where T : class
    {
        if (source is not null)
        {
            await inspectFunc(source);
        }

        return source;
    }

    /// <summary>
    /// Calls an inspect function if the instance of <see cref="Nullable{T}"/> has value.
    /// </summary>
    /// <param name="source">The source value to be checked for null.</param>
    /// <param name="inspectFunc">The inspect function to be called.</param>
    /// <typeparam name="T">The type of the source value.</typeparam>
    /// <returns>The unchanged source value.</returns>
    public static async Task<T?> InspectAsync<T>(this T? source, Func<T, Task> inspectFunc) where T : struct
    {
        if (source.HasValue)
        {
            await inspectFunc(source.Value);
        }

        return source;
    }

    /// <summary>
    /// Calls an inspect function if the output of the <see cref="Task{T}"/> is not null.
    /// </summary>
    /// <param name="sourceTask">The source task used to get a source value.</param>
    /// <param name="inspectFunc">The inspect function.</param>
    /// <typeparam name="T">The type of the source value.</typeparam>
    /// <returns>The unchanged output of the given <see cref="Task{T}"/></returns>
    public static async Task<T?> InspectAsync<T>(this Task<T?> sourceTask, Func<T, Task> inspectFunc)
        where T : class
    {
        var sourceValue = await sourceTask;
        if (sourceValue is not null)
        {
            await inspectFunc(sourceValue);
        }

        return sourceValue;
    }

    /// <summary>
    /// Calls an inspect function if the output of the <see cref="Task{T}"/> is not null.
    /// </summary>
    /// <param name="sourceTask">The source task used to get a source value.</param>
    /// <param name="inspectFunc">The inspect function.</param>
    /// <typeparam name="T">The type of the source value.</typeparam>
    /// <returns>The unchanged output of the given <see cref="Task{T}"/></returns>
    public static async Task<T?> InspectAsync<T>(this Task<T?> sourceTask, Func<T, Task> inspectFunc)
        where T : struct
    {
        var sourceValue = await sourceTask;
        if (sourceValue.HasValue)
        {
            await inspectFunc(sourceValue.Value);
        }

        return sourceValue;
    }
}