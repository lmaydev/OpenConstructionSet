﻿namespace OpenConstructionSet.Models;

/// <summary>
/// Represents a game data file.
/// </summary>
public record DataFile(FileType Type, Header? Header, int LastId, List<Item> Items);