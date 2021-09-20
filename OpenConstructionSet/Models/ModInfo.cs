using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenConstructionSet.Models;

[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[XmlRoot(Namespace = "", IsNullable = false, ElementName = "ModData")]
public class ModInfo
{
    public ModInfo() : this(0, "", "", Array.Empty<string>(), 0, DateTime.Now)
    {
    }

    public ModInfo(uint id, string mod, string title, string[] tags, byte visibility, DateTime? lastUpdate)
    {
        Id = id;
        Mod = mod;
        Title = title;
        Tags = tags;
        Visibility = visibility;
        LastUpdate = lastUpdate;
    }

    [XmlElement(elementName: "id")]
    public uint Id { get; set; }

    [XmlElement(elementName: "mod")]
    public string Mod { get; set; }

    [XmlElement(elementName: "title")]
    public string Title { get; set; }

    [XmlArray(ElementName = "tags")]
    [XmlArrayItem(IsNullable = false)]
    public string[] Tags { get; set; }

    [XmlElement(elementName: "visibility")]
    public byte Visibility { get; set; }

    [XmlElement(elementName: "lastUpdate")]
    public DateTime? LastUpdate { get; set; }
}
