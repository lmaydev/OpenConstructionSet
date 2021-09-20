namespace OpenConstructionSet.IO;

public class ModFile : IEquatable<ModFile?>
{
    public string Name { get; set; }

    public string FullName { get; set; }

    public Header Header { get; set; }

    public ModInfo? Info { get; set; }

    public ModFile()
    {
        Name = FullName = string.Empty;

        Header = new Header();
    }

    public override bool Equals(object? obj) => Equals(obj as ModFile);

    public bool Equals(ModFile? other) => other != null && FullName == other.FullName;

    public override int GetHashCode() => 733961487 + EqualityComparer<string>.Default.GetHashCode(FullName);

    public static bool operator ==(ModFile? left, ModFile? right) => EqualityComparer<ModFile?>.Default.Equals(left, right);

    public static bool operator !=(ModFile? left, ModFile? right) => !(left == right);
}
