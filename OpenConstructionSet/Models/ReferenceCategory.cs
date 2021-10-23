using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConstructionSet.Models;

public sealed record ReferenceCategory(string Name, ReferenceCollection References)
{
    public ReferenceCategory(ReferenceCategory original)
    {
        Name = original.Name;

        References = new(original.References.Select(r => r with { }));
    }
}
