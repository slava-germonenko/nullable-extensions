namespace SG.NullableExtensions.Tasks;

/// <summary>
/// A container for <c>Task</c> async overloads of the extension methods for nullable types.
/// </summary>
public static partial class NullableExtensions
{
    /// <summary>
    /// Calls an async <c>action</c> if ths source value is not null.
    /// </summary>
    /// <param name="source">An object to make action against.</param>
    /// <param name="action">An async action to be made against the object.</param>
    /// <typeparam name="T">Type of the object.</typeparam>
    /// <returns>A task that returns the unchanged source value.</returns>
    public static async Task<T?> InspectAsync<T>(this T? source, Func<T, Task> action)
    {
        if (source is not null)
        {
            await action(source);
        }

        return source;
    }

    /// <summary>
    /// Calls an async <c>action</c> if the output of the given task is not null.
    /// </summary>
    /// <param name="getSourceTask">A task that returns a nullable value.</param>
    /// <param name="action">An async action to be made against the object.</param>
    /// <typeparam name="T">Type of the object.</typeparam>
    /// <returns>A task that returns the unchanged source value.</returns>
    public static async Task<T?> InspectAsync<T>(this Task<T?> getSourceTask, Func<T, Task> action)
    {
        var source = await getSourceTask;
        if (source is not null)
        {
            await action(source);
        }

        return source;
    }

    /// <summary>
    /// Calls an <c>action</c> if the output of the given task is not null.
    /// </summary>
    /// <param name="getSourceTask">A task that returns a nullable value.</param>
    /// <param name="action">The action to be made against the object.</param>
    /// <typeparam name="T">Type of the object.</typeparam>
    /// <returns>A task that returns the unchanged source value.</returns>
    public static async Task<T?> InspectAsync<T>(this Task<T?> getSourceTask, Action<T> action)
    {
        var source = await getSourceTask;
        if (source is not null)
        {
            action(source);
        }

        return source;
    }
}