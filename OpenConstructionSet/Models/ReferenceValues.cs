using forgotten_construction_set;

namespace OpenConstructionSet.Models
{
    /// <summary>
    /// Representation of the three values associated with a reference.
    /// </summary>
    public class ReferenceValues
    {
        /// <summary>
        /// Value 0.
        /// </summary>
        public int Value0 { get; set; }

        /// <summary>
        /// Value 1.
        /// </summary>
        public int Value1 { get; set; }

        /// <summary>
        /// Value 2.
        /// </summary>
        public int Value2 { get; set; }

        /// <summary>
        /// Create an empty object.
        /// </summary>
        public ReferenceValues()
        {
        }

        /// <summary>
        /// Retrieve the values from a <c>TripleInt</c> object.
        /// </summary>
        /// <param name="value"><c>TripleInt</c> object to take values from.</param>
        public ReferenceValues(GameData.TripleInt value)
        {
            Value0 = value.v0;
            Value1 = value.v1;
            Value2 = value.v2;
        }
    }
}