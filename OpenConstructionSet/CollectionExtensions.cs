namespace OpenConstructionSet;

/// <summary>
/// A collection of extensions for collections.
/// </summary>
public static class CollectionExtensions
{
    /// <summary>
    /// Filters a collection of <see cref="IItem"/>s by their type.
    /// </summary>
    /// <typeparam name="TItem">The concreate type of the <see cref="IItem"/>s in the collection.</typeparam>
    /// <param name="collection">The collection to filter.</param>
    /// <param name="itemType">The type to filter by.</param>
    /// <returns>All <see cref="IItem"/>s in <c>collection</c> of the matching <see cref="ItemType"/>.</returns>
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
