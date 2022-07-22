
namespace CarDealer.Dtos.Import
{
    using System;
    using System.Xml.Serialization;
    [XmlType("Car")]
    public class CarDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TravelledDistance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public CarPartDto[] CarParts { get; set; }
    }
}
