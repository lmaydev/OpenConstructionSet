namespace OpenConstructionSet.Models;

public record ModFile(string FullName, Header Header, ModInfo? Info)
{
    public string FileName => Path.GetFileName(FullName);

    public string Name => Path.GetFileNameWithoutExtension(FullName);
}
