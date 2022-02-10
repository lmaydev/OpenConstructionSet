using OpenConstructionSet.Mods;

namespace OpenConstructionSet;

/// <summary>
/// A collection of extensions for collections.
/// </summary>
public static class CollectionExtensions
{
    /// <summary>
    /// Returns all <see cref="Item"/>s of the given <see cref="ItemType"/> from the collection.
    /// </summary>
    /// <param name="collection">A collection of <see cref="Item"/>s to filter.</param>
    /// <param name="type">The type of <see cref="Item"/> to return.</param>
    /// <returns>All <see cref="Item"/>s from the collection with the given type.</returns>
    public static IEnumerable<Item> OfType(this IEnumerable<Item> collection, ItemType type) => collection.Where(i => i.Type == type);

    /// <summary>
    /// Returns all <see cref="Item"/>s of the given <see cref="ItemType"/> from the collection.
    /// </summary>
    /// <param name="dictionary">A dictionary of <see cref="Item"/>s to filter.</param>
    /// <param name="type">The type of <see cref="Item"/> to return.</param>
    /// <returns>All <see cref="Item"/>s from the collection with the given type.</returns>
    public static IEnumerable<KeyValuePair<string, Item>> OfType(this IDictionary<string, Item> dictionary, ItemType type) => dictionary.Where(p => p.Value.Type == type);

    /// <summary>
    /// Returns all <see cref="Item"/>s of the given <see cref="ItemType"/> from the collection.
    /// </summary>
    /// <param name="collection">A collection of <see cref="Item"/>s to filter.</param>
    /// <param name="type">The type of <see cref="Item"/> to return.</param>
    /// <returns>All <see cref="Item"/>s from the collection with the given type.</returns>
    public static IEnumerable<ModItem> OfType(this IEnumerable<ModItem> collection, ItemType type) => collection.Where(i => i.Type == type);

    /// <summary>
    /// Returns all <see cref="Item"/>s of the given <see cref="ItemType"/> from the collection.
    /// </summary>
    /// <param name="dictionary">A dictionary of <see cref="Item"/>s to filter.</param>
    /// <param name="type">The type of <see cref="Item"/> to return.</param>
    /// <returns>All <see cref="Item"/>s from the collection with the given type.</returns>
    public static IEnumerable<KeyValuePair<string, ModItem>> OfType(this IDictionary<string, ModItem> dictionary, ItemType type) => dictionary.Where(p => p.Value.Type == type);

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
