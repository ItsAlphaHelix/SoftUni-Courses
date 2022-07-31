
namespace Theatre.DataProcessor.ExportDto
{
    using System;
    using System.Xml.Serialization;
    using Theatre.Data.Models.Enums;

    [XmlType("Play")]
    public class PlayXmlExportModel
    {
        [XmlAttribute]
        public string Title { get; set; }

        [XmlAttribute]
        public string Duration { get; set; }

        [XmlAttribute]
        public string Rating { get; set; }

        [XmlAttribute]
        public Genre Genre { get; set; }

        [XmlArray]
        public ActorXmlExportModel[] Actors { get; set; }
    }
}
