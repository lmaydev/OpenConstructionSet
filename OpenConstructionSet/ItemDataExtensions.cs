using System.Collections.Generic;
using System.Linq;
using forgotten_construction_set;

namespace OpenConstructionSet
{
    public static class ItemExtensions
    {
        /// <summary>
        /// Returns all items of the specified type.
        /// </summary>
        /// <param name="items">Dictionary of <c>GameData.Item</c>s to filter.</param>
        /// <param name="type">The type used to filter the <c>GameData.Item</c>s.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <c>GameData.Item</c>s with the given type.</returns>
        public static IEnumerable<GameData.Item> OfType(this IDictionary<string, GameData.Item> items, itemType type)
            => items.Values.OfType(type);

        /// <summary>
        /// Returns all items of the specified type.
        /// </summary>
        /// <param name="items">Collection of <c>GameData.Item</c>s to filter.</param>
        /// <param name="type">The type used to filter the <c>GameData.Item</c>s.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <c>GameData.Item</c>s with the given type.</returns>
        public static IEnumerable<GameData.Item> OfType(this IEnumerable<GameData.Item> items, itemType type)
            => items.Where(i => i.type == type);
    }
}