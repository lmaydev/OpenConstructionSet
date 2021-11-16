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
    /// Initialise a new writer working against the given stream.
    /// </summary>
    /// <param name="stream"></param>
    public OcsWriter(Stream stream) => writer = new(stream);

    /// <summary>
    /// Dispose the underlying stream.
    /// </summary>
    public void Dispose() => writer.Dispose();

    private void Write(object value)
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
            case Header v:
                Write(v);
                break;
            case Item v:
                Write(v);
                break;

            default:
                throw new InvalidOperationException($"Unexpected type {value.GetType().FullName}");
        }
    }

    /// <summary>
    /// Write a collection of objects to the stream.
    /// T will be runtime bound to one of the Write methods. Passing an unsupported type will result in errors.
    /// </summary>
    /// <param name="collection">The collection to write to stream.</param>
    public void Write<T>(IEnumerable<T> collection)
    {
        Write(collection.Count());

        foreach (object? item in collection)
        {
            if (item is null)
            {
                continue;
            }

            Write(item);
        }
    }

    /// <summary>
    /// Write an <c>Item</c> to the stream.
    /// </summary>
    /// <param name="value">The <c>Item</c> to write to stream.</param>
    public void Write(Item value)
    {
        // Instance count?
        Write(0);

        Write((int)value.Type);
        Write(value.Id);
        Write(value.Name);
        Write(value.StringId);
        Write((int)value.Changes);

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
            if (!category.References.Any())
            {
                continue;
            }

            Write(category.Name);

            Write(category.References);
        }

        Write(value.Instances);

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

                Write(item.Value);
            }
        }
    }

    /// <summary>
    /// Write an <c>Instance</c> to the stream.
    /// </summary>
    /// <param name="value">The <c>Instance</c> to write to stream.</param>
    public void Write(Instance value)
    {
        Write(value.Id);
        Write(value.Target);
        Write(value.Position);
        Write(value.Rotation, true);

        Write(value.States);
    }

    /// <summary>
    /// Write a <c>Reference</c> to the stream.
    /// </summary>
    /// <param name="value">The <c>Reference</c> to write to stream.</param>
    public void Write(Reference value)
    {
        Write(value.TargetId);
        Write(value.Value0);
        Write(value.Value1);
        Write(value.Value2);
    }

    /// <summary>
    /// Write a <c>Header</c> object to the stream.
    /// </summary>
    /// <param name="value">The <c>Header</c> object to write to stream.</param>
    public void Write(Header value)
    {
        Write(value.Version);
        Write(value.Author);
        Write(value.Description);
        Write(string.Join(",", value.Dependencies));
        Write(string.Join(",", value.References));
    }

    /// <summary>
    /// Write a string to the stream.
    /// </summary>
    /// <param name="value">The string to write to stream.</param>
    public void Write(string value)
    {
        var data = System.Text.Encoding.UTF8.GetBytes(value);

        Write(data.Length);
        writer.Write(data);
    }

    /// <summary>
    /// Write a <c>FileValue</c> object to the stream.
    /// </summary>
    /// <param name="value">The <c>fileValue</c> object to write to stream.</param>
    public void Write(FileValue value) => Write(value.Path);

    /// <summary>
    /// Write a <c>Vector3</c> object to the stream.
    /// </summary>
    /// <param name="value">The <c>Vector</c> object to write to stream.</param>
    public void Write(Vector3 value)
    {
        Write(value.X);
        Write(value.Y);
        Write(value.Z);
    }

    /// <summary>
    /// Write a <c>Vector4</c> object to the stream.
    /// </summary>
    /// <param name="value">The <c>Vector4</c> object to write to stream.</param>
    /// <param name="wFirst">If <c>true</c> the W value will be written first. Otherwise it will be written last.</param>
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
    /// Write a bool to the stream.
    /// </summary>
    /// <param name="value">The bool to write to stream.</param>
    public void Write(bool value) => writer.Write(value ? (byte)1 : (byte)0);

    /// <summary>
    /// Write a float to the stream.
    /// </summary>
    /// <param name="value">The flaot to write to stream.</param>
    public void Write(float value) => writer.Write(value);

    /// <summary>
    /// Write an int to the stream.
    /// </summary>
    /// <param name="value">The int to write to stream.</param>
    public void Write(int value) => writer.Write(value);
}
