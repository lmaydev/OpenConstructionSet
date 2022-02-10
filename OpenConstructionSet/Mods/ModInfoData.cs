using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenConstructionSet.Mods;

/// <summary>
/// Represents the data stored within an <see cref="IModFile"/>'s .info file.
/// </summary>
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[XmlRoot(Namespace = "", IsNullable = false, ElementName = "ModData")]
public class ModInfoData
{
    /// <summary>
    /// Creates an empty <see cref="ModInfoData"/> instance.
    /// </summary>
    public ModInfoData() : this(0, "", "", Array.Empty<string>(), 0, DateTime.Now)
    {
    }

    /// <summary>
    /// Creates a <see cref="ModInfoData"/> based on the provided data.
    /// </summary>
    /// <param name="id">Mod's Id.</param>
    /// <param name="mod">Mod's name.</param>
    /// <param name="title">Mod's title.</param>
    /// <param name="tags">Mod's tags. See <see cref="OcsConstants.InfoTags"/> for valid values.</param>
    /// <param name="visibility">Mod's visibility.</param>
    /// <param name="lastUpdate">Date/time of the mod's last update.</param>
    public ModInfoData(uint id, string mod, string title, string[] tags, byte visibility, DateTime? lastUpdate)
    {
        Id = id;
        ModName = mod;
        Title = title;
        Tags = tags;
        Visibility = visibility;
        LastUpdate = lastUpdate;
    }

    /// <summary>
    /// Mod's Id.
    /// </summary>
    [XmlElement(elementName: "id")]
    public uint Id { get; set; }

    /// <summary>
    /// Date/time of the mod's laste update.
    /// </summary>
    [XmlElement(elementName: "lastUpdate")]
    public DateTime? LastUpdate { get; set; }

    /// <summary>
    /// Mod's name.
    /// </summary>
    [XmlElement(elementName: "mod")]
    public string ModName { get; set; }

    /// <summary>
    /// Mod's tags. See <see cref="OcsConstants.InfoTags"/> for valid values.
    /// </summary>
    [XmlArray(ElementName = "tags")]
    [XmlArrayItem(IsNullable = false)]
    public string[] Tags { get; set; }

    /// <summary>
    /// Mod's title.
    /// </summary>
    [XmlElement(elementName: "title")]
    public string Title { get; set; }

    /// <summary>
    /// Mod's visibility.
    /// </summary>
    [XmlElement(elementName: "visibility")]
    public byte Visibility { get; set; }
}
