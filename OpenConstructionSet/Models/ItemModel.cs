using forgotten_construction_set;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConstructionSet.Models
{
    /// <summary>
    /// POCO representation of <c>GameData.Item</c>.
    /// </summary>
    public class ItemModel
    {
        /// <summary>
        /// The item's ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The item's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The item's original name.
        /// </summary>
        public string OriginalName { get; set; }

        /// <summary>
        /// The item's type.
        /// </summary>
        public itemType Type { get; set; }

        /// <summary>
        /// The mod that owns this item.
        /// </summary>
        public string Mod { get; set; }

        /// <summary>
        /// The reference count (I guess).
        /// </summary>
        public int RefCount { get; set; }

        /// <summary>
        /// The item's string ID (used when referencing)
        /// </summary>
        public string StringId { get; set; }

        /// <summary>
        /// I think it's the item's name in the current mod.
        /// </summary>
        public string ModName { get; set; }

        /// <summary>
        /// Whether or not the item has instances?
        /// </summary>
        public bool HasInstances {  get; set; }

        /// <summary>
        /// Values attached to the item.
        /// </summary>
        public IDictionary<string, object> Values { get; set; }

        /// <summary>
        /// Collection of references.
        /// </summary>
        public IDictionary<string, IList<ItemReference>> References { get; set; }
    }
}
