using System.Text;

namespace OpenConstructionSet.IO;

/// <summary>
/// Reader for the game's data files. Can read from a <c>Stream</c> or a byte buffer.
/// </summary>
public sealed class OcsReader : IDisposable
{
    private readonly BinaryReader reader;

    /// <summary>
    /// Initialize a new <see cref="OcsReader"/> to work against the provided buffer.
    /// </summary>
    /// <param name="buffer"></param>
    public OcsReader(byte[] buffer) : this(new MemoryStream(buffer))
    {
    }

    /// <summary>
    /// Initialize a new <see cref="OcsReader"/> to work against the provided <c>Stream</c>.
    /// </summary>
    /// <param name="stream"></param>
    public OcsReader(Stream stream) => reader = new(stream);

    /// <summary>
    /// Dispose the underlying Stream if provided.
    /// </summary>
    public void Dispose() => reader.Dispose();

    /// <summary>
    /// Read a <c>bool</c> from the data.
    /// </summary>
    /// <returns>A <c>bool</c> read from the data.</returns>
    public bool ReadBool() => reader.ReadBoolean();

    /// <summary>
    /// Read a <c>float</c> from the data.
    /// </summary>
    /// <returns>A <c>float</c> read from the data.</returns>
    public float ReadFloat() => reader.ReadSingle();

    public Header ReadHeader(DataFileType type)
    {
        // Thanks to https://github.com/TokcDK (https://github.com/lmaydev/OpenConstructionSet/pull/8/)
        var endPosition = type == DataFileType.MergeMod ? ReadInt()/*header length*/ + reader.BaseStream.Position : 0;

        var header = ReadHeader();

        if (type == DataFileType.MergeMod)
        {
            reader.BaseStream.Seek(endPosition, SeekOrigin.Begin);
        }

        return header;
    }

    /// <summary>
    /// Read an <see cref="Instance"/> from the data.
    /// </summary>
    /// <returns>An <see cref="Instance"></see> read from the data.</returns>
    public Instance ReadInstance() => new(ReadString(), ReadString(), ReadVector3(), ReadVector4(true), ReadStrings());

    /// <summary>
    /// Read an <c>int</c> from the data.
    /// </summary>
    /// <returns>An <c>int</c> read from the data.</returns>
    public int ReadInt() => reader.ReadInt32();

    /// <summary>
    /// Read an <see cref="Item"/> from the data. This includes the <see cref="Item"/>'s values,
    /// instances and references.
    /// </summary>
    /// <returns>An <c>Item</c> read from the data.</returns>
    public Item ReadItem()
    {
        // Instance count?
        ReadInt();

        // & change type with 3 to remove save count from number.
        var item = new Item((ItemType)ReadInt(), ReadInt(), ReadString(), ReadString(), (ItemChangeType)(ReadInt() & 0x3));

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
                category.References.Add(ReadReference());
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
    /// Read a collection of <see cref="Item"/> s from the data.
    /// </summary>
    /// <returns>A collection of <see cref="Item"/> s read from the data.</returns>
    public IEnumerable<Item> ReadItems()
    {
        var count = ReadInt();

        for (var i = 0; i < count; i++)
        {
            yield return ReadItem();
        }
    }

    /// <summary>
    /// Read a <see cref="Reference"/> from the data.
    /// </summary>
    /// <returns>A <see cref="Reference"/> read from the data.</returns>
    public Reference ReadReference() => new(ReadString(), ReadInt(), ReadInt(), ReadInt());

    /// <summary>
    /// Read a <c>string</c> from the data.
    /// </summary>
    /// <returns>A <c>string</c> read from the data.</returns>
    public string ReadString()
    {
        var length = ReadInt();

        return Encoding.UTF8.GetString(reader.ReadBytes(length));
    }

    /// <summary>
    /// Read a comma separated list of <c>string</c> s from the data.
    /// </summary>
    /// <returns>An array of <c>string</c> s read from a comma separated list in the data.</returns>
    public string[] ReadStringList() => ReadString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

    /// <summary>
    /// Reads a collection of <c>string</c> s from the data.
    /// </summary>
    /// <returns>A collection of <c>string</c> s read from the data.</returns>
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
    /// Read a <see cref="Vector3"/> object from the data.
    /// </summary>
    /// <returns>A <see cref="Vector3"/> object read from the data.</returns>
    public Vector3 ReadVector3() => new(ReadFloat(), ReadFloat(), ReadFloat());

    /// <summary>
    /// Read a <see cref="Vector4"/> object from the data.
    /// </summary>
    /// <returns>A <see cref="Vector4"/> object read from the data.</returns>
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

    /// <summary>
    /// Read a <see cref="Header"/> object from the data.
    /// </summary>
    /// <returns>A <see cref="Header"/> object read from the data.</returns>
    private Header ReadHeader() => new(ReadInt(), ReadString(), ReadString())
    {
        Dependencies = ReadStringList().ToList(),
        References = ReadStringList().ToList()
    };
}
