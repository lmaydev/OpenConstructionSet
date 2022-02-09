namespace OpenConstructionSet.Mods;

public class ModContext
{
    public ModContext()
    {
        Items = new(this);
    }

    public ModItemCollection Items { get; }
}
