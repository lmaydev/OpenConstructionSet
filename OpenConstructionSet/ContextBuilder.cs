using OpenConstructionSet.Mods;
using OpenConstructionSet.Mods.Context;

namespace OpenConstructionSet;

/// <inheritdoc/>
public class ContextBuilder : IContextBuilder
{
    /// <inheritdoc/>
    public async Task<IModContext> BuildAsync(ModContextOptions options)
    {
        var lastId = 0;

        var modFileName = options.Name.AddModExtension();

        var baseMods = new HashSet<string>();

        if (options.LoadGameFiles == Mods.ModLoadType.Base)
        {
            baseMods.AddRange(OcsConstants.BaseMods);
        }

        if (options.LoadEnabledMods == Mods.ModLoadType.Base)
        {
            baseMods.AddRange(await options.Installation.ReadEnabledModsAsync().ConfigureAwait(false));
        }

        if (options.BaseMods is not null)
        {
            baseMods.AddRange(options.BaseMods.Select(m => Path.GetFileName(m).AddModExtension()));
        }

        baseMods.Remove(modFileName);

        var baseItems = new Dictionary<string, ModItem>();

        await ReadModsAsync(baseMods, baseItems).ConfigureAwait(false);

        var activeMods = new HashSet<string>();

        if (options.LoadGameFiles == Mods.ModLoadType.Active)
        {
            activeMods.AddRange(OcsConstants.BaseMods);
        }

        if (options.LoadEnabledMods == Mods.ModLoadType.Active)
        {
            activeMods.AddRange(await options.Installation.ReadEnabledModsAsync().ConfigureAwait(false));
        }

        if (options.ActiveMods is not null)
        {
            activeMods.AddRange(options.ActiveMods.Select(m => Path.GetFileName(m).AddModExtension()));
        }

        activeMods.Remove(modFileName);

        var activeItems = new Dictionary<string, ModItem>();

        foreach (var baseItem in baseItems)
        {
            activeItems[baseItem.Key] = baseItem.Value.DeepClone();
        }

        await ReadModsAsync(activeMods, activeItems).ConfigureAwait(false);

        var header = options.Header;
        var info = options.Info;

        if (options.Installation.TryFind(modFileName, out var activeMod))
        {
            await ReadItemsAsync(activeMod, activeItems).ConfigureAwait(false);

            if (header is null)
            {
                header = await activeMod.ReadHeaderAsync().ConfigureAwait(false);
            }

            if (info is null)
            {
                info = await activeMod.ReadInfoAsync().ConfigureAwait(false);
            }
        }

        return new ModContext(baseItems, activeItems.Values, options.Installation, modFileName, lastId, header, info);

        async Task ReadModsAsync(IEnumerable<string> toLoad, IDictionary<string, ModItem> items)
        {
            foreach (var mod in toLoad)
            {
                if (!options.Installation.TryFind(mod, out var file))
                {
                    if (options.ThrowIfMissing)
                    {
                        throw new FileNotFoundException($"Could not find the file {mod}");
                    }

                    continue;
                }

                await ReadItemsAsync(file, items).ConfigureAwait(false);
            }
        }

        async Task ReadItemsAsync(IModFile file, IDictionary<string, ModItem> items)
        {
            using var reader = new OcsReader(await File.ReadAllBytesAsync(file.Path).ConfigureAwait(false));

            var fileType = (DataFileType)reader.ReadInt();

            if (!fileType.IsModType())
            {
                if (options.ThrowIfMissing)
                {
                    throw new InvalidDataException($"Not a valid mod file {file.Path}");
                }

                return;
            }

            reader.ReadHeader(fileType);

            lastId = Math.Max(lastId, reader.ReadInt());

            var itemCount = reader.ReadInt();

            for (int i = 0; i < itemCount; i++)
            {
                reader.ReadInt();

                var type = (ItemType)reader.ReadInt();

                // id
                reader.ReadInt();

                var name = reader.ReadString();

                var stringId = reader.ReadString();

                // Change type
                reader.ReadInt();

                if (!items.TryGetValue(stringId, out var item))
                {
                    item = new(type, name, stringId);

                    items[stringId] = item;
                }
                else
                {
                    item.Type = type;
                    item.Name = name;
                }

                var dictionaryCount = reader.ReadInt();

                // bool values
                for (int j = 0; j < dictionaryCount; j++)
                {
                    item.Values[reader.ReadString()] = reader.ReadBool();
                }

                dictionaryCount = reader.ReadInt();

                // float values
                for (int j = 0; j < dictionaryCount; j++)
                {
                    item.Values[reader.ReadString()] = reader.ReadFloat();
                }

                dictionaryCount = reader.ReadInt();

                // int values
                for (int j = 0; j < dictionaryCount; j++)
                {
                    item.Values[reader.ReadString()] = reader.ReadInt();
                }

                dictionaryCount = reader.ReadInt();

                // vector3 values
                for (int j = 0; j < dictionaryCount; j++)
                {
                    item.Values[reader.ReadString()] = reader.ReadVector3();
                }

                dictionaryCount = reader.ReadInt();

                // vector4 values
                for (int j = 0; j < dictionaryCount; j++)
                {
                    item.Values[reader.ReadString()] = reader.ReadVector4();
                }

                dictionaryCount = reader.ReadInt();

                // string value
                for (int j = 0; j < dictionaryCount; j++)
                {
                    item.Values[reader.ReadString()] = reader.ReadString();
                }

                dictionaryCount = reader.ReadInt();

                // file values
                for (int j = 0; j < dictionaryCount; j++)
                {
                    item.Values[reader.ReadString()] = new FileValue(reader.ReadString());
                }

                var categoryCount = reader.ReadInt();

                // category count
                for (int j = 0; j < categoryCount; j++)
                {
                    var categoryName = reader.ReadString();

                    if (!item.ReferenceCategories.TryGetValue(categoryName, out var category))
                    {
                        category = new(categoryName);
                        item.ReferenceCategories.Add(category);
                    }

                    var referenceCount = reader.ReadInt();

                    for (int k = 0; k < referenceCount; k++)
                    {
                        var targetId = reader.ReadString();

                        var value0 = reader.ReadInt();
                        var value1 = reader.ReadInt();
                        var value2 = reader.ReadInt();

                        // deleted
                        if (value0 == int.MaxValue && value1 == int.MaxValue && value2 == int.MaxValue)
                        {
                            category.References.RemoveByKey(targetId);
                        }
                        // possibly modified
                        else if (category.References.TryGetValue(targetId, out var reference))
                        {
                            reference.Value0 = value0;
                            reference.Value1 = value1;
                            reference.Value2 = value2;
                        }
                        // new
                        else
                        {
                            category.References.Add(new ModReference(targetId, value0, value1, value2));
                        }
                    }
                }

                var instanceCount = reader.ReadInt();

                // instance count
                for (int j = 0; j < instanceCount; j++)
                {
                    var id = reader.ReadString();

                    var targetId = reader.ReadString();

                    var position = reader.ReadVector3();

                    var rotation = reader.ReadVector4(true);

                    var states = reader.ReadStrings();

                    if (targetId.Length == 0)
                    {
                        item.Instances.RemoveByKey(id);
                    }
                    else if (item.Instances.TryGetValue(id, out var instance))
                    {
                        instance.TargetId = targetId;
                        instance.Position = position;
                        instance.Rotation = rotation;
                        instance.States.Clear();
                        instance.States.AddRange(states);
                    }
                    else
                    {
                        item.Instances.Add(new ModInstance(id, targetId, position, rotation, states));
                    }
                }
            }
        }
    }
}
