namespace OpenConstructionSet.IO;

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

    public OcsWriter(BinaryWriter writer) => this.writer = writer;

    public void Dispose() => writer.Dispose();

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

        Write(value.References.Count);
        foreach (var pair in value.References)
        {
            Write(pair.Key);

            Write(pair.Value);
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

                Write((dynamic)item.Value);
            }
        }
    }

    public void Write<T>(IEnumerable<T> collection)
    {
        Write(collection.Count());

        foreach (dynamic? item in collection)
        {
            if (item is null)
            {
                continue;
            }

            Write(item);
        }
    }

    public void Write(Instance value)
    {
        Write(value.Id);
        Write(value.Target);
        Write(value.Position);
        Write(value.Rotation, true);

        Write(value.States.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
    }

    public void Write(Reference value)
    {
        Write(value.TargetId);
        Write(value.Values);
    }

    public void Write(ReferenceValues value)
    {
        Write(value.Value0);
        Write(value.Value1);
        Write(value.Value2);
    }

    public void Write(Header value)
    {
        Write(value.Version);
        Write(value.Author);
        Write(value.Description);
        Write(string.Join(",", value.Dependencies));
        Write(string.Join(",", value.References));
    }

    public void Write(string value)
    {
        var data = System.Text.Encoding.UTF8.GetBytes(value);

        Write(data.Length);
        writer.Write(data);
    }

    public void Write(FileValue value) => Write(value.Path);

    public void Write(Vector3 value)
    {
        Write(value.X);
        Write(value.Y);
        Write(value.Z);
    }

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

    public void Write(bool value) => writer.Write(value ? (byte)1 : (byte)0);

    public void Write(float value) => writer.Write(value);

    public void Write(int value) => writer.Write(value);
}
