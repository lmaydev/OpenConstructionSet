using System.Collections;

namespace OpenConstructionSet.Collections;

public abstract class OcsCollection<T> : IList<T>
{
    protected readonly List<T> list;

    public OcsCollection() => list = new();

    public OcsCollection(IEnumerable<T> collection) => list = new(collection);

    public T this[int index] { get => list[index]; set => Insert(index, value); }

    public int Count => list.Count;
    public bool IsReadOnly => false;

    public void Add(T item)
    {
        RemoveById(GetId(item));
        list.Add(item);
    }
    public void Clear() => list.Clear();
    public bool Contains(T item) => list.Contains(item);
    public void CopyTo(T[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);
    public IEnumerator<T> GetEnumerator() => list.GetEnumerator();
    public int IndexOf(T item) => list.IndexOf(item);

    public void Insert(int index, T item)
    {
        RemoveById(GetId(item));
        list.Insert(index, item);
    }

    protected abstract string GetId(T item);

    public bool Remove(T item) => list.Remove(item);
    public void RemoveAt(int index) => list.RemoveAt(index);
    IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();

    public T? FindById(string id) => list.Find(i => GetId(i) == id);

    public int IndexOfId(string id) => list.FindIndex(i => GetId(i) == id);

    public bool RemoveById(string id)
    {
        var index = IndexOfId(id);

        if (index > -1)
        {
            RemoveAt(index);
            return true;
        }

        return false;
    }
}
