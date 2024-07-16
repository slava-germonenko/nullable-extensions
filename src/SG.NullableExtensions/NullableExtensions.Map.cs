namespace SG.NullableExtensions;

public static partial class NullableExtensions
{
    public static TResult? Map<TSource, TResult>(this TSource? source, Func<TSource, TResult> map) where TResult : class
        => source is null ? null : map(source);

    public static TResult? Map<TSource, TResult>(this TSource? source, Func<TSource, TResult> map)
        where TSource : struct
        where TResult : struct
        => source is null ? null : map(source.Value);

    public static ValueTask<TResult?> MapAsync<TSource, TResult>(
        this TSource? source,
        Func<TSource, ValueTask<TResult?>> map
    ) where TResult : class
        => source is null ? ValueTask.FromResult<TResult?>(null) : map(source);
}