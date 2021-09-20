using OpenConstructionSet.Models;
using System.Diagnostics.CodeAnalysis;

namespace OpenConstructionSet
{
    public interface IOcsModInfoService
    {
        string GetInfoFileName(string modPath);
        ModInfo? Read(string path, bool modPath = false);
        bool TryRead(string path, [MaybeNullWhen(false)] out ModInfo info, bool modPath = false);
        bool TryWrite(string path, ModInfo info, bool modPath = false);
        void Write(string path, ModInfo info, bool modPath = false);
    }
}