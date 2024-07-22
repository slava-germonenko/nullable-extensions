namespace SG.NullableExtensions;

public static partial class NullableExtensions
{
    /// <summary>
    /// Checks if the source value is null. If it's not, then it'll simply return the value.
    /// Otherwise, it'll return the specified <c>defaultValue</c>.
    /// </summary>
    /// <param name="source">The source possibly null value.</param>
    /// <param name="defaultValue">The default value to be used instead.</param>
    /// <typeparam name="T">The type of the source value.</typeparam>
    /// <returns>
    ///     Returns the value itself if it's defined. Otherwise, returns the <c>defaultValue</c>.
    /// </returns>
    public static T ValueOr<T>(this T? source, T defaultValue) => source ?? defaultValue;

    /// <summary>
    /// Checks if the source value is null. If it's not, then it'll simply return the value.
    /// Otherwise, it'll return the output of the factory <c>defaultValueFactory</c>.
    /// </summary>
    /// <param name="source">The source possibly null value.</param>
    /// <param name="defaultValueFactory">The factory that will be used to get an alternative value.</param>
    /// <typeparam name="T">The type of the source value.</typeparam>
    /// <returns>
    ///     Returns the value itself if it's defined.
    ///     Otherwise, returns the output of the factory <c>defaultValueFactory</c>.
    /// </returns>
    public static T ValueOr<T>(this T? source, Func<T> defaultValueFactory) => source ?? defaultValueFactory();
}