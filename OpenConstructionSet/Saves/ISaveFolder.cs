
namespace OpenConstructionSet.Saves
{
    public interface ISaveFolder
    {
        string Path { get; set; }

        IEnumerable<Save> GetSaves();
    }
}