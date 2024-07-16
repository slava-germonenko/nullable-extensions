namespace SG.NullableExtensions;

public static partial class NullableExtensions
{
    public static bool Is<T>(this T? source, T compareValue) where T : class
        => source is not null && source == compareValue;

    public static bool Is<T>(this T? source, T compareValue) where T : struct
        => source is not null && source.Value == compareValue;

    public static bool Is<T>(this T? source, Predicate<T> predicate)
        => source is not null && predicate(source);
}