namespace ProductShop.Dtos.Export
{
    using System;
    using System.Xml.Serialization;

    [XmlType("User")]
    public class UserProductDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("soldProducts")]
        public SoldProductDto[] SoldProducts { get; set; }
    }
}
