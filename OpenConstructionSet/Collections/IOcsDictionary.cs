namespace OpenConstructionSet.Collections;

public interface IOcsDictionary<T> : IReadOnlyDictionary<string, T>
{
    IReadOnlyCollection<string> Added { get; }
    IReadOnlyCollection<string> Modified { get; }
    IReadOnlyDictionary<string, T> OriginalValues { get; }
    IReadOnlyDictionary<string, T> Removed { get; }

    bool ChildrenSupportTracking { get; }
    bool ChildrenSupportRevert { get; }

    DictionaryChanges<T> GetChanges();
}
