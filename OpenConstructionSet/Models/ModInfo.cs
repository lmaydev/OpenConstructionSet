using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenConstructionSet.Models;

/// <summary>
/// POCO class representing a mod's info file.
/// </summary>
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[XmlRoot(Namespace = "", IsNullable = false, ElementName = "ModData")]
public class ModInfo
{
    /// <summary>
    /// Creates an empty ModInfo instance.
    /// </summary>
    public ModInfo() : this(0, "", "", Array.Empty<string>(), 0, DateTime.Now)
    {
    }

    /// <summary>
    /// Creates a populated ModInfo instance.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="mod"></param>
    /// <param name="title"></param>
    /// <param name="tags"></param>
    /// <param name="visibility"></param>
    /// <param name="lastUpdate"></param>
    public ModInfo(uint id, string mod, string title, string[] tags, byte visibility, DateTime? lastUpdate)
    {
        Id = id;
        Mod = mod;
        Title = title;
        Tags = tags;
        Visibility = visibility;
        LastUpdate = lastUpdate;
    }

    /// <summary>
    /// Id
    /// </summary>
    [XmlElement(elementName: "id")]
    public uint Id { get; set; }

    /// <summary>
    /// Mod name.
    /// </summary>
    [XmlElement(elementName: "mod")]
    public string Mod { get; set; }

    /// <summary>
    /// Mod title.
    /// </summary>
    [XmlElement(elementName: "title")]
    public string Title { get; set; }

    /// <summary>
    /// Mod Tags.
    /// </summary>
    [XmlArray(ElementName = "tags")]
    [XmlArrayItem(IsNullable = false)]
    public string[] Tags { get; set; }

    /// <summary>
    /// Mod visibility.
    /// </summary>
    [XmlElement(elementName: "visibility")]
    public byte Visibility { get; set; }

    /// <summary>
    /// Last updated date/time.
    /// </summary>
    [XmlElement(elementName: "lastUpdate")]
    public DateTime? LastUpdate { get; set; }
}
