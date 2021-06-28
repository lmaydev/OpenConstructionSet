using forgotten_construction_set;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConstructionSet.Models
{
    public class ItemReference
    {
        public string Id { get; set; }

        public ReferenceValues Values { get; set; }

        public ItemReference()
        {
        }

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
