namespace SG.NullableExtensions;

/// <summary>
/// A container for sync extension methods for nullable types.
/// </summary>
public static partial class NullableExtensions
{
    /// <summary>
    /// Calls an <c>action</c> if a reference is not null and the value matches a predicate.
    /// </summary>
    /// <param name="source">An object to make action against.</param>
    /// <param name="action">An action to be made against the object.</param>
    /// <typeparam name="T">Type of the object.</typeparam>
    /// <returns>The unchanged source value.</returns>
    public static T? Inspect<T>(this T? source, Action<T> action) where T : class
    {
        if (source is not null)
        {
            action(source);
        }

        return source;
    }

    /// <summary>
    /// Calls an <c>action</c> if the underlying value of a <see cref="Nullable{T}"/> is not null.
    /// </summary>
    /// <param name="source">An object to make action against.</param>
    /// <param name="action">An action to be made against the object.</param>
    /// <typeparam name="T">Type of the object.</typeparam>
    /// <returns>The unchanged source value.</returns>
    public static T? Inspect<T>(this T? source, Action<T> action) where T : struct
    {
        if (source.HasValue)
        {
            action(source.Value);
        }

        return source;
    }
}