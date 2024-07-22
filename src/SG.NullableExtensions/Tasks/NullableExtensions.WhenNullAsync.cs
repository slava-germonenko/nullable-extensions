namespace SG.NullableExtensions.Tasks;

public static partial class NullableExtensions
{
    /// <summary>
    /// Calls an async function if the given source value is null.
    /// </summary>
    /// <param name="source">The source value to be checked.</param>
    /// <param name="asyncAction">The async action to be called.</param>
    /// <typeparam name="T">The type of the source value.</typeparam>
    /// <returns>The unchanged source value.</returns>
    public static async Task<T?> WhenNullAsync<T>(this T? source, Func<Task> asyncAction) where T : class
    {
        if (source is null)
        {
            await asyncAction();
        }

        return source;
    }

    /// <summary>
    /// Calls an async function if the given <see cref="Nullable{T}"/> has value unset.
    /// </summary>
    /// <param name="source">The source value to be checked.</param>
    /// <param name="asyncAction">The async action to be called.</param>
    /// <typeparam name="T">The type of the source value.</typeparam>
    /// <returns>The unchanged source value.</returns>
    public static async Task<T?> WhenNullAsync<T>(this T? source, Func<Task> asyncAction) where T : struct
    {
        if (source is null)
        {
            await asyncAction();
        }

        return source;
    }

    /// <summary>
    /// Calls an async action if the output of the <see cref="Task{T}"/> is null.
    /// </summary>
    /// <param name="sourceTask">The source task used to get a source value.</param>
    /// <param name="asyncAction">The async action.</param>
    /// <typeparam name="T">The type of the source value.</typeparam>
    /// <returns>The unchanged output of the given <see cref="Task{T}"/></returns>
    public static async Task<T?> WhenNullAsync<T>(
        this Task<T?> sourceTask,
        Func<Task> asyncAction
    ) where T : class
    {
        var value = await sourceTask;
        if (value is null)
        {
            await asyncAction();
        }

        return value;
    }

    /// <summary>
    /// Calls an async action if the output of the <see cref="Task{T}"/> is null.
    /// </summary>
    /// <param name="sourceTask">The source task used to get a source value.</param>
    /// <param name="asyncAction">The async action.</param>
    /// <typeparam name="T">The type of the source value.</typeparam>
    /// <returns>The unchanged output of the given <see cref="Task{T}"/></returns>
    public static async Task<T?> WhenNullAsync<T>(
        this Task<T?> sourceTask,
        Func<Task> asyncAction
    ) where T : struct
    {
        var value = await sourceTask;
        if (value is null)
        {
            await asyncAction();
        }

        return value;
    }
}