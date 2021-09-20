using OpenConstructionSet.Collections;
using OpenConstructionSet.Data;
using OpenConstructionSet.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace OpenConstructionSet
{
    public static class CollectionExtensions
    {
        public static Entity New(this OcsRefDictionary<Entity> collection, string stringId, string name, ItemType type)
        {
            if (collection.ContainsKey(stringId))
            {
                throw new ArgumentException("Cannot add duplicate key");
            }

            if (TryRestoreAndClear(collection, stringId, out var item))
            {
                if (item.Type != type)
                {
                    collection.Remove(stringId);

                    throw new ArgumentException("Item type must be the same as in the base data", nameof(type));
                }

                return item;
            }

            item = new Entity(type, stringId, name);

            collection.items[item.StringId] = item;

            return item;
        }

        public static OcsDictionary<ReferenceValues> New(this OcsRefDictionary<OcsDictionary<ReferenceValues>> collection, string category)
        {
            if (collection.ContainsKey(category))
            {
                throw new ArgumentException("Cannot add duplicate key");
            }

            if (TryRestoreAndClear(collection, category, out var item))
            {
                return item;
            }

            item = new();

            collection.items[category] = item;

            return item;
        }

        private static bool TryRestoreAndClear<T>(OcsRefDictionary<T> collection, string key, [MaybeNullWhen(false)] out T item)
            where T : class, IClearable
        {
            if (collection.items.Removed.TryGetValue(key, out var removedItem))
            {
                removedItem.Clear();

                collection.items[key] = removedItem;

                item = removedItem;
                return true;
            }

            item = default;

            return false;
        }

        public static IEnumerable<Entity> OfType(this IEnumerable<Entity> collection, ItemType type) => collection.Where(e => e.Type == type);
        internal static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }
    }
}
