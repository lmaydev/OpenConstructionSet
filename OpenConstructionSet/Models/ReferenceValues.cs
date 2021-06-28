using forgotten_construction_set;

namespace OpenConstructionSet.Models
{
    public class ReferenceValues
    {
        public int Value0 { get; set; }

        public int Value1 { get; set; }

        public int Value2 { get; set; }

        public ReferenceValues()
        {
        }

        public ReferenceValues(GameData.TripleInt value)
        {
            Value0 = value.v0;
            Value1 = value.v1;
            Value2 = value.v2;
        }
    }
}