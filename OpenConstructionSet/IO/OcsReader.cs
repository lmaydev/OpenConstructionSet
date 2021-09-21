using System.Text;

namespace OpenConstructionSet.IO;

public sealed class OcsReader : IDisposable
{
    private readonly BinaryReader reader;

    public OcsReader(BinaryReader reader) => this.reader = reader;

    public Item ReadItem()
    {
        // Instance count?
        ReadInt();

        var item = new Item((ItemType)ReadInt(), ReadInt(), ReadString(), ReadString(), (ItemChanges)(uint)ReadInt());

        ReadDictionary(ReadBool);
        ReadDictionary(ReadFloat);
        ReadDictionary(ReadInt);
        ReadDictionary(ReadVector3);
        ReadDictionary(() => ReadVector4());
        ReadDictionary(ReadString);
        ReadDictionary(() => new FileValue(ReadString()));

        var categoryCount = ReadInt();

        for (var i = 0; i < categoryCount; i++)
        {
            var references = new List<Reference>();

            var key = ReadString();

            var referenceCount = ReadInt();
            for (var j = 0; j < referenceCount; j++)
            {
                var reference = ReadReference();

                references.Add(reference);
            }

            item.References[key] = references;
        }

        // Instances
        var instanceCount = ReadInt();
        for (var i = 0; i < instanceCount; i++)
        {
            var instance = ReadInstance();
            item.Instances.Add(instance);
        }

        return item;

        void ReadDictionary<T>(Func<T> read)
        {
            var count = ReadInt();

            for (var i = 0; i < count; i++)
            {
                item.Values.Add(ReadString(), read()!);
            }
        }
    }

    public Instance ReadInstance() => new(ReadString(), ReadString(), ReadVector3(), ReadVector4(true), string.Join(",", ReadStrings()));

    public List<string> ReadStrings()
    {
        var strings = new List<string>();

        var count = ReadInt();

        for (var i = 0; i < count; i++)
        {
            strings.Add(ReadString());
        }

        return strings;
    }

    public IEnumerable<Item> ReadItems()
    {
        var count = ReadInt();

        for (var i = 0; i < count; i++)
        {
            yield return ReadItem();
        }
    }

    public Reference ReadReference() => new(ReadString(), ReadReferenceValues());

    public ReferenceValues ReadReferenceValues() => new(ReadInt(), ReadInt(), ReadInt());

    public Header ReadHeader() => new(ReadInt(), ReadString(), ReadString())
    {
        Dependencies = ReadStringList().ToList(),
        References = ReadStringList().ToList()
    };

    public string ReadString()
    {
        var length = ReadInt();

        var data = reader.ReadBytes(length);

        return Encoding.UTF8.GetString(data.ToArray());
    }

    public string[] ReadStringList() => ReadString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

    public Vector3 ReadVector3() => new(ReadFloat(), ReadFloat(), ReadFloat());

    public Vector4 ReadVector4(bool wFirst = false)
    {
        float w, x, y, z;

        if (wFirst)
        {
            w = ReadFloat();
            x = ReadFloat();
            y = ReadFloat();
            z = ReadFloat();
        }
        else
        {
            x = ReadFloat();
            y = ReadFloat();
            z = ReadFloat();
            w = ReadFloat();
        }

        return new Vector4(w, x, y, z);
    }

    public bool ReadBool() => reader.ReadBoolean();

    public float ReadFloat() => reader.ReadSingle();

    public int ReadInt() => reader.ReadInt32();

    public void Dispose() => ((IDisposable)reader).Dispose();
}
