namespace OpenConstructionSet.Models;

/// <summary>
/// Represents a reference from a game data files.
/// </summary>
/// <param name="TargetId">The StringId of the item being referenced</param>
/// <param name="Values">The values assigned to this reference.</param>
/// <param name="Category">The category of this reference.</param>
public sealed record Reference(string TargetId, ReferenceValues Values, string Category)
{
    private string? key = null;

    /// <summary>
    /// Lazy initialised key.
    /// To identify a reference you need combine TargetId and Category.
    /// </summary>
    public string Key => key ??= Category + TargetId;
}