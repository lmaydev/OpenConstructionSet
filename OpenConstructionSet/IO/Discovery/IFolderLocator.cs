using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace OpenConstructionSet.IO.Discovery
{
    public interface IFolderLocator
    {
        string Id { get; }

        bool TryFind([MaybeNullWhen(false)] out DiscoveredFolders folders);
    }
}
