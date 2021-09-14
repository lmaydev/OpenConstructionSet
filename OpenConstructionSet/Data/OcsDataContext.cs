using OpenConstructionSet.Collections;
using OpenConstructionSet.IO;
using System.Collections.Generic;
using System.ComponentModel;

namespace OpenConstructionSet.Models
{
    public class OcsDataContext : IRevertibleChangeTracking
    {
        private readonly PropertyTracker properties = new();

        public OcsRefDictionary<Entity> Items { get; }
        public string ModName { get; }

        public int LastId
        {
            get => properties.Get<int>(nameof(LastId));

            set => properties.Set(nameof(LastId), value);
        }

        public Header Header { get; set; }

        public ModInfo? Info { get; set; }

        public bool IsChanged => Items.IsChanged || properties.IsChanged;

        public OcsDataContext(OcsRefDictionary<Entity> items, string modName, int lastId, Header? header = null, ModInfo? info = null)
        {
            Items = items;
            ModName = modName;
            LastId = lastId;
            Header = header ?? new();
            Info = info ?? new();
        }

        public Entity NewItem(ItemType type, string name)
        {
            LastId++;

            return Items.New($"{LastId}-{ModName}", name, type);
        }

        public void RejectChanges()
        {
            properties.RejectChanges();

            Items.RejectChanges();
        }

        void IChangeTracking.AcceptChanges()
        {
            properties.AcceptChanges();

            (Items as IChangeTracking)?.AcceptChanges();
        }

        public void Save(string path)
        {
            var items = new Dictionary<string, Item>();

            var changes = Items.GetChanges();

            foreach (var removed in changes.Removed)
            {
                items.Add(removed.Key, removed.Value.AsDeleted());
            }

            foreach (var pair in changes.Added)
            {
                items.Add(pair.Key, pair.Value.GetChanges(true));
            }

            foreach (var pair in changes.Modified)
            {
                items.Add(pair.Key, pair.Value.GetChanges(false));
            }

            var dataFile = new DataFile(FileType.Mod, Header, LastId, Info, items);

            using var writer = new OcsWriter(path);

            OcsModFile.Write(dataFile, writer);

            if (Info is not null)
            {
                OcsModInfoFile.Write(path, Info, true);
            }
        }
    }
}
