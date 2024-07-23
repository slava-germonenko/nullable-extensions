namespace SG.NullableExtensions;

public static partial class NullableExtensions
{
    /// <summary>
    /// Maps a value if it is defined. Otherwise, returns null.
    /// </summary>
    /// <param name="source">The source value to be mapped.</param>
    /// <param name="map">The map function.</param>
    /// <typeparam name="TSource">The type of the source value.</typeparam>
    /// <typeparam name="TResult">The type of the output.</typeparam>
    /// <returns>
    /// Returns the result of the <c>map</c> function if the source value id defined.
    /// Otherwise, returns <c>null</c>.
    /// </returns>
    public static TResult? Map<TSource, TResult>(this TSource? source, Func<TSource, TResult> map)
        where TSource : class where TResult : class
        => source is null ? null : map(source);

    /// <summary>
    /// Maps the underlying value of a <see cref="Nullable{T}"/>. Otherwise, returns null.
    /// </summary>
    /// <param name="source">The source value to be mapped.</param>
    /// <param name="map">The map function.</param>
    /// <typeparam name="TSource">The type of the source value.</typeparam>
    /// <typeparam name="TResult">The type of the output.</typeparam>
    /// <returns>
    /// Returns the result of the <c>map</c> function if the source value id defined.
    /// Otherwise, returns <c>null</c>.
    /// </returns>
    public static TResult? Map<TSource, TResult>(this TSource? source, Func<TSource, TResult> map)
        where TSource : struct where TResult : struct
        => source.HasValue ? map(source.Value) : null;
}