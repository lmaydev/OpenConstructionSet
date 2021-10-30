namespace OpenConstructionSet;

/// <summary>
/// Used to build <see cref="OcsDataContext"/> instances.
/// </summary>
public interface IOcsDataContextBuilder
{
    /// <summary>
    /// Build a <c>OcsDataContext</c> from the provided options.
    /// </summary>
    /// <param name="options">Contains all the information needed to build the context.</param>
    /// <returns>A <c>OcsDataContext"</c> built using the provided options.</returns>
    OcsDataContext Build(OcsDataContexOptions options);
}