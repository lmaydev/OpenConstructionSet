using System.Collections.Generic;
using System.Linq;
using forgotten_construction_set;

namespace OpenConstructionSet
{
    public static class ItemExtensions
    {
        public static IEnumerable<GameData.Item> OfType(this IDictionary<string, GameData.Item> items, itemType type)
            => items.Values.Where(i => i.type == type);
    }
}