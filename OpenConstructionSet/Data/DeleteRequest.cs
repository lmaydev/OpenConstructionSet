namespace OpenConstructionSet.Data;

public readonly record struct DeleteRequest(uint Version, string Items);

public record struct ItemSaveData(uint SaveCount, ItemChangeType ChangeType)
{
    public ItemSaveData(uint value) : this(value >> 4, (ItemChangeType)(value & 0xF))
    {

    }

    public static implicit operator uint(ItemSaveData data)
        => (uint)data.ChangeType | (data.SaveCount << 4);

    public static implicit operator ItemSaveData(uint value) => new(value);
}

public readonly record struct MergeEntry(uint Version1, uint Version2);
