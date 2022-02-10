using OpenConstructionSet.Installations;

namespace OpenConstructionSet.Mods.Context
{
    public interface IModContext
    {
        Header Header { get; set; }
        ModInfoData? Info { get; set; }
        ModItemCollection Items { get; }
        int LastId { get; set; }
        string ModName { get; }

        ModItem NewItem(ItemType type, string name);
        Task SaveAsync();
        Task SaveAsync(IModFolder folder, string modName);
        Task SaveAsync(string path);
    }
}