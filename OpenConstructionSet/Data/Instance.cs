namespace OpenConstructionSet.Data
{
    public class Instance
    {
        public Instance(Instance instance)
        {
            Id = instance.Id;
            TargetId = instance.TargetId;
            Position = instance.Position;
            Rotation = instance.Rotation;
            States = new(instance.States);
        }

        public Instance(string id, string targetId, Vector3 position, Vector4 rotation, IEnumerable<string> states)
        {
            this.Id = id;
            TargetId = targetId;
            Position = position;
            Rotation = rotation;
            States = new(states);
        }

        /// <summary>
        /// The instance's identifier.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The position of the instance.
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// The rotation of the instance.
        /// </summary>
        public Vector4 Rotation { get; set; }

        /// <summary>
        /// The attached states.
        /// </summary>
        public List<string> States { get; } = new();

        /// <summary>
        /// The StringId of the target <seealso cref="Item"/>.
        /// </summary>
        public string TargetId { get; set; }

        public void Delete() => TargetId = string.Empty;

        public override bool Equals(object? obj)
        {
            return obj is Instance instance &&
                   Id == instance.Id &&
                   Position.Equals(instance.Position) &&
                   Rotation.Equals(instance.Rotation) &&
                   TargetId == instance.TargetId &&
                   States.SequenceEqual(instance.States);
        }

        public override int GetHashCode()
        {
            var statesValue = new HashCode();

            States.ForEach(s => statesValue.Add(s));

            return HashCode.Combine(Id, Position, Rotation, TargetId, statesValue.ToHashCode());
        }

        public bool IsDeleted() => TargetId.Length == 0;
    }
}