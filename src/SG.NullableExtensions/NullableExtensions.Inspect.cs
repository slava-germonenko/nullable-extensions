namespace SG.NullableExtensions;

/// <summary>
/// A container for the extensions methods.
/// </summary>
public static partial class NullableExtensions
{
    /// <summary>
    /// Calls an <c>action</c> if the source value is not null.
    /// </summary>
    /// <param name="source">An object to make action against.</param>
    /// <param name="action">An action to be made against the object.</param>
    /// <typeparam name="T">Type of the object.</typeparam>
    /// <returns>The unchanged source value.</returns>
    public static T? Inspect<T>(this T? source, Action<T> action)
    {
        if (source is not null)
        {
            action(source);
        }

        return source;
    }

    /// <summary>
    /// Calls an async <c>action</c> if ths source value is not null.
    /// </summary>
    /// <param name="source">An object to make action against.</param>
    /// <param name="action">An async action to be made against the object.</param>
    /// <typeparam name="T">Type of the object.</typeparam>
    /// <returns>A task that returns the unchanged source value.</returns>
    public static async ValueTask<T?> InspectAsync<T>(this T? source, Func<T, ValueTask> action)
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
    public static async ValueTask<T?> InspectAsync<T>(this ValueTask<T?> getSourceTask, Func<T, ValueTask> action)
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
    public static async ValueTask<T?> InspectAsync<T>(this ValueTask<T?> getSourceTask, Action<T> action)
    {
        var source = await getSourceTask;
        if (source is not null)
        {
            action(source);
        }

        return source;
    }
}