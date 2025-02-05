using System.Collections.Immutable;
using OpenConstructionSet.Data;

namespace OpenConstructionSet.IO;

/// <summary>
/// Writer for the game's data files.
/// </summary>
public sealed class OcsWriter : IDisposable
{
    private static readonly Type[] ValueTypes = new[]
    {
            typeof(bool),
            typeof(float),
            typeof(int),
            typeof(Vector3),
            typeof(Vector4),
            typeof(string),
            typeof(FileValue),
        };

    private readonly BinaryWriter writer;

    /// <summary>
    /// Initialize a new writer working against the given <c>Stream</c>.
    /// </summary>
    /// <param name="stream">The <c>Stream</c> to write to.</param>
    public OcsWriter(Stream stream) => writer = new(stream);

    /// <summary>
    /// Dispose the underlying <c>Stream</c>.
    /// </summary>
    public void Dispose() => writer.Dispose();

    public void Write(DataFileData data)
    {
        Write((int)data.Type);

        if (data.Type.IsModType())
        {
            Write(data.Type, data.Header ?? new Header());
        }

        Write(data.LastId);
        Write(data.Type, data.Items);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fileType"></param>
    /// <param name="value"></param>
    public void Write(DataFileType fileType, IReadOnlyCollection<Item> value)
    {
        Write(value.Count);

        foreach (var item in value)
        {
            Write(fileType, item);
        }
    }

    /// <summary>
    /// Write a collection of objects to the <c>Stream</c>. T will be runtime bound to one of the
    /// Write methods. Passing an unsupported type will result in errors.
    /// </summary>
    /// <param name="collection">The collection to write to <c>Stream</c>.</param>
    public void Write<T>(IEnumerable<T> collection)
    {
        Write(collection.Count());

        foreach (object? item in collection)
        {
            if (item is null)
            {
                continue;
            }

            WriteValue(item);
        }
    }

    /// <summary>
    /// Write an <see cref="Item"/> to the <c>Stream</c>.
    /// </summary>
    /// <param name="value">The <see cref="Item"/> to write to <c>Stream</c>.</param>
    public void Write(DataFileType fileType, Item value)
    {
        var startPosition = (int)writer.BaseStream.Position;

        // instance count or place holder for item length
        if (!fileType.IsModType() && value.Type == ItemType.InstanceCollection)
        {
            Write(value.Instances.Count);
        }
        else
        {
            Write(0);
        }

        Write((int)value.Type);
        Write(value.Id);
        Write(value.Name);
        Write(value.StringId);
        Write((uint)value.SaveData);

        var groupedValues = value.Values.OrderBy(p => p.Key)
                                        .GroupBy(v => v.Value.GetType())
                                        .ToDictionary(g => g.Key, g => g.ToArray());

        foreach (var type in ValueTypes)
        {
            WriteDictionary(type);
        }

        Write(value.ReferenceCategories.Count);
        foreach (var category in value.ReferenceCategories)
        {
            if (category.References.Count == 0)
            {
                continue;
            }

            Write(category.Name);

            Write(category.References);
        }

        Write(value.Instances);

        // write item length before item if writing a mod file
        if (fileType.IsModType())
        {
            var endPosition = (int)writer.BaseStream.Position;

            var length = endPosition - startPosition;

            writer.Seek(startPosition, SeekOrigin.Begin);

            Write(length);

            writer.Seek(endPosition, SeekOrigin.Begin);
        }

        void WriteDictionary(Type type)
        {
            if (!groupedValues.TryGetValue(type, out var collection))
            {
                Write(0);
                return;
            }

            Write(collection.Length);
            foreach (var item in collection)
            {
                Write(item.Key);

                WriteValue(item.Value);
            }
        }
    }

    /// <summary>
    /// Write an <see cref="Instance"/> to the <c>Stream</c>.
    /// </summary>
    /// <param name="value">The <see cref="Instance"/> to write to <c>Stream</c>.</param>
    public void Write(Instance value)
    {
        Write(value.Id);
        Write(value.TargetId);
        Write(value.Position);
        Write(value.Rotation, true);

        Write(value.States);
    }

    /// <summary>
    /// Write a <see cref="Reference"/> to the <c>Stream</c>.
    /// </summary>
    /// <param name="value">The <see cref="Reference"/> to write to <c>Stream</c>.</param>
    public void Write(Reference value)
    {
        Write(value.TargetId);
        Write(value.Value0);
        Write(value.Value1);
        Write(value.Value2);
    }

    /// <summary>
    /// Write a <see cref="Header"/> object to the <c>Stream</c>.
    /// </summary>
    /// <param name="fileType">Type of the data file being written.</param>
    /// <param name="value">The <see cref="Header"/> object to write to <c>Stream</c>.</param>
    public void Write(DataFileType fileType, Header value)
    {
        int startPosition = 0;

        if (fileType.HasMergeData())
        {
            Write(0);
            startPosition = (int)writer.BaseStream.Position;
        }

        Write(value.Version);
        Write(value.Author);
        Write(value.Description);
        Write(string.Join(",", value.Dependencies));
        Write(string.Join(",", value.References));

        if (fileType.HasMergeData())
        {
            Write(value.SaveCount);
            Write(value.LastMerge);

            WriteMergeEntries(value.MergeEntries);
            WriteDeleteRequests(value.DeleteRequests);

            int headerLength = (int)writer.BaseStream.Position - startPosition;

            writer.Seek(startPosition - 4, SeekOrigin.Begin);

            Write(headerLength);

            writer.Seek(startPosition + headerLength, SeekOrigin.Begin);
        }

        void WriteMergeEntries(ICollection<KeyValuePair<string, MergeEntry>> mergeEntries)
        {
            writer.Write((byte)mergeEntries.Count);

            foreach (var entry in mergeEntries)
            {
                Write(entry.Key);
                Write(entry.Value.Version1);
                Write(entry.Value.Version2);
            }
        }

        void WriteDeleteRequests(ICollection<KeyValuePair<string, DeleteRequest>> deleteRequests)
        {
            writer.Write((byte)deleteRequests.Count);

            foreach (var request in deleteRequests)
            {
                Write(request.Key);
                Write(request.Value.Version);
                Write(request.Value.Items);
            }
        }
    }

    /// <summary>
    /// Write a <c>string</c> to the <c>Stream</c>.
    /// </summary>
    /// <param name="value">The <c>string</c> to write to <c>Stream</c>.</param>
    public void Write(string value)
    {
        var data = System.Text.Encoding.UTF8.GetBytes(value);

        Write(data.Length);
        writer.Write(data);
    }

    /// <summary>
    /// Write a <see cref="FileValue"/> object to the <c>Stream</c>.
    /// </summary>
    /// <param name="value">The <see cref="FileValue"/> object to write to <c>Stream</c>.</param>
    public void Write(FileValue value) => Write(value.Path);

    /// <summary>
    /// Write a <see cref="Vector3"/> object to the <c>Stream</c>.
    /// </summary>
    /// <param name="value">The <see cref="Vector3"/> object to write to <c>Stream</c>.</param>
    public void Write(Vector3 value)
    {
        Write(value.X);
        Write(value.Y);
        Write(value.Z);
    }

    /// <summary>
    /// Write a <see cref="Vector4"/> object to the <c>Stream</c>.
    /// </summary>
    /// <param name="value">The <see cref="Vector4"/> object to write to <c>Stream</c>.</param>
    /// <param name="wFirst">
    /// If <c>true</c> the W value will be written first. Otherwise it will be written last.
    /// </param>
    public void Write(Vector4 value, bool wFirst = false)
    {
        if (wFirst)
        {
            Write(value.W);
        }

        Write(value.X);
        Write(value.Y);
        Write(value.Z);

        if (!wFirst)
        {
            Write(value.W);
        }
    }

    /// <summary>
    /// Write a <c>bool</c> to the <c>Stream</c>.
    /// </summary>
    /// <param name="value">The <c>bool</c> to write to <c>Stream</c>.</param>
    public void Write(bool value) => writer.Write(value ? (byte)1 : (byte)0);

    /// <summary>
    /// Write a <c>float</c> to the <c>Stream</c>.
    /// </summary>
    /// <param name="value">The <c>float</c> to write to <c>Stream</c>.</param>
    public void Write(float value) => writer.Write(value);

    /// <summary>
    /// Write an <c>int</c> to the <c>Stream</c>.
    /// </summary>
    /// <param name="value">The <c>int</c> to write to <c>Stream</c>.</param>
    public void Write(int value) => writer.Write(value);

    /// <summary>
    /// Write an <c>uint</c> to the <c>Stream</c>.
    /// </summary>
    /// <param name="value">The <c>uint</c> to write to <c>Stream</c>.</param>
    public void Write(uint value) => writer.Write(value);

    private void WriteValue(object value)
    {
        switch (value)
        {
            case bool v:
                Write(v);
                break;

            case float v:
                Write(v);
                break;

            case int v:
                Write(v);
                break;

            case Vector3 v:
                Write(v);
                break;

            case Vector4 v:
                Write(v);
                break;

            case string v:
                Write(v);
                break;

            case FileValue v:
                Write(v);
                break;

            case Instance v:
                Write(v);
                break;

            case Reference v:
                Write(v);
                break;

            default:
                throw new InvalidOperationException($"Unexpected type {value.GetType().FullName}");
        }
    }
}
