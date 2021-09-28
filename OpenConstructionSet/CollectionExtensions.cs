namespace OpenConstructionSet;

public static class CollectionExtensions
{
    public static IEnumerable<Item> OfType(this IDictionary<string, Item> collection, ItemType type) => collection.Values.Where(i => i.Type == type);

    internal static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        foreach (var item in collection)
        {
            action(item);
        }
    }
}
