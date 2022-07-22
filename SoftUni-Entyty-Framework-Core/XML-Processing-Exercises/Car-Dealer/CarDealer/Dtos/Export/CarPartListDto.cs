
namespace CarDealer.Dtos.Export
{
    using System;
    using System.Xml.Serialization;

    [XmlType("car")]
    public class CarPartListDto
    {

        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public PartsDto[] Parts { get; set; }
    }
}
