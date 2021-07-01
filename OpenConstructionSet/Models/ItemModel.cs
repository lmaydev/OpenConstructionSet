using forgotten_construction_set;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConstructionSet.Models
{
    public class ItemModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string OriginalName { get; set; }

        public itemType Type { get; set; }

        public string Mod { get; set; }

        public int RefCount { get; set; }

        public string StringId { get; set; }

        public string ModName { get; set; }

        public bool HasInstances {  get; set; }

        public IDictionary<string, object> Values { get; set; }

        public IDictionary<string, IList<ItemReference>> References { get; set; }
    }
}
