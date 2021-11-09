
namespace OpenConstructionSet;

/// <summary>
/// Used to build game data consisting of multiple mod files.
/// </summary>
public interface IOcsDataBuilder
{
    /// <summary>
    /// Build game data using the provided options.
    /// </summary>
    /// <param name="options">Contains the information required to build the game data.</param>
    /// <returns>The game data built from the provided options.</returns>
    DataFile Build(OcsDataOptions options);
}