using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Footballer")]
    public class FootballerXmlExportModel
    {
        public string Name { get; set; }

        public string Position { get; set; }
    }
}