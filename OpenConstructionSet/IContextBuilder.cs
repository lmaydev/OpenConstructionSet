using OpenConstructionSet.Mods.Context;

namespace OpenConstructionSet;

public interface IContextBuilder
{
    Task<IModContext> BuildAsync(ModContextOptions options);
}