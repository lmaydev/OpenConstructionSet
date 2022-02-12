namespace OpenConstructionSet;

/// <summary>
/// A collection of extensions for collections.
/// </summary>
public static class CollectionExtensions
{
    public static IEnumerable<TItem> OfType<TItem>(this IEnumerable<TItem> collection, ItemType itemType)
        where TItem : IItem
        => collection.Where(i => i.Type == itemType);

    internal static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            collection.Add(item);
        }
    }

    internal static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        foreach (var item in collection)
        {
            action(item);
        }
    }
}
