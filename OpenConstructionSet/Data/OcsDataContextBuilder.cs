using OpenConstructionSet.Collections;
using OpenConstructionSet.IO;
using OpenConstructionSet.IO.Discovery;
using OpenConstructionSet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace OpenConstructionSet.Data
{
    public class OcsDataContextBuilder : IOcsDataContextBuilder
    {
        private readonly IOcsFileService fileService;
        private readonly IOcsModInfoService modInfoService;
        private readonly IModNameResolver resolver;

        public OcsDataContextBuilder(IOcsFileService fileService, IOcsModInfoService modInfoService, IModNameResolver resolver)
        {
            this.fileService = fileService;
            this.modInfoService = modInfoService;
            this.resolver = resolver;
        }

        public OcsDataContext Build(string name, IEnumerable<ModFolder>? folders = null, IEnumerable<string>? baseMods = null, IEnumerable<string>? activeMods = null,
            Header? header = null, ModInfo? info = null, bool loadGameFiles = false)
        {
            folders ??= Enumerable.Empty<ModFolder>();

            IEnumerable<ModFile>? baseModFiles = baseMods is null ? null : resolver.ResolveOrThrow(baseMods, folders);
            IEnumerable<ModFile>? activeModFiles = activeMods is null ? null : resolver.ResolveOrThrow(activeMods, folders);

            var items = new OcsRefDictionary<Entity>();

            var lastId = 0;

            if (loadGameFiles)
            {
                if (folders?.Any() != true)
                {
                    throw new ArgumentException("folders can not be null or empty when attempting to load game files");
                }

                resolver.ResolveOrThrow(OcsConstants.BaseMods, folders).ForEach(ReadFile);
            }

            if (baseMods is not null)
            {
                foreach (var mod in baseModFiles.Distinct())
                {
                    ReadFile(mod);
                }
            }

            // Set base data as original values. All changes after this will be part of the active mod.
            (items as IChangeTracking)?.AcceptChanges();

            if (activeMods is not null)
            {
                foreach (var mod in activeModFiles.Distinct())
                {
                    ReadFile(mod);
                }
            }

            return new OcsDataContext(fileService, modInfoService, items, name, lastId, header, info);

            void ReadFile(ModFile file)
            {
                using var reader = new OcsReader(file.FullName);

                var type = (FileType)reader.ReadInt();

                if (type != FileType.Mod)
                {
                    throw new InvalidOperationException($"Invalid file type. Expected Mod (16); received {type}");
                }

                reader.ReadHeader();

                lastId = Math.Max(lastId, reader.ReadInt());

                reader.ReadItems().ForEach(AddOrUpdate);
            }

            void AddOrUpdate(Item data)
            {
                if (!items.TryGetValue(data.StringId, out var item))
                {
                    item = items.New(data.StringId, data.Name, data.Type);
                }

                item.Update(data);
            }
        }
    }
}
