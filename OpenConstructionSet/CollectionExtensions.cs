namespace OpenConstructionSet;

public static class CollectionExtensions
{
    public static IEnumerable<Entity> OfType(this IEnumerable<Entity> collection, ItemType type) => collection.Where(e => e.Type == type);
    internal static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        foreach (var item in collection)
        {
            action(item);
        }
    }
}
