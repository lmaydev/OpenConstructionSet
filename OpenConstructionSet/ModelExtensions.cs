namespace OpenConstructionSet;

public static class ModelExtensions
{
    private const string RemovedValueKey = "REMOVED";

    public static bool Deleted(this Item item) => item.Values.TryGetValue(RemovedValueKey, out var value)
          && value is bool removed
          && removed;

    public static void Delete(this Item item)
    {
        item.References.Clear();
        item.Instances.Clear();
        item.Values.Clear();

        item.Values[RemovedValueKey] = true;
    }

    public static Reference Delete(this Reference reference) => reference with { Values = ReferenceValues.Deleted };

    public static bool Deleted(this Reference reference) => reference.Values.Equals(ReferenceValues.Deleted);

    public static bool Deleted(this Instance instance) => string.IsNullOrEmpty(instance.Target);

    public static Instance Delete(this Instance instance) => instance with { Target = "" };
}