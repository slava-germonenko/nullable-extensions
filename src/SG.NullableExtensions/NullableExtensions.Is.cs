namespace SG.NullableExtensions;

public static partial class NullableExtensions
{
    /// <summary>
    /// Checks if the underlying value is not null and matches a predicate.
    /// <code>
    /// // true if the user is not null and the email addresses are equal.
    /// var credentialsAreCorrect = users.FirstOrDefault(u => u.EmailAddress == emailAddress)
    ///     .Is(u => u.PasswordHash == passwordHash);
    /// </code>
    /// </summary>
    /// <param name="source">A nullable value</param>
    /// <param name="predicate">The predicate to be run against the underlying value</param>
    /// <typeparam name="T">The type of the possible underlying value</typeparam>
    /// <returns>
    ///     Returns true if the value is set and the predicate returns <c>true</c>.
    ///     Otherwise, return <c>false</c>.
    /// </returns>
    public static bool Is<T>(this T? source, Predicate<T> predicate)
        => source is not null && predicate(source);
}