namespace OpenConstructionSet.Models;

/// <summary>
/// Represents a reference from a game data files.
/// </summary>
/// <param name="TargetId">The StringId of the item being referenced</param>
/// <param name="Values">The values assigned to this reference.</param>
public sealed record Reference(string TargetId, ReferenceValues Values);