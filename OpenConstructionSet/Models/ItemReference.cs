using forgotten_construction_set;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConstructionSet.Models
{
    /// <summary>
    /// Represents a reference to another <c>GameData.Item</c>.
    /// </summary>
    public class ItemReference
    {
        /// <summary>
        /// The ID of the item being referenced.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The 3 values associated with this reference.
        /// </summary>
        public ReferenceValues Values { get; set; }

        /// <summary>
        /// Create an empty object.
        /// </summary>
        public ItemReference()
        {
        }

        /// <summary>
        /// Create based on the provided <c>GameData.Reference</c>.
        /// </summary>
        /// <param name="reference">The source <c>GameData.Reference</c>.</param>
        public ItemReference(GameData.Reference reference)
        {
            if (reference is null)
            {
                throw new ArgumentNullException(nameof(reference));
            }

            Id = reference.itemID;
            Values = new ReferenceValues(reference.Values);
        }
    }
}
