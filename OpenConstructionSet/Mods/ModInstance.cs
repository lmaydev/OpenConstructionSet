namespace OpenConstructionSet.Mods
{
    public class ModInstance : IInstance
    {
        private readonly IModContext owner;

        /// <summary>
        /// Creates a new <see cref="ModInstance"/> from another.
        /// </summary>
        /// <param name="instance">The <see cref="IInstance"/> to copy.</param>
        public ModInstance(IModContext owner, IInstance instance)
        {
            Id = instance.Id;
            TargetId = instance.TargetId;
            Position = instance.Position;
            Rotation = instance.Rotation;
            States = new(instance.States);
            this.owner = owner;
        }

        /// <summary>
        /// Creates a new <see cref="ModInstance"/> from the provided data.
        /// </summary>
        /// <param name="id">The identifier for the <see cref="ModInstance"/>.</param>
        /// <param name="targetId">The <see cref="IItem.StringId"/> of the targeted <see cref="IItem"/>.</param>
        /// <param name="position">The <see cref="ModInstance"/>'s position.</param>
        /// <param name="rotation">The <see cref="ModInstance"/>'s rotation.</param>
        /// <param name="states">A collection of states for the <see cref="ModInstance"/>.</param>
        public ModInstance(IModContext owner, string id, string targetId, Vector3 position, Vector4 rotation, IEnumerable<string> states)
        {
            this.owner = owner;
            this.Id = id;
            TargetId = targetId;
            Position = position;
            Rotation = rotation;
            States = new(states);
        }

        /// <summary>
        /// The <see cref="ModInstance"/>'s identifier.
        /// </summary>
        public string Id { get; }

        public string Key => Id;

        /// <summary>
        /// The <see cref="ModInstance"/>'s position.
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// The <see cref="ModInstance"/>'s rotation.
        /// </summary>
        public Vector4 Rotation { get; set; }

        /// <summary>
        /// A collection of states for the <see cref="ModInstance"/>.
        /// </summary>
        public List<string> States { get; } = new();

        public ModItem? Target => owner.Items.TryGetValue(TargetId, out var target) ? target : null;

        /// <summary>
        /// The <see cref="Item.StringId"/> of the targeted <see cref="Item"/>.
        /// </summary>
        public string TargetId { get; set; }
    }
}
