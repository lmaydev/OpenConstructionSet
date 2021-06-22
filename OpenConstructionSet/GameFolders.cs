namespace OpenConstructionSet
{
    public class GameFolders
    {
        public GameFolder Data { get; set; }

        public GameFolder Mod { get; set; }

        public GameFolder[] ToArray() => new GameFolder[] { Data, Mod };
    }
}