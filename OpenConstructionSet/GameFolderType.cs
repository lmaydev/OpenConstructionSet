using System;

namespace OpenConstructionSet
{
    /// <summary>
    /// Represents the type of a game folder.
    /// </summary>
    [Flags]
    public enum GameFolderType : int
    {
        /// <summary>
        /// Data folders store the files in their root.
        /// e.g. [folder]/example.mod
        /// </summary>
        Data=1,
        /// <summary>
        /// Mod folders store the files in a sub directory of their name
        /// e.g. [folder]/example/example.mod
        /// </summary>
        Mod=2,
        /// <summary>
        /// This folder will be treated as both types.
        /// For operations <see cref="Mod"/> will be used first.
        /// </summary>
        Both = Data | Mod,
    }
}