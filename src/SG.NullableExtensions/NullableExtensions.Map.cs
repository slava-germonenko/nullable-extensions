namespace SG.NullableExtensions;

public static partial class NullableExtensions
{
    /// <summary>
    /// Maps a nullable value if defined using a map function.
    /// <code>
    /// var token = userService.GetUserOrNull(id)
    ///     .Map(user => tokenService.GenerateToken(user));
    /// </code>
    /// </summary>
    /// <param name="source">The source value to be mapped.</param>
    /// <param name="map">The map function.</param>
    /// <typeparam name="TSource">The type of the source value.</typeparam>
    /// <typeparam name="TResult">The type of the output.</typeparam>
    /// <returns>
    ///     Returns the result of the <c>map</c> function if the source value id defined.
    ///     Otherwise, returns <c>null</c>.
    /// </returns>
    public static TResult? Map<TSource, TResult>(this TSource? source, Func<TSource, TResult> map) where TResult : class
        => source is null ? null : map(source);
}