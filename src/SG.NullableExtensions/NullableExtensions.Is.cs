namespace SG.NullableExtensions;

public static partial class NullableExtensions
{
    /// <summary>
    /// Checks if a reference is not null and the value matches a predicate.
    /// </summary>
    /// <param name="source">A nullable value</param>
    /// <param name="predicate">The predicate to be run against the underlying value</param>
    /// <typeparam name="T">The type of the possible underlying value</typeparam>
    /// <returns>
    /// Returns true if the value is set and the predicate returns <c>true</c>.
    /// Otherwise, return <c>false</c>.
    /// </returns>
    public static bool Is<T>(this T? source, Predicate<T> predicate) where T : class
        => source is not null && predicate(source);

    /// <summary>
    /// Checks if the underlying value of a <see cref="Nullable{T}"/> is not null and matches a predicate.
    /// </summary>
    /// <param name="source">A nullable value</param>
    /// <param name="predicate">The predicate to be run against the underlying value</param>
    /// <typeparam name="T">The type of the possible underlying value</typeparam>
    /// <returns>
    /// Returns true if the value is set and the predicate returns <c>true</c>.
    /// Otherwise, return <c>false</c>.
    /// </returns>
    public static bool Is<T>(this T? source, Predicate<T> predicate) where T : struct
        => source.HasValue && predicate(source.Value);
}