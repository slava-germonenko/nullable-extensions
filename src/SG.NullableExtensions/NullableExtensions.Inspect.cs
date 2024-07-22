namespace SG.NullableExtensions;

/// <summary>
/// A container for sync extension methods for nullable types.
/// </summary>
public static partial class NullableExtensions
{
    /// <summary>
    /// Calls an <c>action</c> if the source value is not null.
    /// <code>
    /// var product = products.FirstOrDefault(p => p.Code == Code);
    /// // This is called only if the product is not null.
    /// product.Inspect(product => product.UpdatedDate = DateTime.NowUtc);
    /// </code>
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
}