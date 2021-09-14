using System;

namespace OpenConstructionSet.Models
{
    public struct ReferenceValues
    {
        public int value0, value1, value2;

        public ReferenceValues(Int32 value0, Int32 value1, Int32 value2)
        {
            this.value0 = value0;
            this.value1 = value1;
            this.value2 = value2;
        }

        public static ReferenceValues Deleted { get; } = new(int.MaxValue, int.MinValue, int.MaxValue);
    }
}