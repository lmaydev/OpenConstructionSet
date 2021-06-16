namespace OpenConstructionSet
{
    public class DefaultFolders
    {
        public ModFolder Base { get; set; }

        public ModFolder Mod { get; set; }

        public ModFolder[] ToArray() => new ModFolder[] { Base, Mod };
    }
}