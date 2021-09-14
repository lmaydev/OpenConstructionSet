using System;

namespace OpenConstructionSet.Models
{
    public struct Vector4
    {
        public Single w, x, y, z;

        public Vector4(float w, float x, float y, float z)
        {
            this.w = w;
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}