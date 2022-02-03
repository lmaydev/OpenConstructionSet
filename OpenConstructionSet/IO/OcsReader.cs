using System.Text;

namespace OpenConstructionSet.IO;

/// <summary>
/// Reader for the game's data files.
/// Can read from a <c>Stream</c> or a byte buffer.
/// </summary>
public sealed class OcsReader : IDisposable
{
    private readonly BinaryReader reader;

    /// <summary>
    /// Initialize a new <c>OcsReader</c> to work against the provided buffer.
    /// </summary>
    /// <param name="buffer"></param>
    public OcsReader(byte[] buffer) : this(new MemoryStream(buffer))
    {
    }

    /// <summary>
    /// Initialize a new <c>OcsReader</c> to work against the provided <c>Stream</c>.
    /// </summary>
    /// <param name="stream"></param>
    public OcsReader(Stream stream) => reader = new(stream);

    /// <summary>
    /// Dispose the underlying stream if provided.
    /// </summary>
    public void Dispose() => reader.Dispose();

    /// <summary>
    /// Read a bool from the data.
    /// </summary>
    /// <returns>A bool read from the data.</returns>
    public bool ReadBool() => reader.ReadBoolean();

    /// <summary>
    /// Read a float from the data.
    /// </summary>
    /// <returns>A float object read from the data.</returns>
    public float ReadFloat() => reader.ReadSingle();

    /// <summary>
    /// Read a <c>Header</c> object from the data.
    /// </summary>
    /// <returns>A <c>Hader</c> object read from the data.</returns>
    public Header ReadHeader() => new(ReadInt(), ReadString(), ReadString())
    {
        Dependencies = ReadStringList().ToList(),
        References = ReadStringList().ToList()
    };

    /// <summary>
    /// Read an <c>Instance</c> from the data.
    /// </summary>
    /// <returns>An <c>Instance</c> read from the data.</returns>
    public Instance ReadInstance() => new(ReadString(), ReadString(), ReadVector3(), ReadVector4(true), ReadStrings());

    /// <summary>
    /// Read an int from the data.
    /// </summary>
    /// <returns>An int read from the data.</returns>
    public int ReadInt() => reader.ReadInt32();

    /// <summary>
    /// Read an <c>Item</c> from the data.
    /// This includes the <c>Item</c>'s values, instances and references.
    /// </summary>
    /// <returns>An <c>Item</c> read from the data.</returns>
    public Item ReadItem()
    {
        // Instance count?
        ReadInt();

        var item = new Item((ItemType)ReadInt(), ReadInt(), ReadString(), ReadString(), (ItemChangeType)ReadInt());

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
            var name = ReadString();

            var category = new ReferenceCategory(name, new List<Reference>());

            var referenceCount = ReadInt();
            for (var j = 0; j < referenceCount; j++)
            {
                category.Add(ReadReference());
            }

            item.ReferenceCategories.Add(category);
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
                item.Values[ReadString()] = read()!;
            }
        }
    }

    /// <summary>
    /// Read a collection of <c>Item</c>s from the data.
    /// </summary>
    /// <returns>A collection of <c>Items</c>s read from the data.</returns>
    public IEnumerable<Item> ReadItems()
    {
        var count = ReadInt();

        for (var i = 0; i < count; i++)
        {
            yield return ReadItem();
        }
    }

    /// <summary>
    /// Read a <c>Reference</c> from the data.
    /// </summary>
    /// <returns>A <c>Reference</c> read from the data.</returns>
    public Reference ReadReference() => new(ReadString(), ReadInt(), ReadInt(), ReadInt());

    /// <summary>
    /// Read a string from the data.
    /// </summary>
    /// <returns>A string read from the data.</returns>
    public string ReadString()
    {
        var length = ReadInt();

        return Encoding.UTF8.GetString(reader.ReadBytes(length));
    }

    /// <summary>
    /// Read a comma separated list from the data.
    /// </summary>
    /// <returns>An array of strings read from a comma separated list in the data.</returns>
    public string[] ReadStringList() => ReadString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

    /// <summary>
    /// Reads a collection of strings from the data.
    /// </summary>
    /// <returns>A collection of strings read from the data.</returns>
    public string[] ReadStrings()
    {
        var count = ReadInt();

        var strings = new string[count];

        for (var i = 0; i < count; i++)
        {
            strings[i] = ReadString();
        }

        return strings;
    }

    /// <summary>
    /// Read a <c>Vector3</c> object from the data.
    /// </summary>
    /// <returns>A <c>Vector3</c> object read from the data.</returns>
    public Vector3 ReadVector3() => new(ReadFloat(), ReadFloat(), ReadFloat());

    /// <summary>
    /// Read a <c>Vector4</c> object from the data.
    /// </summary>
    /// <returns>A <c>Vector4</c> object read from the data.</returns>
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
}