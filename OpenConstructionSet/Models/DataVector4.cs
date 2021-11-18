namespace OpenConstructionSet.Models;

public record class DataVector4 : IEquatable<Vector4>
{
    public float W { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public DataVector4()
    {
    }

    public DataVector4(Vector4 value) : this(value.W, value.X, value.Y, value.Z)
    {
    }

    public DataVector4(float w, float x, float y, float z)
    {
        W = w;
        X = x;
        Y = y;
        Z = z;
    }

    public bool Equals(Vector4 other) => W == other.W && X == other.X && Y == other.Y && Z == other.Z;
}
