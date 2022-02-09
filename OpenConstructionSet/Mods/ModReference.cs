namespace OpenConstructionSet.Mods
{
    public class ModReference : IReference
    {
        private readonly IModContext owner;

        /// <summary>
        /// Creates a <see cref="ModReference"/> from another.
        /// </summary>
        /// <param name="reference">The <see cref="Data.IReference"/> to copy.</param>
        internal ModReference(IModContext owner, Data.IReference reference)
        {
            TargetId = reference.TargetId;
            Value0 = reference.Value0;
            Value1 = reference.Value1;
            Value2 = reference.Value2;
            this.owner = owner;
        }

        /// <summary>
        /// Creates a new <see cref="ModReference"/> from the provided values.
        /// </summary>
        /// <param name="owner">The context this reference belongs to.</param>
        /// <param name="targetId">The <see cref="Item.StringId"/> of the target <see cref="Item"/>.</param>
        /// <param name="value0">The first value.</param>
        /// <param name="value1">The second value.</param>
        /// <param name="value2">The third value.</param>
        internal ModReference(IModContext owner, string targetId, int value0 = 0, int value1 = 0, int value2 = 0)
        {
            this.owner = owner;
            TargetId = targetId;
            Value0 = value0;
            Value1 = value1;
            Value2 = value2;
        }

        public string Key => TargetId;

        public ModItem? Target => owner.Items.TryGetValue(TargetId, out var target) ? target : null;

        /// <summary>
        /// The <see cref="IItem.StringId"/> of the target <see cref="ModItem"/>.
        /// </summary>
        public string TargetId { get; }

        /// <summary>
        /// The first value.
        /// </summary>
        public int Value0 { get; set; }

        /// <summary>
        /// The second value.
        /// </summary>
        public int Value1 { get; set; }

        /// <summary>
        /// The third value.
        /// </summary>
        public int Value2 { get; set; }
    }
}
