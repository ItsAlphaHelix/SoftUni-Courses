
namespace CarDealer.Dto.Import
{
    using System;
    using System.Xml.Serialization;

    [XmlType("Supplier")]
    public class SupplierDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }
    }
}
