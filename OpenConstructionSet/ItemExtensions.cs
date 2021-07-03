using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using forgotten_construction_set;
using OpenConstructionSet.Models;

namespace OpenConstructionSet
{
    /// <summary>
    /// Collection of extensaion methods to help when working with <c>GameData.Item</c>s.
    /// </summary>
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
        /// <param name="items">Dictionary of <see cref="ItemModel"/>s to filter.</param>
        /// <param name="type">The type used to filter the <see cref="ItemModel"/>s.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="ItemModel"/>s with the given type.</returns>
        public static IEnumerable<ItemModel> OfType(this IDictionary<string, ItemModel> items, itemType type)
            => items.Values.OfType(type);


        /// <summary>
        /// Returns all items of the specified type.
        /// </summary>
        /// <param name="items">Collection of <c>GameData.Item</c>s to filter.</param>
        /// <param name="type">The type used to filter the <c>GameData.Item</c>s.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <c>GameData.Item</c>s with the given type.</returns>
        public static IEnumerable<GameData.Item> OfType(this IEnumerable<GameData.Item> items, itemType type)
            => items.Where(i => i.type == type);

        /// <summary>
        /// Returns all items of the specified type.
        /// </summary>
        /// <param name="items">Collection of <see cref="ItemModel"/>s to filter.</param>
        /// <param name="type">The type used to filter the <see cref="ItemModel"/>s.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="ItemModel"/>s with the given type.</returns>
        public static IEnumerable<ItemModel> OfType(this IEnumerable<ItemModel> items, itemType type)
            => items.Where(i => i.Type == type);


        private readonly static FieldInfo itemData = typeof(GameData.Item).GetField("data", BindingFlags.Instance | BindingFlags.NonPublic);
        private readonly static FieldInfo itemLocked = typeof(GameData.Item).GetField("lockedData", BindingFlags.Instance | BindingFlags.NonPublic);
        private readonly static FieldInfo itemMod = typeof(GameData.Item).GetField("modData", BindingFlags.Instance | BindingFlags.NonPublic);
        private readonly static FieldInfo itemReferences = typeof(GameData.Item).GetField("references", BindingFlags.Instance | BindingFlags.NonPublic);

        /// <summary>
        /// Converts the <c>GameData.Item</c>s to <see cref="ItemModel"/>s.
        /// </summary>
        /// <param name="items">The <c>GameData.Item</c>s to convert.</param>
        /// <returns>Collection of <see cref="ItemModel"/>s.</returns>
        public static IEnumerable<ItemModel> ToModels(this IEnumerable<GameData.Item> items)
        {
            foreach (var item in items)
            {
                yield return item.ToModel();
            }
        }

        /// <summary>
        /// Converts the <c>GameData.Item</c> to  an <see cref="ItemModel"/>.
        /// </summary>
        /// <param name="item">The <c>GameData.Item</c> to convert.</param>
        /// <returns>Collection of <see cref="ItemModel"/>s.</returns>
        public static ItemModel ToModel(this GameData.Item item)
        {
            return new ItemModel
            {
                Id = item.id,
                HasInstances = item.HasInstances,
                Type = item.type,
                Mod = item.Mod,
                ModName = item.ModName,
                Name = item.Name,
                OriginalName = item.OriginalName,
                RefCount = item.refCount,
                StringId = item.stringID,
                Values = GetValues(),
                References = GetReferences(),
            };

            IDictionary<string, object> GetValues()
            {
                var data = (IDictionary<string, object>)itemData.GetValue(item);

                var values = new Dictionary<string, object>(data);

                var mod = (IDictionary<string, object>)itemMod.GetValue(item);

                foreach (var pair in mod)
                {
                    values[pair.Key] = pair.Value;
                }

                var locked = (IDictionary<string, object>)itemLocked.GetValue(item);

                foreach (var pair in locked)
                {
                    values[pair.Key] = pair.Value;
                }

                return data;
            }

            IDictionary<string, IList<ItemReference>> GetReferences()
            {
                var referenceDictionary = (IDictionary<string, ArrayList>)itemReferences.GetValue(item);

                var references = new Dictionary<string, IList<ItemReference>>();

                foreach (var pair in referenceDictionary)
                {
                    references[pair.Key] = new List<ItemReference>();

                    foreach (var value in pair.Value.OfType<GameData.Reference>())
                    {
                        references[pair.Key].Add(new ItemReference(value));
                    }
                }

                return references;
            }
        }
    }
}