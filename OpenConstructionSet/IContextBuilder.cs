using OpenConstructionSet.Mods.Context;

namespace OpenConstructionSet;

/// <summary>
/// Builder used when creating FCS like mod contexts.
/// </summary>
public interface IContextBuilder
{
    /// <summary>
    /// Build a <see cref="IModContext"/> from the provided <see cref="ModContextOptions"/>.
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    Task<IModContext> BuildAsync(ModContextOptions options);
}
