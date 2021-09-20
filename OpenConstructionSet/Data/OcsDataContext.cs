using OpenConstructionSet.Collections;
using OpenConstructionSet.IO;
using OpenConstructionSet.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace OpenConstructionSet.Data
{
    public class OcsDataContext : IRevertibleChangeTracking
    {
        private readonly PropertyTracker properties = new();
        private readonly IOcsFileService fileService;
        private readonly IOcsModInfoService modInfoService;

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

        public OcsDataContext(IOcsFileService fileService, IOcsModInfoService modInfoService, OcsRefDictionary<Entity> items, string modName, int lastId, Header? header = null, ModInfo? info = null)
        {
            Items = items;
            ModName = modName.AddModExtension();
            LastId = lastId;
            Header = header ?? new();
            Info = info ?? new();

            this.fileService = fileService;
            this.modInfoService = modInfoService;
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
            var items = new List<Item>();

            var changes = Items.GetChanges();

            changes.Removed.Values.ForEach(item => items.Add(item.AsDeleted()));

            changes.Added.Values.ForEach(item => items.Add(item.GetChanges(true)));

            changes.Modified.Values.ForEach(item => items.Add(item.GetChanges(false)));

            using var writer = new OcsWriter(path);

            fileService.Write(writer, Header, LastId, items);

            if (Info is not null)
            {
                modInfoService.Write(path, Info, true);
            }
        }

        public void Save(ModFolder folder)
        {
            Save(fileService.GetPath(folder, ModName));
        }
    }
}
