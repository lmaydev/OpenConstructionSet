using OpenConstructionSet.Collections;
using OpenConstructionSet.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace OpenConstructionSet.Models
{
    public class OcsDataContextBuilder
    {
        private readonly string name;
        private readonly List<string> _baseMods = new();
        private readonly List<string> _mods = new();
        private readonly HashSet<string> _folders = new();
        private bool loadGameFiles;
        private Header? header;
        private ModInfo? info;

        public OcsDataContextBuilder(string name)
        {
            this.name = name;
        }

        public OcsDataContext Build()
        {
            var modsFolders = ModFolder.Discover(_folders);

            var items = new OcsRefDictionary<Entity>();

            var lastId = 0;

            if (loadGameFiles)
            {
                _baseMods.InsertRange(0, OcsConstants.BaseMods);
            }

            foreach (var baseMod in _baseMods.Distinct())
            {
                var path = ResolvePath(baseMod);

                ReadFile(path);
            }

            (items as IChangeTracking)?.AcceptChanges();

            foreach (var mod in _mods.Distinct())
            {
                var path = ResolvePath(mod);

                ReadFile(path);
            }

            return new OcsDataContext(items, name, lastId, header, info);

            void ReadFile(string path)
            {
                using var reader = new OcsReader(path);

                var type = (FileType)reader.ReadInt();

                if (type != FileType.Mod)
                {
                    throw new InvalidOperationException($"Invalid file type. Expected 16; received {type}");
                }

                reader.ReadHeader();

                lastId = Math.Max(lastId, reader.ReadInt());

                var itemCount = reader.ReadInt();

                for (int i = 0; i < itemCount; i++)
                {
                    ReadItem(reader);
                }
            }

            void ReadItem(OcsReader reader)
            {
                var data = reader.ReadItem();

                if (!items.TryGetValue(data.StringId, out var item))
                {
                    item = items.New(data.StringId, data.Name, data.Type);
                }

                item.Update(data);
            }

            string ResolvePath(string mod)
            {
                if (File.Exists(mod))
                {
                    return mod;
                }

                foreach (var folder in modsFolders)
                {
                    if (folder.Mods.TryGetValue(mod, out var modFile))
                    {
                        return modFile.FullName;
                    }
                }

                throw new FileNotFoundException("Mod not found", mod);
            }
        }

        public OcsDataContextBuilder LoadGameFiles(bool load = true)
        {
            loadGameFiles = load;

            return this;
        }

        public OcsDataContextBuilder UsingFolders(params string[] folders)
        {
            foreach (var folder in folders)
            {
                _folders.Add(folder);
            }

            return this;
        }

        public OcsDataContextBuilder WithBaseMods(params string[] mods)
        {
            _baseMods.AddRange(mods);

            return this;
        }

        public OcsDataContextBuilder WithMods(params string[] mods)
        {
            _mods.AddRange(mods);

            return this;
        }

        public OcsDataContextBuilder WithHeader(Header header)
        {
            this.header = header;

            return this;
        }

        public OcsDataContextBuilder WithInfo(ModInfo info)
        {
            this.info = info;

            return this;
        }
    }
}
