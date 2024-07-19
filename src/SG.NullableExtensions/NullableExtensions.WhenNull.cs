namespace SG.NullableExtensions;

public static partial class NullableExtensions
{
    /// <summary>
    /// Calls an <c>action</c> if the source value is null.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="action">The action to be called if the value is null.</param>
    /// <typeparam name="T"></typeparam>
    /// <returns>The unchanged source value.</returns>
    public static T? WhenNull<T>(this T? source, Action action)
    {
        if (source is null)
        {
            action();
        }

        return source;
    }

    /// <summary>
    /// Calls an async <c>action</c> if the source value is null.
    /// </summary>
    /// <param name="source">The source value.</param>
    /// <param name="action">The async action to be called if the value is null.</param>
    /// <typeparam name="T">The type of the source value.</typeparam>
    /// <returns>A task that returns the unchanged source value.</returns>
    public static async ValueTask<T?> WhenNullAsync<T>(this T? source, Func<ValueTask> action)
    {
        if (source is null)
        {
            await action();
        }

        return source;
    }

    /// <summary>
    /// Calls an async <c>action</c> if the output of the given task is null.
    /// </summary>
    /// <param name="getSourceTask">The task that returns a value.</param>
    /// <param name="action">The async action to be called if the value is null.</param>
    /// <typeparam name="T">The type of the source value.</typeparam>
    /// <returns>A task that returns the unchanged source value.</returns>
    public static async ValueTask<T?> WhenNullAsync<T>(this ValueTask<T?> getSourceTask, Func<ValueTask> action)
    {
        var source = await getSourceTask;
        if (source is null)
        {
            await action();
        }

        return source;
    }

    /// <summary>
    /// Calls an <c>action</c> if the output of the given task is null.
    /// </summary>
    /// <param name="getSourceTask">The task that returns a value.</param>
    /// <param name="action">The action to be called if the value is null.</param>
    /// <typeparam name="T">The type of the source value.</typeparam>
    /// <returns>A task that returns the unchanged source value.</returns>
    public static async ValueTask<T?> WhenNullAsync<T>(this ValueTask<T?> getSourceTask, Action action)
    {
        var source = await getSourceTask;
        if (source is null)
        {
            action();
        }

        return source;
    }
}