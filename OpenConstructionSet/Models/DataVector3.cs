using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConstructionSet.Models;

public record class DataVector3 : IEquatable<Vector3>
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public DataVector3()
    {
    }

    public DataVector3(Vector3 value) : this(value.X, value.Y, value.Z)
    {
    }

    public DataVector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public bool Equals(Vector3 other) => X == other.X && Y == other.Y && Z == other.Z;
}
