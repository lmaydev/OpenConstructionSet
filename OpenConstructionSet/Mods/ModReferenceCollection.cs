using LMay.Collections;

namespace OpenConstructionSet.Mods
{
    public class ModInstanceCollection : KeyedItemList<string, ModInstance>
    {
        private readonly IModContext owner;

        public ModInstanceCollection(IModContext owner)
        {
            this.owner = owner;
        }

        public ModInstanceCollection(IModContext owner, IEqualityComparer<string> comparer) : base(comparer)
        {
            this.owner = owner;
        }

        public ModInstanceCollection(IModContext owner, IEnumerable<ModInstance> collection) : this(owner, collection, EqualityComparer<string>.Default)
        {
            this.owner = owner;
        }

        public ModInstanceCollection(IModContext owner, IEnumerable<ModInstance> collection, IEqualityComparer<string> comparer)
            : base(collection.Select(i => new ModInstance(owner, i)), comparer)
        {
            this.owner = owner;
        }

        public void Add(IInstance instance) => Add(new ModInstance(owner, instance));

        public override void Add(ModInstance item) => Add(new ModInstance(owner, item));

        private void Add(ModInstance instance) => base.Add(instance);
    }

    public class ModReferenceCategoryCollection : SortedKeyedItemCollection<string, ModReferenceCategory>
    {
        private readonly IModContext owner;

        public ModReferenceCategoryCollection(IModContext owner)
        {
            this.owner = owner;
        }

        public ModReferenceCategoryCollection(IModContext owner, IComparer<string>? comparer) : base(comparer)
        {
            this.owner = owner;
        }

        public ModReferenceCategoryCollection(IModContext owner, IEnumerable<IReferenceCategory> collection) : this(owner, collection, null)
        {
        }

        public ModReferenceCategoryCollection(IModContext owner, IEnumerable<IReferenceCategory> collection, IComparer<string>? comparer) :
            base(collection.Select(r => new ModReferenceCategory(owner, r)), comparer)
        {
            this.owner = owner;
        }

        public void Add(IReferenceCategory reference) => base.Add(new ModReferenceCategory(owner, reference));

        public override void Add(ModReferenceCategory item) => Add(item);

        public void Add(string name) => base.Add(new ModReferenceCategory(owner, name));
    }

    public class ModReferenceCollection : SortedKeyedItemCollection<string, ModReference>
    {
        private readonly IModContext owner;

        public ModReferenceCollection(IModContext owner)
        {
            this.owner = owner;
        }

        public ModReferenceCollection(IModContext owner, IComparer<string>? comparer) : base(comparer)
        {
            this.owner = owner;
        }

        public ModReferenceCollection(IModContext owner, IEnumerable<ModReference> collection) : this(owner, collection, null)
        {
        }

        public ModReferenceCollection(IModContext owner, IEnumerable<ModReference> collection, IComparer<string>? comparer) :
            base(collection.Select(r => new ModReference(owner, r)), comparer)
        {
            this.owner = owner;
        }

        public void Add(IReference reference) => Add(new ModReference(owner, reference));

        public override void Add(ModReference item) => Add(new ModReference(owner, item));

        public void Add(string targetId, int value0 = 0, int value1 = 0, int value2 = 0) => Add(new ModReference(owner, targetId, value0, value1, value2));

        public void Add(IItem target, int value0 = 0, int value1 = 0, int value2 = 0) => Add(target.StringId, value0, value1, value2);

        private void Add(ModReference reference) => base.Add(reference);
    }
}
