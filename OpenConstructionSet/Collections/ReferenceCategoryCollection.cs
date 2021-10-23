using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConstructionSet.Collections;

public class ReferenceCategoryCollection : OcsCollection<ReferenceCategory>
{
    public ReferenceCategoryCollection()
    {
    }

    public ReferenceCategoryCollection(IEnumerable<ReferenceCategory> collection) : base(collection)
    {
    }

    protected override string GetId(ReferenceCategory item) => item.Name;
}
