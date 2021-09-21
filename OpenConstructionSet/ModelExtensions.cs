namespace OpenConstructionSet;

internal static class ModelExtensions
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

    public static Reference Delete(this Reference reference)
    {
        reference.Values = ReferenceValues.Deleted;

        return reference;
    }

    public static bool Deleted(this Reference reference) => reference.Values.Equals(ReferenceValues.Deleted);

    public static bool Deleted(this Instance instance) => string.IsNullOrEmpty(instance.Target);

    public static Instance Delete(this Instance instance)
    {
        instance.Target = "";

        return instance;
    }
}