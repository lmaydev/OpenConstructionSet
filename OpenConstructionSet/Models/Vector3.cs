using System;

namespace OpenConstructionSet.Models
{
    public struct Vector3
    {
        public float x, y, z;

        public Vector3(Single x, Single y, Single z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}