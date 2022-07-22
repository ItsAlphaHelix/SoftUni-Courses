
namespace CarDealer.Dtos.Export
{
    using System;
    using System.Xml.Serialization;

    [XmlType("part")]
    public class PartsDto
    {

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
