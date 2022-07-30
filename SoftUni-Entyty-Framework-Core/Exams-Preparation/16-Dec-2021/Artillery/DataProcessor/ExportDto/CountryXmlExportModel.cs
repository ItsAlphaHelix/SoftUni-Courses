using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Country")]
    public class CountryXmlExportModel
    {
        [XmlAttribute]
        public string Country { get; set; }

        [XmlAttribute]
        public int ArmySize { get; set; }
    }
}