namespace SG.NullableExtensions;

public static partial class NullableExtensions
{
    /// <summary>
    /// Calls the <see cref="tapAction"/> delegate if <see cref="source"/> is defined.
    /// </summary>
    /// <param name="source">An object to make action against.</param>
    /// <param name="tapAction">An action to be made against the object.</param>
    /// <typeparam name="T">Type of the object.</typeparam>
    public static void Tap<T>(this T? source, Action<T> tapAction)
    {
        if (source is not null)
        {
            tapAction(source);
        }
    }
}