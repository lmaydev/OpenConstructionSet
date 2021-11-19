using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConstructionSet.Models;

/// <summary>
/// Editable representation of a Vector3.
/// </summary>
public record class DataVector3 : IEquatable<Vector3>
{
    /// <summary>
    /// The X value.
    /// </summary>
    public float X { get; set; }

    /// <summary>
    /// The Y value.
    /// </summary>
    public float Y { get; set; }

    /// <summary>
    /// The Z value.
    /// </summary>
    public float Z { get; set; }

    /// <summary>
    /// Create a zeroed <c>DataVector3</c>.
    /// </summary>
    public DataVector3()
    {
    }

    /// <summary>
    /// Creates a new <c>DataVector3</c> from the provided values.
    /// </summary>
    /// <param name="value"><c>Vector3</c> whose values will be used.</param>
    public DataVector3(Vector3 value) : this(value.X, value.Y, value.Z)
    {
    }

    /// <summary>
    /// Create <c>DataVector3</c> with the provided values.
    /// </summary>
    /// <param name="x">The X value.</param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    public DataVector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    /// <summary>
    /// Determines if the other item is equal to this.
    /// </summary>
    /// <param name="other">Item to compare to this.</param>
    /// <returns><c>true</c> if this and the other item are equal.</returns>
    public bool Equals(Vector3 other) => X == other.X && Y == other.Y && Z == other.Z;
}
