
namespace CarDealer.Dtos.Import
{
    using System;
    using System.Xml.Serialization;

    [XmlType("Part")]
    public class PartDto
    {

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("quantity")]
        public int Quantity { get; set; }

        [XmlElement("supplierId")]
        public int SupplierId { get; set; }
    }
}
