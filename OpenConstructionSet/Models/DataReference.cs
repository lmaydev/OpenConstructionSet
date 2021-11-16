﻿namespace OpenConstructionSet.Models;

/// <summary>
/// Represents the values assigned to a <see cref="Reference"/> in the game data files.
/// </summary>
/// <param name="Value0">Value 0</param>
/// <param name="Value1">Value 1</param>
/// <param name="Value2">Value 2</param>
public record DataReference : IEquatable<Reference>
{
    public DataReference(Reference reference)
    {
        Value0 = reference.Value0;
        Value1 = reference.Value1;
        Value2 = reference.Value2;
    }

    public DataReference(int value0, int value1, int value2)
    {
        Value0 = value0;
        Value1 = value1;
        Value2 = value2;
    }

    public int Value0 { get; set; }
    public int Value1 { get; set; }
    public int Value2 { get; set; }

    public bool Equals(Reference other) => Value0 == other.Value0 && Value1 == other.Value1 && Value2 == other.Value2;
}