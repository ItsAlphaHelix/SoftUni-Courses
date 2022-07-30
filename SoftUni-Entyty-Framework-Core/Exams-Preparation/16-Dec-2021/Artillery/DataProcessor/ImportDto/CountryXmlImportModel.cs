
namespace Artillery.DataProcessor.ImportDto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Country")]
    public class CountryXmlImportModel
    {
        [Required]
        [StringLength(60, MinimumLength = 4)]
        public string CountryName { get; set; }

        [Range(50000, 10000000)]
        public int ArmySize { get; set; }
    }
}
