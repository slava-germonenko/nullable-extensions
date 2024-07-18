namespace SG.NullableExtensions;

public static partial class NullableExtensions
{
    /// <summary>
    /// Calls the <see cref="action"/> delegate if <see cref="source"/> is not null.
    /// </summary>
    /// <param name="source">An object to make action against.</param>
    /// <param name="action">An action to be made against the object.</param>
    /// <typeparam name="T">Type of the object.</typeparam>
    public static T? Do<T>(this T? source, Action<T> action)
    {
        if (source is not null)
        {
            action(source);
        }

        return source;
    }

    /// <summary>
    /// Calls the async <see cref="action"/> delegate if <see cref="source"/> is not null.
    /// </summary>
    /// <param name="source">An object to make action against.</param>
    /// <param name="action">An async action to be made against the object.</param>
    /// <typeparam name="T">Type of the object.</typeparam>
    public static async ValueTask<T?> DoAsync<T>(this T? source, Func<T, ValueTask> action)
    {
        if (source is not null)
        {
            await action(source);
        }

        return source;
    }

    /// <summary>
    /// Calls the async <see cref="action"/> delegate if the output of <see cref="getSourceTask"/> is not null.
    /// </summary>
    /// <param name="getSourceTask">A task that returns a nullable value.</param>
    /// <param name="action">An async action to be made against the object.</param>
    /// <typeparam name="T">Type of the object.</typeparam>
    public static async ValueTask<T?> DoAsync<T>(this ValueTask<T?> getSourceTask, Func<T, ValueTask> action)
    {
        var source = await getSourceTask;
        if (source is not null)
        {
            await action(source);
        }

        return source;
    }
}