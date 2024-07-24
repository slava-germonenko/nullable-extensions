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
}